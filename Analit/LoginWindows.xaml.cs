using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Analit
{
	/// <summary>
	/// Interaction logic for LoginWindows.xaml
	/// </summary>
	public partial class LoginWindows : Window
	{
		public LoginWindows()
		{
			InitializeComponent();
		}

		private void okButton_Click(object sender, RoutedEventArgs e)
		{
			if (LoginTextBox.Text=="" && PasswordTextBox.Password=="")
				{
				MessageBox.Show("Не введен логин или пароль пользователя!","Ошибка");
				}

			MainWindow mWnd = new MainWindow();
			mWnd.Show();
			this.Close();
		}

		
	}
}
