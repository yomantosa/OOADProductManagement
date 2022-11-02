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
    public partial class Frm_Insert : Form
    {
        public Frm_Insert()
        {
            InitializeComponent();
        }

        private SqlConnection con;
        private SqlCommand cmd;

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=LAPTOP-C1548M6R\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True");
                cmd = new SqlCommand(@"insert into Product (ID,P_Name,P_Price)VALUES(@ID,@P_Name,@P_Price)",
                    con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", int.Parse(tb_Id.Text));
                cmd.Parameters.AddWithValue("@P_Name", tb_Name.Text);
                cmd.Parameters.AddWithValue("@P_Price", decimal.Parse(tb_Price.Text));
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
