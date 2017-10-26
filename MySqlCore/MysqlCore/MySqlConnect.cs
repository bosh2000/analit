using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MysqlCore
{
	public class MySqlConnect
	{
		string connectionString = "Database=analit;Data Source=127.0.0.1;User Id=root;Password=627753!q";
		string userSelectSql="SELECT Login, Password , UserRigths FROM analit.login WHERE Login=@LoginParam ;";
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

		/// <summary>
		/// Получение данных о пользователе по логину
		/// </summary>
		/// <param name="userLogin"></param>
		/// <returns></returns>
		public MySqlDataReader GetUserData(string userLogin)
		{
			
			MySqlCommand cmd = new MySqlCommand(userSelectSql,myConnectiion);
			myConnectiion.Open();
			cmd.Parameters.AddWithValue("@LoginParam", userLogin);
			
			MySqlDataReader rdr= cmd.ExecuteReader();
			return rdr;
		}

		/// <summary>
		/// Получение списка товаров
		/// </summary>
		/// <returns></returns>
		public MySqlDataReader GetItemList()
		{
			return null;
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