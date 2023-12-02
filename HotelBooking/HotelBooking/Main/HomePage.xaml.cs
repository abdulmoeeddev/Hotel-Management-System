using HotelBooking.Reservation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        int carousel1 = 0;
        int carousel2 = 1;
        DataTable DT;
        string userID = null;
        public event EventHandler openReservePage;
        public event EventHandler openLoginPage;
        public HomePage()
        {
            InitializeComponent();
        }
        public HomePage(string userID)
        {
            this.userID = userID;
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var connection = Configuration.Configuration.getInstance().getConnection();
            string query = "SELECT * FROM Room JOIN RoomType ON Room.RoomTypeID = RoomType.ID ORDER BY RoomNumber";
            SqlCommand command = new SqlCommand(query,connection);
            SqlDataAdapter DA = new SqlDataAdapter(command);
            DT = new DataTable();
            DA.Fill(DT);
            UpdateCarousel();
            
        }

        private void UpdateCarousel()
        {
            if (carousel1 <= DT.Rows.Count)
            {
                //byte[] byteArray = (byte[])(DT.Rows[carousel1][4]);
                //BitmapImage img = imgFromStream(byteArray);
                //img1.Source = img;
                img1.Source = new BitmapImage(new Uri(@"download (1).jpg", UriKind.Relative));
                lblDescription.Text = DT.Rows[carousel1][5].ToString();
                lblPrice.Text = "$" + DT.Rows[carousel1][8].ToString();
                lblType.Text = DT.Rows[carousel1][7].ToString();

                if(carousel2 < DT.Rows.Count)
                {
                    img2.Source = new BitmapImage(new Uri(@"/Main/download.jpg", UriKind.Relative));
                    lblPrice2.Text = "$" + DT.Rows[carousel2][8].ToString();
                    lblDescription2.Text = DT.Rows[carousel2][5].ToString();
                    lblType2.Text = DT.Rows[carousel2][7].ToString();
                    btnReserve_1.Visibility = Visibility.Visible;
                }
                else
                {
                    img2.Source = null;
                    lblPrice2.Text = "";
                    lblDescription2.Text = " ";
                    lblType2.Text = "";
                    btnReserve_1.Visibility = Visibility.Hidden;
                }
            }
        }

        private BitmapImage imgFromStream(byte[] bytes)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    return bitmapImage;
                }
            }
            catch (Exception ex)
            {
                // Handle exception, e.g., log or display an error message
                MessageBox.Show("Error converting byte array to image: " + ex.Message);
                return null;
            }

        }

        private void btnleft_Click(object sender, RoutedEventArgs e)
        {
            if(carousel1-1 >=0)
            {
                carousel1 = (carousel1-1);
                carousel2 = (carousel2-1);
                UpdateCarousel();
            }

        }

        private void btnright_Click(object sender, RoutedEventArgs e)
        {
            if (carousel1 + 1 < DT.Rows.Count)
            {
                carousel1 = (carousel1 + 1);
                carousel2 = (carousel2 + 1);
                UpdateCarousel();
            }
        }

        private void btnReserve_0_Click(object sender, RoutedEventArgs e)
        {
            if(userID != null)
            {
                string roomID = DT.Rows[carousel1][0].ToString();
                List<string> objects = new List<string>() { userID, roomID};
                openReservePage?.Invoke(objects, EventArgs.Empty);
            }
            else
            {
                openLoginPage?.Invoke(null, EventArgs.Empty);
            }
        }
    }
}
