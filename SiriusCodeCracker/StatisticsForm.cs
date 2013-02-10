using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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

			if (System.IO.File.Exists("CodeCrackerStatistics.csv"))
			{
				DataTable statisticsTable = GetDataTableFromCsv("CodeCrackerStatistics.csv", false);

				if (statisticsTable != null && statisticsTable.Columns.Count == 7)
				{
					statisticsTable.Columns[0].ColumnName = "User";
					statisticsTable.Columns[1].ColumnName = "DateTime";
					statisticsTable.Columns[2].ColumnName = "Rows";
					statisticsTable.Columns[3].ColumnName = "Columns";
					statisticsTable.Columns[4].ColumnName = "Time";
					statisticsTable.Columns[5].ColumnName = "Corrections";
					statisticsTable.Columns[6].ColumnName = "GivenWords";

					StatisticsDataGridView.DataSource = statisticsTable;
					StatisticsDataGridView.Sort(StatisticsDataGridView.Columns[4], ListSortDirection.Ascending);
				}
			}
		}

		static DataTable GetDataTableFromCsv(string fileName, bool isFirstRowHeader)
		{
			string header = isFirstRowHeader ? "Yes" : "No";

			string pathOnly = Application.StartupPath;

			string sql = @"SELECT * FROM [" + fileName + "]";

			using (OleDbConnection connection = new OleDbConnection(
					  @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
					  ";Extended Properties=\"Text;HDR=" + header + "\""))
			using (OleDbCommand command = new OleDbCommand(sql, connection))
			using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
			{
				DataTable dataTable = new DataTable();
				dataTable.Locale = System.Globalization.CultureInfo.CurrentCulture;
				adapter.Fill(dataTable);
				return dataTable;
			}
		}
	}
}
