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

namespace Пр4
{
    /// <summary>
    /// Логика взаимодействия для TechSupportWindow.xaml
    /// </summary>
    public partial class TechSupportWindow : Window
    {
        public TechSupportWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new TicketsDashboardPage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }

        private void NavigateToTickets(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TicketsDashboardPage());
        }

        private void NavigateToChat(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SupportChatPage());
        }

        private void NavigateToKnowledgeBase(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new KnowledgeBasePage());
        }

    }
}

