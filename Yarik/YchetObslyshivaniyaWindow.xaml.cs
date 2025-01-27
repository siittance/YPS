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
    /// Логика взаимодействия для YchetObslyshivaniyaWindow.xaml
    /// </summary>
    public partial class YchetObslyshivaniyaWindow : Window
    {
        InstrumentServicesEntities1 yp = new InstrumentServicesEntities1();

        public YchetObslyshivaniyaWindow()
        {
            InitializeComponent();
            ComboOborudov.ItemsSource = yp.Maintenance.ToList();
            ComboOborudov.SelectedValuePath = "ID_Equipment";
            ComboOborudov.DisplayMemberPath = "EquipmentName";

            ComboTypeWork.ItemsSource = yp.Maintenance.ToList();
            ComboTypeWork.SelectedValuePath = "ID_WorkTypes";
            ComboTypeWork.DisplayMemberPath = "NameWorkType";

            ComboStatus.ItemsSource = yp.Maintenance.ToList();
            ComboStatus.SelectedValuePath = "ID_MaintenanceStatus";
            ComboStatus.DisplayMemberPath = "MainStatus";
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            TechnikMain technikMain = new TechnikMain();
            technikMain.Show();
            this.Close();
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
            ComboOborudov.Text = null;
            DateObslText.Text = null;
            ComboTypeWork.Text = null;
            ComboStatus.Text = null;                
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
