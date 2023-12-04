using HotelBooking.Admin;
using HotelBooking.Customer;
using HotelBooking.Main;
using HotelBooking.Reservation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string userId = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.openLoginPage += new EventHandler(onHaveAnAccountClicked);
            homePage.openReservePage += new EventHandler(openReservePage);
            homePage.openDashBoard += new EventHandler(openDashBoard);
            mainPanel.Content = homePage;
            //SignUp signUp = new SignUp();
            //signUp.haveAnAccount += new EventHandler(onHaveAnAccountClicked);
            //mainPanel.Content = signUp;
            
        }

        private void openDashBoard(object sender, EventArgs e)
        {
            

        }

        private void openReservePage(object sender, EventArgs e)
        {
            List<string> obj = (List<string>)sender;
            Reserve reserve = new Reserve(obj[0], obj[1]);
            reserve.openHomePage += new EventHandler(openHomePage);
            mainPanel.Content = reserve;
        }

        private void onHaveAnAccountClicked(object sender, EventArgs e)
        {
            Login login = new Login();
            login.createNewAccount += new EventHandler(createNewAccount);
            login.openAdminDashboard += new EventHandler(openAdminDashBoard);
            login.openHomePage += new EventHandler(openHomePage);
            mainPanel.Content = login;
        }

        private void openHomePage(object sender, EventArgs e)
        {
            userId = ((string)sender);
            HomePage homePage = new HomePage((string)sender);
            homePage.openLoginPage += new EventHandler(onHaveAnAccountClicked);
            homePage.openReservePage += new EventHandler(openReservePage);
            btnlogout.Visibility = Visibility.Visible;
            mainPanel.Content = homePage;
        }

        private void openAdminDashBoard(object sender, EventArgs e)
        {
            AdminDashBoard adminDashBoard = new AdminDashBoard(userId);
            mainPanel.Content = adminDashBoard;
        }

        private void createNewAccount(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.haveAnAccount += new EventHandler(onHaveAnAccountClicked);
            mainPanel.Content = signUp;
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            if (userId == null)
            {
                Login login = new Login();
                login.createNewAccount += new EventHandler(createNewAccount);
                login.openAdminDashboard += new EventHandler(openAdminDashBoard);
                login.openHomePage += new EventHandler(openHomePage);
                mainPanel.Content = login;
            }
            else
            {
                var connection = Configuration.Configuration.getInstance().getConnection();
                string query = $"SELECT RoleId FROM SystemUsers WHERE UserId = {userId}";
                SqlCommand command = new SqlCommand(query, connection);
                string roleId = command.ExecuteScalar().ToString();

                if (roleId == "1")
                {
                    AdminDashBoard admin = new AdminDashBoard(userId);
                    mainPanel.Content = admin;
                }
                else
                {
                    CustomerDashboard customer = new CustomerDashboard(userId);
                    mainPanel.Content = customer;
                }
            }
        }

        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to logout?", "Logging Out", (MessageBoxButtons)MessageBoxButton.YesNo);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                userId = null;
                btnlogout.Visibility = Visibility.Hidden;
                mainPanel.Content = new HomePage();
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HomePage homePage;
            if(userId != null)
                homePage = new HomePage(userId);
            else
                homePage = new HomePage();

            homePage.openLoginPage += new EventHandler(onHaveAnAccountClicked);
            homePage.openReservePage += new EventHandler(openReservePage);
            mainPanel.Content = homePage;
        }
    }
}
