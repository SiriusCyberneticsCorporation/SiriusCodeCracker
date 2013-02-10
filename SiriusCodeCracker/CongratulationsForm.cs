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
	public partial class CongratulationsForm : Form
	{
		public CongratulationsForm()
		{
			InitializeComponent();

			DurationLabel.Text = "Duration: ";
			if (CrackerData.GameDuration.Value.Hours > 0)
			{
				DurationLabel.Text += string.Format("{0}:{1}:{2}",
													CrackerData.GameDuration.Value.Hours.ToString("00"),
													CrackerData.GameDuration.Value.Minutes.ToString("00"),
													CrackerData.GameDuration.Value.Seconds.ToString("00"));
			}
			else if (CrackerData.GameDuration.Value.Minutes > 0)
			{
				DurationLabel.Text += string.Format("{0}:{1}",
													CrackerData.GameDuration.Value.Minutes.ToString("00"),
													CrackerData.GameDuration.Value.Seconds.ToString("00"));
			}
			else 
			{
				DurationLabel.Text += string.Format("{0} seconds!!!",
													CrackerData.GameDuration.Value.Seconds.ToString("00"));
			}

			ExtraLabel.Text = "with " + CrackerData.Corrections + " corrections and " + CrackerData.GivenLetters + " given letters";
		}

		private void CongratulationsForm_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
