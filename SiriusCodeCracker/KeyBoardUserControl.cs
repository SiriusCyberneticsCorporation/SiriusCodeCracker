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
		public delegate void LetterSelectedHandler();
		public event LetterSelectedHandler LetterSelected;

		bool m_resized = true;
		Font m_keyLetterFont;
		Font m_letterFont;
		Font m_numberFont;
		StringFormat m_centreFormat;

		public KeyBoardUserControl()
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);

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

			CrackerData.Keyboard[2, 0] = new KeyboardCharacter('<');
			CrackerData.Keyboard[2, 1] = new KeyboardCharacter('Z');
			CrackerData.Keyboard[2, 2] = new KeyboardCharacter('X');
			CrackerData.Keyboard[2, 3] = new KeyboardCharacter('C');
			CrackerData.Keyboard[2, 4] = new KeyboardCharacter('V');
			CrackerData.Keyboard[2, 5] = new KeyboardCharacter('B');
			CrackerData.Keyboard[2, 6] = new KeyboardCharacter('N');
			CrackerData.Keyboard[2, 7] = new KeyboardCharacter('M');
			CrackerData.Keyboard[2, 8] = new KeyboardCharacter('>');

			for (int keyNumber = 0; keyNumber < 10; keyNumber++)
			{
				if (!CrackerData.KeyboardLookup.ContainsKey(CrackerData.Keyboard[0, keyNumber].Letter))
				{
					CrackerData.KeyboardLookup.Add(CrackerData.Keyboard[0, keyNumber].Letter, CrackerData.Keyboard[0, keyNumber]);
				}
			}

			for (int keyNumber = 0; keyNumber < 9; keyNumber++)
			{
				if (!CrackerData.KeyboardLookup.ContainsKey(CrackerData.Keyboard[1, keyNumber].Letter))
				{
					CrackerData.KeyboardLookup.Add(CrackerData.Keyboard[1, keyNumber].Letter, CrackerData.Keyboard[1, keyNumber]);
				}
			}

			for (int keyNumber = 1; keyNumber < 8; keyNumber++)
			{
				if (!CrackerData.KeyboardLookup.ContainsKey(CrackerData.Keyboard[2, keyNumber].Letter))
				{
					CrackerData.KeyboardLookup.Add(CrackerData.Keyboard[2, keyNumber].Letter, CrackerData.Keyboard[2, keyNumber]);
				}
			} 
			m_centreFormat = new StringFormat();
			m_centreFormat.LineAlignment = StringAlignment.Center;
			m_centreFormat.Alignment = StringAlignment.Center;
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
													new SizeF(keyWidth * 0.5f, keyHeight * 0.5f));

				m_resized = false;
			}
	
			e.Graphics.Clear(SystemColors.Control);//.White);

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
			bool highlighted = false;
			RectangleF keyCell = new RectangleF(keyX, keyY, keyWidth, keyHeight);
			RectangleF letterCell = new RectangleF(keyX, keyY, keyWidth * 0.9f, keyHeight * 0.9f);
			RectangleF numberCell = new RectangleF(keyX + (keyWidth * 0.55f), keyY + (keyHeight * 0.4f), keyWidth * 0.35f, keyHeight * 0.45f);

			if (CrackerData.SelectedCharacter != null)
			{
				if (key.Letter == CrackerData.SelectedCharacter.SelectedLetter)
				{
					highlighted = true;
				}
			}

			if (key.NotRequired)
			{
				Tools.DrawRoundedRectangle(g, keyCell, Pens.DarkGray, Color.LightGray);

				keyCell.Inflate(-0.2f, -0.2f);
				keyCell.Y += keyCell.Height * 0.05f;
				g.DrawString(key.Letter.ToString(), m_keyLetterFont, Brushes.DarkGray, keyCell, m_centreFormat);
			}
			else if (key.Given)
			{
				if (highlighted)
				{
					g.FillRectangle(CrackerData.Configuration.HighlightBrush, keyCell);
				}
				g.DrawString(key.Letter.ToString(), m_letterFont, CrackerData.Configuration.GivenBrush, letterCell, m_centreFormat);
				g.DrawString(key.Number.ToString(), m_numberFont, CrackerData.Configuration.GivenBrush, numberCell, m_centreFormat);
			}
			else if (key.Used)
			{
				if (highlighted)
				{
					g.FillRectangle(CrackerData.Configuration.HighlightBrush, keyCell);
				}
				g.DrawString(key.Letter.ToString(), m_letterFont, CrackerData.Configuration.UsedLetterBrush, letterCell, m_centreFormat);
				g.DrawString(key.Number.ToString(), m_numberFont, CrackerData.Configuration.UsedLetterBrush, numberCell, m_centreFormat);
			}
			else
			{
				Tools.DrawRoundedRectangle(g, keyCell, CrackerData.Configuration.GridPen, CrackerData.Configuration.BackgroundColour);

				keyCell.Inflate(-0.2f, -0.2f);
				keyCell.Y += keyCell.Height * 0.05f;
				if (key.Letter == '<' || key.Letter == '>')
				{
					g.DrawString("Delete", m_numberFont, CrackerData.Configuration.LetterBrush, keyCell, m_centreFormat);
				}
				else
				{
					g.DrawString(key.Letter.ToString(), m_keyLetterFont, CrackerData.Configuration.LetterBrush, keyCell, m_centreFormat);
				}
			}
		}

		private void KeyBoardUserControl_Resize(object sender, EventArgs e)
		{
			m_resized = true;
		}

		private void KeyBoardUserControl_MouseClick(object sender, MouseEventArgs e)
		{
			if (CrackerData.GameIsActive())
			{
				bool deletePressed = false;
				KeyboardCharacter selectedKey = null;
				float keyWidth = (float)this.Width / (float)10.0f;
				float keyHeight = (float)this.Height / 3.0f;

				int columnSelected = -1;
				int rowSelected = (int)(e.Y / keyHeight);

				switch (rowSelected)
				{
					case 0:
						columnSelected = (int)(e.X / keyWidth);
						break;
					case 1:
						{
							float shiftedX = e.X - (keyWidth / 2);
							if (shiftedX >= 0)
							{
								columnSelected = (int)(shiftedX / keyWidth);
								if (columnSelected > 8)
								{
									columnSelected = -1;
								}
							}
						}
						break;
					case 2:
						{
							float shiftedX = e.X - (keyWidth * 1.5f);
							if (shiftedX >= 0)
							{
								columnSelected = (int)(shiftedX / keyWidth);
								if (columnSelected > 6)
								{
									deletePressed = true;
									columnSelected = -1;
								}
								else
								{
									// Skip the delete keys.
									columnSelected += 1;
								}
							}
							else
							{
								deletePressed = true;
							}
						}
						break;
				}

				if (columnSelected >= 0)
				{
					selectedKey = CrackerData.Keyboard[rowSelected, columnSelected];
				}

				ProcessKey(selectedKey, deletePressed);
			}
		}

		public void HandleKeyPress(Keys keyPressed)
		{
			bool deletePressed = false;
			KeyboardCharacter selectedKey = null;

			if (keyPressed == Keys.Back || keyPressed == Keys.Delete)
			{
				deletePressed = true;
			}
			else if (keyPressed >= Keys.A && keyPressed <= Keys.Z &&
					CrackerData.KeyboardLookup.ContainsKey(char.ToUpper((char)keyPressed)))
			{
				selectedKey = CrackerData.KeyboardLookup[char.ToUpper((char)keyPressed)];
			}

			ProcessKey(selectedKey, deletePressed);
		}

		private void ProcessKey(KeyboardCharacter selectedKey, bool deletePressed)
		{
			if (CrackerData.SelectedCharacter != null)
			{
				if (CrackerData.SelectedCharacter.IsGiven())
				{
					MessageBox.Show("You cannot change letters that were provided to you at the beginning of the game.", "Unable to change");
				}
				else if (deletePressed)
				{
					if (CrackerData.SelectedCharacter.SelectedLetter != GridCharacter.NO_LETTER)
					{
						CrackerData.Corrections++;
						CrackerData.MarkKeyboardLetterUnused(CrackerData.SelectedCharacter.SelectedLetter);
						CrackerData.UnassignLetter(CrackerData.SelectedCharacter.SelectedLetter);
						if (LetterSelected != null)
						{
							LetterSelected();
						}
					}
				}
				else if (selectedKey != null && !selectedKey.Given && !selectedKey.NotRequired)
				{
					if (CrackerData.SelectedCharacter.IsGameLetter() && CrackerData.SelectedCharacter.SelectedLetter != selectedKey.Letter)
					{
						CrackerData.AskingQuestion(true);
						if (MessageBox.Show(string.Format("Do you wish to change the letter from '{0}' to '{1}'?",
															CrackerData.SelectedCharacter.SelectedLetter,
															selectedKey.Letter),
											"Change Letter", MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							CrackerData.Corrections++;
							CrackerData.MarkKeyboardLetterUnused(CrackerData.SelectedCharacter.SelectedLetter);
							CrackerData.AssignLetter(selectedKey.Letter);
							if (LetterSelected != null)
							{
								LetterSelected();
							}
						}
						CrackerData.AskingQuestion(false);
					}
					else if (selectedKey.Used && CrackerData.SelectedCharacter.SelectedLetter != selectedKey.Letter)
					{
						CrackerData.AskingQuestion(true);
						if (MessageBox.Show(string.Format("The letter '{0}' is already used. Do you wish to move it to the new location?",
															selectedKey.Letter),
											"Move Letter", MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
							CrackerData.Corrections++;
							CrackerData.UnassignLetter(selectedKey.Letter);
							CrackerData.AssignLetter(selectedKey.Letter);
							if (LetterSelected != null)
							{
								LetterSelected();
							}
						}
						CrackerData.AskingQuestion(false);
					}
					else if (!selectedKey.Used)
					{
						CrackerData.AssignLetter(selectedKey.Letter);
						if (LetterSelected != null)
						{
							LetterSelected();
						}
					}
				}
			}
		}

		private void KeyBoardUserControl_Enter(object sender, EventArgs e)
		{
			Refresh();
		}

	}
}
