using RLS1000Utility.DataAccess;
using RLS1000Utility.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLS1000Utility
{
    public partial class CompanyMasterForm : Form
    {
        AppConfigurationDASqLite ConfigurationDA;
        public CompanyMasterForm()
        {
            InitializeComponent();
            ConfigurationDA = new AppConfigurationDASqLite();
        }

        private void CompanyMaster_Load(object sender, EventArgs e)
        {
            var ACS = ConfigurationDA.GetAppCompanySetup();
            if (ACS != null && ACS.ID == 1)
            {
                txtCompanyName.Text=ACS.CompanyName;
                txtPhoneNo.Text=ACS.CompanyPhone;
                txtEMail.Text=ACS.CompanyEmail;
                txtWebsite.Text=ACS.CompanyWebSite;
                txtCurrency.Text=ACS.CompanyCurrency;
                txtAddress.Text=ACS.CompanyAddress;
                txtImageURL.Text=ACS.CompanyLogo;
            }
        }

        private void btnSaveLocal_Click(object sender, EventArgs e)
        {
            var ACS = ConfigurationDA.GetAppCompanySetup();
            if (ACS != null && ACS.ID == 1)
                ConfigurationDA.UpdateAppCompanySetup(new AppCompanySetup
                    (
                    1,
                    string.IsNullOrEmpty(txtCompanyName.Text) ? " " : txtCompanyName.Text,
                    string.IsNullOrEmpty(txtImageURL.Text) ? " " : txtImageURL.Text,
                    string.IsNullOrEmpty(txtPhoneNo.Text) ? " " : txtPhoneNo.Text,
                    string.IsNullOrEmpty(txtEMail.Text) ? " " : txtEMail.Text,
                    string.IsNullOrEmpty(txtAddress.Text) ? " " : txtAddress.Text,
                    string.IsNullOrEmpty(txtWebsite.Text) ? " " : txtWebsite.Text,
                    new byte[0],
                    string.IsNullOrEmpty(txtCurrency.Text) ? " " : txtCurrency.Text,
                    3
                ));
            else
                ConfigurationDA.InsertAppCompanySetup(new AppCompanySetup
                    (
                    1,
                    string.IsNullOrEmpty(txtCompanyName.Text) ? " " : txtCompanyName.Text,
                    string.IsNullOrEmpty(txtImageURL.Text) ? " " : txtImageURL.Text,
                    string.IsNullOrEmpty(txtPhoneNo.Text) ? " " : txtPhoneNo.Text,
                    string.IsNullOrEmpty(txtEMail.Text) ? " " : txtEMail.Text,
                    string.IsNullOrEmpty(txtAddress.Text) ? " " : txtAddress.Text,
                    string.IsNullOrEmpty(txtWebsite.Text) ? " " : txtWebsite.Text,
                    new byte[0],
                    string.IsNullOrEmpty(txtCurrency.Text) ? " " : txtCurrency.Text,
                    3
                ));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CompanyMasterForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(198, 11, 7), ButtonBorderStyle.Solid);
        }
    }
}
