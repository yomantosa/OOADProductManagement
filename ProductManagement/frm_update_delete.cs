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
    public partial class frm_update_delete : Form
    {
        
        public frm_update_delete()
        {
            InitializeComponent();
        }

        private SqlConnection con;
        private SqlCommand cmd;

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=LAPTOP-C1548M6R\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True");
                cmd = new SqlCommand(@"update Product set ID=@ID, P_Name=@P_Name, P_Price=@P_Price",
                    con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", int.Parse(tb_Id.Text));
                cmd.Parameters.AddWithValue("@P_Name", tb_Name.Text);
                cmd.Parameters.AddWithValue("@P_Price", decimal.Parse(tb_Price.Text));
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Successfully Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=LAPTOP-C1548M6R\\SQLEXPRESS;Initial Catalog=Product;Integrated Security=True");
                cmd = new SqlCommand(@"delete Product where ID=@ID", con);
               
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", int.Parse(tb_Id.Text));
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
