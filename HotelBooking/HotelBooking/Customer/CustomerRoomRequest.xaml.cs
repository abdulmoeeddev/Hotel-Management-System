using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for CustomerRoomRequest.xaml
    /// </summary>
    public partial class CustomerRoomRequest : UserControl
    {
        string userId;
        public CustomerRoomRequest(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void DGPendingRequest_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var connection = Configuration.Configuration.getInstance().getConnection();
            string query = $"SELECT RoomNumber, DateReserved, StartDate, EndDate, CASE WHEN Status = 0 THEN 'Pending' ELSE 'Approved' END as Status FROM Reservation as R JOIN ReservationDetails as RD ON R.ReserveId = RD.ReserveId JOIN Room on Room.RoomId = RD.RoomId WHERE Status = 0 AND UserId = {userId} ";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter DA = new SqlDataAdapter(command);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            DGPendingRequest.ItemsSource = DT.DefaultView;
        }
    }
}
