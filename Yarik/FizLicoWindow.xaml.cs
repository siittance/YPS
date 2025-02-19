﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Yarik
{
    public partial class FizLicoWindow : Window
    {
        InstrumentServicesEntities1 yp = new InstrumentServicesEntities1();

        public FizLicoWindow()
        {
            InitializeComponent();
            PerexodTypeClient.Items.Add("Физ. лицо");
            PerexodTypeClient.Items.Add("Юр. лицо");
            ClientsWatch.ItemsSource = yp.Clients.Where(c => c.ClientType_ID == 2).ToList();
            Dolshnost.ItemsSource = yp.ClientRole.ToList();
            Dolshnost.SelectedValuePath = "ID_ClientRole";
            Dolshnost.DisplayMemberPath = "ClientsRoleName";

            INN.MaxLength = 10;
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
            string inn = INN.Text;

            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(inn))
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

            if (!IsValidINN(inn))
            {
                MessageBox.Show("ИНН должен быть числовым значением и длиной не более 10 символов", "Ошибка");
                return;
            }

            if (inn == null)
            {
                MessageBox.Show("ИНН должен быть числовым значением", "Ошибка");
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

            if (yp.Clients.Any(c => c.INN == inn)) 
            {
                MessageBox.Show("Клиент с таким ИНН уже существует", "Ошибка");
                return;
            }

            Clients newClient = new Clients
            {
                CompanyName = CompanyName.Text,
                ClientName = ClientName.Text,
                ClientSurname = ClientSurname.Text,
                ClientMiddleName = ClientMiddleName.Text,
                PhoneNumber = phone,
                Email = email,
                INN = inn, 
                ClientAddress = ClientAddress.Text,
                ClientRole_ID = (Dolshnost.SelectedItem as ClientRole)?.ID_ClientRole ?? 0,
                ClientType_ID = 2,
            };

            yp.Clients.Add(newClient);
            yp.SaveChanges();
            ClientsWatch.ItemsSource = yp.Clients.Where(c => c.ClientType_ID == 2).ToList();
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
            string inn = INN.Text;

            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Некорректный номер телефона (должно быть 12 символов, начиная с +7)", "Ошибка");
                return;
            }

            if (!IsValidINN(inn))
            {
                MessageBox.Show("ИНН должен быть числовым значением и длиной не более 10 символов", "Ошибка");
                return;
            }

            if (inn == null)
            {
                MessageBox.Show("ИНН должен быть числовым значением", "Ошибка");
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

            if (yp.Clients.Any(c => c.INN == inn && c.ID_Clients != selectedClient.ID_Clients)) 
            {
                MessageBox.Show("Клиент с таким ИНН уже существует", "Ошибка");
                return;
            }

            selectedClient.CompanyName = CompanyName.Text;
            selectedClient.ClientName = ClientName.Text;
            selectedClient.ClientSurname = ClientSurname.Text;
            selectedClient.ClientMiddleName = ClientMiddleName.Text;
            selectedClient.PhoneNumber = phone;
            selectedClient.Email = email;
            selectedClient.INN = inn;
            selectedClient.ClientRole_ID = (Dolshnost.SelectedItem as ClientRole)?.ID_ClientRole ?? 0;



            yp.SaveChanges();
            ClientsWatch.ItemsSource = yp.Clients.Where(c => c.ClientType_ID == 2).ToList();
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^\+7\d{10}$");
        }

        private bool IsValidINN(string inn)
        {
            return Regex.IsMatch(inn, @"^\d{10}$");
        }


        private void Clear(object sender, RoutedEventArgs e)
        {
            CompanyName.Text = null;
            ClientName.Text = null;
            ClientSurname.Text = null;
            ClientMiddleName.Text = null;
            PhoneNumber.Text = null;
            Email.Text = null;
            INN.Text = null;
            ClientAddress.Text = null;
            Dolshnost.Text = null;
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

        private void PerenosFiz(object sender, SelectionChangedEventArgs e)
        {
            var selectedCl = (Clients)ClientsWatch.SelectedItem;
            if (selectedCl != null)
            {
                CompanyName.Text = selectedCl.CompanyName;
                ClientName.Text = selectedCl.ClientName;
                ClientSurname.Text = selectedCl.ClientSurname;
                ClientMiddleName.Text = selectedCl.ClientMiddleName;
                Email.Text = selectedCl.Email;
                PhoneNumber.Text = selectedCl.PhoneNumber;
                INN.Text = selectedCl.INN.ToString();  
                ClientAddress.Text = selectedCl.ClientAddress;
                Dolshnost.SelectedValue = selectedCl.ClientRole_ID;
            }
        }

        private void PhoneNumberPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[\d+]$");
        }

        private void INNPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^\d$");
        }
    }
}