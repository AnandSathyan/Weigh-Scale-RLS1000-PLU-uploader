namespace RLS1000Utility
{
    partial class ScaleUtilityForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbxSearchFilter = new System.Windows.Forms.ComboBox();
            this.progressBarApp = new System.Windows.Forms.ProgressBar();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblAppStatus = new System.Windows.Forms.Label();
            this.lblScaleStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnResetSearch = new System.Windows.Forms.Button();
            this.btnSearchPLU = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkbxAllScale = new System.Windows.Forms.CheckBox();
            this.chkbxPLUOnline = new System.Windows.Forms.CheckBox();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.btnChangeScaleScrollText = new System.Windows.Forms.Button();
            this.btnClearPLUList = new System.Windows.Forms.Button();
            this.btnGetPLU = new System.Windows.Forms.Button();
            this.btnChecckWeight = new System.Windows.Forms.Button();
            this.btnClearPluDataOnScale = new System.Windows.Forms.Button();
            this.btnDownloadPluFromScale = new System.Windows.Forms.Button();
            this.btnUploadPluToScale = new System.Windows.Forms.Button();
            this.btnCheckScaleConnection = new System.Windows.Forms.Button();
            this.dgvPLUData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLUData)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbxSearchFilter);
            this.panel1.Controls.Add(this.progressBarApp);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.lblAppStatus);
            this.panel1.Controls.Add(this.lblScaleStatus);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnResetSearch);
            this.panel1.Controls.Add(this.btnSearchPLU);
            this.panel1.Location = new System.Drawing.Point(12, 683);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 98);
            this.panel1.TabIndex = 0;
            // 
            // cmbxSearchFilter
            // 
            this.cmbxSearchFilter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbxSearchFilter.FormattingEnabled = true;
            this.cmbxSearchFilter.Items.AddRange(new object[] {
            "ALL",
            "LFCode",
            "Barcode",
            "PLUName",
            "UnitPrice"});
            this.cmbxSearchFilter.Location = new System.Drawing.Point(445, 30);
            this.cmbxSearchFilter.Name = "cmbxSearchFilter";
            this.cmbxSearchFilter.Size = new System.Drawing.Size(121, 29);
            this.cmbxSearchFilter.TabIndex = 33;
            // 
            // progressBarApp
            // 
            this.progressBarApp.Location = new System.Drawing.Point(7, 70);
            this.progressBarApp.Name = "progressBarApp";
            this.progressBarApp.Size = new System.Drawing.Size(339, 23);
            this.progressBarApp.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(929, 27);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 50);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(572, 31);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(284, 26);
            this.txtSearch.TabIndex = 3;
            // 
            // lblAppStatus
            // 
            this.lblAppStatus.AutoSize = true;
            this.lblAppStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppStatus.Location = new System.Drawing.Point(101, 10);
            this.lblAppStatus.Name = "lblAppStatus";
            this.lblAppStatus.Size = new System.Drawing.Size(92, 20);
            this.lblAppStatus.TabIndex = 5;
            this.lblAppStatus.Text = "No Status";
            // 
            // lblScaleStatus
            // 
            this.lblScaleStatus.AutoSize = true;
            this.lblScaleStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScaleStatus.Location = new System.Drawing.Point(113, 47);
            this.lblScaleStatus.Name = "lblScaleStatus";
            this.lblScaleStatus.Size = new System.Drawing.Size(92, 20);
            this.lblScaleStatus.TabIndex = 6;
            this.lblScaleStatus.Text = "No Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "App Status : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Scale Status : ";
            // 
            // btnResetSearch
            // 
            this.btnResetSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetSearch.Location = new System.Drawing.Point(572, 63);
            this.btnResetSearch.Name = "btnResetSearch";
            this.btnResetSearch.Size = new System.Drawing.Size(133, 30);
            this.btnResetSearch.TabIndex = 2;
            this.btnResetSearch.Text = "Reset";
            this.btnResetSearch.UseVisualStyleBackColor = true;
            this.btnResetSearch.Click += new System.EventHandler(this.btnResetSearch_Click);
            // 
            // btnSearchPLU
            // 
            this.btnSearchPLU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPLU.Location = new System.Drawing.Point(711, 63);
            this.btnSearchPLU.Name = "btnSearchPLU";
            this.btnSearchPLU.Size = new System.Drawing.Size(145, 30);
            this.btnSearchPLU.TabIndex = 2;
            this.btnSearchPLU.Text = "Search";
            this.btnSearchPLU.UseVisualStyleBackColor = true;
            this.btnSearchPLU.Click += new System.EventHandler(this.btnSearchPLU_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox2.Controls.Add(this.chkbxAllScale);
            this.groupBox2.Controls.Add(this.chkbxPLUOnline);
            this.groupBox2.Controls.Add(this.tbWeight);
            this.groupBox2.Controls.Add(this.btnChangeScaleScrollText);
            this.groupBox2.Controls.Add(this.btnClearPLUList);
            this.groupBox2.Controls.Add(this.btnGetPLU);
            this.groupBox2.Controls.Add(this.btnChecckWeight);
            this.groupBox2.Controls.Add(this.btnClearPluDataOnScale);
            this.groupBox2.Controls.Add(this.btnDownloadPluFromScale);
            this.groupBox2.Controls.Add(this.btnUploadPluToScale);
            this.groupBox2.Controls.Add(this.btnCheckScaleConnection);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 330);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scale Functions";
            // 
            // chkbxAllScale
            // 
            this.chkbxAllScale.AutoSize = true;
            this.chkbxAllScale.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkbxAllScale.Location = new System.Drawing.Point(10, 97);
            this.chkbxAllScale.Name = "chkbxAllScale";
            this.chkbxAllScale.Size = new System.Drawing.Size(104, 25);
            this.chkbxAllScale.TabIndex = 4;
            this.chkbxAllScale.Text = "All Scale";
            this.chkbxAllScale.UseVisualStyleBackColor = true;
            this.chkbxAllScale.CheckedChanged += new System.EventHandler(this.chkbxAllScale_CheckedChanged);
            // 
            // chkbxPLUOnline
            // 
            this.chkbxPLUOnline.AutoSize = true;
            this.chkbxPLUOnline.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkbxPLUOnline.Location = new System.Drawing.Point(10, 64);
            this.chkbxPLUOnline.Name = "chkbxPLUOnline";
            this.chkbxPLUOnline.Size = new System.Drawing.Size(126, 25);
            this.chkbxPLUOnline.TabIndex = 4;
            this.chkbxPLUOnline.Text = "Online PLU";
            this.chkbxPLUOnline.UseVisualStyleBackColor = true;
            // 
            // tbWeight
            // 
            this.tbWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbWeight.Location = new System.Drawing.Point(10, 135);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(112, 26);
            this.tbWeight.TabIndex = 3;
            // 
            // btnChangeScaleScrollText
            // 
            this.btnChangeScaleScrollText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeScaleScrollText.Location = new System.Drawing.Point(10, 205);
            this.btnChangeScaleScrollText.Name = "btnChangeScaleScrollText";
            this.btnChangeScaleScrollText.Size = new System.Drawing.Size(263, 30);
            this.btnChangeScaleScrollText.TabIndex = 2;
            this.btnChangeScaleScrollText.Text = "Change Scroll Text";
            this.btnChangeScaleScrollText.UseVisualStyleBackColor = true;
            this.btnChangeScaleScrollText.Click += new System.EventHandler(this.btnChangeScaleScrollText_Click);
            // 
            // btnClearPLUList
            // 
            this.btnClearPLUList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearPLUList.Location = new System.Drawing.Point(142, 97);
            this.btnClearPLUList.Name = "btnClearPLUList";
            this.btnClearPLUList.Size = new System.Drawing.Size(131, 30);
            this.btnClearPLUList.TabIndex = 2;
            this.btnClearPLUList.Text = "Clear PLU List";
            this.btnClearPLUList.UseVisualStyleBackColor = true;
            this.btnClearPLUList.Click += new System.EventHandler(this.btnClearPLUList_Click);
            // 
            // btnGetPLU
            // 
            this.btnGetPLU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPLU.Location = new System.Drawing.Point(142, 61);
            this.btnGetPLU.Name = "btnGetPLU";
            this.btnGetPLU.Size = new System.Drawing.Size(131, 30);
            this.btnGetPLU.TabIndex = 2;
            this.btnGetPLU.Text = "Check PLU";
            this.btnGetPLU.UseVisualStyleBackColor = true;
            this.btnGetPLU.Click += new System.EventHandler(this.btnGetPLU_Click);
            // 
            // btnChecckWeight
            // 
            this.btnChecckWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChecckWeight.Location = new System.Drawing.Point(128, 133);
            this.btnChecckWeight.Name = "btnChecckWeight";
            this.btnChecckWeight.Size = new System.Drawing.Size(145, 30);
            this.btnChecckWeight.TabIndex = 2;
            this.btnChecckWeight.Text = "Check Weight";
            this.btnChecckWeight.UseVisualStyleBackColor = true;
            this.btnChecckWeight.Click += new System.EventHandler(this.btnChecckWeight_Click);
            // 
            // btnClearPluDataOnScale
            // 
            this.btnClearPluDataOnScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearPluDataOnScale.Location = new System.Drawing.Point(10, 169);
            this.btnClearPluDataOnScale.Name = "btnClearPluDataOnScale";
            this.btnClearPluDataOnScale.Size = new System.Drawing.Size(263, 30);
            this.btnClearPluDataOnScale.TabIndex = 2;
            this.btnClearPluDataOnScale.Text = "Clear PLU On Scale";
            this.btnClearPluDataOnScale.UseVisualStyleBackColor = true;
            this.btnClearPluDataOnScale.Click += new System.EventHandler(this.btnClearPluDataOnScale_Click);
            // 
            // btnDownloadPluFromScale
            // 
            this.btnDownloadPluFromScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadPluFromScale.Location = new System.Drawing.Point(10, 241);
            this.btnDownloadPluFromScale.Name = "btnDownloadPluFromScale";
            this.btnDownloadPluFromScale.Size = new System.Drawing.Size(263, 30);
            this.btnDownloadPluFromScale.TabIndex = 2;
            this.btnDownloadPluFromScale.Text = "Download PLU From Scale";
            this.btnDownloadPluFromScale.UseVisualStyleBackColor = true;
            this.btnDownloadPluFromScale.Click += new System.EventHandler(this.btnDownloadPluFromScale_Click);
            // 
            // btnUploadPluToScale
            // 
            this.btnUploadPluToScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadPluToScale.Location = new System.Drawing.Point(10, 277);
            this.btnUploadPluToScale.Name = "btnUploadPluToScale";
            this.btnUploadPluToScale.Size = new System.Drawing.Size(263, 30);
            this.btnUploadPluToScale.TabIndex = 2;
            this.btnUploadPluToScale.Text = "Upload PLU To Scale";
            this.btnUploadPluToScale.UseVisualStyleBackColor = true;
            this.btnUploadPluToScale.Click += new System.EventHandler(this.btnUploadPluToScale_Click);
            // 
            // btnCheckScaleConnection
            // 
            this.btnCheckScaleConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckScaleConnection.Location = new System.Drawing.Point(10, 23);
            this.btnCheckScaleConnection.Name = "btnCheckScaleConnection";
            this.btnCheckScaleConnection.Size = new System.Drawing.Size(263, 30);
            this.btnCheckScaleConnection.TabIndex = 2;
            this.btnCheckScaleConnection.Text = "Check Connection";
            this.btnCheckScaleConnection.UseVisualStyleBackColor = true;
            this.btnCheckScaleConnection.Click += new System.EventHandler(this.btnCheckScaleConnection_Click);
            // 
            // dgvPLUData
            // 
            this.dgvPLUData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPLUData.Location = new System.Drawing.Point(12, 348);
            this.dgvPLUData.Name = "dgvPLUData";
            this.dgvPLUData.ReadOnly = true;
            this.dgvPLUData.RowHeadersWidth = 51;
            this.dgvPLUData.RowTemplate.Height = 24;
            this.dgvPLUData.Size = new System.Drawing.Size(976, 329);
            this.dgvPLUData.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.groupBox1.Controls.Add(this.dgvDevices);
            this.groupBox1.Location = new System.Drawing.Point(305, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 329);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scales List";
            // 
            // dgvDevices
            // 
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Location = new System.Drawing.Point(6, 22);
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.RowHeadersWidth = 51;
            this.dgvDevices.RowTemplate.Height = 26;
            this.dgvDevices.Size = new System.Drawing.Size(671, 301);
            this.dgvDevices.TabIndex = 0;
            // 
            // ScaleUtilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPLUData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScaleUtilityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScaleUtilityForm";
            this.Load += new System.EventHandler(this.ScaleUtilityForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ScaleUtilityForm_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLUData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAppStatus;
        private System.Windows.Forms.Label lblScaleStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBarApp;
        private System.Windows.Forms.TextBox tbWeight;
        private System.Windows.Forms.Button btnChangeScaleScrollText;
        private System.Windows.Forms.Button btnClearPLUList;
        private System.Windows.Forms.Button btnGetPLU;
        private System.Windows.Forms.Button btnChecckWeight;
        private System.Windows.Forms.Button btnClearPluDataOnScale;
        private System.Windows.Forms.Button btnDownloadPluFromScale;
        private System.Windows.Forms.Button btnUploadPluToScale;
        private System.Windows.Forms.Button btnCheckScaleConnection;
        private System.Windows.Forms.CheckBox chkbxPLUOnline;
        private System.Windows.Forms.DataGridView dgvPLUData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.CheckBox chkbxAllScale;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearchPLU;
        private System.Windows.Forms.Button btnResetSearch;
        private System.Windows.Forms.ComboBox cmbxSearchFilter;
    }
}