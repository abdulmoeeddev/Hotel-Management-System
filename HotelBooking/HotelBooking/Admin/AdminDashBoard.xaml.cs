using HotelBooking.Admin.Item;
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

namespace HotelBooking.Admin
{
    /// <summary>
    /// Interaction logic for AdminDashBoard.xaml
    /// </summary>
    public partial class AdminDashBoard : UserControl
    {
        public AdminDashBoard()
        {
            InitializeComponent();
        }

        private void btnRoomType_Click(object sender, RoutedEventArgs e)
        {
            RoomType roomType = new RoomType();
            Dashboard.Content = roomType;
        }

        private void btnRoom_Click(object sender, RoutedEventArgs e)
        {
            Room room = new Room();
            Dashboard.Content = room;
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category();
            Dashboard.Content = category;
        }
    }
}
