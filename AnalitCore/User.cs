using System;
using System.Security.Cryptography;
using System.Text;
using MysqlCore;
using MySql.Data.MySqlClient;


namespace AnalitCore
{
	public class User
	{
		public string login;
		public string name;
		public string password;
		public int userRigth;

		public User(string login, string password)
		{
			this.login = login;
			this.password = password;
		}

		/// <summary>
		/// Проверка введенного пароля с хешем из базы 
		/// </summary>
		/// <returns></returns>
		public bool CheckPassword()
		{
			bool returnValue = false;
			MySqlData myCon = new MySqlData();
			MySqlDataReader dataReader = myCon.GetUserData(this.login);
			while (dataReader.Read())
			{
				MD5 mD5hash = MD5.Create();
				string hash = GetMd5Hash(mD5hash, password);
				if (VerifyMd5Hash(mD5hash, dataReader["Password"].ToString(), hash))
				{
					returnValue = true;
				}
			}
			myCon.CloseConnection();
			return returnValue;
		}

		public string GetMd5Hash(MD5 md5Hash, string input)
		{
			byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

			StringBuilder sBuilder = new StringBuilder();

			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			return sBuilder.ToString();
		}

		public bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
		{
//			string hashOfInput = GetMd5Hash(md5Hash, input);

			StringComparer comparer = StringComparer.OrdinalIgnoreCase;

			if (0 == comparer.Compare(input, hash))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}