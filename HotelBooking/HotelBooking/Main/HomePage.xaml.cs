using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var connection = Configuration.Configuration.getInstance().getConnection();
            string query = "SELECT * FROM Room JOIN RoomType ON Room.RoomTypeID = RoomType.ID";
            SqlCommand command = new SqlCommand(query,connection);
            SqlDataAdapter DA = new SqlDataAdapter(command);
            DataTable DT = new DataTable();
            DA.Fill(DT);

            lblDescription.Text = DT.Rows[0][5].ToString();
            lblDescription2.Text = DT.Rows[1][5].ToString();

            lblPrice.Text = "$" + DT.Rows[0][8].ToString();
            lblPrice2.Text ="$" + DT.Rows[1][8].ToString();

            lblType.Text = DT.Rows[0][7].ToString();
            lblType2.Text = DT.Rows[1][7].ToString();
        }

        private BitmapImage imgFromStream(byte[] bytes)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    stream.Position = 0;
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
    }
}
