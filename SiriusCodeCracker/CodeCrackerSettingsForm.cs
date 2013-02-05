using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SiriusCodeCracker
{
	public partial class CodeCrackerSettingsForm : Form
	{
		public CodeCrackerSettingsForm()
		{
			InitializeComponent();

			ColumnsNumericUpDown.Value = CrackerData.Configuration.Columns;
			RowsNumericUpDown.Value = CrackerData.Configuration.Rows;
			StartingLettersNumericUpDown.Value = CrackerData.Configuration.GivenLetters;
			StartingLettersGroupedCheckBox.Checked = CrackerData.Configuration.GivenLettersGrouped;
			ShowAllErrorsCheckBox.Checked = CrackerData.Configuration.ShowAllErrors;
			ShowIncorrectWordsCheckBox.Checked = CrackerData.Configuration.ShowIncorrectWords;

			BackgroundColourPictureBox.BackColor = CrackerData.Configuration.BackgroundColour;
			LetterColourPictureBox.BackColor = CrackerData.Configuration.LetterColour;
			GridColourPictureBox.BackColor = CrackerData.Configuration.GridColour;
			NumberColourPictureBox.BackColor = CrackerData.Configuration.NumberColour;
			HighlightColourPictureBox.BackColor = CrackerData.Configuration.HighlightColour;
			GivenLetterColourPictureBox.BackColor = CrackerData.Configuration.GivenColour;
			UsedLetterColourPictureBox.BackColor = CrackerData.Configuration.UsedLetterColour;
			ErrorColourPictureBox.BackColor = CrackerData.Configuration.ErrorColour;
		}

		private void BackgroundColourPictureBox_Click(object sender, EventArgs e)
		{
			ColourSelectionDialog.Color = BackgroundColourPictureBox.BackColor;
			if (ColourSelectionDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				BackgroundColourPictureBox.BackColor = ColourSelectionDialog.Color;
				ColourTestArea.Refresh();
			}
		}

		private void LetterColourPictureBox_Click(object sender, EventArgs e)
		{
			ColourSelectionDialog.Color = LetterColourPictureBox.BackColor;
			if (ColourSelectionDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				LetterColourPictureBox.BackColor = ColourSelectionDialog.Color;
				ColourTestArea.Refresh();
			}
		}

		private void GridColourPictureBox_Click(object sender, EventArgs e)
		{
			ColourSelectionDialog.Color = GridColourPictureBox.BackColor;
			if (ColourSelectionDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				GridColourPictureBox.BackColor = ColourSelectionDialog.Color;
				ColourTestArea.Refresh();
			}
		}

		private void NumberColourPictureBox_Click(object sender, EventArgs e)
		{
			ColourSelectionDialog.Color = NumberColourPictureBox.BackColor;
			if (ColourSelectionDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				NumberColourPictureBox.BackColor = ColourSelectionDialog.Color;
				ColourTestArea.Refresh();
			}
		}

		private void HighlightColourPictureBox_Click(object sender, EventArgs e)
		{
			ColourSelectionDialog.Color = HighlightColourPictureBox.BackColor;
			if (ColourSelectionDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				HighlightColourPictureBox.BackColor = ColourSelectionDialog.Color;
				ColourTestArea.Refresh();
			}
		}

		private void GivenLetterColourPictureBox_Click(object sender, EventArgs e)
		{
			ColourSelectionDialog.Color = GivenLetterColourPictureBox.BackColor;
			if (ColourSelectionDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				GivenLetterColourPictureBox.BackColor = ColourSelectionDialog.Color;
				ColourTestArea.Refresh();
			}
		}

		private void UsedLetterColourPictureBox_Click(object sender, EventArgs e)
		{
			ColourSelectionDialog.Color = UsedLetterColourPictureBox.BackColor;
			if (ColourSelectionDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				UsedLetterColourPictureBox.BackColor = ColourSelectionDialog.Color;
				ColourTestArea.Refresh();
			}
		}

		private void ErrorColourPictureBox_Click(object sender, EventArgs e)
		{
			ColourSelectionDialog.Color = ErrorColourPictureBox.BackColor;
			if (ColourSelectionDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				ErrorColourPictureBox.BackColor = ColourSelectionDialog.Color;
				ColourTestArea.Refresh();
			}
		}

		private void ColourTestArea_Paint(object sender, PaintEventArgs e)
		{
			float columnWidth = (float)e.ClipRectangle.Width / 4;
			float rowHeight = (float)e.ClipRectangle.Height / 4;

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

			RectangleF cell;

			cell = new RectangleF(columnWidth, rowHeight*3, columnWidth * 4, rowHeight*4);
			e.Graphics.FillRectangle(new SolidBrush(ErrorColourPictureBox.BackColor), cell);

			cell = new RectangleF(0, rowHeight*2, columnWidth, rowHeight);
			e.Graphics.FillRectangle(new SolidBrush(HighlightColourPictureBox.BackColor), cell);

			cell = new RectangleF(0, rowHeight, columnWidth, rowHeight);
			e.Graphics.FillRectangle(new SolidBrush(GridColourPictureBox.BackColor), cell);
			cell = new RectangleF(0, rowHeight * 3, columnWidth, rowHeight);
			e.Graphics.FillRectangle(new SolidBrush(GridColourPictureBox.BackColor), cell);
			cell = new RectangleF(columnWidth * 2, rowHeight, columnWidth, rowHeight * 2);
			e.Graphics.FillRectangle(new SolidBrush(GridColourPictureBox.BackColor), cell);

			cell = new RectangleF(0, 0, columnWidth, rowHeight);
			e.Graphics.DrawString("W", letterFont, new SolidBrush(LetterColourPictureBox.BackColor), cell, letterFormat);
			cell = new RectangleF(columnWidth, 0, columnWidth, rowHeight);
			e.Graphics.DrawString("O", letterFont, new SolidBrush(GivenLetterColourPictureBox.BackColor), cell, letterFormat);
			cell = new RectangleF(columnWidth*2, 0, columnWidth, rowHeight);
			e.Graphics.DrawString("R", letterFont, new SolidBrush(GivenLetterColourPictureBox.BackColor), cell, letterFormat);
			cell = new RectangleF(columnWidth*3, 0, columnWidth, rowHeight);
			e.Graphics.DrawString("D", letterFont, new SolidBrush(GivenLetterColourPictureBox.BackColor), cell, letterFormat);

			cell = new RectangleF(0, rowHeight * 2, columnWidth, rowHeight);
			e.Graphics.DrawString("R", letterFont, new SolidBrush(GivenLetterColourPictureBox.BackColor), cell, letterFormat);

			cell = new RectangleF(columnWidth, rowHeight, columnWidth, rowHeight);
			e.Graphics.DrawString("12", numberFont, new SolidBrush(NumberColourPictureBox.BackColor), cell, letterFormat);
			cell = new RectangleF(columnWidth, rowHeight*2, columnWidth, rowHeight);
			e.Graphics.DrawString("7", numberFont, new SolidBrush(NumberColourPictureBox.BackColor), cell, letterFormat);
			cell = new RectangleF(columnWidth, rowHeight*3, columnWidth, rowHeight);
			e.Graphics.DrawString("Y", letterFont, new SolidBrush(LetterColourPictureBox.BackColor), cell, letterFormat);

			cell = new RectangleF(columnWidth * 2, rowHeight*3, columnWidth, rowHeight);
			e.Graphics.DrawString("U", letterFont, new SolidBrush(LetterColourPictureBox.BackColor), cell, letterFormat);

			cell = new RectangleF(columnWidth * 3, rowHeight, columnWidth, rowHeight);
			e.Graphics.DrawString("A", letterFont, new SolidBrush(LetterColourPictureBox.BackColor), cell, letterFormat);
			cell = new RectangleF(columnWidth * 3, rowHeight * 2, columnWidth, rowHeight);
			e.Graphics.DrawString("Y", letterFont, new SolidBrush(LetterColourPictureBox.BackColor), cell, letterFormat);
			cell = new RectangleF(columnWidth * 3, rowHeight * 3, columnWidth, rowHeight);
			e.Graphics.DrawString("S", letterFont, new SolidBrush(LetterColourPictureBox.BackColor), cell, letterFormat);

			// Draw the lines last to cover the edges of highlighted cells.
			e.Graphics.DrawLine(new Pen(GridColourPictureBox.BackColor), topLeft, topRight);
			e.Graphics.DrawLine(new Pen(GridColourPictureBox.BackColor), topRight, bottomRight);
			e.Graphics.DrawLine(new Pen(GridColourPictureBox.BackColor), bottomRight, bottomLeft);
			e.Graphics.DrawLine(new Pen(GridColourPictureBox.BackColor), bottomLeft, topLeft);

			for (int column = 1; column < CrackerData.Configuration.Columns; column++)
			{
				PointF start = new PointF(columnWidth * column, top);
				PointF finish = new PointF(columnWidth * column, bottom);

				e.Graphics.DrawLine(new Pen(GridColourPictureBox.BackColor), start, finish);
			}
			for (int row = 1; row < CrackerData.Configuration.Rows; row++)
			{
				PointF start = new PointF(left, rowHeight * row);
				PointF finish = new PointF(right, rowHeight * row);

				e.Graphics.DrawLine(new Pen(GridColourPictureBox.BackColor), start, finish);
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			CrackerData.Configuration.Columns = (int)ColumnsNumericUpDown.Value;
			CrackerData.Configuration.Rows = (int)RowsNumericUpDown.Value;
			CrackerData.Configuration.GivenLetters = (int)StartingLettersNumericUpDown.Value;
			CrackerData.Configuration.GivenLettersGrouped = StartingLettersGroupedCheckBox.Checked;
			CrackerData.Configuration.ShowAllErrors = ShowAllErrorsCheckBox.Checked;
			CrackerData.Configuration.ShowIncorrectWords = ShowIncorrectWordsCheckBox.Checked;

			CrackerData.Configuration.BackgroundColour = BackgroundColourPictureBox.BackColor;
			CrackerData.Configuration.LetterColour = LetterColourPictureBox.BackColor;
			CrackerData.Configuration.GridColour = GridColourPictureBox.BackColor;
			CrackerData.Configuration.NumberColour = NumberColourPictureBox.BackColor;
			CrackerData.Configuration.HighlightColour = HighlightColourPictureBox.BackColor;
			CrackerData.Configuration.GivenColour = GivenLetterColourPictureBox.BackColor;
			CrackerData.Configuration.UsedLetterColour = UsedLetterColourPictureBox.BackColor;
			CrackerData.Configuration.ErrorColour = ErrorColourPictureBox.BackColor;

			// Save the settings.
			Properties.Settings.Default.Save();

			Close();
		}

		private void TheCancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
