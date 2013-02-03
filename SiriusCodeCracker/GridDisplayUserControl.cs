using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SiriusCodeCracker
{
	public partial class GridDisplayUserControl : UserControl
	{
		public GridDisplayUserControl()
		{
			InitializeComponent();
		}

		private void GridDisplayUserControl_Paint(object sender, PaintEventArgs e)
		{
			float columnWidth = (float)this.Width / (float)CrackerData.Configuration.Columns;
			float rowHeight = (float)this.Height / (float)CrackerData.Configuration.Rows;

			int left = e.ClipRectangle.Left;
			int right = e.ClipRectangle.Right - 1;
			int top = e.ClipRectangle.Top;
			int bottom = e.ClipRectangle.Bottom - 1;
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

			if (CrackerData.CharacterGrid != null)
			{
				for (int column = 0; column < CrackerData.Configuration.Columns; column++)
				{
					for (int row = 0; row < CrackerData.Configuration.Rows; row++)
					{
						RectangleF cell = new RectangleF(columnWidth * column, rowHeight * row, columnWidth, rowHeight);

						if (CrackerData.CharacterGrid[column, row].IsGiven())
						{
							string letter = CrackerData.CharacterGrid[column, row].Letter.ToString();
							e.Graphics.DrawString(letter, letterFont, CrackerData.Configuration.GivenBrush, cell, letterFormat);
						}
						else if (!CrackerData.CharacterGrid[column, row].IsLetter())
						{
							e.Graphics.FillRectangle(CrackerData.Configuration.GridBrush, cell);
						}
						else
						{
							string letter = CrackerData.CharacterGrid[column, row].Letter.ToString();

							if (CrackerData.CharacterGrid[column, row].GameState == Enumerations.CellGameState.Number)
							{
								e.Graphics.DrawString(CrackerData.GetNumber(CrackerData.CharacterGrid[column, row].Letter).ToString(),
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
		}

		private void GridDisplayUserControl_Resize(object sender, EventArgs e)
		{
			this.Refresh();
		}
	}
}
