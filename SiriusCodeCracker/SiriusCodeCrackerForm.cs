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
	public partial class SiriusCodeCrackerForm : Form
	{
		CrosswordGenerator m_crosswordGenerator = new CrosswordGenerator();

		public SiriusCodeCrackerForm()
		{
			InitializeComponent();

			CrosswordGrid.CellSelected += new GridDisplayUserControl.CellSelectedHandler(CrosswordGrid_CellSelected);
			CodeCrackerKeyBoard.LetterSelected += new KeyBoardUserControl.LetterSelectedHandler(CodeCrackerKeyBoard_LetterSelected);
		}

		void CodeCrackerKeyBoard_LetterSelected()
		{
			if (CrackerData.CheckCompletion())
			{
				CrosswordGrid.Refresh();
				CodeCrackerKeyBoard.Refresh();

				MessageBox.Show("Congratulations, you have unravelled the code", "Puzzle Complete");
			}
			else
			{
				CrosswordGrid.Refresh();
				CodeCrackerKeyBoard.Refresh();
			}
		}

		void CrosswordGrid_CellSelected()
		{
			CodeCrackerKeyBoard.Refresh();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			m_crosswordGenerator.Populate();

			CrosswordGrid.Refresh();
			CodeCrackerKeyBoard.Refresh();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			CodeCrackerSettingsForm iCodeCrackerSettingsForm = new CodeCrackerSettingsForm();
			
			iCodeCrackerSettingsForm.ShowDialog(this);
		}

		private void SiriusCodeCrackerForm_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void SiriusCodeCrackerForm_KeyDown(object sender, KeyEventArgs e)
		{
			CodeCrackerKeyBoard.HandleKeyPress(e.KeyCode);
		}

	}
}
