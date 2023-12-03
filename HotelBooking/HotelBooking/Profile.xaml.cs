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

namespace HotelBooking
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        string userId;
        public Profile(string userId)
        {
            this.userId = userId;
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "")
            {
                if (txtEmail.Text != "")
                {
                    if (txtPassword.Text != "")
                    {
                        if (txtConfirmPassword.Text != "")
                        {
                            if (txtConfirmPassword.Text != txtPassword.Text)
                            {
                                var connection = Configuration.Configuration.getInstance().getConnection();
                                string query = $"UPDATE SystemsUsers SET Name = '{txtName.Text}', Email = '{txtPassword.Text}', Password = '{txtPassword.Text}' WHERE UserId = '{userId}'";
                                SqlCommand command = new SqlCommand(query, connection);
                                command.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show("Password and Confirm Password do not match");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Confirm your Password");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Enter Password");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Email");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Name");
            }
        }
    }
}
