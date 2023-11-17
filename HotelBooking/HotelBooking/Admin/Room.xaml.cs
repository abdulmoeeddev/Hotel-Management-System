using Microsoft.Win32;
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
using System.Xml.Linq;

namespace HotelBooking.Admin
{
    /// <summary>
    /// Interaction logic for Room.xaml
    /// </summary>
    /// 
    public partial class Room : UserControl
    {
        byte[] image;
        int id = 0;
        public Room()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var connection = Configuration.Configuration.getInstance().getConnection();
            string query = "SELECT * FROM RoomType";
            SqlCommand command = new SqlCommand(query,connection);
            SqlDataAdapter DA = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            DA.Fill(dataTable);

            cmbxRoomType.ItemsSource = dataTable.DefaultView;
            cmbxRoomType.DisplayMemberPath = "type";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtRoomDesc.Text != "" && txtRoomNumber.Text != "" && txtSecurity.Text != "" && cmbxRoomType.Text != "")
            {
                var connection = Configuration.Configuration.getInstance().getConnection();
                string query = $"INSERT INTO Room VALUES('{id}', '{txtSecurity.Text}', {int.Parse(txtRoomNumber.Text)}, '{image}', '{txtRoomDesc.Text}')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Room Added Successfully");
            }
            else
            {
                MessageBox.Show("Add All Fields");
            }
        }

        private void cmbxRoomType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object[] data = ((DataRowView)e.AddedItems[0]).Row.ItemArray;
            id = int.Parse(data[0].ToString());
        }

        private byte[] UploadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage image = new BitmapImage(new Uri(openFileDialog.FileName));
                    btnUpload.Content = openFileDialog.FileName;
                    byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);
                    return imageData;
                }
                catch(Exception exp) {
                    MessageBox.Show(exp.Message);
                }
            }
            return null;
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            image = UploadImage();
            MessageBox.Show(image.ToString());
        }
        private BitmapImage imgFromStream(byte[] bytes)
        {
            try
            {
                BitmapImage image = new BitmapImage();
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    stream.Position = 0;
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                }

                return image;
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
