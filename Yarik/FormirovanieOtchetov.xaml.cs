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
    /// Логика взаимодействия для FormirovanieOtchetov.xaml
    /// </summary>
    public partial class FormirovanieOtchetov : Window
    {
        private Window _parentWindow; //родительское окно
        public FormirovanieOtchetov(Window parentWindow)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            _parentWindow.Show(); 
            this.Close();
        }
    }
}
