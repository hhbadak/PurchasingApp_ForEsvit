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
    public partial class Categories : Form
    {
        DataModel dm = new DataModel();
        public Categories()
        {
            InitializeComponent();
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            // DataTable oluşturun
            DataTable dt = new DataTable();

            // Sütunları tanımlayın ve başlıkları belirleyin
            dt.Columns.Add("ID", typeof(int)); // Sütun adı ve türü
            dt.Columns.Add("Name", typeof(string)); // Kategori Adı

            // Verileri DataTable'a ekleyin
            foreach (var category in dm.GetCategories())
            {
                dt.Rows.Add(category.ID, category.Name);
            }

            // DataGridView'a DataTable'ı bağlayın
            dgv_categoryList.DataSource = dt;

            // DataGridView sütun başlıklarını güncelleme
            dgv_categoryList.Columns["ID"].HeaderText = "ID";
            dgv_categoryList.Columns["Name"].HeaderText = "Kategori Adı";

            // Sütun genişliklerini otomatik ayarlama
            dgv_categoryList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Alternatif: Fill

            // Sütun genişliklerini yeniden hesaplama
            dgv_categoryList.AutoResizeColumns();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_name.Text.Trim()))
            {
                DataAccessLayer.Categories model = new DataAccessLayer.Categories();
                model.Name = tb_name.Text;
                model = dm.AddCategory(model);
                if (model.ID != 0)
                {
                    MessageBox.Show($"kategori {model.ID} id ile başarıyla eklenmiştir", "Başarılı");
                    tb_name.Text = "";
                    dgv_categoryList.DataSource = dm.GetCategories();
                }
                else
                {
                    MessageBox.Show("kategori Eklenirken bir hata oluştu", "Hata Oluştu");
                }
            }
            else
            {
                MessageBox.Show("İsim Boş Olamaz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_create.PerformClick();  // btn_create butonunun tıklanma olayını tetikler
                e.SuppressKeyPress = true;  // Enter tuşunun formda başka bir işlem yapmasını engeller
            }
        }
    }
}
