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
        // using for loop add prod into products oduct
        

        private void Frm_Order_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Product", "Data Source=LAPTOP-C1548M6R\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True");
            DataSet ds = new DataSet();
            da.Fill(ds, "Product");
            DataGridView dgv = new DataGridView();
            dgv.DataSource = ds.Tables["Product"].DefaultView;

            label1.Text = dgv.Rows[0].Cells[0].Value.ToString();
            
        }

        public Product prod;

        private void ReadingRow(){
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Product", "Data Source=LAPTOP-C1548M6R\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True");
            DataSet ds = new DataSet();
            da.Fill(ds, "Product");
            DataGridView dgv = new DataGridView();
            dgv.DataSource = ds.Tables["Product"].DefaultView;

            /* products.AddRange(new[] { 
                 new Product(Convert.ToInt32(dgv.CurrentRow.Cells[0].Value.ToString()),dgv.CurrentRow.Cells[1].Value.ToString(), Convert.ToDecimal(dgv.CurrentRow.Cells[2].Value.ToString()))
         }) */

            for (int i = 0; i < RowCount() ; i++)
            {
                prod.InsertProduct(Convert.ToInt32(dgv.Rows[i].Cells[0].Value), Convert.ToString(dgv.Rows[i].Cells[1].Value), Convert.ToDecimal(dgv.Rows[i].Cells[2].Value));
                products.Add(prod);
            }

            for (int i = 0; i < RowCount(); i++)
            {
                listBox1.Items.Add(products[i].productName);
            }
        }
    }
}