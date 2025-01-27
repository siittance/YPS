using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class EmploWIndow : Window
    {
        InstrumentServicesEntities1 yp = new InstrumentServicesEntities1();

        public EmploWIndow()
        {
            InitializeComponent();
            EmploWatch.ItemsSource = yp.Employees.ToList();
            ComboRole.ItemsSource = yp.EmployeesRole.ToList();
            ComboRole.SelectedValuePath = "ID_EmployeesRole";
            ComboRole.DisplayMemberPath = "EmployeesRoleName";
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            DirektorMain direktorMain = new DirektorMain();
            direktorMain.Show();
            this.Close();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            EmploName.Text = null;
            EmploSurname.Text = null;
            EmploMiddleName.Text = null;
            PhoneNumber.Text = null;
            Email.Text = null;
            Password.Text = null;
            ComboRole.Text = null;
            Salary.Text = null;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            string password = Password.Text;
            string email = Email.Text;
            string phoneNumber = PhoneNumber.Text;

            if (string.IsNullOrEmpty(EmploName.Text) ||
                string.IsNullOrEmpty(EmploSurname.Text) ||
                string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(Salary.Text) ||
                ComboRole.SelectedItem == null)
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Неккоректный пароль", "Ошибка");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Некорректный email", "Ошибка");
                return;
            }

            if (yp.Employees.Any(emp => emp.Email == email))
            {
                MessageBox.Show("Сотрудник с такой почтой уже существует", "Ошибка");
                return;
            }

            if (yp.Employees.Any(emp => emp.PhoneNumber == phoneNumber))
            {
                MessageBox.Show("Сотрудник с таким номером уже существует", "Ошибка");
                return;
            }

            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Некорректный номер телефона", "Ошибка");
                return;
            }

            if (!decimal.TryParse(Salary.Text, out decimal salary) || salary <= 0)
            {
                MessageBox.Show("Введите корректную зарплату", "Ошибка");
                return;
            }

            Employees newEmployee = new Employees
            {
                EmployeesName = EmploName.Text,
                EmployeesSurname = EmploSurname.Text,
                EmployeesMiddleName = EmploMiddleName.Text,
                PhoneNumber = phoneNumber,
                Salary = salary,
                Email = email,
                Passwordd = password,
                EmployeesRole_ID = (ComboRole.SelectedItem as EmployeesRole)?.ID_EmployeesRole ?? 0
            };

            yp.Employees.Add(newEmployee);
            yp.SaveChanges();
            EmploWatch.ItemsSource = yp.Employees.ToList();
            Clear(null, null);
        }

        private bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).{8,}$");
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\+7\d{10}$");
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            if (EmploWatch.SelectedItem == null)
            {
                MessageBox.Show("Выберите сотрудника для изменения", "Ошибка");
                return;
            }

            string password = Password.Text;
            string email = Email.Text;
            string phoneNumber = PhoneNumber.Text;

            if (string.IsNullOrEmpty(EmploName.Text) ||
                string.IsNullOrEmpty(EmploSurname.Text) ||
                string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(Salary.Text) ||
                ComboRole.SelectedItem == null)
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Некорректный пароль", "Ошибка");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Некорректный email", "Ошибка");
                return;
            }

            Employees selectedEmployee = EmploWatch.SelectedItem as Employees;
            if (yp.Employees.Any(emp => emp.Email == email && emp.ID_Employees != selectedEmployee.ID_Employees))
            {
                MessageBox.Show("Сотрудник с такой почтой уже существует", "Ошибка");
                return;

            }

            if (yp.Employees.Any(emp => emp.PhoneNumber == phoneNumber && emp.ID_Employees != selectedEmployee.ID_Employees))
            {
                MessageBox.Show("Сотрудник с таким номером уже существует", "Ошибка");
                return;

            }

            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Неккоректный номер телефона", "Ошибка");
                return;
            }

            if (!decimal.TryParse(Salary.Text, out decimal salary) || salary <= 0)
            {
                MessageBox.Show("Введите корректную зарплату", "Ошибка");
                return;
            }

            selectedEmployee.EmployeesName = EmploName.Text;
            selectedEmployee.EmployeesSurname = EmploSurname.Text;
            selectedEmployee.EmployeesMiddleName = EmploMiddleName.Text;
            selectedEmployee.PhoneNumber = phoneNumber;
            selectedEmployee.Salary = salary;
            selectedEmployee.Email = email;
            selectedEmployee.Passwordd = password;
            selectedEmployee.EmployeesRole_ID = (ComboRole.SelectedItem as EmployeesRole)?.ID_EmployeesRole ?? 0;

            yp.SaveChanges();
            EmploWatch.ItemsSource = yp.Employees.ToList();
            Clear(null, null);
        }


        private bool Deleted(Employees selectedEmployee)
        {
            if (yp.EmployeesRole.Any(entry => entry.ID_EmployeesRole == selectedEmployee.ID_Employees))
            {
                MessageBox.Show("Нельзя удалить, есть связи");
                return false;
            }

            return true;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(EmploName.Text) &&
                !string.IsNullOrEmpty(EmploSurname.Text) &&
                !string.IsNullOrEmpty(PhoneNumber.Text) &&
                !string.IsNullOrEmpty(Email.Text) &&
                !string.IsNullOrEmpty(Password.Text) &&
                ComboRole.SelectedItem != null)
            {
                if (!Deleted(EmploWatch.SelectedItem as Employees))
                    return;

                if (EmploWatch.SelectedItem != null)
                {
                    Employees lpa = EmploWatch.SelectedItem as Employees;
                    yp.Employees.Remove(lpa);
                    yp.SaveChanges();
                    EmploWatch.ItemsSource = yp.Employees.ToList();
                }
            }
            else
            {
                MessageBox.Show("Пустые места не оставлять");
            }
        }

        private void EmploPerenos(object sender, SelectionChangedEventArgs e)
        {
            var selectedEmployee = (Employees)EmploWatch.SelectedItem;
            if (selectedEmployee != null)
            {
                EmploName.Text = selectedEmployee.EmployeesName;
                EmploSurname.Text = selectedEmployee.EmployeesSurname;
                EmploMiddleName.Text = selectedEmployee.EmployeesMiddleName;
                PhoneNumber.Text = selectedEmployee.PhoneNumber;
                Email.Text = selectedEmployee.Email;
                Password.Text = selectedEmployee.Passwordd;
                Salary.Text = selectedEmployee.Salary.ToString();
                ComboRole.SelectedValue = selectedEmployee.EmployeesRole_ID;
            }
        }
    }
}
