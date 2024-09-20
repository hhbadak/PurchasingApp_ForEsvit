namespace PurchasingApp
{
    partial class DepartmentsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentsForm));
            this.gb_departments = new System.Windows.Forms.GroupBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.dgv_departments = new System.Windows.Forms.DataGridView();
            this.gb_departments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_departments)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_departments
            // 
            this.gb_departments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_departments.Controls.Add(this.btn_create);
            this.gb_departments.Controls.Add(this.label1);
            this.gb_departments.Controls.Add(this.tb_name);
            this.gb_departments.Location = new System.Drawing.Point(16, 15);
            this.gb_departments.Margin = new System.Windows.Forms.Padding(4);
            this.gb_departments.Name = "gb_departments";
            this.gb_departments.Padding = new System.Windows.Forms.Padding(4);
            this.gb_departments.Size = new System.Drawing.Size(485, 128);
            this.gb_departments.TabIndex = 1;
            this.gb_departments.TabStop = false;
            this.gb_departments.Text = "Bölüm İşlemleri";
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
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "BÖLÜM ADI";
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
            // 
            // dgv_departments
            // 
            this.dgv_departments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_departments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_departments.Location = new System.Drawing.Point(1, 151);
            this.dgv_departments.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_departments.Name = "dgv_departments";
            this.dgv_departments.RowHeadersWidth = 51;
            this.dgv_departments.Size = new System.Drawing.Size(1064, 401);
            this.dgv_departments.TabIndex = 2;
            // 
            // DepartmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dgv_departments);
            this.Controls.Add(this.gb_departments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DepartmentsForm";
            this.Text = "Bölümler Sayfası";
            this.Load += new System.EventHandler(this.DepartmentsForm_Load);
            this.gb_departments.ResumeLayout(false);
            this.gb_departments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_departments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_departments;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.DataGridView dgv_departments;
    }
}