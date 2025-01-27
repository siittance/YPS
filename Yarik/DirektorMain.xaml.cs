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
	/// Логика взаимодействия для DirektorMain.xaml
	/// </summary>
	public partial class DirektorMain : Window
	{
		public DirektorMain()
		{
			InitializeComponent();
		}

        private void YpravSotr(object sender, RoutedEventArgs e)
        {
            EmploWIndow emploWIndow = new EmploWIndow();
            emploWIndow.Show();
            this.Close();
        }

        private void YpravSkladom(object sender, RoutedEventArgs e)
        {
            YpravleSkladom ypravleSkladom = new YpravleSkladom();
            ypravleSkladom.Show();
            this.Close();
        }

        private void ProsmotrOtchetov(object sender, RoutedEventArgs e)
        {
            FormirovanieOtchetov formirovanieOtchetov = new FormirovanieOtchetov(this);
            formirovanieOtchetov.Show();
            this.Hide();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
