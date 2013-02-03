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
		}

		private void button1_Click(object sender, EventArgs e)
		{
			m_crosswordGenerator.Populate(20,20);
			CrackerData.AssignGivenLetters(3, true);

			CrosswordGrid.Refresh();
			CodeCrackerKeyBoard.Refresh();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			CodeCrackerSettingsForm iCodeCrackerSettingsForm = new CodeCrackerSettingsForm();
			
			iCodeCrackerSettingsForm.ShowDialog(this);
		}

	}
}
