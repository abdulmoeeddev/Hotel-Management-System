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

namespace HotelBooking.Main
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public event EventHandler createNewAccount;
        public event EventHandler openAdminDashboard;
        public Login()
        {
            InitializeComponent();
        }

        private void lblCreate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            createNewAccount?.Invoke(this, e);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(txtName.Text != "" && txtPassword.Text!="")
            {
                var connection = Configuration.Configuration.getInstance().getConnection();
                string query = $"SELECT * FROM SystemUsers WHERE Name = '{txtName.Text}' AND Password = '{txtPassword.Text}'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter DA = new SqlDataAdapter(command);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                if(DT.Rows.Count != 0)
                {
                    MessageBox.Show("Logged In Successfully"+ DT.Rows[0][6].ToString());

                    if (DT.Rows[0][6].ToString() == "1")
                    {
                        openAdminDashboard?.Invoke(this, e);
                    }
                }
                else
                {
                    MessageBox.Show("No such User Exist");
                }
            }
            else
            {
                MessageBox.Show("Fill All Fields Properly");
            }
        }
    }
}
