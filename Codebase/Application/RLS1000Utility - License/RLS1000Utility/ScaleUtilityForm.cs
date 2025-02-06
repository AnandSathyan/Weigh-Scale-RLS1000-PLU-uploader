using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RLS1000Utility.DeviceUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RLS1000Utility.DataAccess;
using RLS1000Utility.Models;
using System.Threading;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace RLS1000Utility
{
    public partial class ScaleUtilityForm : Form
    {
        int connid = 0;
        AppConfigurationDASqLite ConfigurationDA;
        PLUDAOleDB PLUDA;
        private readonly ClientDBSetup clientDBSetup;

        List<PLUDataDB> listPludata;
        List<AppDeviceMasterGrid> listDevices;


        Thread thread;
        LoadingForm loadingDlg;

        public ScaleUtilityForm()
        {
            InitializeComponent();
            ConfigurationDA = new AppConfigurationDASqLite();
            clientDBSetup = ConfigurationDA.GetClientDBSetup();
        }

        private void ScaleUtilityForm_Load(object sender, EventArgs e)
        {
            try
            {

                cmbxSearchFilter.SelectedIndex = 0;

                FillDeviceList(ConfigurationDA.GetAppDeviceMaster());
                if (clientDBSetup != null && clientDBSetup.ID != 0)
                {
                    PLUDA = new PLUDAOleDB(clientDBSetup.ConnString);
                    if (!PLUDA.OpenConnection())
                    {
                        MessageBox.Show("Client Server Not connected.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chkbxPLUOnline.Checked = false;
                        chkbxPLUOnline.Enabled = false;
                        FillPLUListLocal(ConfigurationDA.GetAppPLUData());
                        return;
                    }
                    else
                    {
                        FillPLUList(PLUDA.GetAllPLUData
                        ($"SELECT {clientDBSetup.LFCodeColumn},{clientDBSetup.BarcodeColumn},{clientDBSetup.PLUNameColumn},{clientDBSetup.UnitPriceColumn} FROM {clientDBSetup.DBObjectName}"));
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Kindly Setup Client Server DB.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkbxPLUOnline.Checked = false;
                    chkbxPLUOnline.Enabled = false;
                    FillPLUListLocal(ConfigurationDA.GetAppPLUData());
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScaleUtilityForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(198, 11, 7), ButtonBorderStyle.Solid);
        }

        private void btnCheckScaleConnection_Click(object sender, EventArgs e)
        {
            try
            {
                List<AppDeviceMasterGrid> devList = new List<AppDeviceMasterGrid>();
                if (chkbxAllScale.Checked)
                {
                    devList = GetAllDeviceDetailFromGrid();
                }
                else
                {
                    devList = GetSelectedDevicesDetailFromGrid();
                }

                foreach (var dev in devList)
                {
                    if (dev.DeviceID == 0)
                        return;
                    bool res = CheckScaleConnection(dev.DeviceIP);

                    listDevices.Where(x => x.DeviceIP == dev.DeviceIP).FirstOrDefault().Status = res ? "Connected" : "Not Connected";
                }

                FillDeviceList(listDevices);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckScaleConnection(string ipadd)
        {
            try
            {
                if (!string.IsNullOrEmpty(ipadd))
                {
                    IPAddress iP;
                    if (IPAddress.TryParse(ipadd, out iP))
                    {
                        if (ConnectScale(ipadd))
                        {
                            ChangeScaleStatus(true, "Connected");
                            ChangeAppStatus(true, "Scale Connected");

                            DisconnectScale();

                            return true;
                        }
                        else
                        {
                            ChangeScaleStatus(false, "Disconnected");
                            ChangeAppStatus(false, "Scale Connection Failed");
                        }
                    }
                    else
                        ChangeAppStatus(false, "Enter Correct IP");
                }
                else
                    ChangeAppStatus(false, "Enter Correct IP");

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnGetPLU_Click(object sender, EventArgs e)
        {
            try
            {

                if (chkbxPLUOnline.Checked)
                {
                    if (!PLUDA.OpenConnection())
                    {
                        MessageBox.Show("Client Server Not connected.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chkbxPLUOnline.Checked = false;
                        chkbxPLUOnline.Enabled = false;
                        return;
                    }
                    else
                    {
                        FillPLUList(PLUDA.GetAllPLUData
                        ($"SELECT {clientDBSetup.LFCodeColumn}, {clientDBSetup.BarcodeColumn}, {clientDBSetup.PLUNameColumn}, {clientDBSetup.UnitPriceColumn} FROM {clientDBSetup.DBObjectName}"));
                        return;

                    }
                }
                else
                {
                    FillPLUListLocal(ConfigurationDA.GetAppPLUData());
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearPLUList_Click(object sender, EventArgs e)
        {
            listPludata = new List<PLUDataDB>();
            dgvPLUData.DataSource = listPludata;
        }

        private void btnChecckWeight_Click(object sender, EventArgs e)
        {
            try
            {
                var dev = GetSelectedDevicesDetailFromGrid().FirstOrDefault();
                if (dev == null)
                {
                    MessageBox.Show("Please Select Scale.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dev.DeviceID == 0)
                {
                    MessageBox.Show("Please Select Scale.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string ipadd = dev.DeviceIP;

                if (!string.IsNullOrEmpty(ipadd))
                {
                    IPAddress iP;
                    if (IPAddress.TryParse(ipadd, out iP))
                    {
                        if (ConnectScale(ipadd))
                        {
                            double dWeight = 0;
                            int iRtn = -1;
                            iRtn = LabelScale.rtscaleGetPluWeight(connid, ref dWeight);
                            if (iRtn < 0)
                                MessageBox.Show("Failed to get the weight.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                tbWeight.Text = dWeight.ToString();
                            //MessageBox.Show(dWeight.ToString());
                            DisconnectScale();
                        }
                        else
                        {
                            ChangeScaleStatus(false, "Disconnected");
                            ChangeAppStatus(false, "Scale Connection Failed");
                        }
                    }
                    else
                        ChangeAppStatus(false, "Enter Correct IP");
                }
                else
                    ChangeAppStatus(false, "Enter Correct IP");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearPluDataOnScale_Click(object sender, EventArgs e)
        {
            try
            {
                List<AppDeviceMasterGrid> devList = new List<AppDeviceMasterGrid>();
                if (chkbxAllScale.Checked)
                    devList = GetAllDeviceDetailFromGrid();
                else
                    devList = GetSelectedDevicesDetailFromGrid();

                foreach (var dev in devList)
                {
                    if (dev.DeviceID == 0)
                        return;

                    string ipadd = dev.DeviceIP;

                    if (!string.IsNullOrEmpty(ipadd))
                    {
                        IPAddress iP;
                        if (IPAddress.TryParse(ipadd, out iP))
                        {
                            if (ConnectScale(ipadd))
                            {
                                if (LabelScale.rtscaleClearPLUData(connid) == 0)
                                    MessageBox.Show($"Plu Data Cleared on Scale {dev.DeviceName}.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //LabelScale.rtscaleDisConnect(connid);
                                DisconnectScale();
                            }
                            else
                            {
                                ChangeScaleStatus(false, "Disconnected");
                                ChangeAppStatus(false, "Scale Connection Failed");
                            }
                        }
                        else
                            ChangeAppStatus(false, "Enter Correct IP");
                    }
                    else
                        ChangeAppStatus(false, "Enter Correct IP");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangeScaleScrollText_Click(object sender, EventArgs e)
        {
            try
            {
                List<AppDeviceMasterGrid> devList = new List<AppDeviceMasterGrid>();
                if (chkbxAllScale.Checked)
                    devList = GetAllDeviceDetailFromGrid();
                else
                    devList = GetSelectedDevicesDetailFromGrid();

                foreach (var dev in devList)
                {
                    if (dev.DeviceID == 0)
                        continue;

                    string ipadd = dev.DeviceIP;

                    if (!string.IsNullOrEmpty(ipadd))
                    {
                        IPAddress iP;
                        if (IPAddress.TryParse(ipadd, out iP))
                        {
                            if (ConnectScale(ipadd))
                            {
                                int iret = LabelScale.rtscaleDownLoadAdHead(connid, dev.ScrollText, dev.ScrollText.Length);

                                //LabelScale.rtscaleDisConnect(connid);
                                DisconnectScale();
                                if (iret == 0)
                                    ChangeAppStatus(true, "Header Message Changed");
                                else
                                    ChangeAppStatus(false, "Header Message Change Failed");
                            }
                            else
                            {
                                ChangeScaleStatus(false, "Disconnected");
                                ChangeAppStatus(false, "Scale Connection Failed");
                            }
                        }
                        else
                            ChangeAppStatus(false, "Enter Correct IP");
                    }
                    else
                        ChangeAppStatus(false, "Enter Correct IP");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownloadPluFromScale_Click(object sender, EventArgs e)
        {
            try
            {
                var dev = GetSelectedDevicesDetailFromGrid().FirstOrDefault();
                if (dev.DeviceID == 0)
                    return;

                string ipadd = dev.DeviceIP;

                if (!string.IsNullOrEmpty(ipadd))
                {
                    IPAddress iP;
                    if (IPAddress.TryParse(ipadd, out iP))
                    {
                        if (ConnectScale(ipadd))
                        {
                            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//文件存放路径，保证文件存在。
                            String fileName = path + "plulist.csv";
                            File.Delete(fileName);

                            Callback info = uploadPluDataCallback;
                            IntPtr p = Marshal.GetFunctionPointerForDelegate(info);
                            int iret = LabelScale.rtscaleUploadPluData(connid, p);//Ok: return  Total number of records  Fail: return <0 
                            LabelScale.rtscaleDisConnect(connid);
                            if (iret >= 0)
                            {
                                MessageBox.Show($"Plu Data Downloaded from Scale {dev.DeviceName}.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //System.Diagnostics.Process.Start(fileName); //直
                            }
                            else
                            {
                                MessageBox.Show($"Plu Data Download from Scale {dev.DeviceName} Failed.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            DisconnectScale();
                        }
                        else
                        {
                            ChangeScaleStatus(false, "Disconnected");
                            ChangeAppStatus(false, "Scale Connection Failed");
                        }
                    }
                    else
                        ChangeAppStatus(false, "Enter Correct IP");
                }
                else
                    ChangeAppStatus(false, "Enter Correct IP");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUploadPluToScale_Click(object sender, EventArgs e)
        {
            try
            {
                if (listPludata != null && listPludata.Count > 0) { }
                else
                {
                    MessageBox.Show("Kindly Get the PLU List", "Error", MessageBoxButtons.OK);
                    return;
                }



                //---------------
                if (chkbxPLUOnline.Checked)
                {
                    if (!PLUDA.OpenConnection())
                    {
                        MessageBox.Show("Client Server Not connected.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        chkbxPLUOnline.Checked = false;
                        chkbxPLUOnline.Enabled = false;
                    }
                    else
                    {
                        FillPLUList(PLUDA.GetAllPLUData
                        ($"SELECT {clientDBSetup.LFCodeColumn}, {clientDBSetup.BarcodeColumn}, {clientDBSetup.PLUNameColumn}, {clientDBSetup.UnitPriceColumn} FROM {clientDBSetup.DBObjectName}"));

                    }
                }
                else
                {
                    FillPLUListLocal(ConfigurationDA.GetAppPLUData());
                }
                //---------------
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    groupBox2.Enabled = false;
                });
                List<AppDeviceMasterGrid> devList = new List<AppDeviceMasterGrid>();
                if (chkbxAllScale.Checked)
                    devList = GetAllDeviceDetailFromGrid();
                else
                    devList = GetSelectedDevicesDetailFromGrid();

                foreach (var dev in devList)
                {
                    if (dev.DeviceID == 0)
                        continue;
                    string ipadd = dev.DeviceIP.Trim();

                    if (!string.IsNullOrEmpty(ipadd))
                    {
                        IPAddress iP;
                        if (IPAddress.TryParse(ipadd, out iP))
                        {
                            if (ConnectScale(ipadd))
                            {

                                progressBarApp.Maximum = listPludata.Count;
                                progressBarApp.Step = 1;
                                var progress = new Progress<int>(v => { progressBarApp.Value = v; });
                                await Task.Run(() => DownloadPluAsync(progress));

                                if (SendHotKey())
                                {
                                    MessageBox.Show($"Plu Data Uploaded Scale {dev.DeviceName}.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show($"Plu Data Upload to Scale {dev.DeviceName} Failed.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                DisconnectScale();

                            }
                            else
                            {
                                ChangeScaleStatus(false, "Disconnected");
                                ChangeAppStatus(false, "Scale Connection Failed");
                            }
                        }
                        else
                            ChangeAppStatus(false, "Enter Correct IP");
                    }
                    else
                        ChangeAppStatus(false, "Enter Correct IP");

                    //listDevices.Where(x => x.DeviceIP == dev.DeviceIP).FirstOrDefault().Status = res ? "PLU Uploaded" : "Not Connected";
                }

                //FillDeviceList(listDevices);


                this.BeginInvoke((MethodInvoker)delegate ()
                { groupBox2.Enabled = true; });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke((MethodInvoker)delegate ()
                { groupBox2.Enabled = true; });
            }
        }

        private void btnUploadPluToScale_Click_Old(object sender, EventArgs e)
        {
            try
            {
                if (listPludata != null && listPludata.Count > 0) { }
                else
                {
                    MessageBox.Show("Kindly Get the PLU List", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (chkbxAllScale.Checked)
                {
                    var devList = GetAllDeviceDetailFromGrid();

                    foreach (var dev in devList)
                    {
                        if (dev.DeviceID == 0)
                            return;

                        //thread = new Thread(new ThreadStart(DownloadpluByJsonAsync));
                        //thread.IsBackground = true;
                        //// so not to have stray running threads if the main
                        ////form is closed
                        //thread.Start();
                        //// Display the Please Wait Dialog here
                        //loadingDlg = new LoadingForm();
                        //loadingDlg.ShowDialog(this);
                        //thread.Abort();



                        //UploadPluToScaleAsync(dev.DeviceIP);

                        bool res = UploadPluToScale(dev.DeviceIP);

                        listDevices.Where(x => x.DeviceIP == dev.DeviceIP).FirstOrDefault().Status = res ? "PLU Uploaded" : "Not Connected";
                    }

                    FillDeviceList(listDevices);
                }
                else
                {
                    var dev = GetSelectedDevicesDetailFromGrid().FirstOrDefault();
                    if (dev.DeviceID == 0)
                        return;
                    bool res = UploadPluToScale(dev.DeviceIP);

                    listDevices.Where(x => x.DeviceIP == dev.DeviceIP).FirstOrDefault().Status = res ? "PLU Uploaded" : "Not Connected";

                    FillDeviceList(listDevices);

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK);
            }
        }

        private bool UploadPluToScale(string ipadd)
        {
            try
            {
                ipadd = ipadd.Trim();
                if (!string.IsNullOrEmpty(ipadd))
                {
                    IPAddress iP;
                    if (IPAddress.TryParse(ipadd, out iP))
                    {
                        if (ConnectScale(ipadd))
                        {

                            thread = new Thread(new ThreadStart(DownloadpluByJson));
                            thread.IsBackground = true;
                            // so not to have stray running threads if the main
                            //form is closed
                            thread.Start();
                            // Display the Please Wait Dialog here
                            loadingDlg = new LoadingForm();
                            loadingDlg.ShowDialog(this);
                            thread.Abort();

                            //DownloadpluByJson();

                            if (SendHotKey())
                            {
                                MessageBox.Show("ok");
                                return true;
                            }
                            else
                                MessageBox.Show("Fail");

                            DisconnectScale();

                        }
                        else
                        {
                            ChangeScaleStatus(false, "Disconnected");
                            ChangeAppStatus(false, "Scale Connection Failed");
                        }
                    }
                    else
                        ChangeAppStatus(false, "Enter Correct IP");
                }
                else
                    ChangeAppStatus(false, "Enter Correct IP");
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK);
                thread.Abort();
                return false;
            }
        }

        private async void UploadPluToScaleAsync(string ipadd)
        {
            try
            {
                if (!string.IsNullOrEmpty(ipadd))
                {
                    IPAddress iP;
                    if (IPAddress.TryParse(ipadd, out iP))
                    {
                        if (ConnectScale(ipadd))
                        {

                            //thread = new Thread(new ThreadStart(DownloadpluByJsonAsync));
                            //thread.IsBackground = true;
                            //// so not to have stray running threads if the main
                            ////form is closed
                            //thread.Start();
                            //// Display the Please Wait Dialog here
                            //loadingDlg = new LoadingForm();
                            //loadingDlg.ShowDialog(this);
                            //thread.Abort();

                            DownloadpluByJsonAsync();

                            if (SendHotKey())
                            {
                                MessageBox.Show("ok");
                            }
                            else
                                MessageBox.Show("Fail");

                            DisconnectScale();

                        }
                        else
                        {
                            ChangeScaleStatus(false, "Disconnected");
                            ChangeAppStatus(false, "Scale Connection Failed");
                        }
                    }
                    else
                        ChangeAppStatus(false, "Enter Correct IP");
                }
                else
                    ChangeAppStatus(false, "Enter Correct IP");

                loadingDlg.ShouldCloseNow = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK);

                loadingDlg.ShouldCloseNow = true;
            }
        }

        private void btnSearchPLU_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtSearch.Text))
                    return;
                var strSearch = txtSearch.Text;
                List<PLUDataDB> searchList = new List<PLUDataDB>();
                switch (cmbxSearchFilter.SelectedIndex)
                {
                    case 0://ALL
                        {
                            searchList = listPludata.Where(x => (x.LFCode.ToString().Contains(strSearch.Trim()))
                            || (x.Code.ToString().Contains(strSearch.Trim()))
                            || (x.UnitPrice.ToString().Contains(strSearch.Trim()))
                            || (x.PluName.ToString().Contains(strSearch.Trim()))).ToList();
                        }
                        break;
                    case 1://LFCode
                        {
                            searchList = listPludata.Where(x => (x.LFCode.ToString().Contains(strSearch.Trim()))).ToList();
                        }
                        break;
                    case 2://Barcode
                        {
                            searchList = listPludata.Where(x => (x.Code.ToString().Contains(strSearch.Trim()))).ToList();
                        }
                        break;
                    case 3://PLUName
                        {
                            searchList = listPludata.Where(x => (x.PluName.ToString().Contains(strSearch.Trim()))).ToList();
                        }
                        break;
                    case 4://UnitPrice
                        {
                            searchList = listPludata.Where(x => (x.UnitPrice.ToString().Contains(strSearch.Trim()))).ToList();
                        }
                        break;
                    default:
                        break;
                }

                dgvPLUData.DataSource = null;
                dgvPLUData.DataSource = searchList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            dgvPLUData.DataSource = null;
            dgvPLUData.DataSource = listPludata;
            cmbxSearchFilter.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkbxAllScale_CheckedChanged(object sender, EventArgs e)
        {
            var devlist = GetAllDeviceDetailFromGrid();
            if (chkbxAllScale.Checked)
            {
                foreach (var item in devlist)
                {
                    item.Selected = true;
                }
            }
            else
            {
                foreach (var item in devlist)
                {
                    item.Selected = false;
                }
            }
            FillDeviceList(devlist);
        }

        private async void ChangeAppStatus(bool state, string message)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    lblAppStatus.Text = message;
                    if (state)
                        lblAppStatus.ForeColor = Color.Green;
                    else
                        lblAppStatus.ForeColor = Color.Red;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void ChangeScaleStatus(bool state, string message)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    lblScaleStatus.Text = message;
                    if (state)
                        lblScaleStatus.ForeColor = Color.Green;
                    else
                        lblScaleStatus.ForeColor = Color.Red;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillPLUList(DataTable dt)
        {
            try
            {

                listPludata = new List<PLUDataDB>();
                if (dt.Rows.Count == 0)
                {
                    dgvPLUData.DataSource = null;
                    MessageBox.Show($"No Data Found.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        listPludata.Add(new PLUDataDB
                        {
                            HotKey = i,
                            PluName = Convert.ToString(dt.Rows[i][clientDBSetup.PLUNameColumn]),
                            LFCode = Convert.ToInt32(dt.Rows[i][clientDBSetup.LFCodeColumn]),
                            Code = Convert.ToString(dt.Rows[i][clientDBSetup.BarcodeColumn]),
                            BarCode = 101,
                            UnitPrice = Convert.ToDecimal(dt.Rows[i][clientDBSetup.UnitPriceColumn]),
                            WeightUnit = 4,
                            QtyUnit = 0,
                            Deptment = 0,
                            Tare = 0,
                            ShlefTime = 0,
                            PackageType = 0,
                            PackageWeight = 0,
                            Tolerance = 0,
                            Message1 = 0,
                            Message2 = 0,
                            LabelId = 0,
                            Rebate = 0

                        });
                    }

                    dgvPLUData.DataSource = listPludata;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillPLUListLocal(DataTable dt)
        {
            try
            {

                listPludata = new List<PLUDataDB>();
                if (dt.Rows.Count == 0)
                {
                    dgvPLUData.DataSource = null;
                    MessageBox.Show($"No Data Found.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        listPludata.Add(new PLUDataDB
                        {
                            HotKey = i,
                            PluName = Convert.ToString(dt.Rows[i]["PLUName"]),
                            LFCode = Convert.ToInt32(dt.Rows[i]["LFCode"]),
                            Code = Convert.ToString(dt.Rows[i]["Barcode"]),
                            BarCode = 101,
                            UnitPrice = Convert.ToDecimal(dt.Rows[i]["UnitPrice"]),
                            WeightUnit = 4,
                            QtyUnit = 0,
                            Deptment = 0,
                            Tare = 0,
                            ShlefTime = 0,
                            PackageType = 0,
                            PackageWeight = 0,
                            Tolerance = 0,
                            Message1 = 0,
                            Message2 = 0,
                            LabelId = 0,
                            Rebate = 0

                        });
                    }

                    dgvPLUData.DataSource = listPludata;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillDeviceList(List<AppDeviceMaster> listDev)
        {
            try
            {

                listDevices = new List<AppDeviceMasterGrid>();

                if (listDev != null && listDev.Count > 0)
                {
                    DataGridTextBoxColumn dgLabel = new DataGridTextBoxColumn();
                    DataGridTableStyle dgStyle = new DataGridTableStyle();


                    foreach (var item in listDev)
                    {
                        listDevices.Add(new AppDeviceMasterGrid(
                            item.DeviceID,
                            item.DeviceIP,
                            item.DeviceName,
                            item.ScrollText,
                            "Disconnected",
                            false));

                    }
                    dgvDevices.DataSource = listDevices;
                }
                else
                {
                    MessageBox.Show($"No Devices Found ..!!!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillDeviceList(List<AppDeviceMasterGrid> listDev)
        {
            try
            {

                listDevices = new List<AppDeviceMasterGrid>();

                if (listDev != null && listDev.Count > 0)
                {
                    DataGridTextBoxColumn dgLabel = new DataGridTextBoxColumn();
                    DataGridTableStyle dgStyle = new DataGridTableStyle();


                    foreach (var item in listDev)
                    {
                        listDevices.Add(new AppDeviceMasterGrid(
                            item.DeviceID,
                            item.DeviceIP,
                            item.DeviceName,
                            item.ScrollText,
                            item.Status,
                            item.Selected));

                    }
                    dgvDevices.DataSource = null;
                    dgvDevices.DataSource = listDevices;
                }
                else
                {
                    MessageBox.Show($"No Devices Found ..!!!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private AppDeviceMasterGrid GetSelectedDeviceDetailFromGrid_UC()
        {
            try
            {

                int selectedRow = 0;
                if (dgvDevices.SelectedRows.Count > 0) { selectedRow = dgvDevices.SelectedRows[0].Index; }
                else if (dgvDevices.SelectedCells.Count > 0) { selectedRow = dgvDevices.SelectedCells[0].RowIndex; }
                else
                {
                    MessageBox.Show("Kindly Select a Device ..!!!", "Error", MessageBoxButtons.OK);
                    return new AppDeviceMasterGrid();
                }

                return new AppDeviceMasterGrid(
                    Convert.ToInt32(dgvDevices.Rows[selectedRow].Cells["DeviceID"].Value),
                    Convert.ToString(dgvDevices.Rows[selectedRow].Cells["DeviceIP"].Value),
                    Convert.ToString(dgvDevices.Rows[selectedRow].Cells["DeviceName"].Value),
                    Convert.ToString(dgvDevices.Rows[selectedRow].Cells["ScrollText"].Value),
                    Convert.ToString(dgvDevices.Rows[selectedRow].Cells["Status"].Value),
                    Convert.ToBoolean(dgvDevices.Rows[selectedRow].Cells["Selected"].Value)
                    );
            }
            catch (Exception)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK); return new AppDeviceMasterGrid();
            }

        }

        private List<AppDeviceMasterGrid> GetAllDeviceDetailFromGrid()
        {
            try
            {
                List<AppDeviceMasterGrid> ListDev = new List<AppDeviceMasterGrid>();
                for (int i = 0; i < dgvDevices.Rows.Count; i++)
                {
                    ListDev.Add(
                    new AppDeviceMasterGrid(
                    Convert.ToInt32(dgvDevices.Rows[i].Cells["DeviceID"].Value),
                    Convert.ToString(dgvDevices.Rows[i].Cells["DeviceIP"].Value),
                    Convert.ToString(dgvDevices.Rows[i].Cells["DeviceName"].Value),
                    Convert.ToString(dgvDevices.Rows[i].Cells["ScrollText"].Value),
                    Convert.ToString(dgvDevices.Rows[i].Cells["Status"].Value),
                    Convert.ToBoolean(dgvDevices.Rows[i].Cells["Selected"].Value)
                    ));
                }
                return ListDev;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<AppDeviceMasterGrid>();
            }

        }

        private List<AppDeviceMasterGrid> GetSelectedDevicesDetailFromGrid()
        {
            try
            {
                List<AppDeviceMasterGrid> ListDev = new List<AppDeviceMasterGrid>();
                for (int i = 0; i < dgvDevices.Rows.Count; i++)
                {
                    if ((bool)dgvDevices.Rows[i].Cells["Selected"].Value)
                    {
                        ListDev.Add(
                        new AppDeviceMasterGrid(
                        Convert.ToInt32(dgvDevices.Rows[i].Cells["DeviceID"].Value),
                        Convert.ToString(dgvDevices.Rows[i].Cells["DeviceIP"].Value),
                        Convert.ToString(dgvDevices.Rows[i].Cells["DeviceName"].Value),
                        Convert.ToString(dgvDevices.Rows[i].Cells["ScrollText"].Value),
                        Convert.ToString(dgvDevices.Rows[i].Cells["Status"].Value),
                        Convert.ToBoolean(dgvDevices.Rows[i].Cells["Selected"].Value)
                        ));
                    }
                }
                return ListDev;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<AppDeviceMasterGrid>();
            }

        }



        #region Device Functions

        private Boolean ConnectScale(string scaleIP)
        {
            //LabelScale.rtscaleLoadIniFile(@".\SYSTEM.CFG");

            if (!string.IsNullOrEmpty(scaleIP))
            {
                IPAddress iP;
                if (IPAddress.TryParse(scaleIP, out iP))
                {
                    int iRtn = LabelScale.rtscaleConnect(scaleIP, 0, ref connid);
                    if (iRtn >= 0)
                    {
                        ChangeScaleStatus(true, "Connected");
                        ChangeAppStatus(true, "Scale Connected");
                        return true;
                    }
                    else
                    {
                        ChangeScaleStatus(false, "Disconnected");
                        ChangeAppStatus(false, "Scale Connection Failed");
                    }
                }
                else
                    ChangeAppStatus(false, "Enter Correct IP");
            }
            else
                ChangeAppStatus(false, "Enter Correct IP");

            return false;

        }

        private Boolean DisconnectScale()
        {
            return LabelScale.rtscaleDisConnect(connid) == 0;//以太网断开 Ethernet disconnected
                                                             //  rtsdrv.rtscaleDisConnect(22); com断开 com disconnected
        }

        private Boolean SendHotKey()
        {

            //传送热键，要分三次传，1次只传84个 Send hotkey data to the scale, to be divided into three passes, one can only send 84
            int[] HotkeyTable = new int[84];
            for (int i = 0; i < 84; i++)
            {
                HotkeyTable[i] = 10001 + i; //对应LFCode Corresponding LFCode
            }
            if (LabelScale.rtscaleDownLoadHotkey(connid, HotkeyTable, 0) != 0)
                return false;

            for (int i = 0; i < 84; i++)
            {
                HotkeyTable[i] = 10001 + 84 + i;
            }
            if (LabelScale.rtscaleDownLoadHotkey(connid, HotkeyTable, 1) != 0)
                return false;

            for (int i = 0; i < 224 - 84 * 2; i++)
            {
                HotkeyTable[i] = 10001 + 84 * 2 + i;
            }
            if (LabelScale.rtscaleDownLoadHotkey(connid, HotkeyTable, 2) != 0)
                return false;
            return true;

        }


        public delegate void Callback([MarshalAs(UnmanagedType.LPStr)] string iRecNO, int iPack, int ACount);
        //sResult: retun the json data, iRecNO:Number of records   ACount:Total number of records
        //
        /**
            Json format:
              {
                "Weight": 2.88,
                "Quantity": 1,
                "WeightUnit": 4,
                "TotalPrice": 2.88,
                "UnitPrice": 12.96,
                "OnlineTime": "20180906094400",
                "LFCode": 2,
                "Rebate": 0,
                "SaleTime": "20180906094500",
                "PluName": "aaaa",
                "UserID": 80257,
                "Clerk": 0
               }
        **/
        public static void scaleAccountCallback(string sResult, int iRecNO, int ACount)
        {
            ScaleAccountData accountData;
            accountData = JsonConvert.DeserializeObject<ScaleAccountData>(sResult);
            string s = string.Format("UserId={0},Name={1},LFCode={2},unitPrice={3},WeightUnit={4},"
                  + "TotalPrice={5},Weight={6},saletime={7},Rebate={8},OnlineTime={9},Quantity={10},Clerk={11}",
                  accountData.UserID, accountData.PluName, accountData.LFCode, accountData.UnitPrice, accountData.WeightUnit,
                  accountData.TotalPrice, accountData.Weight, accountData.SaleTime, accountData.Rebate, accountData.OnlineTime,
                  accountData.Quantity, accountData.Clerk);


            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//文件存放路径，保证文件存在。
            String fileName = path + "salelist.txt";
            StreamWriter sw = new StreamWriter(fileName, true);
            sw.WriteLine(s);
            sw.Close();
        }


        public static string UnicodeToString(string srcText)
        {
            string dst = "";
            string src = srcText;
            int len = srcText.Length / 6;
            for (int i = 0; i <= len - 1; i++)
            {
                string str = "";
                str = src.Substring(0, 6).Substring(2);
                src = src.Substring(6);
                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                dst += Encoding.Unicode.GetString(bytes);
            }
            return dst;
        }

        //sResult: retun the json data, iRecNO:Number of records 当前第几条   ACount: Reserved 预留  一次一条
        public static void uploadPluDataCallback(string sResult, int iRecNO, int ACount)
        {
            //  MessageBox.Show(sResult);
            // System.Diagnostics.Debug.WriteLine(sResult);
            Pludata pluData = JsonConvert.DeserializeObject<Pludata>(sResult);
            String s = string.Format("PluName={0},LFCode={1},Code={2},BarCode={3},Rebate={4},"
                  + "UnitPrice={5},WeightUnit={6},Deptment={7},Tare={8},ShlefTime={9},PackageType={10},PackageWeight={11},"
                  + "Tolerance={12},Message1={13},MultiLabel={14},HotKey={15},iRecNO={16}",
                    pluData.PluName, pluData.LFCode, pluData.Code, pluData.BarCode, pluData.Rebate,
                  pluData.UnitPrice, pluData.WeightUnit, pluData.Deptment, pluData.Tare,
                  pluData.ShlefTime, pluData.PackageType, pluData.PackageWeight, pluData.Tolerance,
                  pluData.Message1, pluData.LabelId, pluData.HotKey, iRecNO
                  );

            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//文件存放路径，保证文件存在。
            String fileName = path + "plulist.csv";
            StreamWriter sw = new StreamWriter(fileName, true);
            sw.WriteLine(s);
            sw.Close();


        }

        //sResult: retun the json data, MsgId:ID corresponding to the information  信息ID   ACount: Reserved 预留
        public static void rtscaleUploadMessage(string sResult, int MsgId, int ACount)
        {
            JObject jo = (JObject)JsonConvert.DeserializeObject(sResult);
            MessageBox.Show(string.Format("MsgText={0},MsgId={1}", jo["MsgText"].ToString(), MsgId));
        }

        private void DownloadpluByJson()
        {
            try
            {

                List<Pludata> pluList = new List<Pludata>();
                foreach (var plu in listPludata)
                {
                    pluList.Add(new Pludata
                    {
                        HotKey = plu.HotKey,
                        PluName = plu.PluName,
                        LFCode = plu.LFCode,
                        Code = plu.Code,
                        BarCode = 101,
                        UnitPrice = Convert.ToInt32(plu.UnitPrice * 1000),
                        WeightUnit = 4,
                        QtyUnit = 0,
                        Deptment = 0,
                        Tare = 0,
                        ShlefTime = 0,
                        PackageType = 0,
                        PackageWeight = 0,
                        Tolerance = 0,
                        Message1 = 0,
                        Message2 = 0,
                        LabelId = 0,
                        Rebate = 0
                    });
                }

                int totalPLu = pluList.Count();
                int totalPackage = totalPLu / 4;
                int remainPLu = (totalPLu % 4);
                totalPackage = remainPLu == 0 ? totalPackage : totalPackage + 1;

                int traversePLu = 0;

                for (int TP = 0; TP < totalPackage; TP++)
                {
                    var obj = new JArray();

                    if (TP == totalPackage - 2)
                        for (int PI = 0; PI < remainPLu; PI++)
                        {
                            string sjson = JsonConvert.SerializeObject(pluList[traversePLu]);
                            JObject jo = (JObject)JsonConvert.DeserializeObject(sjson);
                            obj.Add(jo);
                            traversePLu += 1;
                        }
                    else
                        for (int PI = 0; PI < 4; PI++)
                        {
                            string sjson = JsonConvert.SerializeObject(pluList[traversePLu]);
                            JObject jo = (JObject)JsonConvert.DeserializeObject(sjson);
                            obj.Add(jo);
                            traversePLu += 1;
                        }
                    String stmp = obj.ToString();
                    //      StringBuilder sb = new StringBuilder(stmp);
                    if (LabelScale.rtscaleDownLoadPLU(connid, stmp, TP) != 0)
                    {
                        MessageBox.Show("Fail");
                    }

                }
                loadingDlg.ShouldCloseNow = true;
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loadingDlg.ShouldCloseNow = true;
                return;
            }
        }

        private void DownloadpluByJsonAsync()
        {
            List<Pludata> pluList = new List<Pludata>();
            foreach (var plu in listPludata)
            {
                pluList.Add(new Pludata
                {
                    HotKey = plu.HotKey,
                    PluName = plu.PluName,
                    LFCode = plu.LFCode,
                    Code = plu.Code,
                    BarCode = 101,
                    UnitPrice = Convert.ToInt32(plu.UnitPrice * 1000),
                    WeightUnit = 4,
                    QtyUnit = 0,
                    Deptment = 0,
                    Tare = 0,
                    ShlefTime = 0,
                    PackageType = 0,
                    PackageWeight = 0,
                    Tolerance = 0,
                    Message1 = 0,
                    Message2 = 0,
                    LabelId = 0,
                    Rebate = 0
                });
            }

            int totalPLu = pluList.Count();
            int totalPackage = totalPLu / 4;
            int remainPLu = (totalPLu % 4);
            totalPackage = remainPLu == 0 ? totalPackage : totalPackage + 1;

            int traversePLu = 0;

            for (int TP = 0; TP < totalPackage; TP++)
            {
                var obj = new JArray();

                if (TP == totalPackage - 2)
                    for (int PI = 0; PI < remainPLu; PI++)
                    {
                        string sjson = JsonConvert.SerializeObject(pluList[traversePLu]);
                        JObject jo = (JObject)JsonConvert.DeserializeObject(sjson);
                        obj.Add(jo);
                        traversePLu += 1;
                    }
                else
                    for (int PI = 0; PI < 4; PI++)
                    {
                        string sjson = JsonConvert.SerializeObject(pluList[traversePLu]);
                        JObject jo = (JObject)JsonConvert.DeserializeObject(sjson);
                        obj.Add(jo);
                        traversePLu += 1;
                    }
                String stmp = obj.ToString();
                //Thread.Sleep(300);
                //      StringBuilder sb = new StringBuilder(stmp);
                if (LabelScale.rtscaleDownLoadPLU(connid, stmp, TP) != 0)
                {
                    MessageBox.Show("Fail");
                }

            }
            return;

        }

        private void DownloadPluAsync(IProgress<int> progress)
        {
            try
            {
                List<Pludata> pluList = new List<Pludata>();
                foreach (var plu in listPludata)
                {
                    pluList.Add(new Pludata
                    {
                        HotKey = plu.HotKey,
                        PluName = plu.PluName,
                        LFCode = plu.LFCode,
                        Code = plu.Code,
                        BarCode = 101,
                        UnitPrice = Convert.ToInt32(plu.UnitPrice * 1000),
                        WeightUnit = 4,
                        QtyUnit = 0,
                        Deptment = 0,
                        Tare = 0,
                        ShlefTime = 0,
                        PackageType = 0,
                        PackageWeight = 0,
                        Tolerance = 0,
                        Message1 = 0,
                        Message2 = 0,
                        LabelId = 0,
                        Rebate = 0
                    });
                }

                int totalPLu = pluList.Count();
                int totalPackage = totalPLu / 4;
                int remainPLu = (totalPLu % 4);
                totalPackage = remainPLu == 0 ? totalPackage : totalPackage + 1;

                int traversePLu = 0;

                for (int TP = 0; TP < totalPackage; TP++)
                {
                    var obj = new JArray();

                    if (TP == totalPackage - 2)
                        for (int PI = 0; PI < remainPLu; PI++)
                        {
                            string sjson = JsonConvert.SerializeObject(pluList[traversePLu]);
                            JObject jo = (JObject)JsonConvert.DeserializeObject(sjson);
                            obj.Add(jo);
                            traversePLu += 1;
                        }
                    else
                        for (int PI = 0; PI < 4; PI++)
                        {
                            string sjson = JsonConvert.SerializeObject(pluList[traversePLu]);
                            JObject jo = (JObject)JsonConvert.DeserializeObject(sjson);
                            obj.Add(jo);
                            traversePLu += 1;
                        }
                    progress.Report(traversePLu);
                    String stmp = obj.ToString();
                    //      StringBuilder sb = new StringBuilder(stmp);
                    if (LabelScale.rtscaleDownLoadPLU(connid, stmp, TP) != 0)
                    {
                        MessageBox.Show("Fail");
                        break;
                    }

                }
                progress.Report(totalPLu);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion
    }

    public class AppDeviceMasterGrid
    {
        public bool Selected { get; set; }
        public string Status { get; set; }
        public int DeviceID { get; }
        public string DeviceIP { get; }
        public string DeviceName { get; }
        public string ScrollText { get; }

        public AppDeviceMasterGrid(
            int _DeviceID,
            string _DeviceIP,
            string _DeviceName,
            string _ScrollText,
            string _Status,
            bool _Selected)
        {
            DeviceID = _DeviceID;
            DeviceIP = _DeviceIP;
            DeviceName = _DeviceName;
            ScrollText = _ScrollText;
            Status = _Status;
            Selected = _Selected;
        }
        public AppDeviceMasterGrid()
        {
            DeviceID = 0;
            DeviceIP = "";
            DeviceName = "";
            ScrollText = "";
            Status = "Disconnected";
            Selected = false;
        }
    }
}
