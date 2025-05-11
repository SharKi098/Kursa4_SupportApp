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
    public partial class EmployeePanel : Window
    {
        public EmployeePanel()
        {
            InitializeComponent();
        }

        private void NavigateToPersonalAccount(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PersonalAccountPage());
        }
        private void NavigateToCreateTicket(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateTicketPage());
        }

        private void NavigateToTrackTickets(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TrackTicketsPage());
        }

        private void NavigateToRating(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RatingPage());
        }

    }
}
