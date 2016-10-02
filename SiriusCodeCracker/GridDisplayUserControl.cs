using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SiriusCodeCracker
{
	public partial class GridDisplayUserControl : UserControl
	{
		public delegate void CellSelectedHandler();
		public event CellSelectedHandler CellSelected;

		public GridDisplayUserControl()
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
		}

		private void GridDisplayUserControl_Paint(object sender, PaintEventArgs e)
		{
			/*
			if (!CrackerData.GameIsActive() && !CrackerData.GameIsComplete())
			{
				GraphicsPath gradientPath = new GraphicsPath();
				Rectangle gr = new Rectangle(this.ClientRectangle.Location, this.ClientRectangle.Size);
				gr.Inflate(this.ClientRectangle.Width, this.ClientRectangle.Height);
				gradientPath.AddEllipse(gr);

				PathGradientBrush gradientBrush = new PathGradientBrush(gradientPath);
				gradientBrush.CenterPoint = new PointF(50,50);
				gradientBrush.CenterColor = Color.DarkBlue;
				gradientBrush.SurroundColors = new Color[] { Color.Black };
				gradientBrush.SetBlendTriangularShape(.5f, 1.0f);
				gradientBrush.FocusScales = new PointF(0f, 0f);
				e.Graphics.FillPath(gradientBrush, gradientPath);

				//e.Graphics.Clear(Color.Black);
			}
			else
				*/
			{
				float columnWidth = (float)this.Width / (float)CrackerData.Configuration.Columns;
				float rowHeight = (float)this.Height / (float)CrackerData.Configuration.Rows;

				int left = this.ClientRectangle.Left;
				int right = this.ClientRectangle.Right - 1;
				int top = this.ClientRectangle.Top;
				int bottom = this.ClientRectangle.Bottom - 1;
				PointF topLeft = new PointF(left, top);
				PointF topRight = new PointF(right, top);
				PointF bottomLeft = new PointF(left, bottom);
				PointF bottomRight = new PointF(right, bottom);

				Font letterFont = Tools.FindBestFitFont(e.Graphics, "W",
													new System.Drawing.Font(FontFamily.GenericSansSerif, rowHeight, FontStyle.Bold),
													new SizeF(columnWidth, rowHeight));
				Font numberFont = Tools.FindBestFitFont(e.Graphics, "8",
													new System.Drawing.Font(FontFamily.GenericSansSerif, rowHeight, FontStyle.Bold),
													new SizeF(columnWidth * 0.5f, rowHeight * 0.5f));

				StringFormat letterFormat = new StringFormat();
				letterFormat.LineAlignment = StringAlignment.Center;
				letterFormat.Alignment = StringAlignment.Center;

				e.Graphics.Clear(CrackerData.Configuration.BackgroundColour);

				if (CrackerData.CharacterGrid != null)
				{
					if (CrackerData.Configuration.ShowIncorrectWords)
					{
						foreach (CodeWord gridWord in CrackerData.GridWords)
						{
							if (!gridWord.Correct && gridWord.Complete)
							{
								RectangleF cell;

								if (gridWord.Horizontal)
								{
									cell = new RectangleF(columnWidth * gridWord.Column, rowHeight * gridWord.Row,
															columnWidth * gridWord.Word.Length, rowHeight);
								}
								else
								{
									cell = new RectangleF(columnWidth * gridWord.Column, rowHeight * gridWord.Row,
															columnWidth, rowHeight * gridWord.Word.Length);
								}
								e.Graphics.FillRectangle(CrackerData.Configuration.ErrorBrush, cell);
							}
						}
					}

					
					for (int column = 0; column < CrackerData.Configuration.Columns; column++)
					{
						for (int row = 0; row < CrackerData.Configuration.Rows; row++)
						{
							bool highlighted = false;
							RectangleF cell = new RectangleF(columnWidth * column, rowHeight * row, columnWidth, rowHeight);

							if (CrackerData.SelectedCharacter != null)
							{
								if (CrackerData.CharacterGrid[column, row].CorrectLetter == CrackerData.SelectedCharacter.CorrectLetter)
								{
									e.Graphics.FillRectangle(CrackerData.Configuration.HighlightBrush, cell);
									highlighted = true;
								}
							}

							if (CrackerData.CharacterGrid[column, row].IsGiven())
							{
								string letter = CrackerData.CharacterGrid[column, row].CorrectLetter.ToString();
								e.Graphics.DrawString(letter, letterFont, CrackerData.Configuration.GivenBrush, cell, letterFormat);
							}
							else if (!CrackerData.CharacterGrid[column, row].IsLetter())
							{
								e.Graphics.FillRectangle(CrackerData.Configuration.GridBrush, cell);
							}
							else
							{
								string letter = CrackerData.CharacterGrid[column, row].SelectedLetter.ToString();

								if (CrackerData.Configuration.ShowAllErrors &&
									CrackerData.CharacterGrid[column, row].SelectedLetter != GridCharacter.NO_LETTER &&
									CrackerData.CharacterGrid[column, row].SelectedLetter != CrackerData.CharacterGrid[column, row].CorrectLetter)
								{
									e.Graphics.FillRectangle(CrackerData.Configuration.ErrorBrush, cell);
								}
								else if(!highlighted  && CrackerData.CharacterGrid[column, row].GameState == Enumerations.CellGameState.Number)
								{
									e.Graphics.FillRectangle(CrackerData.Configuration.BackgroundBrush, cell);
								}

								if (CrackerData.CharacterGrid[column, row].GameState == Enumerations.CellGameState.Number)
								{
									e.Graphics.DrawString(CrackerData.GetNumber(CrackerData.CharacterGrid[column, row].CorrectLetter).ToString(),
															numberFont, CrackerData.Configuration.NumberBrush, cell, letterFormat);
								}
								else
								{
									e.Graphics.DrawString(letter, letterFont, CrackerData.Configuration.LetterBrush, cell, letterFormat);
								}
							}

						}
					}
				}

				// Draw the lines last to cover the edges of highlighted cells.
				e.Graphics.DrawLine(CrackerData.Configuration.GridPen, topLeft, topRight);
				e.Graphics.DrawLine(CrackerData.Configuration.GridPen, topRight, bottomRight);
				e.Graphics.DrawLine(CrackerData.Configuration.GridPen, bottomRight, bottomLeft);
				e.Graphics.DrawLine(CrackerData.Configuration.GridPen, bottomLeft, topLeft);

				for (int column = 1; column < CrackerData.Configuration.Columns; column++)
				{
					PointF start = new PointF(columnWidth * column, top);
					PointF finish = new PointF(columnWidth * column, bottom);

					e.Graphics.DrawLine(CrackerData.Configuration.GridPen, start, finish);
				}
				for (int row = 1; row < CrackerData.Configuration.Rows; row++)
				{
					PointF start = new PointF(left, rowHeight * row);
					PointF finish = new PointF(right, rowHeight * row);

					e.Graphics.DrawLine(CrackerData.Configuration.GridPen, start, finish);
				}
			}

			if (!CrackerData.GameIsActive() && !CrackerData.GameIsComplete())
			{
				SolidBrush translucentBrush = new SolidBrush(Color.FromArgb(220, 128, 128, 255));
				e.Graphics.FillRectangle(translucentBrush, this.ClientRectangle);
				
				GraphicsPath gradientPath = new GraphicsPath();
				Rectangle gr = new Rectangle(this.ClientRectangle.Location, this.ClientRectangle.Size);
				gr.Inflate(this.ClientRectangle.Width, this.ClientRectangle.Height);
				gradientPath.AddEllipse(gr);

				PathGradientBrush gradientBrush = new PathGradientBrush(gradientPath);
				gradientBrush.CenterPoint = new PointF(50, 50);
				gradientBrush.CenterColor = Color.FromArgb(240, Color.DarkBlue);
				gradientBrush.SurroundColors = new Color[] { Color.FromArgb(240, Color.Black) };
				gradientBrush.SetBlendTriangularShape(.5f, 1.0f);
				gradientBrush.FocusScales = new PointF(0f, 0f);
				e.Graphics.FillPath(gradientBrush, gradientPath);
			}
		}
		
		private void GridDisplayUserControl_MouseClick(object sender, MouseEventArgs e)
		{
			float columnWidth = (float)this.Width / (float)CrackerData.Configuration.Columns;
			float rowHeight = (float)this.Height / (float)CrackerData.Configuration.Rows;

			int columnSelected = (int)(e.X / columnWidth);
			int rowSelected = (int)(e.Y / rowHeight);

			CrackerData.SelectCell(columnSelected, rowSelected);
			this.Refresh();
			if (CellSelected != null)
			{
				CellSelected();
			}
		}

		private void GridDisplayUserControl_Enter(object sender, EventArgs e)
		{
			Refresh();
		}
	}
}
