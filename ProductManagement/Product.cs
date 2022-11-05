using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement
{
    public interface IProduct
    {
        void InsertProduct(int id, string name, decimal price);
    }
    public class Product:IProduct
    {
        public int ID;
        public string productName;
        public decimal productPrice;
        public int units = 0;
        public Product(int ID, string productName,decimal productPrice)
        {
            this.ID = ID;
            this.productName = productName;
            this.productPrice = productPrice;
        }

        public void InsertProduct(int id, string name, decimal price)
        {
            ID = id;
            productName = name;
            productPrice = price;
        }
    }
}
