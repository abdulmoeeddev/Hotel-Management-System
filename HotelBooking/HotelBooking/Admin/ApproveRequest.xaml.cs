using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Collections;

namespace HotelBooking.Admin
{
    /// <summary>
    /// Interaction logic for ApproveRequest.xaml
    /// </summary>
    public partial class ApproveRequest : UserControl
    {
        public ApproveRequest()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var connection = Configuration.Configuration.getInstance().getConnection();
            string query = $"SELECT R.ReserveId,SystemUsers.UserId, SystemUsers.Name, SystemUsers.Email, RoomNumber, DateReserved, StartDate, EndDate FROM Reservation as R JOIN ReservationDetails as RD ON R.ReserveId = RD.ReserveId JOIN Room on Room.RoomId = RD.RoomId JOIN SystemUsers ON SystemUsers.UserId = R.UserId WHERE Status = 0";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter DA = new SqlDataAdapter(command);
            DataTable DT = new DataTable();
            DA.Fill(DT);

            List<string> status = new List<string>() { "Approve", "Not Approve" };

            DataColumn PendingStatus = new DataColumn("PendingStatus", typeof(String));
            DT.Columns.Add(PendingStatus);


            DataGridComboBoxColumn pending = new DataGridComboBoxColumn();
            pending.Header = "PendingStatus";
            pending.ItemsSource = status;

            pending.SelectedItemBinding = new Binding("PendingStatus");
            DGPendingRequest.Columns.Add(pending);
            DGPendingRequest.ItemsSource = DT.DefaultView;
            DGPendingRequest.Columns[0].DisplayIndex = 8;
            DGPendingRequest.Columns[9].Visibility = Visibility.Hidden;
            DGPendingRequest.Columns[1].Visibility = Visibility.Hidden;
            DGPendingRequest.Columns[2].Visibility = Visibility.Hidden;

        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            var connection = Configuration.Configuration.getInstance().getConnection();
            foreach (DataRowView row in DGPendingRequest.Items)
            {
                System.Data.DataRow MyRow = row.Row;
                if (MyRow != null && MyRow["UserId"].ToString() != "")
                {
                    int UserId = int.Parse(MyRow["UserId"].ToString());
                    int ReserveId = int.Parse(MyRow["ReserveId"].ToString());
                    string status = MyRow["PendingStatus"].ToString();
                    if (status == "" || status == "Approve")
                        status = "1";
                    else
                        status = "0";
                    if (status == "1")
                    {
                        string query = $"UPDATE Reservation SET Status = 1 WHERE UserId = {UserId} AND ReserveId = {ReserveId}";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("All are approved");
        }
    }
}
