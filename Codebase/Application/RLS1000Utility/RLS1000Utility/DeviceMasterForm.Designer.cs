namespace RLS1000Utility
{
    partial class DeviceMasterForm
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
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSavrDeviceDetails = new System.Windows.Forms.Button();
            this.btnSelectDevice = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeviceScrollText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeviceIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeviceLicenseID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeviceID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDevices);
            this.panel1.Location = new System.Drawing.Point(13, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 329);
            this.panel1.TabIndex = 0;
            // 
            // dgvDevices
            // 
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Location = new System.Drawing.Point(4, 4);
            this.dgvDevices.MultiSelect = false;
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.RowHeadersWidth = 51;
            this.dgvDevices.RowTemplate.Height = 26;
            this.dgvDevices.Size = new System.Drawing.Size(768, 322);
            this.dgvDevices.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSavrDeviceDetails);
            this.panel2.Controls.Add(this.btnSelectDevice);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtDeviceScrollText);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtDeviceIPAddress);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtDeviceName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtDeviceLicenseID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtDeviceID);
            this.panel2.Location = new System.Drawing.Point(12, 448);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 340);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(623, 287);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 50);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSavrDeviceDetails
            // 
            this.btnSavrDeviceDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnSavrDeviceDetails.FlatAppearance.BorderSize = 0;
            this.btnSavrDeviceDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavrDeviceDetails.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavrDeviceDetails.ForeColor = System.Drawing.Color.White;
            this.btnSavrDeviceDetails.Location = new System.Drawing.Point(623, 187);
            this.btnSavrDeviceDetails.Name = "btnSavrDeviceDetails";
            this.btnSavrDeviceDetails.Size = new System.Drawing.Size(150, 50);
            this.btnSavrDeviceDetails.TabIndex = 8;
            this.btnSavrDeviceDetails.Text = "SAVE";
            this.btnSavrDeviceDetails.UseVisualStyleBackColor = false;
            this.btnSavrDeviceDetails.Click += new System.EventHandler(this.btnSavrDeviceDetails_Click);
            // 
            // btnSelectDevice
            // 
            this.btnSelectDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnSelectDevice.FlatAppearance.BorderSize = 0;
            this.btnSelectDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectDevice.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectDevice.ForeColor = System.Drawing.Color.White;
            this.btnSelectDevice.Location = new System.Drawing.Point(623, 125);
            this.btnSelectDevice.Name = "btnSelectDevice";
            this.btnSelectDevice.Size = new System.Drawing.Size(150, 50);
            this.btnSelectDevice.TabIndex = 8;
            this.btnSelectDevice.Text = "SELECT";
            this.btnSelectDevice.UseVisualStyleBackColor = false;
            this.btnSelectDevice.Click += new System.EventHandler(this.btnSelectDevice_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.label5.Location = new System.Drawing.Point(13, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "SCALE SCROLL TEXT";
            // 
            // txtDeviceScrollText
            // 
            this.txtDeviceScrollText.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtDeviceScrollText.Location = new System.Drawing.Point(12, 278);
            this.txtDeviceScrollText.Name = "txtDeviceScrollText";
            this.txtDeviceScrollText.Size = new System.Drawing.Size(438, 38);
            this.txtDeviceScrollText.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.label3.Location = new System.Drawing.Point(13, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "SCALE IP ADDRESS";
            // 
            // txtDeviceIPAddress
            // 
            this.txtDeviceIPAddress.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtDeviceIPAddress.Location = new System.Drawing.Point(12, 194);
            this.txtDeviceIPAddress.Name = "txtDeviceIPAddress";
            this.txtDeviceIPAddress.Size = new System.Drawing.Size(438, 38);
            this.txtDeviceIPAddress.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.label1.Location = new System.Drawing.Point(13, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "SCALE NAME";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtDeviceName.Location = new System.Drawing.Point(12, 116);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(438, 38);
            this.txtDeviceName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.label4.Location = new System.Drawing.Point(129, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "DEVICE LICENSE ID";
            // 
            // txtDeviceLicenseID
            // 
            this.txtDeviceLicenseID.BackColor = System.Drawing.SystemColors.Control;
            this.txtDeviceLicenseID.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtDeviceLicenseID.Location = new System.Drawing.Point(128, 37);
            this.txtDeviceLicenseID.Name = "txtDeviceLicenseID";
            this.txtDeviceLicenseID.ReadOnly = true;
            this.txtDeviceLicenseID.Size = new System.Drawing.Size(322, 38);
            this.txtDeviceLicenseID.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "DEVICE ID";
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.BackColor = System.Drawing.SystemColors.Control;
            this.txtDeviceID.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtDeviceID.Location = new System.Drawing.Point(12, 37);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.ReadOnly = true;
            this.txtDeviceID.Size = new System.Drawing.Size(97, 38);
            this.txtDeviceID.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(338, 40);
            this.label6.TabIndex = 1011;
            this.label6.Text = "Scale Device Setup";
            // 
            // DeviceMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeviceMasterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeviceMasterForm";
            this.Load += new System.EventHandler(this.DeviceMasterForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DeviceMasterForm_Paint);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeviceID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeviceIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Button btnSelectDevice;
        private System.Windows.Forms.Button btnSavrDeviceDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeviceLicenseID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeviceScrollText;
        private System.Windows.Forms.Label label6;
    }
}