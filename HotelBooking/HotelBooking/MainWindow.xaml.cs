using HotelBooking.Admin;
using HotelBooking.Main;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            mainPanel.Content = homePage;
            //SignUp signUp = new SignUp();
            //signUp.haveAnAccount += new EventHandler(onHaveAnAccountClicked);
            //mainPanel.Content = signUp;
        }

        private void onHaveAnAccountClicked(object sender, EventArgs e)
        {
            Login login = new Login();
            login.createNewAccount += new EventHandler(createNewAccount);
            login.openAdminDashboard += new EventHandler(openAdminDashBoard);
            mainPanel.Content = login;
        }

        private void openAdminDashBoard(object sender, EventArgs e)
        {
            AdminDashBoard adminDashBoard = new AdminDashBoard();
            mainPanel.Content = adminDashBoard;
        }

        private void createNewAccount(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.haveAnAccount += new EventHandler(onHaveAnAccountClicked);
            mainPanel.Content = signUp;
        }
    }
}
