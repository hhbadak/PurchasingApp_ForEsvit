using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchasingApp
{
    public partial class DepartmentsForm : Form
    {
        DataModel dm = new DataModel();
        public DepartmentsForm()
        {
            InitializeComponent();
        }

        private void DepartmentsForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            // DataTable oluşturun
            DataTable dt = new DataTable();

            // Sütunları tanımlayın ve başlıkları belirleyin
            dt.Columns.Add("ID", typeof(int)); // Sütun adı ve türü
            dt.Columns.Add("Name", typeof(string)); // Bölüm Adı

            // Verileri DataTable'a ekleyin
            foreach (var department in dm.DepartmentList())
            {
                dt.Rows.Add(department.ID, department.Name);
            }

            // DataGridView'a DataTable'ı bağlayın
            dgv_departments.DataSource = dt;

            // DataGridView sütun başlıklarını güncelleme
            dgv_departments.Columns["ID"].HeaderText = "ID";
            dgv_departments.Columns["Name"].HeaderText = "Bölüm Adı";

            // Sütun genişliklerini otomatik ayarlama
            dgv_departments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Alternatif: Fill

            // Sütun genişliklerini yeniden hesaplama
            dgv_departments.AutoResizeColumns();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_name.Text.Trim()))
            {
                Departments model = new Departments();
                model.Name = tb_name.Text;
                model = dm.AddDepartment(model);
                if (model.ID != 0)
                {
                    MessageBox.Show($"Bölüm {model.ID} id ile başarıyla eklenmiştir", "Başarılı");
                    tb_name.Text = "";
                    dgv_departments.DataSource = dm.DepartmentList();
                }
                else
                {
                    MessageBox.Show("Bölüm Eklenirken bir hata oluştu", "Hata Oluştu");
                }
            }
            else
            {
                MessageBox.Show("İsim Boş Olamaz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
