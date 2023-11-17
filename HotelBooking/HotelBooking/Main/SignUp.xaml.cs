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
using HotelBooking.Configuration;

namespace HotelBooking.Main
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        public event EventHandler haveAnAccount;
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if(txtName.Text.Length > 0 && txtEmail.Text.Length > 0 && txtPassword.Text.Length > 0 && cmbxRole.Text!="")
            {
                var connection = Configuration.Configuration.getInstance().getConnection();
                string query = $"SELECT RoleId FROM Roles WHERE Name = '{cmbxRole.Text}'";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                query = "INSERT into SystemUsers(Name, Email, Password, DateAdded, isDeleted, RoleId )VALUES(@Name, @Email, @Password, @DateAdded, @isDeleted, @RoleId)";
                cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@isDeleted", 0);
                cmd.Parameters.AddWithValue("@RoleId",int.Parse(DT.Rows[0][0].ToString()));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully", "Alert!!!");
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbxRole.Items.Add("Admin");
            cmbxRole.Items.Add("Customer");
        }

        private void lblAccount_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            haveAnAccount?.Invoke(this, EventArgs.Empty);
        }
    }
}
