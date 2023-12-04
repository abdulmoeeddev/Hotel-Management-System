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
        string userId;
        public AdminDashBoard(string userId)
        {
            InitializeComponent();
            this.userId = userId;
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

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            Dashboard.Content = product;
        }

        private void btnStock_Click(object sender, RoutedEventArgs e)
        {
            Stock stock = new Stock();
            Dashboard.Content = stock;
        }

        private void btnPending_Click(object sender, RoutedEventArgs e)
        {
            ApproveRequest approveRequest = new ApproveRequest();
            Dashboard.Content = approveRequest;
        }

        private void btnOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            OrderDetails orderDetails = new OrderDetails(userId);
            Dashboard.Content = orderDetails;
        }

        private void btnRoomList_Click(object sender, RoutedEventArgs e)
        {
            RoomList roomList = new RoomList(userId);
            Dashboard.Content = roomList;
        }

        private void btnFacility_Click(object sender, RoutedEventArgs e)
        {
            Facility facility = new Facility();
            Dashboard.Content = facility;
        }
    }
}
