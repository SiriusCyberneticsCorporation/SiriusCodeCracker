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
		public int NumberOfColumns { get { return m_numberOfColumns; } set { m_numberOfColumns = Math.Max(5, Math.Min(32, value)); } }
		public int NumberOfRows { get { return m_numberOfRows; } set { m_numberOfRows = Math.Max(5, Math.Min(32, value)); } }

		private int m_numberOfColumns = 13;
		private int m_numberOfRows = 13;

		public char[,] m_theGrid = null;

		public GridDisplayUserControl()
		{
			InitializeComponent();
		}

		private void GridDisplayUserControl_Paint(object sender, PaintEventArgs e)
		{
			float columnWidth = (float)this.Width / (float)m_numberOfColumns;
			float rowHeight = (float)this.Height / (float)m_numberOfRows;

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

			StringFormat letterFormat = new StringFormat();
			letterFormat.LineAlignment = StringAlignment.Center;
			letterFormat.Alignment = StringAlignment.Center;

			e.Graphics.Clear(Color.White);
			e.Graphics.DrawLine(Pens.Black, topLeft, topRight);
			e.Graphics.DrawLine(Pens.Black, topRight, bottomRight);
			e.Graphics.DrawLine(Pens.Black, bottomRight, bottomLeft);
			e.Graphics.DrawLine(Pens.Black, bottomLeft, topLeft);

			for (int column = 1; column < m_numberOfColumns; column++)
			{
				PointF start = new PointF(columnWidth * column, top);
				PointF finish = new PointF(columnWidth * column, bottom);

				e.Graphics.DrawLine(Pens.Black, start, finish);
			}
			for (int row = 1; row < m_numberOfRows; row++)
			{
				PointF start = new PointF(left, rowHeight * row);
				PointF finish = new PointF(right, rowHeight * row);

				e.Graphics.DrawLine(Pens.Black, start, finish);
			}

			if (m_theGrid != null)
			{
				for (int column = 0; column < m_numberOfColumns; column++)
				{
					for (int row = 0; row < m_numberOfRows; row++)
					{
						RectangleF cell = new RectangleF(columnWidth * column, rowHeight * row, columnWidth, rowHeight);

						if (m_theGrid[column, row] < Definitions.FIRST_LETTER)
						{
							e.Graphics.FillRectangle(Brushes.Black, cell);
						}
						else
						{
							string letter = m_theGrid[column, row].ToString();

							e.Graphics.DrawString(letter, letterFont, Brushes.Black, cell, letterFormat);
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
