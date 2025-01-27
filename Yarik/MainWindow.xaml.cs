using System;
using System.Linq;
using System.Windows;

namespace Yarik
{
    public partial class MainWindow : Window
    {
        InstrumentServicesEntities1 yp = new InstrumentServicesEntities1();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Auth(object sender, RoutedEventArgs e)
        {
            var vxod = yp.Employees.ToList();
            bool avtoriz = false;

            if (string.IsNullOrWhiteSpace(PochtaText.Text) || string.IsNullOrWhiteSpace(PasswordText.Password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            foreach (var v in vxod)
            {
                if (v.Email == PochtaText.Text && v.Passwordd == PasswordText.Password)
                {
                    avtoriz = true;

                    if (v.EmployeesRole_ID == 1)
                    {
                        MenedsherMain menedsher = new MenedsherMain();
                        menedsher.Show();
                    }
                    else if (v.EmployeesRole_ID == 2)
                    {
                        DirektorMain direktor = new DirektorMain();
                        direktor.Show();
                    }
                    else if (v.EmployeesRole_ID == 3)
                    {
                        TechnikMain technik = new TechnikMain();
                        technik.Show();
                    }

                    Close();
                    break;
                }
            }

            if (!avtoriz)
            {
                MessageBox.Show("Такого логина/пароля не существует. Попробуйте еще раз.");
                PochtaText.Text = null;
                PasswordText.Password = null;
            }
        }
    }
}
