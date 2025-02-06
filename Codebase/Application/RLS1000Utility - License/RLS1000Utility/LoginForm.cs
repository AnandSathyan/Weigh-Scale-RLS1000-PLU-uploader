using PegasusSecurity;
using RLS1000Utility.DataAccess;
using RLS1000Utility.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLS1000Utility
{
    public partial class LoginForm : Form
    {
        AppConfigurationDASqLite DA;
        Thread thread;
        LoadingForm loadingDlg;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.lblVersion.Text = " Ver " + version.Major + "." + version.Minor + "." + version.Build + "." + version.Revision;
            DA = new AppConfigurationDASqLite();
            if (!DA.DBExist())
            {
                Cursor = Cursors.WaitCursor;
                thread = new Thread(new ThreadStart(SetupAppDB));
                thread.IsBackground = true;
                // so not to have stray running threads if the main
                //form is closed
                thread.Start();
                // Display the Please Wait Dialog here
                loadingDlg = new LoadingForm();
                loadingDlg.ShowDialog();
                thread.Abort();

                Cursor = Cursors.Default;
            }

            var PS = DA.GetPegasusSettings();
            if (PS == null)
            {
                LicensingForm licensing = new LicensingForm();
                licensing.ShowDialog();
            }
            else if (PS.ID == 0)
            {
                LicensingForm licensing = new LicensingForm();
                licensing.ShowDialog();
            }

            var LP = DA.GetAppLoginPararmeter();
            if (LP != null)
            {
                txtUserID.Text = LP.UserID;
                txtPassword.Text = LP.UserPassword;
            }

        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            var loginParams = DA.GetAllAppLoginPararmeter();
            //DataTable dt = new DataTable();
            //dt = dac.ReturnTable("Select * from ParameterSetup");

            //if (dt.Rows.Count > 0)
            if (loginParams != null && loginParams.Count > 0)
            {
                //DataTable dtDevice = dac.ReturnTable("Select * from DeviceMaster");
                var LDM = DA.GetAppDeviceMaster();
                //if (dtDevice.Rows.Count == 0)
                if (LDM == null)
                {
                    LicensingForm objLicense = new LicensingForm();
                    objLicense.ShowDialog();
                }

                string UserID = loginParams[0].UserID;
                string UserPassword = loginParams[0].UserPassword;
                if ((UserID == txtUserID.Text) && (UserPassword == txtPassword.Text))
                {
                    if (!CheckLicValidation())
                    {
                        MessageBox.Show("License Error.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                    //mainForm.ShowDialog(this);
                    //this.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect UserID or Password.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserID.Text = "";
                    txtPassword.Text = "";
                    txtUserID.Focus();
                }
            }
            else
            {
                MessageBox.Show("Database not Valid, Please wait Database Setup Form Will Open", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);



                txtUserID.Text = "";
                txtPassword.Text = "";
                txtUserID.Focus();
                Application.Exit();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetupAppDB()
        {
            try
            {
                DA.InitDB();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
            }
            loadingDlg.ShouldCloseNow = true;
        }
        private bool CheckLicValidation()
        {
            try
            {
                string objLicFile = (Path.GetDirectoryName(Application.ExecutablePath) + "\\PegasusLic.txt");
                //FileStream fs = null;
                if (!File.Exists(objLicFile))
                {
                    DA.DeleteAllAppDeviceMaster();
                    //dac.ExecuteDML("Delete From  DeviceMaster");
                    //dac.ExecuteDML("Delete From  DeviceMedia");
                }
                else
                {
                    PegasusSecurity.EncryptionUtility objE = new EncryptionUtility();
                    String[] spearator = { "##" };
                    var fileStream = new FileStream(@"" + objLicFile, FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        string line;
                        string strLast = "";

                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (line.Length > 0)
                            {
                                strLast = objE.Decrypt(line);
                            }
                        }

                        if (strLast.Length > 0)
                        {
                            String[] strlist = strLast.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
                            if (strlist.Length == 2)
                            {
                                var LDM = DA.GetAppDeviceMaster();
                                if (LDM == null)
                                    return false;
                                if (LDM.Count.ToString() != strlist[1])
                                    return false;



                                //DataTable dtTemp = dac.ReturnTable("Select count(*)  From  DeviceMaster where license_key ='" + objE.Encrypt(strlist[0]).ToString() + "'");
                                //if (dtTemp.Rows[0][0].ToString() != strlist[1])
                                //{
                                //    return false;
                                //}
                            }
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(198, 11, 7), ButtonBorderStyle.Solid);
        }
    }
}
