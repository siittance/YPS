using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Yarik
{
    public partial class YchetObslyshivaniyaWindow : Window
    {
        InstrumentServicesEntities1 yp = new InstrumentServicesEntities1();

        public YchetObslyshivaniyaWindow()
        {
            InitializeComponent();
            MaintenanceWatch.ItemsSource = yp.Maintenance.ToList();
            ComboOborudov.ItemsSource = yp.Equipment.ToList();
            ComboOborudov.SelectedValuePath = "ID_Equipment";
            ComboOborudov.DisplayMemberPath = "EquipmentName";

            ComboTypeWork.ItemsSource = yp.WorkTypes.ToList();
            ComboTypeWork.SelectedValuePath = "ID_WorkTypes";
            ComboTypeWork.DisplayMemberPath = "NameWorkType";

            ComboStatus.ItemsSource = yp.MaintenanceStatus.ToList();
            ComboStatus.SelectedValuePath = "ID_MaintenanceStatus";
            ComboStatus.DisplayMemberPath = "MainStatus";
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            TechnikMain technikMain = new TechnikMain();
            technikMain.Show();
            this.Close();
        }

        private bool IsValidDate(string date)
        {
            return DateTime.TryParseExact(date, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out _);
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DateObslText.Text) ||
                ComboOborudov.SelectedItem == null ||
                ComboTypeWork.SelectedItem == null ||
                ComboStatus.SelectedItem == null)
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
                return;
            }

            if (!IsValidDate(DateObslText.Text))
            {
                MessageBox.Show("Введите дату в формате ДД.ММ.ГГГГ", "Ошибка");
                return;
            }

            DateTime enteredDate = DateTime.ParseExact(DateObslText.Text, "dd.MM.yyyy", null);

            DateTime minDate = DateTime.Today.AddYears(-1); 
            DateTime maxDate = DateTime.Today.AddYears(1); 

            if (enteredDate < minDate)
            {
                MessageBox.Show($"Дата не может быть раньше {minDate:dd.MM.yyyy}", "Ошибка");
                DateObslText.Text = string.Empty;
                return;
            }

            if (enteredDate > maxDate)
            {
                MessageBox.Show($"Дата не может быть позже {maxDate:dd.MM.yyyy}", "Ошибка");
                DateObslText.Text = string.Empty;
            }

            Maintenance newMaintenance = new Maintenance
            {
                MaintenanceDate = DateObslText.Text,
                Equipment_ID = (ComboOborudov.SelectedItem as Equipment)?.ID_Equipment ?? 0,
                WorkTypes_ID = (ComboTypeWork.SelectedItem as WorkTypes)?.ID_WorkTypes ?? 0,
                MaintenanceStatus_ID = (ComboStatus.SelectedItem as MaintenanceStatus)?.ID_MaintenanceStatus ?? 0
            };

            yp.Maintenance.Add(newMaintenance);
            yp.SaveChanges();
            MaintenanceWatch.ItemsSource = yp.Maintenance.ToList();
            Clear(null, null);
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            if (MaintenanceWatch.SelectedItem == null)
            {
                MessageBox.Show("Выберите запись для изменения", "Ошибка");
                return;
            }

            if (string.IsNullOrEmpty(DateObslText.Text) ||
                ComboOborudov.SelectedItem == null ||
                ComboTypeWork.SelectedItem == null ||
                ComboStatus.SelectedItem == null)
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
                return;
            }

            if (!IsValidDate(DateObslText.Text))
            {
                MessageBox.Show("Введите дату в формате ДД.ММ.ГГГГ", "Ошибка");
                return;
            }
            DateTime enteredDate = DateTime.ParseExact(DateObslText.Text, "dd.MM.yyyy", null);

            // Ограничения
            DateTime minDate = new DateTime(2000, 1, 1);
            DateTime maxDate = DateTime.Today.AddYears(1); // Дата ровно через год от текущего дня

            if (enteredDate < minDate)
            {
                MessageBox.Show($"Дата не может быть раньше {minDate:dd.MM.yyyy}", "Ошибка");
                DateObslText.Text = string.Empty;
                return;
            }

            if (enteredDate > maxDate)
            {
                MessageBox.Show($"Дата не может быть позже {maxDate:dd.MM.yyyy}", "Ошибка");
                DateObslText.Text = string.Empty;
            }

            Maintenance selectedMaintenance = MaintenanceWatch.SelectedItem as Maintenance;
            selectedMaintenance.MaintenanceDate = DateObslText.Text;
            selectedMaintenance.Equipment_ID = (ComboOborudov.SelectedItem as Equipment)?.ID_Equipment ?? 0;
            selectedMaintenance.WorkTypes_ID = (ComboTypeWork.SelectedItem as WorkTypes)?.ID_WorkTypes ?? 0;
            selectedMaintenance.MaintenanceStatus_ID = (ComboStatus.SelectedItem as MaintenanceStatus)?.ID_MaintenanceStatus ?? 0;

            yp.SaveChanges();
            MaintenanceWatch.ItemsSource = yp.Maintenance.ToList();
            Clear(null, null);
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            ComboOborudov.SelectedIndex = -1;
            DateObslText.Text = null;
            ComboTypeWork.SelectedIndex = -1;
            ComboStatus.SelectedIndex = -1;
        }

        private void MaintenancePerenos(object sender, SelectionChangedEventArgs e)
        {
            var selectedMaintenance = MaintenanceWatch.SelectedItem as Maintenance;
            if (selectedMaintenance != null)
            {
                DateObslText.Text = selectedMaintenance.MaintenanceDate;
                ComboOborudov.SelectedValue = selectedMaintenance.Equipment_ID;
                ComboTypeWork.SelectedValue = selectedMaintenance.WorkTypes_ID;
                ComboStatus.SelectedValue = selectedMaintenance.MaintenanceStatus_ID;
            }
        }
    }
}
