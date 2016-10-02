using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SiriusCodeCracker
{
	public partial class SiriusCodeCrackerForm : Form
	{
		private CrosswordGenerator m_crosswordGenerator = null;

		public SiriusCodeCrackerForm()
		{
			InitializeComponent();

			CrosswordGrid.CellSelected += new GridDisplayUserControl.CellSelectedHandler(CrosswordGrid_CellSelected);
			CodeCrackerKeyBoard.LetterSelected += new KeyBoardUserControl.LetterSelectedHandler(CodeCrackerKeyBoard_LetterSelected);
		}

		private void SiriusCodeCrackerForm_Activated(object sender, EventArgs e)
		{
			CrackerData.ReturnToGameGame();
			RefreshGridAndKeyboard();
		}

		private void SiriusCodeCrackerForm_Deactivate(object sender, EventArgs e)
		{
			CrackerData.LeaveGame();
			RefreshGridAndKeyboard();
		}

		private void RefreshGridAndKeyboard()
		{
			CrosswordGrid.Refresh();
			CodeCrackerKeyBoard.Refresh();
		}

		void CodeCrackerKeyBoard_LetterSelected()
		{
			if (CrackerData.CheckCompletion())
			{
				RefreshGridAndKeyboard();

				CongratulationsForm iCongratulationsForm = new CongratulationsForm();
				iCongratulationsForm.ShowDialog(this);

				WordDefinitionButton.Enabled = true;
				PlayerComboBox.Enabled = true;
				StatisticsButton.Text = "Statistics";
				SettingsButton.Text = "Change Settings";
				Text = "Sirius Code Cracker";
			}
			else
			{
				RefreshGridAndKeyboard();
			}
		}

		void CrosswordGrid_CellSelected()
		{
			CodeCrackerKeyBoard.Refresh();
		}

		private void StartNewGameButton_Click(object sender, EventArgs e)
		{
			WordDefinitionButton.Enabled = false;
			PlayerComboBox.Enabled = false;
			StatisticsButton.Text = "Pause Game";
			SettingsButton.Text = "Give Up";

			Properties.Settings.Default.LastPlayer = PlayerComboBox.Text;
			Properties.Settings.Default.Save();
			CrackerData.PlayerName = Properties.Settings.Default.LastPlayer;

			if (File.Exists("Players.txt"))
			{
				bool newPlayer = true;
				string[] lines = File.ReadAllLines("Players.txt");
				foreach (string line in lines)
				{
					if (line == CrackerData.PlayerName)
					{
						newPlayer = false;
						break;
					}
				}

				if (newPlayer)
				{
					File.AppendAllLines("Players.txt", new string[] { CrackerData.PlayerName });
				}
			}

			m_crosswordGenerator.Populate();

			CrackerData.StartGame();

			RefreshGridAndKeyboard();
		}

		private void SettingsButton_Click(object sender, EventArgs e)
		{
			if (CrackerData.GameIsActive())
			{
				CrackerData.StopGame();
				CrackerData.ResetGrid();
				RefreshGridAndKeyboard();

				WordDefinitionButton.Enabled = true;
				PlayerComboBox.Enabled = true;
				StatisticsButton.Text = "Statistics";
				SettingsButton.Text = "Change Settings";
			}
			else
			{
				int currentDifficulty = CrackerData.Configuration.Difficulty;
				CodeCrackerSettingsForm iCodeCrackerSettingsForm = new CodeCrackerSettingsForm();

				if (iCodeCrackerSettingsForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					if (currentDifficulty != CrackerData.Configuration.Difficulty)
					{
						m_crosswordGenerator.InitialiseWords();
					}

					CrackerData.StopGame();
					CrackerData.ResetGrid();
					RefreshGridAndKeyboard();
				}
			}
		}

		private void SiriusCodeCrackerForm_KeyDown(object sender, KeyEventArgs e)
		{
			CodeCrackerKeyBoard.HandleKeyPress(e.KeyCode);
		}

		private void SiriusCodeCrackerForm_Resize(object sender, EventArgs e)
		{
			RefreshGridAndKeyboard();
		}

		private void ExtraLetterButton_Click(object sender, EventArgs e)
		{
			CrackerData.ProvideExtraLetter();
			RefreshGridAndKeyboard();
		}

		private void StatisticsButton_Click(object sender, EventArgs e)
		{
			if (CrackerData.GameIsActive())
			{
				CrackerData.PauseGame();
				StatisticsButton.Text = "Resume Game";
				RefreshGridAndKeyboard();
			}
			else if (CrackerData.GameIsPaused())
			{
				CrackerData.ResumeGame();
				StatisticsButton.Text = "Pause Game";
				RefreshGridAndKeyboard();
			}
			else
			{
				StatisticsForm iStatisticsForm = new StatisticsForm();

				iStatisticsForm.ShowDialog(this);
			}
		}

		private void WordDefinitionButton_Click(object sender, EventArgs e)
		{
			WordDefinitionsForm iWordDefinitionsForm = new WordDefinitionsForm();

			iWordDefinitionsForm.ShowDialog(this);
		}

		private void SecondTimer_Tick(object sender, EventArgs e)
		{
			if (CrackerData.GameIsActive())
			{
				CrackerData.GameDurationSeconds++;
				Text = "Sirius Code Cracker - " + string.Format("Duration : {0}:{1}:{2} Corrections: {3} Given Letters: {4}",
														(CrackerData.GameDurationSeconds / 3600).ToString("00"),
														((CrackerData.GameDurationSeconds % 3600) / 60).ToString("00"),
														(CrackerData.GameDurationSeconds % 60).ToString("00"),
														CrackerData.Corrections,
														CrackerData.GivenLetters);
				/*
				CurrentGameLabel.Text = string.Format("Duration : {0}:{1}:{2} Corrections: {3} Given Letters: {4}",
														(CrackerData.GameDurationSeconds / 3600).ToString("00"),
														((CrackerData.GameDurationSeconds % 3600) / 60).ToString("00"),
														(CrackerData.GameDurationSeconds % 60).ToString("00"),
														CrackerData.Corrections,
														CrackerData.GivenLetters);
				*/
			}
		}

		private void SiriusCodeCrackerForm_Load(object sender, EventArgs e)
		{
			m_crosswordGenerator = new CrosswordGenerator();

			// restore location and size of the form on the desktop
			this.DesktopBounds = new Rectangle(Properties.Settings.Default.Location, Properties.Settings.Default.Size);
			// restore form's window state
			this.WindowState = (FormWindowState)Enum.Parse( typeof(FormWindowState), Properties.Settings.Default.WindowState);

			try
			{
				if (!File.Exists("Players.txt"))
				{
					File.WriteAllLines("Players.txt", new string[] { Environment.UserName });
				}

				if (File.Exists("Players.txt"))
				{
					string [] lines = File.ReadAllLines("Players.txt");
					foreach (string line in lines)
					{
						PlayerComboBox.Items.Add(line);
					}
				}

				if (PlayerComboBox.Items.Count > 0)
				{
					PlayerComboBox.SelectedItem = Properties.Settings.Default.LastPlayer;
					if (PlayerComboBox.SelectedIndex < 0)
					{
						PlayerComboBox.SelectedIndex = 0;
					}
				}
				else
				{
					CrackerData.PlayerName = Environment.UserName;
					PlayerComboBox.Items.Add(CrackerData.PlayerName);
					PlayerComboBox.SelectedIndex = 0;
				}
			}
			catch
			{
			}
		}

		private void SiriusCodeCrackerForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			System.Drawing.Rectangle bounds = this.WindowState != FormWindowState.Normal ? this.RestoreBounds : this.DesktopBounds;
			Properties.Settings.Default.Location = bounds.Location;
			Properties.Settings.Default.Size = bounds.Size;
			Properties.Settings.Default.WindowState = Enum.GetName(typeof(FormWindowState), this.WindowState);
			
			// persist location ,size and window state of the form on the desktop
			Properties.Settings.Default.Save();

		}

		private void GridPanel_SizeChanged(object sender, EventArgs e)
		{
			if (GridPanel.Height > GridPanel.Width)
			{
				CrosswordGrid.Top = GridPanel.Height / 2 - GridPanel.Width / 2;
				CrosswordGrid.Left = 0;
				CrosswordGrid.Height = GridPanel.Width;
				CrosswordGrid.Width = GridPanel.Width;
			}
			else
			{
				CrosswordGrid.Top = 0;
				CrosswordGrid.Left = GridPanel.Width / 2 - GridPanel.Height/2;
				CrosswordGrid.Height = GridPanel.Height;
				CrosswordGrid.Width = GridPanel.Height;
			}
		}

		
	}
}
