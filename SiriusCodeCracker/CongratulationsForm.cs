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
			if (CrackerData.GameDurationSeconds/ 3600 > 0)
			{
				DurationLabel.Text += string.Format("{0}:{1}:{2}",
													(CrackerData.GameDurationSeconds / 3600).ToString("00"),
													((CrackerData.GameDurationSeconds % 3600) / 60).ToString("00"),
													(CrackerData.GameDurationSeconds % 60).ToString("00"));
			}
			else if ((CrackerData.GameDurationSeconds % 3600) / 60 > 0)
			{
				DurationLabel.Text += string.Format("{0}:{1}",
													((CrackerData.GameDurationSeconds % 3600) / 60).ToString("00"),
													(CrackerData.GameDurationSeconds % 60).ToString("00"));
			}
			else 
			{
				DurationLabel.Text += string.Format("{0} seconds!!!",
													((CrackerData.GameDurationSeconds % 3600) / 60).ToString("00"),
													(CrackerData.GameDurationSeconds % 60).ToString("00"));
			}

			ExtraLabel.Text = "with " + CrackerData.Corrections + " corrections and " + CrackerData.GivenLetters + " given letters";
		}

		private void CongratulationsForm_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
