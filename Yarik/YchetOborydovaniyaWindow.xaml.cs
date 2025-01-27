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
    /// Логика взаимодействия для YchetOborydovaniyaWindow.xaml
    /// </summary>
    public partial class YchetOborydovaniyaWindow : Window
    {
        public YchetOborydovaniyaWindow()
        {
            InitializeComponent();
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            MenedsherMain menedsher = new MenedsherMain();
            menedsher.Show();
            this.Close();
        }
    }
}
