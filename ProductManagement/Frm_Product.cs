using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagement
{
    public partial class Frm_Product : Form
    {
        public Frm_Product()
        {
            InitializeComponent();
            DisplayData();
        }

        private SqlConnection con;
        private SqlCommand cmd;

        SqlConnection sqlCon = new SqlConnection("Data Source=LAPTOP-C1548M6R\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True");
        SqlDataAdapter adapt;

        private void Frm_Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'productDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.productDataSet.Product);
            lbl_total.Text = $"Total records: {dataGridView1.RowCount}";

        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            Frm_Insert frm_I = new Frm_Insert();
            frm_I.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            frm_update_delete update_Delete = new frm_update_delete();
            update_Delete.tb_Id.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            update_Delete.tb_Name.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            update_Delete.tb_Price.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            update_Delete.Show();
        }

        private void DisplayData()
        {
            sqlCon.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM Product", sqlCon);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlCon.Close();
            lbl_total.Text = $"Total records: {dataGridView1.RowCount}";
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            DisplayData();
            tb_search.Text = null;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frm_update_delete update_Delete = new frm_update_delete();
            update_Delete.tb_Id.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            update_Delete.tb_Name.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            update_Delete.tb_Price.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            update_Delete.Show();
        }

        // Search
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection("Data Source=LAPTOP-C1548M6R\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True"))
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    using (DataTable dt = new DataTable("Product"))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE P_Name like @P_Name", sqlCon))
                        {
                            cmd.Parameters.AddWithValue("@P_Name", "%" + tb_search.Text + "%");
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                            lbl_total.Text = $"Total records: {dataGridView1.RowCount}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Product> prod = new List<Product>();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            Frm_Order frm = new Frm_Order();
            frm.Show();
        }
    }
}
