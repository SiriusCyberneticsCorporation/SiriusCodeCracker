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
	public partial class StatisticsForm : Form
	{
		public StatisticsForm()
		{
			InitializeComponent();

			string[] lines = System.IO.File.ReadAllLines("Statistics.txt");

			foreach (string line in lines)
			{
				StatisticsListBox.Items.Add(line);
			}
		}
	}
}
