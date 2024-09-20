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
    public partial class LoginPage : Form
    {
        bool girisVar = false;
        DataModel dm = new DataModel();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_username.Text) && !string.IsNullOrEmpty(tb_password.Text))
            {
                Employee model = dm.EmployeeLogin(tb_username.Text, tb_password.Text);
                if (model.Username != null)
                {
                    Helpers.GirisYapanKullanici = model;
                    girisVar = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Bilgileri Hatalı", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Boş Bırakılamaz");
            }
        }
        private void tb_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login_Click(sender, e);
                e.SuppressKeyPress = true; // Bu satır Enter tuşunun bir sonraki kontrolde başka bir etki yaratmasını engeller
            }
        }

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!girisVar) // Eğer giriş yapılmadıysa
            {
                Application.Exit(); // Uygulamayı tamamen kapat
            }
        }
    }
}
