namespace PurchasingApp
{
    partial class SuppliersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuppliersForm));
            this.gb_suppliers = new System.Windows.Forms.GroupBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.dgv_suppliers = new System.Windows.Forms.DataGridView();
            this.gb_suppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_suppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_suppliers
            // 
            this.gb_suppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_suppliers.Controls.Add(this.btn_create);
            this.gb_suppliers.Controls.Add(this.label1);
            this.gb_suppliers.Controls.Add(this.tb_name);
            this.gb_suppliers.Location = new System.Drawing.Point(16, 15);
            this.gb_suppliers.Margin = new System.Windows.Forms.Padding(4);
            this.gb_suppliers.Name = "gb_suppliers";
            this.gb_suppliers.Padding = new System.Windows.Forms.Padding(4);
            this.gb_suppliers.Size = new System.Drawing.Size(485, 128);
            this.gb_suppliers.TabIndex = 1;
            this.gb_suppliers.TabStop = false;
            this.gb_suppliers.Text = "Kategori İşlemleri";
            // 
            // btn_create
            // 
            this.btn_create.BackColor = System.Drawing.Color.Black;
            this.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_create.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_create.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_create.Location = new System.Drawing.Point(377, 76);
            this.btn_create.Margin = new System.Windows.Forms.Padding(4);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(100, 44);
            this.btn_create.TabIndex = 2;
            this.btn_create.Text = "EKLE";
            this.btn_create.UseVisualStyleBackColor = false;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(108, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "TEDARİKÇİ ADI";
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_name.Location = new System.Drawing.Point(8, 76);
            this.tb_name.Margin = new System.Windows.Forms.Padding(4);
            this.tb_name.Multiline = true;
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(360, 43);
            this.tb_name.TabIndex = 0;
            this.tb_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_name_KeyDown);
            // 
            // dgv_suppliers
            // 
            this.dgv_suppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_suppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_suppliers.Location = new System.Drawing.Point(4, 144);
            this.dgv_suppliers.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_suppliers.Name = "dgv_suppliers";
            this.dgv_suppliers.RowHeadersWidth = 51;
            this.dgv_suppliers.Size = new System.Drawing.Size(1061, 409);
            this.dgv_suppliers.TabIndex = 2;
            // 
            // SuppliersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dgv_suppliers);
            this.Controls.Add(this.gb_suppliers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SuppliersForm";
            this.Text = "TEDARİKÇİ SAYFASI";
            this.Load += new System.EventHandler(this.SuppliersForm_Load);
            this.gb_suppliers.ResumeLayout(false);
            this.gb_suppliers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_suppliers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_suppliers;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.DataGridView dgv_suppliers;
    }
}