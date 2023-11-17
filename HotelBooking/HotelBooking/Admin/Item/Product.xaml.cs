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
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : UserControl
    {
        int id = 0;
        public Product()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var connection = Configuration.Configuration.getInstance().getConnection();
            string query = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter DA = new SqlDataAdapter(command);
            DataTable DT = new DataTable();
            DA.Fill(DT);

            cmbxCategory.ItemsSource = DT.DefaultView;
            cmbxCategory.DisplayMemberPath = "Name";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txtProduct.Text != "" && cmbxCategory.Text !="")
            {
                var connection = Configuration.Configuration.getInstance().getConnection();
                string query = $"INSERT INTO Item VALUES({id}, 0,'{txtProduct.Text}')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Product Added Successfully");
            }
            else
            {
                MessageBox.Show("Fill All Fields");

            }
        }

        private void cmbxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object[] data = ((DataRowView)e.AddedItems[0]).Row.ItemArray;
            id = int.Parse(data[0].ToString());
        }
    }
}
