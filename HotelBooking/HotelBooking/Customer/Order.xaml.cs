using HotelBooking.Admin.Item;
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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : UserControl
    {
        List<Product> listProduct = new List<Product>();
        public Order()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var connection = Configuration.Configuration.getInstance().getConnection();
            string query = "SELECT * FROM Product";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter DA = new SqlDataAdapter(command);
            DataTable DT = new DataTable();
            DA.Fill(DT);

            cmbxproduct.ItemsSource = DT.DefaultView;
            cmbxproduct.DisplayMemberPath = "Name";
            DataBind();
        }

        private void DataBind()
        {
            DGOrder.ItemsSource = null;
            DGOrder.ItemsSource = listProduct;


        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
