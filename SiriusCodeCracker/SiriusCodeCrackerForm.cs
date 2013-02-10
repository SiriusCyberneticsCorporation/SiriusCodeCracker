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

				CongratulationsForm iCongratulationsForm = new CongratulationsForm();
				iCongratulationsForm.ShowDialog(this);

				WordDefinitionButton.Enabled = true;
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

		private void StartNewGameButton_Click(object sender, EventArgs e)
		{
			WordDefinitionButton.Enabled = false;

			m_crosswordGenerator.Populate();

			CrosswordGrid.Refresh();
			CodeCrackerKeyBoard.Refresh();
		}

		private void SettingsButton_Click(object sender, EventArgs e)
		{
			CodeCrackerSettingsForm iCodeCrackerSettingsForm = new CodeCrackerSettingsForm();

			if (iCodeCrackerSettingsForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				CrackerData.ResetGrid();
				CrosswordGrid.Refresh();
				CodeCrackerKeyBoard.Refresh();
			}
		}

		private void SiriusCodeCrackerForm_KeyDown(object sender, KeyEventArgs e)
		{
			CodeCrackerKeyBoard.HandleKeyPress(e.KeyCode);
		}

		private void SiriusCodeCrackerForm_Resize(object sender, EventArgs e)
		{
			CrosswordGrid.Refresh();
			CodeCrackerKeyBoard.Refresh();
		}

		private void ExtraLetterButton_Click(object sender, EventArgs e)
		{
			CrackerData.ProvideExtraLetter();
			CrosswordGrid.Refresh();
			CodeCrackerKeyBoard.Refresh();
		}

		private void StatisticsButton_Click(object sender, EventArgs e)
		{
			StatisticsForm iStatisticsForm = new StatisticsForm();

			iStatisticsForm.ShowDialog(this);
		}

		private void WordDefinitionButton_Click(object sender, EventArgs e)
		{
			WordDefinitionsForm iWordDefinitionsForm = new WordDefinitionsForm();

			iWordDefinitionsForm.ShowDialog(this);
		}

		
	}
}
