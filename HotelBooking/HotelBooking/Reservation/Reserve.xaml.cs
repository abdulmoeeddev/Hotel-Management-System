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

namespace HotelBooking.Reservation
{
    /// <summary>
    /// Interaction logic for Reserve.xaml
    /// </summary>
    public partial class Reserve : UserControl
    {
        string userId;
        string roomId;
        public Reserve(string userId, string roomId)
        {
            this.userId = userId;
            this.roomId = roomId;
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var connection = Configuration.Configuration.getInstance().getConnection();
            string query = $"SELECT TOP 1 * FROM Room JOIN RoomType ON Room.RoomTypeID = RoomType.ID WHERE RoomId = '{roomId}'";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter DA = new SqlDataAdapter(command);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            img1.Source = new BitmapImage(new Uri(@"download (1).jpg", UriKind.Relative));
            lblDescription.Text = DT.Rows[0][5].ToString();
            lblPrice.Text = "$" + DT.Rows[0][8].ToString();
            lblType.Text = DT.Rows[0][7].ToString();

            query = $"SELECT * FROM SystemUsers WHERE UserId = '{userId}'";
            command = new SqlCommand(query, connection);
            DA = new SqlDataAdapter(command);
            DataTable userDT = new DataTable();
            DA.Fill(userDT);

            txtName.Text = DT.Rows[0][1].ToString();
            txtEmail.Text = DT.Rows[0][2].ToString();
        }

        private void btnReserve_Click(object sender, RoutedEventArgs e)
        {
            if(StartDate.Text !="" && EndDate.Text!="")
            {
                var connection = Configuration.Configuration.getInstance().getConnection();
                string query = $"INSERT INTO Reservation VALUES('{userId}','{DateTime.Now.Date}')";
                SqlCommand command = new SqlCommand(query , connection);
                command.ExecuteNonQuery();

                query = "SELECT TOP 1 * FROM Reservation ORDER BY ReserveId DESC";
                command = new SqlCommand(query , connection);
                SqlDataAdapter DA = new SqlDataAdapter(command);
                DataTable DT = new DataTable();
                DA.Fill(DT);

                query = $"INSERT INTO ReservationDetails VALUES('{DT.Rows[0][0].ToString()}','{roomId}', '{DateTime.Parse(StartDate.Text).Date}', '{DateTime.Parse(EndDate.Text).Date}')";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                query = $"UPDATE Room SET isReserved = 1 WHERE RoomId = '{roomId}'";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Reservation Added Successfully");
            }
        }
    }
}
