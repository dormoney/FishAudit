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
            try
            {
                using (StreamReader reader = new StreamReader("/FishReports/fishstamp.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string firstLine = reader.ReadLine();
                        string secondLine = reader.ReadLine();
                        Console.WriteLine("Первая строка: " + firstLine);
                        Console.WriteLine("Вторая строка: " + secondLine);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
