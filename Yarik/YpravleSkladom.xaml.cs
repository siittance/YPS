using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;

namespace Yarik
{
    public partial class YpravleSkladom : Window
    {
        private readonly InstrumentServicesEntities1 yp = new InstrumentServicesEntities1();

        public YpravleSkladom()
        {
            InitializeComponent();
            EquipmentWatch.ItemsSource = yp.Equipment.ToList();
            Oborudovanie.ItemsSource = yp.Equipment.ToList();
            Oborudovanie.SelectedValuePath = "ID_Equipment";
            Oborudovanie.DisplayMemberPath = "EquipmentName";
        }


        private void Back(object sender, RoutedEventArgs e)
        {
            DirektorMain direktorMain = new DirektorMain();
            direktorMain.Show();
            this.Close();
        }

        private void ZakazButton(object sender, RoutedEventArgs e)
        {
            if (Oborudovanie.SelectedItem is Equipment selectedEquipment &&
                int.TryParse(HowTextBox.Text, out int orderQuantity) && orderQuantity > 0)
            {
                selectedEquipment.StockCount += orderQuantity;
                yp.Entry(selectedEquipment).State = EntityState.Modified;
                yp.SaveChanges();

                EquipmentWatch.ItemsSource = yp.Equipment.ToList();

                MessageBox.Show($"Заказано {orderQuantity} ед. {selectedEquipment.EquipmentName} на склад.", "Успешно");
            }
            else
            {
                MessageBox.Show("Выберите оборудование и введите корректное количество.", "Ошибка");
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            HowTextBox.Text = null;
            Oborudovanie.Text = null;
        }
    }
}
