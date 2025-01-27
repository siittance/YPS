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
    /// Логика взаимодействия для UrLicoWindow.xaml
    /// </summary>
    public partial class UrLicoWindow : Window
    {
        public UrLicoWindow()
        {
            InitializeComponent();
            PerexodTypeClient.Items.Add("Юр. лицо");
            PerexodTypeClient.Items.Add("Физ. лицо");
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MenedsherMain menedsher = new MenedsherMain();
            menedsher.Show();
            this.Close();
        }

        private void RealizaciaPerexoda(object sender, SelectionChangedEventArgs e)
        {
            if (PerexodTypeClient.SelectedItem is string selectedItem)
            {
                switch (selectedItem)
                {
                    case "Юр. лицо": 
                        new UrLicoWindow().Show();
                        this.Close();
                        break;
                    case "Физ. лицо":
                        new FizLicoWindow().Show();
                        this.Close();
                        break;
                }
            }
        }
    }
}
