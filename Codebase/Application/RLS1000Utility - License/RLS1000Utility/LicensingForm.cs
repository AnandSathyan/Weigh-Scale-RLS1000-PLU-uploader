using Newtonsoft.Json;
using PegasusSecurity;
using RLS1000Utility.DataAccess;
using RLS1000Utility.Models;
using RLS1000Utility.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RLS1000Utility
{
    public partial class LicensingForm : Form
    {
        LicenseTool objLT = new LicenseTool();
        public int iMenu = 0;
        AppConfigurationDASqLite DA;
        PegasusSecurity.EncryptionUtility objE = new EncryptionUtility();

        Thread thread;
        LoadingForm loadingDlg;

        public LicensingForm()
        {
            InitializeComponent();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (txtLicenseKey.Text.Length == 0)
            {
                MessageBox.Show("Invalid License Key!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseKey.Focus();
                return;
            }

            thread = new Thread(new ThreadStart(ActivateLicense));
            thread.IsBackground = true;
            // so not to have stray running threads if the main
            //form is closed
            thread.Start();
            // Display the Please Wait Dialog here
            loadingDlg = new LoadingForm();
            loadingDlg.ShowDialog(this);
            thread.Abort();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (iMenu == 1)
                this.Close();
            else
                Application.Exit();
        }

        private void btnProductBuyLink_Click(object sender, EventArgs e)
        {
            string targetURL = @"https://www.pegasustech.net/products/pegasus-softwares/scale-label-kuwait";
            System.Diagnostics.Process.Start(targetURL);
        }

        private void Licensing_Load(object sender, EventArgs e)
        {
            DA = new AppConfigurationDASqLite();
            if (iMenu == 1)
            {
                pnlInformation.Visible = true;
                btnReActivateLicense.Visible = true;
                //DataTable dtDevice = dac.ReturnTable("Select * from DeviceMaster");
                var device = DA.GetAppDeviceMaster();
                if (device != null && device.Count > 0)
                {
                    lblLicense.Text = objE.Decrypt(device[0].License_Key);
                    lblExpiryDate.Text = Convert.ToDateTime(objE.Decrypt(device[0].Expiry_Date)).ToString("dd-MMM-yyyy");
                    lblNlOfDevice.Text = device.Count.ToString();

                    //DataTable dtSettings = dac.ReturnTable("Select * from PegasusSettings");
                    var PS = DA.GetPegasusSettings();
                    if (PS != null && PS.ID != 0)
                    {
                        lblCompanyName.Text = PS.CompanyName;
                        lblEmail.Text = PS.Email;
                        lblType.Text = PS.VersionType.ToUpper();
                    }
                }
            }
            else
            {
                pnlInformation.Visible = false;
                btnReActivateLicense.Visible = false;
            }
        }

        private void ActivateLicense()
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate () { Cursor = Cursors.WaitCursor; });

                PegasusResource objPR = new PegasusResource();

                DataSet dsDeviceInfo = objLT.DeviceInformation(7, txtLicenseKey.Text, "windows", objPR.GetCode1(), objPR.GetCode2(), objPR.GetCode3(), objPR.GetCode4());

                //DataSet dsTemp = DeviceInformation(7, txtLicenseKey.Text, "", objPR.GetCode1(), objPR.GetCode2(), objPR.GetCode3(), objPR.GetCode4());
                if (dsDeviceInfo.Tables[4].Rows[0][0].ToString() == "Device Details!" || (dsDeviceInfo.Tables[4].Rows[0][0].ToString() == "Data get successfully"))
                {
                    if (dsDeviceInfo.Tables[1].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dsDeviceInfo.Tables[1].Rows[0]["is_registered"]) == 1)
                        {
                            MessageBox.Show("License already used..!! \nKindly contact Pegasus Support at \nsupport@pegasustech.net", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.BeginInvoke((MethodInvoker)delegate ()
                            {
                                txtLicenseKey.Focus();
                                txtLicenseKey.SelectAll();
                            });
                            return;
                        }
                    }


                    DataSet dsCustomerInfo = objLT.CustomerInformation(7, txtLicenseKey.Text);
                    //DataSet ds = dsTemp;

                    if ((dsCustomerInfo.Tables[4].Rows[0][0].ToString() == "Data get successfully"))
                    {


                        for (int i = 0; i < dsCustomerInfo.Tables[2].Rows.Count; i++)
                        {
                            string strlic_customer_license_id, strlic_product_id, strlic_code, strlicense_key, strregistration_date, strexpiry_date;
                            strlic_customer_license_id = objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["lic_customer_license_id"].ToString());
                            strlic_product_id = objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["lic_product_id"].ToString());
                            strlic_code = objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["lic_code"].ToString());
                            strlicense_key = objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["license_key"].ToString());


                            strregistration_date = objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["registration_date"].ToString());
                            strexpiry_date = objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["expiry_date"].ToString());


                            //string strSQL = "Select * From dbo.DeviceMaster Where lic_customer_licesnse_Id = '"
                            //    + strlic_customer_license_id + "' and lic_product_id = '"
                            //    + strlic_product_id + "' and lic_code = '"
                            //    + strlic_code + "' and license_key = '"
                            //    + strlicense_key + "' ";
                            //DataTable dtTemp = dac.ReturnTable(strSQL);

                            var LDM = DA.GetAppDeviceMaster();
                            AppDeviceMaster DM;
                            if (LDM != null && LDM.Count > 0)
                                DM = LDM.Where(x => x.DeviceID == (i + 1)).FirstOrDefault();

                            // DM = LDM.Where(x => (x.Lic_Customer_Licesnse_Id == strlic_customer_license_id)
                            //&& (x.Lic_Product_Id == strlic_product_id)
                            //&& (x.Lic_Code == strlic_code)
                            //&& (x.License_Key == strlicense_key)).FirstOrDefault();
                            else
                                DM = null;

                            bool iRestul = false;
                            //if (dtTemp.Rows.Count > 0)
                            if (DM != null)
                            {
                                DM = new AppDeviceMaster(DM.DeviceID, DM.DeviceIP, DM.DeviceName, DM.SourcePath, DM.DestinationPath, DM.FileType, DM.ScrollText, DM.Lang
                                    , DM.IsUpdate, strregistration_date, strexpiry_date, strlic_customer_license_id, strlic_product_id, strlic_code, strlicense_key);


                                // update
                                //strSQL = "UPDATE DeviceMaster SET expiry_date = '"
                                //    + strexpiry_date + "'  Where lic_customer_licesnse_Id = '"
                                //    + strlic_customer_license_id + "' and lic_product_id = '"
                                //    + strlic_product_id + "' and lic_code = '"
                                //    + strlic_code + "' and license_key = '"
                                //    + strlicense_key + "' ";

                                iRestul = DA.UpdateAppDeviceMaster(DM);
                            }
                            else
                            {
                                DM = new AppDeviceMaster(i + 1, " ", " ", " ", " ", " ", " ", 1, 1, strregistration_date, strexpiry_date, strlic_customer_license_id
                                    , strlic_product_id, strlic_code, strlicense_key);
                                // insert
                                //strSQL = "INSERT INTO  DeviceMaster (regsitration_date,expiry_date,lic_customer_licesnse_Id,lic_product_id,lic_code,license_key) VALUES('"
                                //    + strregistration_date + "','"
                                //    + strexpiry_date + "','"
                                //    + strlic_customer_license_id + "','"
                                //    + strlic_product_id + "','"
                                //    + strlic_code + "','"
                                //    + strlicense_key + "')  ";
                                iRestul = DA.InsertAppDeviceMaster(DM);


                                if (i == 0)
                                {
                                    string objLicFile = (Path.GetDirectoryName(Application.ExecutablePath) + "\\PegasusLic.txt");
                                    FileStream fs = null;
                                    if (!File.Exists(objLicFile))
                                    {
                                        fs = File.Create(objLicFile);
                                        fs.Close();
                                        fs.Dispose();
                                    }

                                    ExportToFile(objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["license_key"].ToString() + "##" + dsCustomerInfo.Tables[2].Rows.Count.ToString()), objLicFile, FileMode.Append);


                                }

                            }
                            //bool iRestul = dac.ExecuteDML(strSQL);

                            if (iRestul)
                            {
                            }
                            else
                            {

                                MessageBox.Show("Error!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        if (dsCustomerInfo.Tables[1].Rows.Count > 0)
                        {
                            var PS = DA.GetPegasusSettings();

                            if (PS != null && PS.ID != 0)
                            {
                                PS = new PegasusSettings(
                                    PS.ID
                                    , dsCustomerInfo.Tables[1].Rows[0]["registration_code"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["email"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["name"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["company_name"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["phone"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["version_type"].ToString()
                                    , txtLicenseKey.Text.Trim());
                                DA.UpdatePegasusSettings(PS);
                            }
                            else
                            {
                                PS = new PegasusSettings(
                                    1
                                    , dsCustomerInfo.Tables[1].Rows[0]["registration_code"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["email"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["name"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["company_name"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["phone"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["version_type"].ToString()
                                    , txtLicenseKey.Text.Trim());
                                DA.InsertPegasusSettings(PS);
                            }

                            var CS = DA.GetAppCompanySetup();
                            if (CS != null && CS.ID != 0)
                            {
                                CS = new AppCompanySetup(
                                    CS.ID
                                    , dsCustomerInfo.Tables[1].Rows[0]["company_name"].ToString()
                                    , " "
                                    , dsCustomerInfo.Tables[1].Rows[0]["phone"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["email"].ToString()
                                    , " "
                                    , " "
                                    , new byte[0]
                                    , "KWD"
                                    , 3);
                                DA.UpdateAppCompanySetup(CS);
                            }
                            else
                            {
                                CS = new AppCompanySetup(
                                    1
                                    , dsCustomerInfo.Tables[1].Rows[0]["company_name"].ToString()
                                    , " "
                                    , dsCustomerInfo.Tables[1].Rows[0]["phone"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["email"].ToString()
                                    , " "
                                    , " "
                                    , new byte[0]
                                    , "KWD"
                                    , 3);
                                DA.InsertAppCompanySetup(CS);
                            }

                            //string strSQL = "Truncate table PegasusSettings";
                            //dac.ExecuteDML(strSQL);
                            //strSQL = "INSERT INTO PegasusSettings(registration_code,email,name,company_name,phone,version_type) values";
                            //strSQL += "('"
                            //    + dsCustomerInfo.Tables[1].Rows[0]["registration_code"].ToString() + "','"
                            //    + dsCustomerInfo.Tables[1].Rows[0]["email"].ToString() + "','"
                            //    + dsCustomerInfo.Tables[1].Rows[0]["name"].ToString() + "','"
                            //    + dsCustomerInfo.Tables[1].Rows[0]["company_name"].ToString() + "','"
                            //    + dsCustomerInfo.Tables[1].Rows[0]["phone"].ToString() + "','"
                            //    + dsCustomerInfo.Tables[1].Rows[0]["version_type"].ToString() + "')";
                            //dac.ExecuteDML(strSQL);



                            var loginParams = DA.GetAllAppLoginPararmeter();
                            if (loginParams != null)
                            {
                                DA.UpdateAppLoginPararmeter(new AppLoginPararmeter(1, 1
                                    , dsCustomerInfo.Tables[1].Rows[0]["email"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["password"].ToString()));
                            }
                            else
                                DA.InsertAppLoginPararmeter(new AppLoginPararmeter(1, 1
                                    , dsCustomerInfo.Tables[1].Rows[0]["email"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["password"].ToString()));

                            //strSQL = "Update ParameterSetup Set  UserID ='" + dsCustomerInfo.Tables[1].Rows[0]["email"].ToString() + "'  , UserPassword = '" + dsCustomerInfo.Tables[1].Rows[0]["password"].ToString() + "'";
                            //dac.ExecuteDML(strSQL);


                        }

                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            Cursor = Cursors.Default;
                        });
                        MessageBox.Show("License Activated Successfully!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Restart Application!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();

                    }
                    else
                    {
                        MessageBox.Show("Invalid License Key!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            txtLicenseKey.Focus();
                            txtLicenseKey.SelectAll();
                        });

                    }
                }
                else
                {
                    MessageBox.Show("" + dsDeviceInfo.Tables[4].Rows[0][0].ToString(), "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        txtLicenseKey.Focus();
                        txtLicenseKey.SelectAll();
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.BeginInvoke((MethodInvoker)delegate () { Cursor = Cursors.Default; });
                loadingDlg.ShouldCloseNow = true;
            }
        }

        private void ReActivateLicense()
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate () { Cursor = Cursors.WaitCursor; });

                PegasusResource objPR = new PegasusResource();

                DataSet dsDeviceInfo = objLT.DeviceInformation(7, lblLicense.Text.Trim(), "windows", objPR.GetCode1(), objPR.GetCode2(), objPR.GetCode3(), objPR.GetCode4());

                //DataSet dsTemp = DeviceInformation(7, txtLicenseKey.Text, "", objPR.GetCode1(), objPR.GetCode2(), objPR.GetCode3(), objPR.GetCode4());
                if (dsDeviceInfo.Tables[4].Rows[0][0].ToString() == "Device Details!" || (dsDeviceInfo.Tables[4].Rows[0][0].ToString() == "Data get successfully"))
                {
                    DataSet dsCustomerInfo = objLT.CustomerInformation(7, lblLicense.Text);
                    //DataSet ds = dsTemp;

                    if ((dsCustomerInfo.Tables[4].Rows[0][0].ToString() == "Data get successfully"))
                    {


                        for (int i = 0; i < dsCustomerInfo.Tables[2].Rows.Count; i++)
                        {
                            string strlic_customer_license_id, strlic_product_id, strlic_code, strlicense_key, strregistration_date, strexpiry_date;
                            strlic_customer_license_id = objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["lic_customer_license_id"].ToString());
                            strlic_product_id = objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["lic_product_id"].ToString());
                            strlic_code = objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["lic_code"].ToString());
                            strlicense_key = objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["license_key"].ToString());


                            strregistration_date = objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["registration_date"].ToString());
                            strexpiry_date = objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["expiry_date"].ToString());


                            //string strSQL = "Select * From dbo.DeviceMaster Where lic_customer_licesnse_Id = '"
                            //    + strlic_customer_license_id + "' and lic_product_id = '"
                            //    + strlic_product_id + "' and lic_code = '"
                            //    + strlic_code + "' and license_key = '"
                            //    + strlicense_key + "' ";
                            //DataTable dtTemp = dac.ReturnTable(strSQL);

                            var LDM = DA.GetAppDeviceMaster();
                            AppDeviceMaster DM;
                            if (LDM != null && LDM.Count > 0)
                                DM = LDM.Where(x => (x.Lic_Customer_Licesnse_Id == strlic_customer_license_id)
                               && (x.Lic_Product_Id == strlic_product_id)
                               && (x.Lic_Code == strlic_code)
                               && (x.License_Key == strlicense_key)).FirstOrDefault();
                            else
                                DM = null;

                            bool iRestul = false;
                            //if (dtTemp.Rows.Count > 0)
                            if (DM != null)
                            {
                                DM = new AppDeviceMaster(DM.DeviceID, DM.DeviceIP, DM.DeviceName, DM.SourcePath, DM.DestinationPath, DM.FileType, DM.ScrollText, DM.Lang
                                    , DM.IsUpdate, DM.Regsitration_Date, strexpiry_date, DM.Lic_Customer_Licesnse_Id, DM.Lic_Product_Id, DM.Lic_Code, DM.License_Key);
                                // update
                                //strSQL = "UPDATE DeviceMaster SET expiry_date = '"
                                //    + strexpiry_date + "'  Where lic_customer_licesnse_Id = '"
                                //    + strlic_customer_license_id + "' and lic_product_id = '"
                                //    + strlic_product_id + "' and lic_code = '"
                                //    + strlic_code + "' and license_key = '"
                                //    + strlicense_key + "' ";

                                iRestul = DA.UpdateAppDeviceMaster(DM);
                            }
                            else
                            {
                                DM = new AppDeviceMaster(i + 1, " ", " ", " ", " ", " ", " ", 1, 1, strregistration_date, strexpiry_date, strlic_customer_license_id
                                    , strlic_product_id, strlic_code, strlicense_key);
                                // insert
                                //strSQL = "INSERT INTO  DeviceMaster (regsitration_date,expiry_date,lic_customer_licesnse_Id,lic_product_id,lic_code,license_key) VALUES('"
                                //    + strregistration_date + "','"
                                //    + strexpiry_date + "','"
                                //    + strlic_customer_license_id + "','"
                                //    + strlic_product_id + "','"
                                //    + strlic_code + "','"
                                //    + strlicense_key + "')  ";
                                iRestul = DA.InsertAppDeviceMaster(DM);


                                if (i == 0)
                                {
                                    string objLicFile = (Path.GetDirectoryName(Application.ExecutablePath) + "\\PegasusLic.txt");
                                    FileStream fs = null;
                                    if (!File.Exists(objLicFile))
                                    {
                                        fs = File.Create(objLicFile);
                                        fs.Close();
                                        fs.Dispose();
                                    }

                                    //ExportToFile(objE.Encrypt(dsCustomerInfo.Tables[2].Rows[i]["license_key"].ToString() + "##" + dsCustomerInfo.Tables[2].Rows.Count.ToString()), objLicFile, FileMode.Append);


                                }

                            }
                            //bool iRestul = dac.ExecuteDML(strSQL);

                            if (iRestul)
                            {
                            }
                            else
                            {

                                this.BeginInvoke((MethodInvoker)delegate ()
                                {
                                    Cursor = Cursors.Default;
                                });

                                MessageBox.Show("Error!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        if (dsCustomerInfo.Tables[1].Rows.Count > 0)
                        {
                            var PS = DA.GetPegasusSettings();

                            if (PS != null && PS.ID != 0)
                            {
                                PS = new PegasusSettings(
                                    PS.ID
                                    , dsCustomerInfo.Tables[1].Rows[0]["registration_code"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["email"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["name"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["company_name"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["phone"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["version_type"].ToString()
                                    , lblLicense.Text.Trim());
                                DA.UpdatePegasusSettings(PS);
                            }
                            else
                            {
                                PS = new PegasusSettings(
                                    1
                                    , dsCustomerInfo.Tables[1].Rows[0]["registration_code"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["email"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["name"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["company_name"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["phone"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["version_type"].ToString()
                                    , lblLicense.Text.Trim());
                                DA.InsertPegasusSettings(PS);
                            }

                            var CS = DA.GetAppCompanySetup();
                            if (CS != null && CS.ID != 0)
                            {
                                CS = new AppCompanySetup(
                                    CS.ID
                                    , dsCustomerInfo.Tables[1].Rows[0]["company_name"].ToString()
                                    , " "
                                    , dsCustomerInfo.Tables[1].Rows[0]["phone"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["email"].ToString()
                                    , " "
                                    , " "
                                    , new byte[0]
                                    , "KWD"
                                    , 3);
                                DA.UpdateAppCompanySetup(CS);
                            }
                            else
                            {
                                CS = new AppCompanySetup(
                                    1
                                    , dsCustomerInfo.Tables[1].Rows[0]["company_name"].ToString()
                                    , " "
                                    , dsCustomerInfo.Tables[1].Rows[0]["phone"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["email"].ToString()
                                    , " "
                                    , " "
                                    , new byte[0]
                                    , "KWD"
                                    , 3);
                                DA.InsertAppCompanySetup(CS);
                            }

                            //string strSQL = "Truncate table PegasusSettings";
                            //dac.ExecuteDML(strSQL);
                            //strSQL = "INSERT INTO PegasusSettings(registration_code,email,name,company_name,phone,version_type) values";
                            //strSQL += "('"
                            //    + dsCustomerInfo.Tables[1].Rows[0]["registration_code"].ToString() + "','"
                            //    + dsCustomerInfo.Tables[1].Rows[0]["email"].ToString() + "','"
                            //    + dsCustomerInfo.Tables[1].Rows[0]["name"].ToString() + "','"
                            //    + dsCustomerInfo.Tables[1].Rows[0]["company_name"].ToString() + "','"
                            //    + dsCustomerInfo.Tables[1].Rows[0]["phone"].ToString() + "','"
                            //    + dsCustomerInfo.Tables[1].Rows[0]["version_type"].ToString() + "')";
                            //dac.ExecuteDML(strSQL);



                            var loginParams = DA.GetAllAppLoginPararmeter();
                            if (loginParams != null)
                            {
                                DA.UpdateAppLoginPararmeter(new AppLoginPararmeter(1, 1
                                    , dsCustomerInfo.Tables[1].Rows[0]["email"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["password"].ToString()));
                            }
                            else
                                DA.InsertAppLoginPararmeter(new AppLoginPararmeter(1, 1
                                    , dsCustomerInfo.Tables[1].Rows[0]["email"].ToString()
                                    , dsCustomerInfo.Tables[1].Rows[0]["password"].ToString()));

                            //strSQL = "Update ParameterSetup Set  UserID ='" + dsCustomerInfo.Tables[1].Rows[0]["email"].ToString() + "'  , UserPassword = '" + dsCustomerInfo.Tables[1].Rows[0]["password"].ToString() + "'";
                            //dac.ExecuteDML(strSQL);


                        }

                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            Cursor = Cursors.Default;
                        });
                        MessageBox.Show("License Activated Successfully!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Restart Application!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();

                    }
                    else
                    {
                        MessageBox.Show("Invalid License Key!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            lblLicense.Focus();
                        });
                        //lblLicense.SelectAll();

                    }
                }
                else
                {
                    MessageBox.Show("" + dsDeviceInfo.Tables[4].Rows[0][0].ToString(), "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        lblLicense.Focus();
                    });
                    //lblLicense.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.BeginInvoke((MethodInvoker)delegate () { Cursor = Cursors.Default; });
                loadingDlg.ShouldCloseNow = true;
            }
        }

        public void ExportToFile(string LogFormat, string Filepath, System.IO.FileMode Mode)
        {
            try
            {
                FileStream fs = new FileStream(Filepath, Mode, FileAccess.Write);
                StreamWriter s = new StreamWriter(fs);
                s.BaseStream.Seek(0, SeekOrigin.End);
                s.WriteLine(LogFormat);
                s.Close();
                fs.Close();
            }
            catch
            {
            }
        }

        private void LicensingForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(198, 11, 7), ButtonBorderStyle.Solid);
        }

        private void btnReActivateLicense_Click(object sender, EventArgs e)
        {
            if (lblLicense.Text.Length == 0)
            {
                MessageBox.Show("Invalid License Key!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseKey.Focus();
                return;
            }

            thread = new Thread(new ThreadStart(ReActivateLicense));
            thread.IsBackground = true;
            // so not to have stray running threads if the main
            //form is closed
            thread.Start();
            // Display the Please Wait Dialog here
            loadingDlg = new LoadingForm();
            loadingDlg.ShowDialog(this);
            thread.Abort();
        }
    }
}
