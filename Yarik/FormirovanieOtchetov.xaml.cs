using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Drawing;
using PdfDocument = Spire.Pdf.PdfDocument;
using PdfTrueTypeFont = Spire.Pdf.Graphics.PdfTrueTypeFont;
using PdfStringFormat = Spire.Pdf.Graphics.PdfStringFormat;
using PdfBrushes = Spire.Pdf.Graphics.PdfBrushes;
using PdfPageBase = Spire.Pdf.PdfPageBase;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Globalization;

namespace Yarik
{
    public partial class FormirovanieOtchetov : Window
    {
        private InstrumentServicesEntities1 _context = new InstrumentServicesEntities1();
        private Window _parentWindow;

        public FormirovanieOtchetov(Window parentWindow)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
            LoadReportList();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            _parentWindow.Show();
            this.Close();
        }

        private void LoadReportList()
        {
            ReportComboBox.ItemsSource = new string[]
            {
                "Доходы от аренды за период",
                "Список оборудования в аренде",
                "Статистика популярности оборудования"
            };
        }

        private void ReportComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (ReportComboBox.SelectedItem == null) return;

            string selectedReport = ReportComboBox.SelectedItem.ToString();
            RentalsWatch.Visibility = Visibility.Collapsed;
            EquipmentWatch.Visibility = Visibility.Collapsed;

            bool isDateFilterEnabled = selectedReport == "Доходы от аренды за период";
            StartDatePicker.IsEnabled = isDateFilterEnabled;
            EndDatePicker.IsEnabled = isDateFilterEnabled;

            switch (selectedReport)
            {
                case "Доходы от аренды за период":
                    RentalsWatch.ItemsSource = _context.Rentals.ToList(); 
                    RentalsWatch.Visibility = Visibility.Visible;
                    break;

                case "Список оборудования в аренде":
                    EquipmentWatch.ItemsSource = _context.Equipment.Where(eq => eq.StockCount > 0).ToList();
                    EquipmentWatch.Visibility = Visibility.Visible;
                    break;

                case "Статистика популярности оборудования":
                    EquipmentWatch.ItemsSource = _context.Equipment
                        .OrderByDescending(eq => eq.Rentals.Count)
                        .ToList();
                    EquipmentWatch.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void GenerateReportButton(object sender, RoutedEventArgs e)
        {
            TxtForm();
        }

        private void TxtForm()
        {
            if (ReportComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите отчет перед генерацией.");
                return;
            }

            string selectedReport = ReportComboBox.SelectedItem.ToString();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string reportsFolderPath = Path.Combine(desktopPath, "Отчёты");

            if (!Directory.Exists(reportsFolderPath))
            {
                Directory.CreateDirectory(reportsFolderPath);
            }

            // Абсолютный путь для временного текстового файла
            string txtFilePath = Path.Combine(reportsFolderPath, "dlyageneracii.txt");
            string pdfFilePath = Path.Combine(reportsFolderPath, $"Отчет_{selectedReport}.pdf");

            // Проверим, где сохраняется файл
            MessageBox.Show($"Файл будет сохранен по пути: {txtFilePath}");

            using (FileStream fs = new FileStream(txtFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
            {
                string header = $"Отчет: {selectedReport}";
                int lineWidth = 70;

                string CenterString(string text, int width)
                {
                    if (text.Length >= width) return text;
                    int padding = (width - text.Length) / 2;
                    return new string(' ', padding) + text;
                }

                writer.WriteLine(CenterString(header, lineWidth));
                writer.WriteLine(new string('-', lineWidth));

                if (selectedReport == "Доходы от аренды за период")
                {
                    if (!StartDatePicker.SelectedDate.HasValue || !EndDatePicker.SelectedDate.HasValue)
                    {
                        MessageBox.Show("Необходимо выбрать начальную и конечную даты.");
                        return;
                    }

                    DateTime startDate = StartDatePicker.SelectedDate.Value.Date;
                    DateTime endDate = EndDatePicker.SelectedDate.Value.Date;

                    if (startDate > endDate)
                    {
                        MessageBox.Show("Дата начала не может быть позже даты окончания.");
                        return;
                    }

                    var allRentalsData = _context.Rentals
                        .Select(r => new
                        {
                            r.RentalDate,
                            r.ReturnDate,
                            r.TotalCost,
                            ClientName = r.Clients.ClientName,
                            ClientSurname = r.Clients.ClientSurname,
                            EquipmentName = r.Equipment.EquipmentName,
                            RentalsStatus = r.RentalsStatus.RentalsStatusName
                        })
                        .ToList();

                    var rentalsData = allRentalsData
                        .Where(r =>
                        {
                            if (string.IsNullOrEmpty(r.RentalDate))
                            {
                                return false;
                            }

                            DateTime rentalDate;
                            bool isValidDate = DateTime.TryParseExact(r.RentalDate.Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out rentalDate);

                            return isValidDate && rentalDate >= startDate && rentalDate <= endDate;
                        })
                        .ToList();

                    if (!rentalsData.Any())
                    {
                        MessageBox.Show("За выбранный период нет данных о доходах.");
                        return;
                    }

                    decimal totalRevenue = 0;
                    foreach (var rental in rentalsData)
                    {
                        string fullName = $"{rental.ClientName} {rental.ClientSurname}";
                        writer.WriteLine($"ФИО клиента: {fullName}");
                        writer.WriteLine($"Оборудование: {rental.EquipmentName}");
                        writer.WriteLine($"Дата аренды: {rental.RentalDate}");
                        writer.WriteLine($"Дата возврата: {rental.ReturnDate}");
                        writer.WriteLine($"Статус аренды: {rental.RentalsStatus}");
                        writer.WriteLine($"Сумма оплаты: {rental.TotalCost}");
                        writer.WriteLine(new string('-', lineWidth));

                        totalRevenue += rental.TotalCost;
                    }
                    writer.WriteLine($"Общая сумма дохода за период: {totalRevenue}");
                }

                else if (selectedReport == "Список оборудования в аренде")
                {
                    var equipmentData = _context.Equipment
                        .Where(eq => eq.StockCount > 0)
                        .Select(eq => new
                        {
                            eq.EquipmentName,
                            eq.InventoryNumber,
                            eq.RentalCost,
                            eq.StockCount,
                            eq.UnitCost,
                            CategoryName = eq.EquipmentCategories.EquipCategoryName,
                            StatusName = eq.EquipmentStatus.EquipmentStatusName
                        })
                        .ToList();

                    foreach (var equipment in equipmentData)
                    {
                        writer.WriteLine($"{"Название оборудования:",-20} {equipment.EquipmentName}");
                        writer.WriteLine($"{"Инвентарный номер:",-20} {equipment.InventoryNumber}");
                        writer.WriteLine($"{"Стоимость аренды:",-20} {equipment.RentalCost}");
                        writer.WriteLine($"{"Количество в наличии:",-20} {equipment.StockCount}");
                        writer.WriteLine($"{"Стоимость за единицу:",-20} {equipment.UnitCost}");
                        writer.WriteLine($"{"Категория:",-20} {equipment.CategoryName}");
                        writer.WriteLine($"{"Статус:",-20} {equipment.StatusName}");
                        writer.WriteLine(new string('-', lineWidth));
                    }
                }
                else if (selectedReport == "Статистика популярности оборудования")
                {
                    var equipmentStats = _context.Equipment
                        .OrderByDescending(eq => eq.Rentals.Count)
                        .Select(eq => new
                        {
                            eq.EquipmentName,
                            RentalCount = eq.Rentals.Count
                        })
                        .ToList();

                    foreach (var equipment in equipmentStats)
                    {
                        writer.WriteLine($"{"Оборудование:",-20} {equipment.EquipmentName}");
                        writer.WriteLine($"{"Количество аренды:",-20} {equipment.RentalCount}");
                        writer.WriteLine(new string('-', lineWidth));
                    }
                }

                writer.Flush();
            }

            // Проверим, что файл существует и его содержимое
            if (File.Exists(txtFilePath))
            {
                MessageBox.Show($"Файл успешно создан. Путь: {txtFilePath}");
            }
            else
            {
                MessageBox.Show($"Ошибка: файл не создан.");
            }

            // Преобразуем текстовый файл в PDF
            ConvertTxtToPdf(txtFilePath, pdfFilePath);
        }

        private void ConvertTxtToPdf(string txtFilePath, string pdfFilePath)
        {
            try
            {
                if (!File.Exists(txtFilePath))
                {
                    MessageBox.Show($"Текстовый файл не найден: {txtFilePath}");
                    return;
                }

                using (PdfDocument document = new PdfDocument())
                {
                    PdfPageBase page = document.Pages.Add();

                    string fontPath = @"C:\Windows\Fonts\times.ttf";
                    float fontSize = 12f;

                    PdfTrueTypeFont font = new PdfTrueTypeFont(fontPath, fontSize);

                    PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Top);
                    string[] lines = File.ReadAllLines(txtFilePath, Encoding.UTF8);

                    float y = 20;
                    float lineHeight = font.MeasureString("A").Height + 2;
                    foreach (string line in lines)
                    {
                        page.Canvas.DrawString(line, font, PdfBrushes.Black, new PointF(20, y), format);
                        y += lineHeight;
                    }
                    document.SaveToFile(pdfFilePath);

                    MessageBox.Show($"PDF файл успешно создан: {pdfFilePath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании PDF: {ex.Message}");
            }
        }


        private void Clear(object sender, RoutedEventArgs e)
        {
            StartDatePicker.Text = null;
            EndDatePicker.Text = null;
            ReportComboBox.Text = null;
        }
    }
}

