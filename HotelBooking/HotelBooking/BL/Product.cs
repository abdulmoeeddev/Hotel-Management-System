using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.BL
{
    public class Product
    {
        private string _name;
        private int _quantity;

        public Product(string name, int quantity)
        {
            _name = name;
            _quantity = quantity;
        }

        public string Name { get => _name; set => _name = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
    }
}
