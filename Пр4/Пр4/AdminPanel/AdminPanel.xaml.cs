using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Пр4
{
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void NavigateToTickets(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(new ManageTicketsPage());
        }

        private void NavigateToEmployees(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(new ManageEmployeesPage());
        }

        private void NavigateToSettings(object sender, RoutedEventArgs e)
        {
            AdminFrame.Navigate(new SettingPage());
        }
    }




}

