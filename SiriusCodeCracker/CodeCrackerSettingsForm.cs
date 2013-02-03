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
	public partial class CodeCrackerSettingsForm : Form
	{
		public CodeCrackerSettingsForm()
		{
			InitializeComponent();
		}

		private void BackgroundColourPictureBox_Click(object sender, EventArgs e)
		{
			ColourSelectionDialog.ShowDialog(this);
		}
	}
}
