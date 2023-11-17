using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelBooking.Configuration
{
    public class Configuration
    {
        private static Configuration instance;
        SqlConnection connect;
        private string dataSource = "(local)";
        private string initialCatalog = "hotel";
        private string security = "True";

        public string DataSource { get => dataSource; set => dataSource = value; }
        public string InitialCatalog { get => initialCatalog; set => initialCatalog = value; }
        public string Security { get => security; set => security = value; }

        public Configuration()
        {
            string connectString = "Data Source = " + dataSource + "; Initial Catalog = " + initialCatalog + "; Integrated Security = " + security + ";";
            connect = new SqlConnection(connectString);
            connect.Open();
        }
        public static Configuration getInstance()
        {
            if (instance == null)
                instance = new Configuration();
            return instance;
        }
        public SqlConnection getConnection()
        {
            return connect;
        }
    }
}
