using System;
using System.Collections.Generic;
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

namespace HotelBooking.Admin
{
    /// <summary>
    /// Interaction logic for RoomType.xaml
    /// </summary>
    public partial class RoomType : UserControl
    {
        public RoomType()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txtRoomType.Text!="" && txtPrice.Text != "")
            {
                var connection = Configuration.Configuration.getInstance().getConnection();
                string query = $"INSERT INTO RoomType VALUES ('{txtRoomType.Text}',{float.Parse(txtPrice.Text)})";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Room Type Added Successfully");
            }

        }
    }
}
