using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Yarik
{
    public partial class UrLicoWindow : Window
    {
        InstrumentServicesEntities1 yp = new InstrumentServicesEntities1();

        public UrLicoWindow()
        {
            InitializeComponent();
            PerexodTypeClient.Items.Add("Физ. лицо");
            PerexodTypeClient.Items.Add("Юр. лицо");
            ClientsWatch.ItemsSource = yp.Clients.Where(c => c.ClientType_ID == 1).ToList();

            PassportData.MaxLength = 10;
            PhoneNumber.MaxLength = 12;
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
                        new FizLicoWindow().Show();
                        this.Close();
                        break;
                    case "Физ. лицо":
                        new UrLicoWindow().Show();
                        this.Close();
                        break;
                }
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            string phone = PhoneNumber.Text;
            string email = Email.Text;
            string passportNumber = PassportData.Text;

            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(passportNumber))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Некорректный email", "Ошибка");
                return;
            }

            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Некорректный номер телефона", "Ошибка");
                return;
            }

            if (!IsValidPassportNumber(passportNumber))
            {
                MessageBox.Show("Паспортный номер должен быть числовым значением и длиной 10 символов", "Ошибка");
                return;
            }

            if (yp.Clients.Any(c => c.PhoneNumber == phone))
            {
                MessageBox.Show("Клиент с таким номером телефона уже существует", "Ошибка");
                return;
            }

            if (yp.Clients.Any(c => c.Email == email))
            {
                MessageBox.Show("Клиент с такой почтой уже существует", "Ошибка");
                return;
            }

            if (yp.Clients.Any(c => c.PassportData == passportNumber))
            {
                MessageBox.Show("Клиент с таким паспортным номером уже существует", "Ошибка");
                return;
            }

            Clients newClient = new Clients
            {
                ClientName = ClientName.Text,
                ClientSurname = ClientSurname.Text,
                ClientMiddleName = ClientMiddleName.Text,
                PhoneNumber = phone,
                Email = email,
                PassportData = passportNumber,
                ClientType_ID = 1,
            };

            yp.Clients.Add(newClient);
            yp.SaveChanges();
            ClientsWatch.ItemsSource = yp.Clients.Where(c => c.ClientType_ID == 1).ToList();
            Clear(null, null);
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            if (ClientsWatch.SelectedItem == null)
            {
                MessageBox.Show("Выберите клиента для изменения", "Ошибка");
                return;
            }

            Clients selectedClient = ClientsWatch.SelectedItem as Clients;
            string phone = PhoneNumber.Text;
            string email = Email.Text;
            string passportNumber = PassportData.Text;

            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Некорректный номер телефона (должно быть 12 символов, начиная с +7)", "Ошибка");
                return;
            }

            if (!IsValidPassportNumber(passportNumber))
            {
                MessageBox.Show("Паспортный номер должен быть числовым значением и длиной 10 символов", "Ошибка");
                return;
            }

            if (yp.Clients.Any(c => c.Email == email && c.ID_Clients != selectedClient.ID_Clients))
            {
                MessageBox.Show("Клиент с такой почтой уже существует", "Ошибка");
                return;
            }

            if (yp.Clients.Any(c => c.PhoneNumber == phone && c.ID_Clients != selectedClient.ID_Clients))
            {
                MessageBox.Show("Клиент с таким номером телефона уже существует", "Ошибка");
                return;
            }

            if (yp.Clients.Any(c => c.PassportData == passportNumber && c.ID_Clients != selectedClient.ID_Clients))
            {
                MessageBox.Show("Клиент с таким паспортным номером уже существует", "Ошибка");
                return;
            }

            selectedClient.ClientName = ClientName.Text;
            selectedClient.ClientSurname = ClientSurname.Text;
            selectedClient.ClientMiddleName = ClientMiddleName.Text;
            selectedClient.PhoneNumber = phone;
            selectedClient.Email = email;
            selectedClient.PassportData = passportNumber;

            yp.SaveChanges();
            ClientsWatch.ItemsSource = yp.Clients.Where(c => c.ClientType_ID == 1).ToList();
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^\+7\d{10}$");
        }

        private bool IsValidPassportNumber(string passportNumber)
        {
            return Regex.IsMatch(passportNumber, @"^\d{10}$");
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            ClientName.Text = null;
            ClientSurname.Text = null;
            ClientMiddleName.Text = null;
            PhoneNumber.Text = null;
            Email.Text = null;
            PassportData.Text = null;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (ClientsWatch.SelectedItem == null)
            {
                MessageBox.Show("Выберите клиента для удаления", "Ошибка");
                return;
            }

            Clients selectedClient = ClientsWatch.SelectedItem as Clients;

            var rentals = yp.Rentals.Any(r => r.Clients_ID == selectedClient.ID_Clients);

            if (rentals)
            {
                MessageBox.Show("Нельзя удалить есть связи", "Ошибка");
                return;
            }

            yp.Clients.Remove(selectedClient);
            yp.SaveChanges();
            ClientsWatch.ItemsSource = yp.Clients.Where(c => c.ClientType_ID == 2).ToList();
            Clear(null, null);
        }

        private void PerenosUr(object sender, SelectionChangedEventArgs e)
        {
            var selectedCl = (Clients)ClientsWatch.SelectedItem;
            if (selectedCl != null)
            {
                ClientName.Text = selectedCl.ClientName;
                ClientSurname.Text = selectedCl.ClientSurname;
                ClientMiddleName.Text = selectedCl.ClientMiddleName;
                Email.Text = selectedCl.Email;
                PhoneNumber.Text = selectedCl.PhoneNumber;
                PassportData.Text = selectedCl.PhoneNumber;
            }
        }

        private void PhoneNumberPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[\d+]$");
        }

        private void PassportDataPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^\d$");
        }
    }
}


