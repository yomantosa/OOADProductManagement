using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagement
{
    public partial class Frm_Receipt : Form
    {
        public Frm_Receipt()
        {
            InitializeComponent();
        }

        public List<string> orderLst = new List<string>();
        public List<decimal> price = new List<decimal>();
        public List<int> qty = new List<int>();


        private void Frm_Receipt_Load(object sender, EventArgs e)
        {
            string shopName = "Shop1";
            string shopAddr = "Address Here";
            string shopCity = "PP";
            string shopTel = "0123456789";
            string dashLine = "----------------------------------------------------";
            var dateTime = DateTime.Now;
            string[] arr = null;
            decimal total = 0;

            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.Text += "\n" + shopName + "\n" + shopAddr + "\n" + shopCity +"\n" + shopTel +"\n" + dashLine + "\n" + dateTime.ToString("F") + "\n" + dashLine;
            
            foreach (var item in orderLst)
            {
                richTextBox1.Text += "\n" + item;
            }

            for (int i = 0; i < orderLst.Count; i++)
            {
                arr = orderLst[i].Split('\t');
                price.Add((Convert.ToDecimal(arr[2])));
                qty.Add(Convert.ToInt32(arr[3]));
                arr = null;
            }

            for (int i = 0; i < orderLst.Count; i++)
            {
                total += price[i] * qty[i];
            }

            richTextBox1.Text += "\n" + dashLine + "\n Total = " + total;
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Order order_frm = new Frm_Order();
            order_frm.Show();
            this.Hide();
        }
    }
}
