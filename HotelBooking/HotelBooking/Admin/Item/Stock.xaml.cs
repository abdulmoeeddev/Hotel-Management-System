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

namespace HotelBooking.Admin.Item
{
    /// <summary>
    /// Interaction logic for Stock.xaml
    /// </summary>
    public partial class Stock : UserControl
    {
        int id = 0;
        public Stock()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var connection = Configuration.Configuration.getInstance().getConnection();
            string query = "SELECT* FROM Item";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter DA = new SqlDataAdapter(command);
            DataTable DT = new DataTable();
            DA.Fill(DT);

            cmbxItemName.ItemsSource = DT.DefaultView;
            cmbxItemName.DisplayMemberPath = "Name";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cmbxItemName.Text != "" && txtQuantity.Text != "" && txtUniPrice.Text != "" && DPdate.Text != "")
            {
                var connection = Configuration.Configuration.getInstance().getConnection();
                string query = $"INSERT INTO Stock VALUES({id},{int.Parse(txtQuantity.Text)}, {float.Parse(txtUniPrice.Text)}, '{DPdate.Text}')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Stock Added Successfully");
            }
            else
            {
                MessageBox.Show("Fill All Fields Properly");
            }
        }

        private void cmbxItemName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object[] data = ((DataRowView)e.AddedItems[0]).Row.ItemArray;
            id = int.Parse(data[0].ToString());
        }
    }
}
