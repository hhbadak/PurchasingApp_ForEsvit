namespace PurchasingApp
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_category = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_departments = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_suppliers = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_IncomingProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_category,
            this.TSMI_departments,
            this.TSMI_suppliers,
            this.TSMI_IncomingProducts});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // TSMI_category
            // 
            this.TSMI_category.Name = "TSMI_category";
            this.TSMI_category.Size = new System.Drawing.Size(165, 26);
            this.TSMI_category.Text = "Kategori";
            this.TSMI_category.Click += new System.EventHandler(this.TSMI_category_Click);
            // 
            // TSMI_departments
            // 
            this.TSMI_departments.Name = "TSMI_departments";
            this.TSMI_departments.Size = new System.Drawing.Size(165, 26);
            this.TSMI_departments.Text = "Bölüm";
            this.TSMI_departments.Click += new System.EventHandler(this.TSMI_departments_Click);
            // 
            // TSMI_suppliers
            // 
            this.TSMI_suppliers.Name = "TSMI_suppliers";
            this.TSMI_suppliers.Size = new System.Drawing.Size(165, 26);
            this.TSMI_suppliers.Text = "Tedarikçi";
            this.TSMI_suppliers.Click += new System.EventHandler(this.TSMI_suppliers_Click);
            // 
            // TSMI_IncomingProducts
            // 
            this.TSMI_IncomingProducts.Name = "TSMI_IncomingProducts";
            this.TSMI_IncomingProducts.Size = new System.Drawing.Size(165, 26);
            this.TSMI_IncomingProducts.Text = "Gelen Ürün";
            this.TSMI_IncomingProducts.Click += new System.EventHandler(this.TSMI_IncomingProducts_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 553);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Home";
            this.Text = "SATINALMA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_category;
        private System.Windows.Forms.ToolStripMenuItem TSMI_departments;
        private System.Windows.Forms.ToolStripMenuItem TSMI_suppliers;
        private System.Windows.Forms.ToolStripMenuItem TSMI_IncomingProducts;
    }
}