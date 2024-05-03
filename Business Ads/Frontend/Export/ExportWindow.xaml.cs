using System.Windows;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using System.Globalization;
using System.IO;
using CsvHelper;
using System.Net.Mail;
using System.Net;
using Frontend.Export;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ExportWindow : Window
    {
        public Window mainWindow;

        public class Stats
        {
            public Stats(int views,int clicks,int buys,int time)
            {
                this.Views = views;
                this.Time = time;
                this.Clicks = clicks;
                this.Buys = buys;
            }

            public int Views { get; set; }

            public int Clicks { get; set; }

            public int Buys { get; set; }

            public int Time { get; set; }
        }

        private readonly Stats stats = new(1000, 100, 5, 30);

        public class User
        {
            public User(string name)
            {
                this.Name = name;
            }

            public string Name { get; set; }

        }

        private readonly User user = new ("Andrew Stone");

        public ExportWindow()
        {
            this.InitializeComponent();

            this.Closed += (sender, eventData) =>
            {
                this.mainWindow.Show();
            };
        }

        public void ExportPDF()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfBrush color = new PdfSolidBrush(System.Drawing.Color.Black);
            int height = 20;
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            if (this.FontBox.SelectedIndex == 1)
            {
                font = font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            }

            if (this.FontBox.SelectedIndex == 2)
            {
                font = _ = new PdfStandardFont(PdfFontFamily.Courier, 12);
            }

            try
            {
                float fontSize = float.Parse(this.SizeInput.Text);
            }
            catch
            {
                throw new Exception("Wrong Size Input");
            }

            if (this.ColorBox.SelectedIndex == 1)
            {
                color = new PdfSolidBrush(System.Drawing.Color.Gray);
            }

            if (this.ColorBox.SelectedIndex == 2)
            {
                color = new PdfSolidBrush(System.Drawing.Color.Red);
            }

            graphics.DrawString("Advertisement Statistics Report", font, color, new PointF((page.Size.Width / 2f) - 100, 10));

            if (this.ImpressionsCheck.IsChecked == true)
            {
                graphics.DrawString("\nAmount of Impressions: " + this.stats.Views.ToString(), font, color, new PointF(10, height));
                height += 20;
            }
            if (this.ClicksCheck.IsChecked == true)
            {
                graphics.DrawString("\nAmount of Clicks: " + this.stats.Clicks.ToString(), font, color, new PointF(10, height));
                height += 20;
            }
            if (this.BuysCheck.IsChecked == true)
            {
                graphics.DrawString("\nAmount of Purchases: " + this.stats.Buys.ToString(), font, color, new PointF(10, height));
                height += 20;
            }
            if (this.TimeCheck.IsChecked == true)
            {
                graphics.DrawString("\nTotal Time Viewed: " + this.stats.Time.ToString(), font, color, new PointF(10, height));
                height += 20;
            }
            if (this.CTRCheck.IsChecked == true)
            {
                graphics.DrawString("\nClick Through Ratio: " + ((float)(this.stats.Clicks / this.stats.Views)).ToString(), font, color, new PointF(10, height));
                height += 20;
            }
            if (this.DateCheck.IsChecked == true)
            {
                graphics.DrawString("Created on:", font, color, new PointF(20, page.Size.Height - 120));
                graphics.DrawString(DateTime.Now.ToString(), font, color, new PointF(20, page.Size.Height - 100));
            }
            if (this.SignatureCheck.IsChecked == true)
            {
                graphics.DrawString("Signature:", font, color, new PointF(page.Size.Width - 200, page.Size.Height - 120));
                graphics.DrawString(user.Name, font, color, new PointF(page.Size.Width - 200, page.Size.Height - 100));
            }
            if (this.RecipientCheck.IsChecked == true)
            {
                graphics.DrawString("Intended Recipient:", font, color, new PointF((page.Size.Width / 2f) - 50, page.Size.Height - 120));
                graphics.DrawString(this.RecipientInput.Text, font, color, new PointF((page.Size.Width / 2f) - 50, page.Size.Height - 100));
            }
            if (this.EmailButton1.IsChecked == true)
            {
                string outputPath = "C:\\Users\\User\\Downloads\\output.pdf";
                document.Save(outputPath);
                this.SendDocEmailAsync(this.EmailInput1.Text, "C:\\Users\\User\\Downloads\\output.pdf");
            }

            if (this.DownloadButton1.IsChecked == true)
            {
                string outputPath = "C:\\Users\\User\\Downloads\\output.pdf";
                document.Save(outputPath);
            }

            document.Close(true);
        }

        public void ExportCSV()
        {
            if (this.EmailButton1.IsChecked == true)
            {
                using (var writer = new StreamWriter("C:\\Users\\User\\Downloads\\output.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    List<Stats> records = new List<Stats> { this.stats };

                    foreach (var record in records)
                    {
                        if (this.ImpressionsCheck.IsChecked == true)
                        {
                            csv.WriteField(record.Views);
                        }

                        if (this.ClicksCheck.IsChecked == true)
                        {
                            csv.WriteField(record.Clicks);
                        }

                        if (this.BuysCheck.IsChecked == true)
                        {
                            csv.WriteField(record.Buys);
                        }

                        if (this.CTRCheck.IsChecked == true)
                        {
                            csv.WriteField((float)record.Views / record.Clicks);
                        }

                        if (this.TimeCheck.IsChecked == true)
                        {
                            csv.WriteField(record.Time);
                        }

                        csv.NextRecord();
                    }
                }

                this.SendDocEmailAsync(this.EmailInput1.Text, "C:\\Users\\User\\Downloads\\output.csv");
            }
            if (this.DownloadButton1.IsChecked == true)
            {
                using var writer = new StreamWriter("C:\\Users\\User\\Downloads\\output.csv");
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                List<Stats> records = new List<Stats> { this.stats };

                foreach (var record in records)
                {
                    if (this.ImpressionsCheck.IsChecked == true)
                    {
                        csv.WriteField(record.Views);
                    }

                    if (this.ClicksCheck.IsChecked == true)
                    {
                        csv.WriteField(record.Clicks);
                    }

                    if (this.BuysCheck.IsChecked == true)
                    {
                        csv.WriteField(record.Buys);
                    }

                    if (this.CTRCheck.IsChecked == true)
                    {
                        csv.WriteField(((float)record.Views / record.Clicks));
                    }

                    if (this.TimeCheck.IsChecked == true)
                    {
                        csv.WriteField(record.Time);
                    }

                    csv.NextRecord();
                }
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Radio7.IsChecked == true)
            {
                this.ExportPDF();
            }
            if (this.Radio5.IsChecked == true)
            {
                this.ExportCSV();
            }

            this.ConfirmExport();
        }

        public void ConfirmExport()
        {
            ExportSucces exportSucces = new ()
            {
                MainWindow = this.mainWindow,
            };
            exportSucces.Show();
            this.Hide();
        }

        public Task SendDocEmailAsync(string recipient, string filename)
        {
            var sender = "osvathrobert03@gmail.com";
            var password = "daes ndml ukpj qvuj";

            var subject = "Statistics Report";
            var message = "Attached are the requested documents";

            var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(sender, password),
                EnableSsl = true,
            };

            var mail = new MailMessage(
                from: sender,
                to: recipient,
                subject: subject,
                body: message

            );
            mail.Attachments.Add(new Attachment(filename));
            return client.SendMailAsync(mail);
        }

        private void ReturnButton1_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.Show();
            this.Close();
        }
    }
}
