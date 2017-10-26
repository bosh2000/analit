using System.Collections.Generic;
using AnalitCore;


namespace MysqlCore
{
	public interface IMySqlUser
	{
		List<User> GetAllUsers();
		bool AddUser(User user);
		bool DeleteUser(User user);
		bool CheckPassword(User user);
	}
}