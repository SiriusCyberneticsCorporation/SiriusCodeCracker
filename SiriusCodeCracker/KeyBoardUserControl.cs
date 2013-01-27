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
	public partial class KeyBoardUserControl : UserControl
	{
		class KeyData
		{
			public KeyData(char letter)
			{
				m_letter = letter;
			}
			public char m_letter;
			public int m_number;
			public bool m_used = false;
			public bool m_given = false;
		}

		KeyData[] m_row1 = new KeyData[10];
		KeyData[] m_row2 = new KeyData[9];
		KeyData[] m_row3 = new KeyData[9];

		bool m_resized = true;
		Font m_keyLetterFont;
		Font m_letterFont;
		Font m_numberFont;
		StringFormat m_centreFormat;

		public KeyBoardUserControl()
		{
			InitializeComponent();

			m_row1[0] = new KeyData('Q');
			m_row1[1] = new KeyData('W');
			m_row1[2] = new KeyData('E');
			m_row1[3] = new KeyData('R');
			m_row1[4] = new KeyData('T');
			m_row1[5] = new KeyData('Y');
			m_row1[6] = new KeyData('U');
			m_row1[7] = new KeyData('I');
			m_row1[8] = new KeyData('O');
			m_row1[9] = new KeyData('P');

			m_row2[0] = new KeyData('A');
			m_row2[1] = new KeyData('S');
			m_row2[2] = new KeyData('D');
			m_row2[3] = new KeyData('F');
			m_row2[4] = new KeyData('G');
			m_row2[5] = new KeyData('H');
			m_row2[6] = new KeyData('J');
			m_row2[7] = new KeyData('K');
			m_row2[8] = new KeyData('L');

			m_row3[0] = new KeyData('-');
			m_row3[1] = new KeyData('Z');
			m_row3[2] = new KeyData('X');
			m_row3[3] = new KeyData('C');
			m_row3[4] = new KeyData('V');
			m_row3[5] = new KeyData('B');
			m_row3[6] = new KeyData('N');
			m_row3[7] = new KeyData('M');
			m_row3[8] = new KeyData('-');

			m_centreFormat = new StringFormat();
			m_centreFormat.LineAlignment = StringAlignment.Center;
			m_centreFormat.Alignment = StringAlignment.Center;


			m_row1[4].m_used = true;
			m_row1[8].m_given = true;
		}

		private void KeyBoardUserControl_Paint(object sender, PaintEventArgs e)
		{
			float keyWidth = (float)this.Width / (float)10.0f;
			float keyHeight = (float)this.Height / 3.0f;

			if (m_resized)
			{
				m_keyLetterFont = Tools.FindBestFitFont(e.Graphics, "W",
													new System.Drawing.Font(FontFamily.GenericSansSerif, keyHeight, FontStyle.Bold),
													new SizeF(keyWidth, keyHeight));
				m_letterFont = Tools.FindBestFitFont(e.Graphics, "W",
													new System.Drawing.Font(FontFamily.GenericSansSerif, keyHeight, FontStyle.Bold),
													new SizeF(keyWidth * 0.95f, keyHeight * 0.95f));
				m_numberFont = Tools.FindBestFitFont(e.Graphics, "W",
													new System.Drawing.Font(FontFamily.GenericSansSerif, keyHeight, FontStyle.Bold),
													new SizeF(keyWidth * 0.7f, keyHeight * 0.7f));

				m_resized = false;
			}
	
			e.Graphics.Clear(Color.White);

			for (int keyNumber = 0; keyNumber < 10; keyNumber++)
			{
				DrawKey(m_row1[keyNumber], e.Graphics, (keyWidth * keyNumber), 0, keyWidth, keyHeight);
			}

			float keyX = keyWidth / 2;
			for (int keyNumber = 0; keyNumber < 9; keyNumber++)
			{
				DrawKey(m_row2[keyNumber], e.Graphics, keyX, keyHeight, keyWidth, keyHeight);
				keyX += keyWidth;
			}

			keyX = 0;
			for (int keyNumber = 0; keyNumber < 9; keyNumber++)
			{
				if (keyNumber == 0 || keyNumber == 8)
				{
					DrawKey(m_row3[keyNumber], e.Graphics, keyX, keyHeight * 2, keyWidth * 1.5f, keyHeight);
					keyX += keyWidth * 1.5f;
				}
				else
				{
					DrawKey(m_row3[keyNumber], e.Graphics, keyX, keyHeight * 2, keyWidth, keyHeight);
					keyX += keyWidth;
				}
			}
		}

		private void DrawKey(KeyData key, Graphics g, float keyX, float keyY, float keyWidth, float keyHeight)
		{
			if (key.m_given)
			{
				RectangleF letterCell = new RectangleF(keyX, keyY, keyWidth * 0.95f, keyHeight * 0.95f);
				RectangleF numberCell = new RectangleF(keyX + (keyWidth * 0.4f), keyY + keyHeight * 0.35f, keyWidth * 0.7f, keyHeight * 0.7f);

				g.DrawString(key.m_letter.ToString(), m_letterFont, Brushes.Blue, letterCell, m_centreFormat);
				g.DrawString(key.m_number.ToString(), m_numberFont, Brushes.Blue, numberCell, m_centreFormat);
			}
			else if (key.m_used)
			{
				RectangleF letterCell = new RectangleF(keyX, keyY, keyWidth * 0.95f, keyHeight * 0.95f);
				RectangleF numberCell = new RectangleF(keyX + (keyWidth * 0.4f), keyY + keyHeight * 0.35f, keyWidth * 0.7f, keyHeight * 0.7f);

				g.DrawString(key.m_letter.ToString(), m_letterFont, Brushes.Gray, letterCell, m_centreFormat);
				g.DrawString(key.m_number.ToString(), m_numberFont, Brushes.Gray, numberCell, m_centreFormat);
			}
			else
			{
				RectangleF keyCell = new RectangleF(keyX, keyY, keyWidth, keyHeight);

				Tools.DrawRoundedRectangle(g, keyCell, Pens.Black, Color.White);

				keyCell.Inflate(-0.2f, -0.2f);
				keyCell.Y += keyCell.Height * 0.05f;
				g.DrawString(key.m_letter.ToString(), m_keyLetterFont, Brushes.Black, keyCell, m_centreFormat);
			}
		}

		private void KeyBoardUserControl_Resize(object sender, EventArgs e)
		{
			m_resized = true;
			this.Refresh();
		}
	}
}
