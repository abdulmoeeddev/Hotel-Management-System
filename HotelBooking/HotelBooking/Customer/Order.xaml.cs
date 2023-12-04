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
        List<BL.Product> listProduct = new List<BL.Product>();
        string userId;
        int productId;
        public Order(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var connection = Configuration.Configuration.getInstance().getConnection();
            string query = "SELECT * FROM Item";
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
            if(txtQuantity.Text.Length > 0 && cmbxproduct.Text != "")   
            { 
                BL.Product product = new BL.Product(productId,  cmbxproduct.Text, int.Parse(txtQuantity.Text));
                listProduct.Add(product);
                DataBind();
            }
        }

        private void DGOrder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DGOrder.SelectedIndex <= listProduct.Count)
                {
                    listProduct.RemoveAt(DGOrder.SelectedIndex);
                    DataBind();
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (listProduct.Count > 0)
            {
                var connection = Configuration.Configuration.getInstance().getConnection();
                string query = $" SELECT Room.RoomId FROM Room JOIN ReservationDetails ON ReservationDetails.RoomId = Room.RoomId JOIN Reservation ON Reservation.ReserveId = ReservationDetails.ReserveId WHERE UserId = {userId} AND isReserved = 1";
                SqlCommand command = new SqlCommand(query, connection);
                int roomId = (int)command.ExecuteScalar();

                query = $"INSERT INTO OrderDetails  (UserId, RoomId, OrderDate) VALUES ({userId}, {roomId}, '{DateTime.Now.Date}')";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                query = $"SELECT TOP 1 OrderId From OrderDetails ORDER BY OrderId DESC";
                command = new SqlCommand (query, connection);
                int orderId = (int)command.ExecuteScalar();

                foreach (BL.Product item in listProduct)
                { 
                    query = $"SELECT UnitPrice FROM Stock WHERE ProductId ={item.Id}";
                    command = new SqlCommand(query, connection);
                    double price = (double)command.ExecuteScalar();
                    if (price != 0)
                    {
                        query = $"INSERT INTO Orders VALUES ({orderId}, {item.Id}, {txtQuantity.Text}, {price})";
                        command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();

                        query = $"UPDATE Stock UnitInStock = UnitInStock - {txtQuantity.Text} WHERE ProductId = {item.Id}";

                    }
                    else
                        MessageBox.Show("No Stock Available for " + item.Name);
                }
                MessageBox.Show("Ordered Successfully");

            }
            else
                MessageBox.Show("No Item Added");


        }

        private void cmbxproduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object[] data = ((DataRowView)e.AddedItems[0]).Row.ItemArray;
            productId = int.Parse(data[0].ToString());
        }
    }
}
