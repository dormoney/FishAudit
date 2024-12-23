using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace FishAudit.Pages
{
    /// <summary>
    /// Логика взаимодействия для InputPage.xaml
    /// </summary>
    public partial class InputPage : Page
    {
        public InputPage()
        {
            InitializeComponent();
            string filePath = "/FishReports/fishstamp.txt";
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
                timeStamp.Text = lines[0];
                tempChanges.Text = lines[1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string timestamp = timeStamp.Text;
            string tempChangesText = tempChanges.Text;
            int minAllowedTemp = int.Parse(min_tem.Text);
            int maxAllowedTemp = int.Parse(max_tem.Text);
            int[] temperatures = tempChangesText.Split(' ').Select(temp => int.Parse(temp)).ToArray();
            int belowMinMinutes = 0;
            int aboveMaxMinutes = 0;

            foreach (int temp in temperatures)
            {
                if (temp < minAllowedTemp)
                {
                    belowMinMinutes += 10;
                }
                else if (temp > maxAllowedTemp)
                {
                    aboveMaxMinutes += 10;
                }
            }
            if (aboveMaxMinutes > int.Parse(max_t_time.Text))
            {
                int totalDeviationMinutes = aboveMaxMinutes;
                string report = $"Дата начала: {timestamp}\n" +
                            $"Всего времени, когда температура была выше максимальной ({minAllowedTemp}°C): {belowMinMinutes} минут.\n";
                using (StreamWriter writer = new StreamWriter("/FishReports/report.txt", false))
                {
                    writer.WriteLine(report);
                }
                MessageBox.Show("Готово");
            }
            else if (belowMinMinutes > int.Parse(min_t_time.Text))
            {
                int totalDeviationMinutes = belowMinMinutes;
                string report = $"Дата начала: {timestamp}\n" +
                            $"Всего времени, когда температура была ниже минимальной ({minAllowedTemp}°C): {belowMinMinutes} минут.\n" +
                            $"Общее время отклонений: {totalDeviationMinutes} минут.\n";
                using (StreamWriter writer = new StreamWriter("/FishReports/report.txt", false))
                {
                    writer.WriteLine(report);
                }
                MessageBox.Show("Готово");
            }
        }
    }
}
