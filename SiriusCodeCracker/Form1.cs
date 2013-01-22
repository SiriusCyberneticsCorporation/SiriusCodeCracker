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
	public partial class Form1 : Form
	{
		CrosswordGenerator m_crosswordGenerator = new CrosswordGenerator();

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			CrosswordGrid.NumberOfColumns = (int)ColumnsNumericUpDown.Value;
			CrosswordGrid.NumberOfRows = (int)RowsNumericUpDown.Value;

			m_crosswordGenerator.SetGridSize(CrosswordGrid.NumberOfColumns, CrosswordGrid.NumberOfRows);
			m_crosswordGenerator.Populate();

			CrosswordGrid.m_theGrid = m_crosswordGenerator.m_theGrid;
			CrosswordGrid.Refresh();
		}

		private void NumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			CrosswordGrid.NumberOfColumns = (int)ColumnsNumericUpDown.Value;
			CrosswordGrid.NumberOfRows = (int)RowsNumericUpDown.Value;
			CrosswordGrid.m_theGrid = null;
			CrosswordGrid.Refresh();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			m_crosswordGenerator.PlaceNext();
			CrosswordGrid.Refresh();
		}

	}
}
