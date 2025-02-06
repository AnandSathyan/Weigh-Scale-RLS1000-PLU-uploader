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
    public partial class DeviceMasterForm : Form
    {
        AppConfigurationDASqLite ConfigurationDA;
        AppDeviceMaster SelectedDevice;
        public DeviceMasterForm()
        {
            InitializeComponent();
            ConfigurationDA = new AppConfigurationDASqLite();
        }

        private void DeviceMasterForm_Load(object sender, EventArgs e)
        {
            try
            {

                var listDev = ConfigurationDA.GetAppDeviceMaster();
                if (listDev != null && listDev.Count > 0)
                {
                    dgvDevices.DataSource = listDev;
                }
                else
                {
                    MessageBox.Show("No Devices Found ..!!!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeviceMasterForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(198, 11, 7), ButtonBorderStyle.Solid);
        }

        private void btnSelectDevice_Click(object sender, EventArgs e)
        {
            int selectedRow = 0;
            if (dgvDevices.SelectedRows.Count > 0) { selectedRow = dgvDevices.SelectedRows[0].Index; }
            else if (dgvDevices.SelectedCells.Count > 0) { selectedRow = dgvDevices.SelectedCells[0].RowIndex; }
            else
            {
                MessageBox.Show("Kindly Select a Device ..!!!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SelectedDevice = new AppDeviceMaster(
                            Convert.ToInt32(dgvDevices.Rows[selectedRow].Cells[0].Value),
                            Convert.ToString(dgvDevices.Rows[selectedRow].Cells[1].Value),
                            Convert.ToString(dgvDevices.Rows[selectedRow].Cells[2].Value),
                            Convert.ToString(dgvDevices.Rows[selectedRow].Cells[3].Value),
                            Convert.ToString(dgvDevices.Rows[selectedRow].Cells[4].Value),
                            Convert.ToString(dgvDevices.Rows[selectedRow].Cells[5].Value),
                            Convert.ToString(dgvDevices.Rows[selectedRow].Cells[6].Value),
                            Convert.ToInt32(dgvDevices.Rows[selectedRow].Cells[7].Value),
                            Convert.ToInt32(dgvDevices.Rows[selectedRow].Cells[8].Value),
                            Convert.ToString(dgvDevices.Rows[selectedRow].Cells[9].Value),
                            Convert.ToString(dgvDevices.Rows[selectedRow].Cells[10].Value),
                            Convert.ToString(dgvDevices.Rows[selectedRow].Cells[11].Value),
                            Convert.ToString(dgvDevices.Rows[selectedRow].Cells[12].Value),
                            Convert.ToString(dgvDevices.Rows[selectedRow].Cells[13].Value),
                            Convert.ToString(dgvDevices.Rows[selectedRow].Cells[14].Value)
                        );
            txtDeviceID.Text = Convert.ToString(SelectedDevice.DeviceID);
            txtDeviceLicenseID.Text = Convert.ToString(SelectedDevice.Lic_Customer_Licesnse_Id);
            txtDeviceName.Text = Convert.ToString(SelectedDevice.DeviceName);
            txtDeviceIPAddress.Text = Convert.ToString(SelectedDevice.DeviceIP);
            txtDeviceScrollText.Text = Convert.ToString(SelectedDevice.ScrollText);

        }

        private void btnSavrDeviceDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDeviceID.Text))
                {
                    if (string.IsNullOrEmpty(txtDeviceIPAddress.Text))
                    {
                        MessageBox.Show("Kindly Enter Scale IP Address ..!!!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrEmpty(txtDeviceName.Text))
                    {
                        MessageBox.Show("Kindly Enter Scale Name ..!!!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SelectedDevice = new AppDeviceMaster(
                                    SelectedDevice.DeviceID,
                                    txtDeviceIPAddress.Text.Trim(),
                                    txtDeviceName.Text.Trim(),
                                    SelectedDevice.SourcePath,
                                    SelectedDevice.DestinationPath,
                                    SelectedDevice.FileType,
                                    txtDeviceScrollText.Text.Trim(),
                                    SelectedDevice.Lang,
                                    SelectedDevice.IsUpdate,
                                    SelectedDevice.Regsitration_Date,
                                    SelectedDevice.Expiry_Date,
                                    SelectedDevice.Lic_Customer_Licesnse_Id,
                                    SelectedDevice.Lic_Product_Id,
                                    SelectedDevice.Lic_Code,
                                    SelectedDevice.License_Key
                                );
                    ConfigurationDA.UpdateAppDeviceMaster(SelectedDevice);

                    txtDeviceID.Text = "";
                    txtDeviceLicenseID.Text = "";
                    txtDeviceName.Text = "";
                    txtDeviceIPAddress.Text = "";
                    txtDeviceScrollText.Text = "";

                    dgvDevices.DataSource = null;
                    var listDev = ConfigurationDA.GetAppDeviceMaster();
                    if (listDev != null && listDev.Count > 0)
                    {
                        dgvDevices.DataSource = listDev;
                    }
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
    }
}
