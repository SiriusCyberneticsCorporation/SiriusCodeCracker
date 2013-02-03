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
		bool m_resized = true;
		Font m_keyLetterFont;
		Font m_letterFont;
		Font m_numberFont;
		StringFormat m_centreFormat;

		public KeyBoardUserControl()
		{
			InitializeComponent();

			CrackerData.Keyboard[0, 0] = new KeyboardCharacter('Q');
			CrackerData.Keyboard[0, 1] = new KeyboardCharacter('W');
			CrackerData.Keyboard[0, 2] = new KeyboardCharacter('E');
			CrackerData.Keyboard[0, 3] = new KeyboardCharacter('R');
			CrackerData.Keyboard[0, 4] = new KeyboardCharacter('T');
			CrackerData.Keyboard[0, 5] = new KeyboardCharacter('Y');
			CrackerData.Keyboard[0, 6] = new KeyboardCharacter('U');
			CrackerData.Keyboard[0, 7] = new KeyboardCharacter('I');
			CrackerData.Keyboard[0, 8] = new KeyboardCharacter('O');
			CrackerData.Keyboard[0, 9] = new KeyboardCharacter('P');

			CrackerData.Keyboard[1, 0] = new KeyboardCharacter('A');
			CrackerData.Keyboard[1, 1] = new KeyboardCharacter('S');
			CrackerData.Keyboard[1, 2] = new KeyboardCharacter('D');
			CrackerData.Keyboard[1, 3] = new KeyboardCharacter('F');
			CrackerData.Keyboard[1, 4] = new KeyboardCharacter('G');
			CrackerData.Keyboard[1, 5] = new KeyboardCharacter('H');
			CrackerData.Keyboard[1, 6] = new KeyboardCharacter('J');
			CrackerData.Keyboard[1, 7] = new KeyboardCharacter('K');
			CrackerData.Keyboard[1, 8] = new KeyboardCharacter('L');

			CrackerData.Keyboard[2, 0] = new KeyboardCharacter('-');
			CrackerData.Keyboard[2, 1] = new KeyboardCharacter('Z');
			CrackerData.Keyboard[2, 2] = new KeyboardCharacter('X');
			CrackerData.Keyboard[2, 3] = new KeyboardCharacter('C');
			CrackerData.Keyboard[2, 4] = new KeyboardCharacter('V');
			CrackerData.Keyboard[2, 5] = new KeyboardCharacter('B');
			CrackerData.Keyboard[2, 6] = new KeyboardCharacter('N');
			CrackerData.Keyboard[2, 7] = new KeyboardCharacter('M');
			CrackerData.Keyboard[2, 8] = new KeyboardCharacter('-');

			for (int keyNumber = 0; keyNumber < 10; keyNumber++)
			{
				CrackerData.KeyboardLookup.Add(CrackerData.Keyboard[0, keyNumber].Letter, CrackerData.Keyboard[0, keyNumber]);
			}

			for (int keyNumber = 0; keyNumber < 9; keyNumber++)
			{
				CrackerData.KeyboardLookup.Add(CrackerData.Keyboard[1, keyNumber].Letter, CrackerData.Keyboard[1, keyNumber]);
			}

			for (int keyNumber = 1; keyNumber < 8; keyNumber++)
			{
				CrackerData.KeyboardLookup.Add(CrackerData.Keyboard[2, keyNumber].Letter, CrackerData.Keyboard[2, keyNumber]);

			} 
			m_centreFormat = new StringFormat();
			m_centreFormat.LineAlignment = StringAlignment.Center;
			m_centreFormat.Alignment = StringAlignment.Center;
		}
		/*
		public void ResetKeyboard()
		{
			foreach (char letter in CrackerData.KeyboardLookup.Keys)
			{
				CrackerData.KeyboardLookup[letter].Used = false;
				CrackerData.KeyboardLookup[letter].Given = false;
				CrackerData.KeyboardLookup[letter].Selected = false;
			}
		}
		
		public void MarkAsGiven(char letter)
		{
			if (CrackerData.KeyboardLookup.ContainsKey(letter))
			{
				CrackerData.KeyboardLookup[letter].Given = true;
			}
		}

		public void MarkAsUsed(char letter)
		{
			if (CrackerData.KeyboardLookup.ContainsKey(letter))
			{
				CrackerData.KeyboardLookup[letter].Used = true;
			}
		}
		*/
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
				DrawKey(CrackerData.Keyboard[0, keyNumber], e.Graphics, (keyWidth * keyNumber), 0, keyWidth, keyHeight);
			}

			float keyX = keyWidth / 2;
			for (int keyNumber = 0; keyNumber < 9; keyNumber++)
			{
				DrawKey(CrackerData.Keyboard[1, keyNumber], e.Graphics, keyX, keyHeight, keyWidth, keyHeight);
				keyX += keyWidth;
			}

			keyX = 0;
			for (int keyNumber = 0; keyNumber < 9; keyNumber++)
			{
				if (keyNumber == 0 || keyNumber == 8)
				{
					DrawKey(CrackerData.Keyboard[2, keyNumber], e.Graphics, keyX, keyHeight * 2, keyWidth * 1.5f, keyHeight);
					keyX += keyWidth * 1.5f;
				}
				else
				{
					DrawKey(CrackerData.Keyboard[2, keyNumber], e.Graphics, keyX, keyHeight * 2, keyWidth, keyHeight);
					keyX += keyWidth;
				}
			}
		}

		private void DrawKey(KeyboardCharacter key, Graphics g, float keyX, float keyY, float keyWidth, float keyHeight)
		{
			if (key.Given)
			{
				RectangleF letterCell = new RectangleF(keyX, keyY, keyWidth * 0.9f, keyHeight * 0.9f);
				RectangleF numberCell = new RectangleF(keyX + (keyWidth * 0.5f), keyY + (keyHeight * 0.35f), keyWidth * 0.55f, keyHeight * 0.65f);

				g.DrawString(key.Letter.ToString(), m_letterFont, CrackerData.Configuration.GivenBrush, letterCell, m_centreFormat);
				g.DrawString(CrackerData.GetNumber(key.Letter).ToString(), m_numberFont, CrackerData.Configuration.GivenBrush, numberCell, m_centreFormat);
			}
			else if (key.Used)
			{
				RectangleF letterCell = new RectangleF(keyX, keyY, keyWidth * 0.9f, keyHeight * 0.9f);
				RectangleF numberCell = new RectangleF(keyX + (keyWidth * 0.5f), keyY + (keyHeight * 0.35f), keyWidth * 0.55f, keyHeight * 0.65f);

				g.DrawString(key.Letter.ToString(), m_letterFont, CrackerData.Configuration.UsedLetterBrush, letterCell, m_centreFormat);
				g.DrawString(CrackerData.GetNumber(key.Letter).ToString(), m_numberFont, CrackerData.Configuration.UsedLetterBrush, numberCell, m_centreFormat);
			}
			else
			{
				RectangleF keyCell = new RectangleF(keyX, keyY, keyWidth, keyHeight);

				Tools.DrawRoundedRectangle(g, keyCell, CrackerData.Configuration.GridPen, CrackerData.Configuration.BackgroundColour);

				keyCell.Inflate(-0.2f, -0.2f);
				keyCell.Y += keyCell.Height * 0.05f;
				g.DrawString(key.Letter.ToString(), m_keyLetterFont, CrackerData.Configuration.LetterBrush, keyCell, m_centreFormat);
			}
		}

		private void KeyBoardUserControl_Resize(object sender, EventArgs e)
		{
			m_resized = true;
			this.Refresh();
		}
	}
}
