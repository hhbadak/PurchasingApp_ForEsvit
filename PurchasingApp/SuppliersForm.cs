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
    public partial class SuppliersForm : Form
    {
        DataModel dm = new DataModel();
        public SuppliersForm()
        {
            InitializeComponent();
        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            // DataTable oluşturun
            DataTable dt = new DataTable();

            // Sütunları tanımlayın ve başlıkları belirleyin
            dt.Columns.Add("ID", typeof(int)); // Sütun adı ve türü
            dt.Columns.Add("Name", typeof(string)); // Tedarikçi Adı

            // Verileri DataTable'a ekleyin
            foreach (var supplier in dm.SupplierList())
            {
                dt.Rows.Add(supplier.ID, supplier.Name);
            }

            // DataGridView'a DataTable'ı bağlayın
            dgv_suppliers.DataSource = dt;

            // DataGridView sütun başlıklarını güncelleme
            dgv_suppliers.Columns["ID"].HeaderText = "ID";
            dgv_suppliers.Columns["Name"].HeaderText = "Tedarikçi Adı";

            // Sütun genişliklerini otomatik ayarlama
            dgv_suppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Alternatif: Fill

            // Sütun genişliklerini yeniden hesaplama
            dgv_suppliers.AutoResizeColumns();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_name.Text.Trim()))
            {
                Suppliers model = new Suppliers();
                model.Name = tb_name.Text;
                model = dm.AddSupplier(model);
                if (model.ID != 0)
                {
                    MessageBox.Show($"Tedarikçi {model.ID} id ile başarıyla eklenmiştir", "Başarılı");
                    tb_name.Text = "";
                    dgv_suppliers.DataSource = dm.SupplierList();
                }
                else
                {
                    MessageBox.Show("Tedarikçi Eklenirken bir hata oluştu", "Hata Oluştu");
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
