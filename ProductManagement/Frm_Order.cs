using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProductManagement
{
    public partial class Frm_Order : Form
    {
        public Frm_Order()
        {
            InitializeComponent();
        }

        private SqlConnection productCon;
        private SqlConnection orderCon;
        private SqlCommand cmd;
        private List<Product> products = new List<Product>();
        private List<Product> tempProducts = new List<Product>();
        

        public int RowCount()
        {
            string stmt = @"SELECT COUNT(*) FROM Product";
            int count = 0;

            using (productCon = new SqlConnection("Data Source=LAPTOP-C1548M6R\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True"))
            {
                using (cmd = new SqlCommand(stmt, productCon))
                {
                    productCon.Open();
                    count = (int)cmd.ExecuteScalar();
                }
            }
            return count;
        }

        private void Frm_Order_Load(object sender, EventArgs e)
        {
            ReadingRow();
        }

        public void ReadingRow(){
            
            Product prod = null;//obj null
            using (productCon = new SqlConnection("Data Source=LAPTOP-C1548M6R\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True"))
            {
                cmd = new SqlCommand(@"select ID, P_Name, P_Price from Product", productCon);
                productCon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(prod = new Product(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToDecimal(reader[2])));
                }
                listBox1.Items.Clear();
                for (int i = 0; i < RowCount(); i++)
                {
                    listBox1.Items.Add(products[i].ID + "\t" + products[i].productName + "\t" + products[i].productPrice);
                }
            }
        }

        private void btn_addToCart_Click(object sender, EventArgs e)
        {
            string[] __temp = listBox1.SelectedItem.ToString().Split('\t');

            if (tempProducts.Count() == 0)
            {
                tempProducts.Add(new Product(Int32.Parse(__temp[0]), __temp[1], Convert.ToDecimal(__temp[2])));
                tempProducts[0].units = 1;
            }
            else
            {
                bool temp = true;
                for (int i = 0; i < tempProducts.Count(); i++)
                {
                    if (tempProducts[i].ID == Int32.Parse(__temp[0]))
                    {
                        tempProducts[i].units++;
                        temp = false;
                        break;
                    }
                }

                if (temp)
                {
                    tempProducts.Add(new Product(Int32.Parse(__temp[0]), __temp[1], Convert.ToDecimal(__temp[2])));
                    tempProducts[tempProducts.Count() - 1].units = 1;
                }
            }

            listBox2.Items.Clear();

            for (int i = 0; i < tempProducts.Count(); i++)
            {
                //itemtemp += tempProducts[i].ID + "\t" + tempProducts[i].productName + "\t" +
                //tempProducts[i].productPrice + "\t" + tempProducts[i].units + "\n";
                listBox2.Items.Add(tempProducts[i].ID + "\t" + tempProducts[i].productName + "\t" +
                    tempProducts[i].productPrice + "\t" + tempProducts[i].units);
            }
        }



        private void btn_checkout_Click(object sender, EventArgs e)
        {
            // Show new Reciept Form in Checkout Button
            Frm_Receipt frm = new Frm_Receipt();
            foreach (var item in listBox2.Items)
            {
                frm.orderLst.Add(item.ToString());
            }
            frm.Show();
            this.Hide();
        }
    }
}