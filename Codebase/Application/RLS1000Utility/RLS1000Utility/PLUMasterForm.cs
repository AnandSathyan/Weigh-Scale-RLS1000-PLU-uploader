using RLS1000Utility.DataAccess;
using RLS1000Utility.DeviceUtility;
using RLS1000Utility.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RLS1000Utility
{
    public partial class PLUMasterForm : Form
    {
        AppConfigurationDASqLite ConfigurationDA;
        private readonly ClientDBSetup clientDBSetup;
        PLUDAOleDB pLUDA;

        List<PLUDataDB> listPludata;

        Thread thread;
        LoadingForm loadingDlg;
        public PLUMasterForm()
        {
            InitializeComponent();
            ConfigurationDA = new AppConfigurationDASqLite();
            clientDBSetup = ConfigurationDA.GetClientDBSetup();
        }

        private void PLUMasterForm_Load(object sender, EventArgs e)
        {
            try
            {

                if (clientDBSetup != null && clientDBSetup.ID != 0)
                {
                    pLUDA = new PLUDAOleDB(clientDBSetup.ConnString);
                }
                else
                {
                    MessageBox.Show("Kindly Setup Client Server DB", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PLUMasterForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(198, 11, 7), ButtonBorderStyle.Solid);
        }

        private void brnCheckServerConnection_Click(object sender, EventArgs e)
        {
            try
            {

                if (pLUDA.OpenConnection())
                {
                    pLUDA.CloseConnection();

                    MessageBox.Show("Client Server connected.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                MessageBox.Show("Client Server not connected.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetPLUFromServer_Click(object sender, EventArgs e)
        {
            try
            {

                listPludata = new List<PLUDataDB>();
                DataTable dt = pLUDA.GetAllPLUData
                    ($"SELECT {clientDBSetup.LFCodeColumn},{clientDBSetup.BarcodeColumn},{clientDBSetup.PLUNameColumn},{clientDBSetup.UnitPriceColumn} FROM {clientDBSetup.DBObjectName}");
                if (dt.Rows.Count == 0)
                {
                    dgvPLUData.DataSource = null;
                    MessageBox.Show("No Data Found.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnGetPLUFromLocal_Click(object sender, EventArgs e)
        {
            try
            {

                listPludata = new List<PLUDataDB>();
                DataTable dt = ConfigurationDA.GetAppPLUData();

                if (dt.Rows.Count == 0)
                {
                    dgvPLUData.DataSource = null;
                    MessageBox.Show("No Data Found.", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveLocal_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(SavePLULocal));
            thread.IsBackground = true;
            // so not to have stray running threads if the main
            //form is closed
            thread.Start();
            // Display the Please Wait Dialog here
            loadingDlg = new LoadingForm();
            loadingDlg.ShowDialog(this);
            thread.Abort();
        }

        private void SavePLULocal()
        {

            if (listPludata != null && listPludata.Count > 0)
            {
                ConfigurationDA.DeleteAllAppPLUData();

                foreach (PLUDataDB pludata in listPludata)
                {
                    ConfigurationDA.InsertAppPLUData(pludata);
                }
            }
            loadingDlg.ShouldCloseNow = true;
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            listPludata = new List<PLUDataDB>();
            dgvPLUData.DataSource = null;
        }
    }
}
