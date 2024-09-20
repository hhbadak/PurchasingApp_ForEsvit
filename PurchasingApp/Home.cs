using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchasingApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent(); this.IsMdiContainer = true; // Ana formu MDI container yap
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoginPage frm = new LoginPage();
            frm.ShowDialog();
            Employee model = Helpers.GirisYapanKullanici;
        }

        private void TSMI_category_Click(object sender, EventArgs e)
        {
            bool acikmi = false;
            Form[] acikformlar = this.MdiChildren;

            foreach (Form item in acikformlar)
            {
                if (item.GetType() == typeof(PurchasingApp.Categories))
                {
                    acikmi = true;
                    item.Activate();
                    item.WindowState = FormWindowState.Maximized; // Ensure it is maximized
                }
            }

            if (acikmi == false)
            {
                PurchasingApp.Categories frm = new PurchasingApp.Categories();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized; // Open in fullscreen
                frm.Show();
            }
        }

        private void TSMI_departments_Click(object sender, EventArgs e)
        {
            bool acikmi = false;
            Form[] acikformlar = this.MdiChildren;

            foreach (Form item in acikformlar)
            {
                if (item.GetType() == typeof(DepartmentsForm))
                {
                    acikmi = true;
                    item.Activate();
                    item.WindowState = FormWindowState.Maximized; // Ensure it is maximized
                }
            }

            if (acikmi == false)
            {
                DepartmentsForm frm = new DepartmentsForm();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized; // Open in fullscreen
                frm.Show();
            }
        }

        private void TSMI_suppliers_Click(object sender, EventArgs e)
        {
            bool acikmi = false;
            Form[] acikformlar = this.MdiChildren;

            foreach (Form item in acikformlar)
            {
                if (item.GetType() == typeof(SuppliersForm))
                {
                    acikmi = true;
                    item.Activate();
                    item.WindowState = FormWindowState.Maximized; // Ensure it is maximized
                }
            }

            if (acikmi == false)
            {
                SuppliersForm frm = new SuppliersForm();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized; // Open in fullscreen
                frm.Show();
            }
        }

        private void TSMI_IncomingProducts_Click(object sender, EventArgs e)
        {
            bool acikmi = false;
            Form[] acikformlar = this.MdiChildren;

            foreach (Form item in acikformlar)
            {
                if (item.GetType() == typeof(IcomingProductsForm))
                {
                    acikmi = true;
                    item.Activate();
                    item.WindowState = FormWindowState.Maximized; // Ensure it is maximized
                }
            }

            if (acikmi == false)
            {
                IcomingProductsForm frm = new IcomingProductsForm();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized; // Open in fullscreen
                frm.Show();
            }
        }

    }
}
