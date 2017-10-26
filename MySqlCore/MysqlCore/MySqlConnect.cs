using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MysqlCore
{
	public class MySqlConnect
	{
		string connectionString = "Database=Analit;Data Source=127.0.0.1;User Id=root;Password=627753";
		private MySqlConnection myConnectiion;


		public MySqlConnect()
		{
			try
			{
				myConnectiion = new MySqlConnection(connectionString);
			}
			catch (MySqlException e)
			{
				MessageBox.Show("Ошибка подключения к базе данных /n" + e.Message);
				throw;
			}
		}

		public bool CloseConnection()
		{
			try
			{
				myConnectiion.Clone();
			}
			catch (Exception e)
			{
				MessageBox.Show("Ошибка подключения к базе данных /n" + e.Message);
				return false;
			}
			return true;
		}
	}
}