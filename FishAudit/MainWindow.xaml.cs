using FishAudit.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FishAudit
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow _instanse;

        public static MainWindow Instanse
        {
            get
            {
                if (_instanse == null)
                {
                    _instanse = new MainWindow();
                }
                return _instanse;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            _instanse = this;
            MainFrame.NavigationService.Navigate(new MainPage());
        }
    }
}
