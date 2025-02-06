using PegasusSecurity;
using RLS1000Utility.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RLS1000Utility
{
    public partial class MainForm : Form
    {
        AppConfigurationDASqLite DA;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.lblVersion.Text = " Ver " + version.Major + "." + version.Minor + "." + version.Build + "." + version.Revision;

            DA = new AppConfigurationDASqLite();
            PegasusSecurity.EncryptionUtility objE = new EncryptionUtility();
            var DM = DA.GetAppDeviceMaster();
            DateTime dtExpiryDate = Convert.ToDateTime(objE.Decrypt(DM[0].Expiry_Date));
            var PS = DA.GetPegasusSettings();
            lblType.Text = PS.VersionType.ToUpper();
            lblLicenseExpiry.Text = dtExpiryDate.ToString("D");

            if (dtExpiryDate < DateTime.Now)
                EnableDisableApp(0);
            else
            {
                if ((dtExpiryDate - DateTime.Now).Days < 15)
                    EnableDisableApp(2);
                else
                    EnableDisableApp(1);
            }

        }

        private void EnableDisableApp(int status)
        {
            btnCompanySetup.Enabled = status == 0 ? false : true;
            btnDBSetup.Enabled = status == 0 ? false : true;
            btnDeviceMaster.Enabled = status == 0 ? false : true;
            btnPLUMaster.Enabled = status == 0 ? false : true;
            btnScaleUtility.Enabled = status == 0 ? false : true;

            if (status == 0)
            {
                lblLicenseExpiry.BackColor = Color.Red;
                lblLicenseExpiry.ForeColor = Color.White;
                lblLicenseStatus.BackColor = Color.Red;
                lblLicenseStatus.ForeColor = Color.White;
                lblLicenseStatus.Text = "EXPIRED";
            }
            else if (status == 1)
            {
                lblLicenseExpiry.BackColor = Color.White;
                lblLicenseExpiry.ForeColor = Color.Green;
                lblLicenseStatus.BackColor = Color.White;
                lblLicenseStatus.ForeColor = Color.Green;
                lblLicenseStatus.Text = "ACTIVE";
            }
            else
            {
                lblLicenseExpiry.BackColor = Color.White;
                lblLicenseExpiry.ForeColor = Color.Red;
                lblLicenseStatus.BackColor = Color.White;
                lblLicenseStatus.ForeColor = Color.Red;
                lblLicenseStatus.Text = "NEAR EXPIRY";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            CloseAll();
            AboutUsForm aboutUs = new AboutUsForm();
            aboutUs.ShowDialog(this);
        }

        private void btnDeviceMaster_Click(object sender, EventArgs e)
        {
            CloseAll();
            DeviceMasterForm deviceMasterForm = new DeviceMasterForm();
            deviceMasterForm.ShowDialog(this);
        }

        private void btnCompanySetup_Click(object sender, EventArgs e)
        {
            CloseAll();
            CompanyMasterForm companyMasterForm = new CompanyMasterForm();
            companyMasterForm.ShowDialog(this);
        }

        public void CloseAll()
        {
            foreach (Form child in MdiChildren)
                child.Close();
        }

        private void btnDBSetup_Click(object sender, EventArgs e)
        {
            CloseAll();
            DBSetupForm dBSetupForm = new DBSetupForm();
            dBSetupForm.ShowDialog(this);
        }

        private void btnPLUMaster_Click(object sender, EventArgs e)
        {
            CloseAll();
            PLUMasterForm plUMasterForm = new PLUMasterForm();
            plUMasterForm.ShowDialog(this);
        }

        private void btnScaleUtility_Click(object sender, EventArgs e)
        {
            CloseAll();
            ScaleUtilityForm scaleUtilityForm = new ScaleUtilityForm();
            scaleUtilityForm.ShowDialog(this);
        }

        private void btnLicenseInfo_Click(object sender, EventArgs e)
        {
            CloseAll();
            LicensingForm licensingForm = new LicensingForm();
            licensingForm.iMenu = 1;
            licensingForm.ShowDialog(this);
        }
    }
}
