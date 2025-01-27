using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Yarik
{
	/// <summary>
	/// Логика взаимодействия для TechnikMain.xaml
	/// </summary>
	public partial class TechnikMain : Window
	{
		public TechnikMain()
		{
			InitializeComponent();
		}

        private void Exit(object sender, RoutedEventArgs e)
        {
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
            this.Close();
        }

        private void YchetObsl(object sender, RoutedEventArgs e)
        {
			YchetObslyshivaniyaWindow ychetObslyshivaniyaWindow = new YchetObslyshivaniyaWindow();
			ychetObslyshivaniyaWindow.Show();
			this.Close();
        }
    }
}
