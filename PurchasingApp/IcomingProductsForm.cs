using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchasingApp
{
    public partial class IcomingProductsForm : Form
    {
        DataModel dm = new DataModel();
        public IcomingProductsForm()
        {
            InitializeComponent();
        }

        private void IcomingProductsForm_Load(object sender, EventArgs e)
        {
            LoadGrid();

            // Kategoriler için listeyi al
            List<DataAccessLayer.Categories> categories = dm.GetCategories();

            // "Seçiniz" seçeneğini listeye ekle
            categories.Insert(0, new DataAccessLayer.Categories { ID = 0, Name = "Seçiniz" });

            cb_categories.ValueMember = "ID";
            cb_categories.DisplayMember = "Name";
            cb_categories.DataSource = categories;

            // Departmanlar için aynı şekilde
            List<DataAccessLayer.Departments> departments = dm.DepartmentList();
            departments.Insert(0, new DataAccessLayer.Departments { ID = 0, Name = "Seçiniz" });

            cb_department.ValueMember = "ID";
            cb_department.DisplayMember = "Name";
            cb_department.DataSource = departments;

            // Döviz için aynı şekilde
            List<DataAccessLayer.ExchangeRate> exchange = dm.ExchangeList();
            exchange.Insert(0, new DataAccessLayer.ExchangeRate { ID = 0, Name = "Seçiniz" });

            cb_exchange.ValueMember = "ID";
            cb_exchange.DisplayMember = "Name";
            cb_exchange.DataSource = exchange;

            // Malzeme Tanımı için aynı şekilde
            List<DataAccessLayer.Materials> material = dm.MaterialList();

            cb_material.ValueMember = "ID";
            cb_material.DisplayMember = "Name";
            cb_material.DataSource = material;

            // Tedarikçiler için de aynı şekilde
            List<DataAccessLayer.Suppliers> suppliers = dm.SupplierList();
            suppliers.Insert(0, new DataAccessLayer.Suppliers { ID = 0, Name = "Seçiniz" });

            cb_suppliers.ValueMember = "ID";
            cb_suppliers.DisplayMember = "Name";
            cb_suppliers.DataSource = suppliers;

            // Kategoriler için listeyi al
            List<DataAccessLayer.Categories> category = dm.GetCategories();

            // "Seçiniz" seçeneğini listeye ekle
            category.Insert(0, new DataAccessLayer.Categories { ID = 0, Name = "Seçiniz" });

            cb_searchCategory.ValueMember = "ID";
            cb_searchCategory.DisplayMember = "Name";
            cb_searchCategory.DataSource = category;

            // Departmanlar için aynı şekilde
            List<DataAccessLayer.Departments> department = dm.DepartmentList();
            department.Insert(0, new DataAccessLayer.Departments { ID = 0, Name = "Seçiniz" });

            cb_searchDepartment.ValueMember = "ID";
            cb_searchDepartment.DisplayMember = "Name";
            cb_searchDepartment.DataSource = department;

            // Tedarikçiler için de aynı şekilde
            List<DataAccessLayer.Suppliers> supplier = dm.SupplierList();
            supplier.Insert(0, new DataAccessLayer.Suppliers { ID = 0, Name = "Seçiniz" });

            cb_searchSupplier.ValueMember = "ID";
            cb_searchSupplier.DisplayMember = "Name";
            cb_searchSupplier.DataSource = supplier;

        }
        private void LoadGrid()
        {
            // DataTable oluşturun
            DataTable dt = new DataTable();

            // Sütunları tanımlayın ve başlıkları belirleyin
            dt.Columns.Add("ID", typeof(int)); // Sütun adı ve türü
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("MaterialDescription", typeof(string));
            dt.Columns.Add("Quantity", typeof(decimal));
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("ExchangeRate", typeof(string));
            dt.Columns.Add("TurkishLiraEquivalent", typeof(decimal));
            dt.Columns.Add("Department", typeof(string));
            dt.Columns.Add("Supplier", typeof(string));

            // Verileri DataTable'a ekleyin
            foreach (var product in dm.IncomingProductList())
            {
                dt.Rows.Add(product.ID, product.Date, product.Category, product.MaterialDescription, product.Quantity, product.UnitPrice, product.Total, product.ExchangeRate, product.TurkishLiraEquivalent, product.Department, product.Supplier);
            }

            // DataGridView'a DataTable'ı bağlayın
            dgv_productList.DataSource = dt;

            // DataGridView sütun başlıklarını Türkçe karakterlerle güncelleme
            dgv_productList.Columns["ID"].HeaderText = "ID";
            dgv_productList.Columns["Date"].HeaderText = "Tarih";
            dgv_productList.Columns["Category"].HeaderText = "Kategori";
            dgv_productList.Columns["MaterialDescription"].HeaderText = "Malzeme Açıklaması";
            dgv_productList.Columns["Quantity"].HeaderText = "Miktar";
            dgv_productList.Columns["UnitPrice"].HeaderText = "Birim Fiyat";
            dgv_productList.Columns["Total"].HeaderText = "Toplam";
            dgv_productList.Columns["ExchangeRate"].HeaderText = "Döviz";
            dgv_productList.Columns["TurkishLiraEquivalent"].HeaderText = "₺ Karşılığı";
            dgv_productList.Columns["Department"].HeaderText = "Departman";
            dgv_productList.Columns["Supplier"].HeaderText = "Tedarikçi";

            // Tarih sütununun formatını ayarlama
            dgv_productList.Columns["Date"].DefaultCellStyle.Format = "d"; // Kısa tarih formatı

            // Sütun genişliklerini otomatik ayarlama
            dgv_productList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Alternatif: Fill

            // Sütun genişliklerini yeniden hesaplama
            dgv_productList.AutoResizeColumns();
        }
        private async void btn_create_Click(object sender, EventArgs e)
        {
            // Malzeme açıklaması eklemek için önce kontrol edelim
            int? materialID = null;
            if (cb_material.SelectedIndex == -1 && !string.IsNullOrEmpty(cb_material.Text))
            {
                // Manuel olarak girilen malzeme açıklamasını ekleyelim
                string newMaterialDescription = cb_material.Text;
                materialID = dm.AddMaterial(newMaterialDescription);

                if (materialID.HasValue)
                {
                    MessageBox.Show("Yeni malzeme açıklaması başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cb_material.SelectedValue = materialID.Value; // Yeni malzeme açıklamasını seçili yap
                }
                else
                {
                    MessageBox.Show("Yeni malzeme açıklaması eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Hata varsa işlemi sonlandır
                }
            }
            else if (cb_material.SelectedIndex >= 0)
            {
                // Seçili malzeme açıklaması varsa
                materialID = Convert.ToInt32(cb_material.SelectedValue);
            }

            // Döviz kuru bilgilerini al
            decimal exchangeRate = 1; // Varsayılan değer
            int exchangeRateID = 0; // Döviz kuru ID için değişken
            bool isTurkishLira = true; // Varsayılan olarak Türk Lirası
            if (cb_exchange.SelectedIndex > 0) // Türk Lirası dışındaki seçimlerde geçerli olacak
            {
                exchangeRateID = Convert.ToInt32(cb_exchange.SelectedValue); // Döviz kuru ID'sini al
                string selectedCurrency = cb_exchange.Text;
                if (selectedCurrency != "Türk Lirası")
                {
                    // Asenkron döviz kuru çağrısı
                    exchangeRate = await dm.GetExchangeRateAsync(GetCurrencyCode(selectedCurrency));
                    isTurkishLira = false; // Seçili döviz Türk Lirası değil
                }
            }

            // Kültür bilgisi oluştur
            var cultureInfo = new System.Globalization.CultureInfo("tr-TR"); // Türk kültür bilgisi

            // Miktar ve birim fiyatı döviz kuru ve kültür ayarlarına göre dönüştür
            decimal quantity = string.IsNullOrEmpty(tb_quantity.Text) ? 0 : Convert.ToDecimal(tb_quantity.Text, cultureInfo);
            decimal unitPrice = string.IsNullOrEmpty(tb_unitPrice.Text) ? 0 : Convert.ToDecimal(tb_unitPrice.Text, cultureInfo);

            // Toplam hesaplama
            decimal total = quantity * unitPrice;

            // Türk Lirası veya döviz seçimine göre karşılık hesaplama
            decimal turkishLiraEquivalent = isTurkishLira
                ? total // Türk Lirası seçili ise, TL karşılığı toplam değeri olduğu gibi kullan
                : total * exchangeRate / 10000; // Diğer dövizler için hesapla

            // IncomingProducts modeli oluştur
            IncomingProducts incomingProduct = new IncomingProducts
            {
                Date = dtp_date.Value, // Tarih alanı DateTime türünde
                CategoryID = cb_categories.SelectedIndex > 0 ? Convert.ToInt32(cb_categories.SelectedValue) : 0, // ComboBox seçili kategori ID'si
                MaterialDescriptionID = materialID.HasValue ? materialID.Value : 0, // Malzeme açıklaması ID
                Quantity = quantity, // Miktar
                UnitPrice = unitPrice, // Birim fiyat
                Total = total, // Toplam (Miktar * Birim Fiyat)
                TurkishLiraEquivalent = turkishLiraEquivalent, // TL karşılığı
                DepartmentID = cb_department.SelectedIndex > 0 ? Convert.ToInt32(cb_department.SelectedValue) : 0, // Seçili departman ID'si
                SupplierID = cb_suppliers.SelectedIndex > 0 ? Convert.ToInt32(cb_suppliers.SelectedValue) : 0, // Seçili tedarikçi ID'si
                ExchangeRateID = exchangeRateID // Döviz kuru ID'si eklendi
            };

            // Verileri veritabanına ekle
            IncomingProducts addedProduct = dm.AddIncomingProduct(incomingProduct);

            if (addedProduct != null)
            {
                MessageBox.Show("Ürün başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cb_categories.SelectedIndex = cb_department.SelectedIndex = cb_suppliers.SelectedIndex = 0;
                cb_material.SelectedIndex = -1; // Seçili malzeme açıklaması yok
                tb_quantity.Text = tb_unitPrice.Text = "";
                cb_material.Text = ""; // Manuel malzeme açıklamasını temizle
                dtp_date.Value = DateTime.Now;
                LoadGrid();
            }
            else
            {
                MessageBox.Show("Ürün ekleme işlemi sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Para birimi kodunu almak için yardımcı metod
        private string GetCurrencyCode(string currencyName)
        {
            switch (currencyName)
            {
                case "Türk Lirası":
                    return "TRY";
                case "ABD Doları":
                    return "USD";
                case "Euro":
                    return "EUR";
                default:
                    return "";
            }
        }
        private void btn_get_Click(object sender, EventArgs e)
        {
            DateTime? searchDate = cbx_searchDate.Checked ? (DateTime?)dtp_searchDate.Value.Date : null;
            int? categoryId = cbx_searchCategory.Checked && cb_searchCategory.SelectedIndex > 0 ? (int?)cb_searchCategory.SelectedValue : null;
            int? supplierId = cbx_searchSupplier.Checked && cb_searchSupplier.SelectedIndex > 0 ? (int?)cb_searchSupplier.SelectedValue : null;
            int? departmentId = cbx_searchDepartment.Checked && cb_searchDepartment.SelectedIndex > 0 ? (int?)cb_searchDepartment.SelectedValue : null;

            DataTable filteredData = dm.GetFilteredIncomingProducts(searchDate, categoryId, supplierId, departmentId);
            dgv_productList.DataSource = filteredData;
        }
    }
}
