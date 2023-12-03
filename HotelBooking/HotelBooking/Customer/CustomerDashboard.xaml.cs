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

namespace HotelBooking.Customer
{
    /// <summary>
    /// Interaction logic for CustomerDashboard.xaml
    /// </summary>
    public partial class CustomerDashboard : UserControl
    {
        string userId;
        public CustomerDashboard(string userId)
        {
            this.userId = userId;
            InitializeComponent();
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(userId);
            Dashboard.Content = profile;  
        }

        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            CustomerRoomRequest roomRequest = new CustomerRoomRequest(userId);
            Dashboard.Content = roomRequest;
        }
    }
}
