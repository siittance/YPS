using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Yarik;

namespace Yarik
{
    public partial class YchetOborydovaniyaWindow : Window
    {
        InstrumentServicesEntities1 yp = new InstrumentServicesEntities1();

        public YchetOborydovaniyaWindow()
        {
            InitializeComponent();
            Category.ItemsSource = yp.EquipmentCategories.ToList();
            Category.DisplayMemberPath = "EquipCategoryName";
            Category.SelectedValuePath = "ID_EquipmentCategories";

            Status.ItemsSource = yp.EquipmentStatus.ToList();
            Status.DisplayMemberPath = "EquipmentStatusName";
            Status.SelectedValuePath = "ID_EquipmentStatus";

            EquipmentWatch.ItemsSource = yp.Equipment.ToList();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MenedsherMain menedsher = new MenedsherMain();
            menedsher.Show();
            this.Close();
        }

        private void Add(object sender, RoutedEventArgs eventArgs)
        {
            string equipmentName = Name.Text;
            string inventoryNumber = Number.Text;
            string rentPrice = RentPrice.Text;
            string count = Count.Text;
            string unitCost = PriceZa1.Text;
            var selectedCategory = Category.SelectedItem as EquipmentCategories;
            var selectedStatus = Status.SelectedItem as EquipmentStatus;

            if (string.IsNullOrEmpty(equipmentName) || string.IsNullOrEmpty(inventoryNumber) || string.IsNullOrEmpty(rentPrice) ||
                string.IsNullOrEmpty(count) || string.IsNullOrEmpty(unitCost) || selectedCategory == null || selectedStatus == null)
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
                return;
            }

            if (!decimal.TryParse(rentPrice, out decimal rentalCost) || !int.TryParse(count, out int stockCount) || !decimal.TryParse(unitCost, out decimal unitCostDecimal))
            {
                MessageBox.Show("Некорректные данные в полях стоимости или количества", "Ошибка");
                return;
            }

            if (!int.TryParse(inventoryNumber, out int inventoryNum))
            {
                MessageBox.Show("Некорректный инвентарный номер", "Ошибка");
                return;
            }

            if (yp.Equipment.Any(e => e.InventoryNumber == inventoryNum))
            {
                MessageBox.Show("Оборудование с таким инвентарным номером уже существует", "Ошибка");
                return;
            }

            var equipment = new Equipment
            {
                EquipmentName = equipmentName,
                InventoryNumber = inventoryNum,
                RentalCost = rentalCost,
                StockCount = stockCount,
                UnitCost = unitCostDecimal,
                EquipmentCategories_ID = selectedCategory.ID_EquipmentCategories,
                EquipmentStatus_ID = selectedStatus.ID_EquipmentStatus
            };

            yp.Equipment.Add(equipment);
            yp.SaveChanges();

            EquipmentWatch.ItemsSource = yp.Equipment.ToList();

            Clear(null, null);
        }

        private void Update(object sender, RoutedEventArgs eventArgs)
        {
            if (EquipmentWatch.SelectedItem == null)
            {
                MessageBox.Show("Выберите оборудование для изменения", "Ошибка");
                return;
            }

            var selectedEquipment = EquipmentWatch.SelectedItem as Equipment;
            string equipmentName = Name.Text;
            string inventoryNumber = Number.Text;
            string rentPrice = RentPrice.Text;
            string count = Count.Text;
            string unitCost = PriceZa1.Text;
            var selectedCategory = Category.SelectedItem as EquipmentCategories;
            var selectedStatus = Status.SelectedItem as EquipmentStatus;

            if (string.IsNullOrEmpty(equipmentName) || string.IsNullOrEmpty(inventoryNumber) || string.IsNullOrEmpty(rentPrice) ||
                string.IsNullOrEmpty(count) || string.IsNullOrEmpty(unitCost) || selectedCategory == null || selectedStatus == null)
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
                return;
            }

            if (!decimal.TryParse(rentPrice, out decimal rentalCost) || !int.TryParse(count, out int stockCount) || !decimal.TryParse(unitCost, out decimal unitCostDecimal))
            {
                MessageBox.Show("Некорректные данные в полях стоимости или количества", "Ошибка");
                return;
            }

            if (!int.TryParse(inventoryNumber, out int inventoryNum))
            {
                MessageBox.Show("Некорректный инвентарный номер", "Ошибка");
                return;
            }

            selectedEquipment.EquipmentName = equipmentName;
            selectedEquipment.InventoryNumber = int.Parse(inventoryNumber);
            selectedEquipment.RentalCost = rentalCost;
            selectedEquipment.StockCount = stockCount;
            selectedEquipment.UnitCost = unitCostDecimal;
            selectedEquipment.EquipmentCategories_ID = selectedCategory.ID_EquipmentCategories;
            selectedEquipment.EquipmentStatus_ID = selectedStatus.ID_EquipmentStatus;

            yp.SaveChanges();

            EquipmentWatch.ItemsSource = yp.Equipment.ToList();
        }

        private void Delete(object sender, RoutedEventArgs eventArgs)
        {
            if (EquipmentWatch.SelectedItem == null)
            {
                MessageBox.Show("Выберите оборудование для удаления", "Ошибка");
                return;
            }

            var selectedEquipment = EquipmentWatch.SelectedItem as Equipment;

            bool isUsedInRentals = yp.Rentals.Any(r => r.Equipment_ID == selectedEquipment.ID_Equipment && r.RentalsStatus_ID != 2); 
            bool isUsedInMaintenance = yp.Maintenance.Any(m => m.Equipment_ID == selectedEquipment.ID_Equipment && m.MaintenanceStatus_ID != 1); 

            if (isUsedInRentals || isUsedInMaintenance)
            {
                MessageBox.Show("Невозможно удалить оборудование, так как оно используется в аренде или обслуживании.", "Ошибка");
                return;
            }

            yp.Equipment.Remove(selectedEquipment);
            yp.SaveChanges();

            EquipmentWatch.ItemsSource = yp.Equipment.ToList();

            MessageBox.Show("Оборудование было успешно удалено.", "Успешно");
        }

        private void Clear(object sender, RoutedEventArgs eventArgs)
        {
            Name.Text = null;
            Number.Text = null;
            RentPrice.Text = null;
            Count.Text = null;
            PriceZa1.Text = null;
            Category.Text = null;
            Status.Text = null;
        }

        private void EquipmentPerenos(object sender, SelectionChangedEventArgs e)
        {
            if (EquipmentWatch.SelectedItem is Equipment selectedEquipment)
            {
                Name.Text = selectedEquipment.EquipmentName;
                Number.Text = selectedEquipment.InventoryNumber.ToString();
                RentPrice.Text = selectedEquipment.RentalCost.ToString();
                Count.Text = selectedEquipment.StockCount.ToString();
                PriceZa1.Text = selectedEquipment.UnitCost.ToString();
                Category.SelectedValue = selectedEquipment.EquipmentCategories_ID;
                Status.SelectedValue = selectedEquipment.EquipmentStatus_ID;
            }
        }
    }
}
