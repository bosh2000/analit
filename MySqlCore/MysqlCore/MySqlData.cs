using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MysqlCore
{
	public class MySqlData
	{
		string connectionString = "Database=analit;Data Source=127.0.0.1;User Id=root;Password=627753!q";
		string userSelectSql="SELECT Login, Password , UserRigths FROM analit.login WHERE Login=@LoginParam ;";
		private string countDocument = "SELECT COUNT(*) FROM analit.saledocument";
		private MySqlConnection myConnectiion;


		public MySqlData()
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
		/// Получение количества строк для получения номера документа
		/// </summary>
		/// <returns></returns>
		public long GetNumberLines()
		{
			MySqlCommand cmd=new MySqlCommand(countDocument,myConnectiion);
			myConnectiion.Open();
			MySqlDataReader rdr = cmd.ExecuteReader();
			long value = 0;
			while (rdr.Read())   ///?????
			{
				value = (long)rdr[0];
			}
			this.CloseConnection();
			return value;
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
			this.CloseConnection();
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