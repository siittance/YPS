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
	/// Логика взаимодействия для AdminMain.xaml
	/// </summary>
	public partial class MenedsherMain : Window
	{
		public MenedsherMain()
		{
			InitializeComponent();
		}

        private void YchetOborud(object sender, RoutedEventArgs e)
        {
            YchetOborydovaniyaWindow ychetOborydovaniyaWindow = new YchetOborydovaniyaWindow();
            ychetOborydovaniyaWindow.Show();
            this.Close();
        }

        private void YpravArend(object sender, RoutedEventArgs e)
        {
            YpravlenieArendoi ypravlenieArendoi = new YpravlenieArendoi();
            ypravlenieArendoi.Show();
            this.Close();
        }

        private void FormOtchetov(object sender, RoutedEventArgs e)
        {
            FormirovanieOtchetov formirovanieOtchetov = new FormirovanieOtchetov(this);
            formirovanieOtchetov.Show();
            this.Hide();
        }

        private void YpravClient(object sender, RoutedEventArgs e)
        {
            FizLicoWindow fizLicoWindow = new FizLicoWindow();
            fizLicoWindow.Show();
            this.Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }
}
