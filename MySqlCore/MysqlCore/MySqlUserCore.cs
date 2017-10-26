using System;
using System.Collections.Generic;
using AnalitCore;

namespace MysqlCore
{
	public class MySqlUserCore : IMySqlUser
	{

		public MySqlUserCore()
		{
			
		}
		
		public List<User> GetAllUsers()
		{
			throw new NotImplementedException();
		}

		public bool AddUser(User user)
		{
			throw new NotImplementedException();
		}

		public bool DeleteUser(User user)
		{
			throw new NotImplementedException();
		}

		public bool CheckPassword(User user)
		{
			MySqlConnect myCon=new MySqlConnect();
			
			myCon.CloseConnection();
		}
	}
}