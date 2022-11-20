
namespace ProductManagement
{
    partial class Frm_Order
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.productDataSet = new ProductManagement.ProductDataSet();
            this.btn_addToCart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_checkout = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(27, 74);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(240, 277);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.productDataSet;
            this.bindingSource1.Position = 0;
            // 
            // productDataSet
            // 
            this.productDataSet.DataSetName = "ProductDataSet";
            this.productDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_addToCart
            // 
            this.btn_addToCart.Location = new System.Drawing.Point(629, 357);
            this.btn_addToCart.Name = "btn_addToCart";
            this.btn_addToCart.Size = new System.Drawing.Size(75, 23);
            this.btn_addToCart.TabIndex = 3;
            this.btn_addToCart.Text = "Add to Cart";
            this.btn_addToCart.UseVisualStyleBackColor = true;
            this.btn_addToCart.Click += new System.EventHandler(this.btn_addToCart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(528, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cart";
            // 
            // btn_checkout
            // 
            this.btn_checkout.Location = new System.Drawing.Point(710, 357);
            this.btn_checkout.Name = "btn_checkout";
            this.btn_checkout.Size = new System.Drawing.Size(75, 23);
            this.btn_checkout.TabIndex = 6;
            this.btn_checkout.Text = "Checkout";
            this.btn_checkout.UseVisualStyleBackColor = true;
            this.btn_checkout.Click += new System.EventHandler(this.btn_checkout_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(319, 74);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(466, 277);
            this.listBox2.TabIndex = 7;
            // 
            // Frm_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 413);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.btn_checkout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_addToCart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "Frm_Order";
            this.Text = "Frm_Order";
            this.Load += new System.EventHandler(this.Frm_Order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private ProductDataSet productDataSet;
        private System.Windows.Forms.Button btn_addToCart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_checkout;
        public System.Windows.Forms.ListBox listBox2;
    }
}