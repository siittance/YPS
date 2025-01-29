using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using iTextSharp.text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfFont = iTextSharp.text.Font;
using DrawingFont = System.Drawing.Font;
using Spire.Pdf.Graphics;
using Spire.Pdf;
using PdfDocument = Spire.Pdf.PdfDocument;


namespace Yarik
{
    public partial class YpravlenieArendoi : Window
    {
        InstrumentServicesEntities1 yp = new InstrumentServicesEntities1();

        public YpravlenieArendoi()
        {
            InitializeComponent();

            Client.ItemsSource = yp.Clients.ToList();
            Client.DisplayMemberPath = "Email";
            Client.SelectedValuePath = "ID_Clients";

            Oborudovanie.ItemsSource = yp.Equipment
                .Where(e => e.EquipmentStatus_ID == 1) 
                .ToList();
            Oborudovanie.DisplayMemberPath = "EquipmentName";
            Oborudovanie.SelectedValuePath = "ID_Equipment";

            RentalsWatch.ItemsSource = yp.Rentals.ToList();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MenedsherMain menedsher = new MenedsherMain();
            menedsher.Show();
            this.Close();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            string startDate = StartDate.Text;
            string endDate = EndDate.Text;
            string reservationDate = DateRezervation.Text;
            string totalCost = CheckBill.Text;
            var selectedClient = Client.SelectedItem as Clients;
            var selectedEquipment = Oborudovanie.SelectedItem as Equipment;

            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate) || string.IsNullOrEmpty(totalCost) || selectedClient == null || selectedEquipment == null)
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
                return;
            }

            if (!IsValidDate(startDate) || !IsValidDate(endDate) || !IsValidDate(reservationDate))
            {
                MessageBox.Show("Некорректный формат даты. Должно быть в формате: ДД.ММ.ГГГГ", "Ошибка");
                return;
            }

            if (!decimal.TryParse(totalCost, out decimal cost) || cost <= 0)
            {
                MessageBox.Show("Некорректная сумма оплаты", "Ошибка");
                return;
            }

            RentalsStatus rentalStatus = GetRentalStatus(startDate, endDate);

            Rentals newRental = new Rentals
            {
                RentalDate = startDate,
                ReturnDate = endDate,
                ReservationDate = reservationDate,
                TotalCost = cost,
                Clients_ID = selectedClient.ID_Clients,
                Equipment_ID = selectedEquipment.ID_Equipment,
                RentalsStatus_ID = rentalStatus.ID_RentalsStatus
            };

            yp.Rentals.Add(newRental);
            yp.SaveChanges();
            GenerateContract(newRental);
            RentalsWatch.ItemsSource = yp.Rentals.ToList();
            Clear(null, null);
        }



        private void Update(object sender, RoutedEventArgs e)
        {
            if (RentalsWatch.SelectedItem == null)
            {
                MessageBox.Show("Выберите аренду для изменения", "Ошибка");
                return;
            }

            Rentals selectedRental = RentalsWatch.SelectedItem as Rentals;
            string startDate = StartDate.Text;
            string endDate = EndDate.Text;
            string reservationDate = DateRezervation.Text;
            string totalCost = CheckBill.Text;
            var selectedClient = Client.SelectedItem as Clients;
            var selectedEquipment = Oborudovanie.SelectedItem as Equipment;

            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate) ||  string.IsNullOrEmpty(totalCost) || selectedClient == null || selectedEquipment == null)
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
                return;
            }

            if (!IsValidDate(startDate) || !IsValidDate(endDate) || !IsValidDate(reservationDate))
            {
                MessageBox.Show("Некорректный формат даты", "Ошибка");
                return;
            }

            if (!decimal.TryParse(totalCost, out decimal cost) || cost <= 0)
            {
                MessageBox.Show("Некорректная сумма оплаты", "Ошибка");
                return;
            }

            RentalsStatus rentalStatus = GetRentalStatus(startDate, endDate);  

            selectedRental.RentalDate = startDate;
            selectedRental.ReturnDate = endDate;
            selectedRental.ReservationDate = reservationDate;
            selectedRental.TotalCost = cost;
            selectedRental.Clients_ID = selectedClient.ID_Clients;
            selectedRental.Equipment_ID = selectedEquipment.ID_Equipment;
            selectedRental.RentalsStatus_ID = rentalStatus.ID_RentalsStatus;  

            yp.SaveChanges();

            RentalsWatch.ItemsSource = yp.Rentals.ToList();
        }


        private void Clear(object sender, RoutedEventArgs e)
        {
            StartDate.Text = null;
            EndDate.Text = null;
            DateRezervation.Text = null;
            CheckBill.Text = null;
            Client.SelectedIndex = -1;
            Oborudovanie.SelectedIndex = -1;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (RentalsWatch.SelectedItem == null)
            {
                MessageBox.Show("Выберите аренду для удаления", "Ошибка");
                return;
            }


            Rentals selectedRental = RentalsWatch.SelectedItem as Rentals;
            yp.Rentals.Remove(selectedRental);
            yp.SaveChanges();
            RentalsWatch.ItemsSource = yp.Rentals.ToList();
            Clear(null, null);
        }

        private void GenerateContract(Rentals rental)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string contractsFolderPath = Path.Combine(desktopPath, "Договора");

            if (!Directory.Exists(contractsFolderPath))
            {
                Directory.CreateDirectory(contractsFolderPath);
            }

            string contractFileName = $"Договор_Аренды_{rental.ID_Rentals}.pdf";
            string contractFilePath = Path.Combine(contractsFolderPath, contractFileName);

            using (PdfDocument document = new PdfDocument())
            {
                PdfPageBase page = document.Pages.Add();

                string fontPath = @"C:\Windows\Fonts\times.ttf";  
                float fontSize = 12f;
                PdfTrueTypeFont font = new PdfTrueTypeFont(fontPath, fontSize);
                PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top);

                float y = 20;
                float lineHeight = font.MeasureString("A").Height + 2;

                string header = "ДОГОВОР АРЕНДЫ";
                float headerWidth = font.MeasureString(header).Width;
                float pageWidth = page.Canvas.ClientSize.Width;
                float xPosition = (pageWidth - headerWidth) / 2;  

                page.Canvas.DrawString(header, font, PdfBrushes.Black, new PointF(xPosition, y), format);
                y += lineHeight * 2;

                string clientName = $"{rental.Clients.ClientName} {rental.Clients.ClientSurname}";
                page.Canvas.DrawString($"Клиент: {clientName}", font, PdfBrushes.Black, new PointF(20, y), format);
                y += lineHeight;

                page.Canvas.DrawString($"Оборудование: {rental.Equipment.EquipmentName}", font, PdfBrushes.Black, new PointF(20, y), format);
                y += lineHeight;

                page.Canvas.DrawString($"Дата аренды: {rental.RentalDate}", font, PdfBrushes.Black, new PointF(20, y), format);
                y += lineHeight;

                page.Canvas.DrawString($"Дата возврата: {rental.ReturnDate}", font, PdfBrushes.Black, new PointF(20, y), format);
                y += lineHeight;

                page.Canvas.DrawString($"Сумма аренды: {rental.TotalCost} руб.", font, PdfBrushes.Black, new PointF(20, y), format);
                y += lineHeight;

                page.Canvas.DrawString($"Статус аренды: {rental.RentalsStatus.RentalsStatusName}", font, PdfBrushes.Black, new PointF(20, y), format);
                y += lineHeight * 2;

                page.Canvas.DrawString("Подписи сторон:", font, PdfBrushes.Black, new PointF(20, y), format);
                y += lineHeight * 2;

                page.Canvas.DrawString("_________________________  (ФИО заказчика)", font, PdfBrushes.Black, new PointF(20, y), format);
                y += lineHeight;

                page.Canvas.DrawString("_________________________  (ФИО представителя компании)", font, PdfBrushes.Black, new PointF(20, y), format);
                y += lineHeight;

                document.SaveToFile(contractFilePath);
                MessageBox.Show($"Договор успешно создан: {contractFilePath}");
            }
        }



        private bool IsValidDate(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return true;
            }
            return Regex.IsMatch(date, @"^\d{2}\.\d{2}\.\d{4}$");
        }


        private void RentalsPerenos(object sender, SelectionChangedEventArgs e)
        {
            if (RentalsWatch.SelectedItem is Rentals selectedRent)
            {
                StartDate.Text = selectedRent.RentalDate;
                EndDate.Text = selectedRent.ReturnDate;
                DateRezervation.Text = selectedRent.ReservationDate;
                CheckBill.Text = selectedRent.TotalCost.ToString();
                Client.Text = selectedRent.Clients.ToString();
                Oborudovanie.SelectedValue = selectedRent.Equipment_ID;
            }
        }

        private RentalsStatus GetRentalStatus(string startDate, string endDate)
        {
            DateTime rentalDate = DateTime.Parse(startDate);
            DateTime returnDate = DateTime.Parse(endDate);
            DateTime currentDate = DateTime.Now;

            RentalsStatus rentalStatus = null;

            if (currentDate < rentalDate)
            {
                rentalStatus = yp.RentalsStatus.FirstOrDefault(r => r.RentalsStatusName == "Оформлен");
            }
            else if (currentDate >= rentalDate && currentDate <= returnDate)
            {
                rentalStatus = yp.RentalsStatus.FirstOrDefault(r => r.RentalsStatusName == "В процессе");
            }
            else
            {
                rentalStatus = yp.RentalsStatus.FirstOrDefault(r => r.RentalsStatusName == "Завершен");
            }

            return rentalStatus;
        }
    }
}
