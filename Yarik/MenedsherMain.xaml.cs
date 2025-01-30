using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Yarik
{
    public partial class MenedsherMain : Window
    {
        InstrumentServicesEntities1 yp = new InstrumentServicesEntities1();

        public MenedsherMain()
        {
            InitializeComponent();
            DisplayRentalWarnings();
        }

        private void DisplayRentalWarnings()
        {
            DateTime tomorrow = DateTime.Now.AddDays(1);
            List<string> warnings = new List<string>();

            foreach (var item in yp.Rentals)
            {
                DateTime dateObject;
                if (!DateTime.TryParse(item.ReturnDate, out dateObject))
                {
                    continue;
                }
                TimeSpan difference = tomorrow - dateObject.Date;
                if (difference.Days <= 2 && difference.Days > 0)
                {
                    warnings.Add($"Срок аренды у оборудования с номером: {item.Equipment.InventoryNumber} заканчивается через {difference.Days} дня!");
                }
            }

            if (warnings.Any())
            {
                RentalWarningsTextBlock.Text = string.Join("\n", warnings);
            }
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
