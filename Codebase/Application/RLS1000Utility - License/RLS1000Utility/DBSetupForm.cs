using RLS1000Utility.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLS1000Utility
{
    public partial class DBSetupForm : Form
    {
        string SourceTableName = string.Empty;

        MSDASC.DataLinks mydlg = new MSDASC.DataLinks();
        ADODB.Connection scn = new ADODB.Connection();
        OleDbConnection ClientConnection = new OleDbConnection();
        AppConfigurationDASqLite DA;
        public DBSetupForm()
        {
            InitializeComponent();
            DA = new AppConfigurationDASqLite();
        }

        private void DBSetupForm_Load(object sender, EventArgs e)
        {
            var cdbs = DA.GetClientDBSetup();

            if (cdbs != null && cdbs.ID != 0)
            {
                txtDBObjectName.Text = cdbs.DBObjectName;
                txtDBConnectionString.Text = cdbs.ConnString;
                txtLFCodeColumn.Text = cdbs.LFCodeColumn;
                txtBarcodeColumn.Text = cdbs.BarcodeColumn;
                txtPluNameColumn.Text = cdbs.PLUNameColumn;
                txtUnitPriceColumn.Text = cdbs.UnitPriceColumn;
            }

        }

        private void btnSaveParameter_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 1;
            try
            {
                if (ClientConnection.ConnectionString.Length <= 0)
                {
                    object o = (object)scn;
                    mydlg.PromptEdit(ref o);

                    var clientConnection = scn.ConnectionString;
                    ClientConnection.ConnectionString = scn.ConnectionString;
                }
                if (ClientConnection.ConnectionString.Length > 0)
                {
                    BindItemTables();
                    pnlitems.Enabled = true;
                    pnlParameter.Enabled = true;
                    tabControl2.SelectedIndex = 1;
                }
                txtConnectionString.Text = ClientConnection.ConnectionString;
            }
            catch
            {

            }
        }

        public void BindItemTables()
        {
            try
            {
                lstitemTables.Items.Clear();
                lstitemSheet.Items.Clear();
                lstItemViews.Items.Clear();
                //if (online == true)
                if (true)
                {
                    DataTable sdt = new DataTable();
                    ClientConnection.Open();
                    sdt = ClientConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    //sdt = ClientConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, null });
                    DataTable sviewsdt = ClientConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "VIEW" });
                    for (int i = 0; i < sdt.Rows.Count; i++)
                    {
                        lstitemTables.Items.Add(sdt.Rows[i]["Table_Name"].ToString());
                    }
                    for (int i = 0; i < sviewsdt.Rows.Count; i++)
                    {
                        lstItemViews.Items.Add(sviewsdt.Rows[i]["Table_Name"].ToString());
                    }
                    ClientConnection.Close();


                }


                //else
                //    if (false)
                //{
                //    DataTable ExcelTablesdt = new DataTable();
                //    strcon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelPath + ";Extended Properties='Excel 12.0;IMEX=1;HDR=" + "Yes" + "'";
                //    ExcelTablesdt = dac.gellallExcelSheets(strcon);
                //    for (int i = 0; i < ExcelTablesdt.Rows.Count; i++)
                //    {
                //        lstitemSheet.Items.Add(ExcelTablesdt.Rows[i]["Table_Name"].ToString());
                //    }

                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void lstitemTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstitemTables.SelectedIndex >= 0)
            {
                SourceTableName = lstitemTables.SelectedItem.ToString();
                lstItemViews.ClearSelected();
                lstitemSheet.ClearSelected();
                cmbitemsCols.Items.Clear();
                txtLFCode.Text = "";
                txtbarcode.Text = "";
                txtPluName.Text = "";
                txtUnitPrice.Text = "";

            }
        }

        private void lstItemViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItemViews.SelectedIndex >= 0)
            {
                SourceTableName = lstItemViews.SelectedItem.ToString();
                lstitemTables.ClearSelected();
                lstitemSheet.ClearSelected();
                cmbitemsCols.Items.Clear();
                txtLFCode.Text = "";
                txtbarcode.Text = "";
                txtPluName.Text = "";
                txtUnitPrice.Text = "";
            }
        }

        private void lstitemSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstitemSheet.SelectedIndex >= 0)
            {
                SourceTableName = lstitemSheet.SelectedItem.ToString();
                lstitemTables.ClearSelected();
                lstItemViews.ClearSelected();
                cmbitemsCols.Items.Clear();
                txtLFCode.Text = "";
                txtbarcode.Text = "";
                txtPluName.Text = "";
                txtUnitPrice.Text = "";
            }
        }

        private void btnBindItemCols_Click(object sender, EventArgs e)
        {
            if (SourceTableName.Length > 0)
            {
                BindSourceColumns(SourceTableName);
            }
            else
            {
                MessageBox.Show("Select Item Table Name", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void BindSourceColumns(string tablename)
        {
            DataTable cols = new DataTable();
            try
            {
                cmbitemsCols.Items.Clear();


                ClientConnection.Open();
                cols = ClientConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns,
    new object[] { null, null, tablename, null });
                ClientConnection.Close();
                for (int i = 0; i < cols.Rows.Count; i++)
                {
                    cmbitemsCols.Items.Add(cols.Rows[i]["Column_Name"].ToString());
                }

                cmbitemsCols.SelectedIndex = 0;

            }

            catch
            {
                if (ClientConnection.State == ConnectionState.Open)
                {
                    ClientConnection.Close();
                }

                MessageBox.Show("Error Occured", "Master Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void btnbarcode_Click(object sender, EventArgs e)
        {
            try
            {
                txtbarcode.Text = cmbitemsCols.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select Column Name", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLFCode_Click(object sender, EventArgs e)
        {
            try
            {
                txtLFCode.Text = cmbitemsCols.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select Column Name", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnitPrice_Click(object sender, EventArgs e)
        {
            try
            {
                txtUnitPrice.Text = cmbitemsCols.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select Column Name", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPLUName_Click(object sender, EventArgs e)
        {
            try
            {
                txtPluName.Text = cmbitemsCols.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select Column Name", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnItemSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(SourceTableName))
                    return;
                if (string.IsNullOrEmpty(txtbarcode.Text))
                    return;
                if (string.IsNullOrEmpty(txtLFCode.Text))
                    return;
                if (string.IsNullOrEmpty(txtPluName.Text))
                    return;
                if (string.IsNullOrEmpty(txtUnitPrice.Text))
                    return;

                var cdbs = DA.GetClientDBSetup();

                bool res = false;
                if (cdbs != null && cdbs.ID != 0)
                {
                    res = DA.UpdateClientDBSetup(new Models.ClientDBSetup(1, 1, 1, 1, 1, 1,
                        ClientConnection.ConnectionString, SourceTableName, txtLFCode.Text, txtbarcode.Text, txtPluName.Text, txtUnitPrice.Text));
                }
                else
                {
                    res = DA.InsertClientDBSetup(new Models.ClientDBSetup(1, 1, 1, 1, 1, 1,
                        ClientConnection.ConnectionString, SourceTableName, txtLFCode.Text, txtbarcode.Text, txtPluName.Text, txtUnitPrice.Text));
                }
                if (res)
                {
                    MessageBox.Show("Parameters Saved Successfully!", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Parameters Saved Not Saved", "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message, "Pegasus PLS Scale Middleware", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DBSetupForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(198, 11, 7), ButtonBorderStyle.Solid);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            ClientConnection.ConnectionString = "";
            tabControl2.SelectedIndex = 0;
            pnlParameter.Enabled = true;
            pnlitems.Enabled = false;
            txtConnectionString.Text = "";
            lstitemSheet.Items.Clear();
            lstitemTables.Items.Clear();
            lstItemViews.Items.Clear();
            cmbitemsCols.Items.Clear();
            txtbarcode.Text = "";
            txtLFCode.Text = "";
            txtPluName.Text = "";
            txtUnitPrice.Text = "";
        }
    }
}
