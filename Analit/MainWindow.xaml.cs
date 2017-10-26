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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AnalitCore;
namespace Analit
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private User loginUser;
		public MainWindow()
		{
			InitializeComponent();
		}

		public MainWindow(User user) :this()
		{
			loginUser = user;
			textBlock1.Text = loginUser.login;
		}

		private void Grid_KeyDown(object sender,KeyEventArgs e )
		{
			SaleDocument saleDocument=new SaleDocument();
			saleDocument.GetLastNumberDocument();
			textBlock1.Text = e.Key.ToString();
		}

		private void GridLoaded(object sender,RoutedEventArgs e)
		{
			mainGrid.Focus();
		}

	}
}
