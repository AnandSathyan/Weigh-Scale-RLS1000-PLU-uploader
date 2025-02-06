namespace RLS1000Utility
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnAboutUs = new System.Windows.Forms.Button();
            this.btnScaleUtility = new System.Windows.Forms.Button();
            this.btnPLUMaster = new System.Windows.Forms.Button();
            this.btnDBSetup = new System.Windows.Forms.Button();
            this.btnDeviceMaster = new System.Windows.Forms.Button();
            this.btnCompanySetup = new System.Windows.Forms.Button();
            this.btnLicenseInfo = new System.Windows.Forms.Button();
            this.pnlInformation = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLicenseExpiry = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLicenseStatus = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnLogout);
            this.panelTop.Controls.Add(this.btnExit);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1120, 100);
            this.panelTop.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.Location = new System.Drawing.Point(956, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(70, 80);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(1040, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 80);
            this.btnExit.TabIndex = 1;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.label2.Location = new System.Drawing.Point(203, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(426, 49);
            this.label2.TabIndex = 0;
            this.label2.Text = "Scale Middleware (PLS110-SF)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pnlInformation);
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.btnAboutUs);
            this.panel1.Controls.Add(this.btnScaleUtility);
            this.panel1.Controls.Add(this.btnPLUMaster);
            this.panel1.Controls.Add(this.btnDBSetup);
            this.panel1.Controls.Add(this.btnDeviceMaster);
            this.panel1.Controls.Add(this.btnCompanySetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 768);
            this.panel1.TabIndex = 3;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.lblVersion.Location = new System.Drawing.Point(1002, 740);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(69, 19);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "v1.0.01";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAboutUs
            // 
            this.btnAboutUs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAboutUs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnAboutUs.FlatAppearance.BorderSize = 0;
            this.btnAboutUs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAboutUs.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAboutUs.ForeColor = System.Drawing.Color.White;
            this.btnAboutUs.Image = ((System.Drawing.Image)(resources.GetObject("btnAboutUs.Image")));
            this.btnAboutUs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAboutUs.Location = new System.Drawing.Point(822, 648);
            this.btnAboutUs.Name = "btnAboutUs";
            this.btnAboutUs.Size = new System.Drawing.Size(262, 70);
            this.btnAboutUs.TabIndex = 1;
            this.btnAboutUs.Text = "ABOUT US";
            this.btnAboutUs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAboutUs.UseVisualStyleBackColor = false;
            this.btnAboutUs.Click += new System.EventHandler(this.btnAboutUs_Click);
            // 
            // btnScaleUtility
            // 
            this.btnScaleUtility.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScaleUtility.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnScaleUtility.FlatAppearance.BorderSize = 0;
            this.btnScaleUtility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScaleUtility.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScaleUtility.ForeColor = System.Drawing.Color.White;
            this.btnScaleUtility.Image = ((System.Drawing.Image)(resources.GetObject("btnScaleUtility.Image")));
            this.btnScaleUtility.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScaleUtility.Location = new System.Drawing.Point(822, 421);
            this.btnScaleUtility.Name = "btnScaleUtility";
            this.btnScaleUtility.Size = new System.Drawing.Size(262, 70);
            this.btnScaleUtility.TabIndex = 1;
            this.btnScaleUtility.Text = "SCALE UTILITY";
            this.btnScaleUtility.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScaleUtility.UseVisualStyleBackColor = false;
            this.btnScaleUtility.Click += new System.EventHandler(this.btnScaleUtility_Click);
            // 
            // btnPLUMaster
            // 
            this.btnPLUMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPLUMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnPLUMaster.FlatAppearance.BorderSize = 0;
            this.btnPLUMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPLUMaster.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPLUMaster.ForeColor = System.Drawing.Color.White;
            this.btnPLUMaster.Image = ((System.Drawing.Image)(resources.GetObject("btnPLUMaster.Image")));
            this.btnPLUMaster.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPLUMaster.Location = new System.Drawing.Point(822, 345);
            this.btnPLUMaster.Name = "btnPLUMaster";
            this.btnPLUMaster.Size = new System.Drawing.Size(262, 70);
            this.btnPLUMaster.TabIndex = 1;
            this.btnPLUMaster.Text = "PLU MASTER";
            this.btnPLUMaster.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPLUMaster.UseVisualStyleBackColor = false;
            this.btnPLUMaster.Click += new System.EventHandler(this.btnPLUMaster_Click);
            // 
            // btnDBSetup
            // 
            this.btnDBSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDBSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnDBSetup.FlatAppearance.BorderSize = 0;
            this.btnDBSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDBSetup.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDBSetup.ForeColor = System.Drawing.Color.White;
            this.btnDBSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnDBSetup.Image")));
            this.btnDBSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDBSetup.Location = new System.Drawing.Point(822, 269);
            this.btnDBSetup.Name = "btnDBSetup";
            this.btnDBSetup.Size = new System.Drawing.Size(262, 70);
            this.btnDBSetup.TabIndex = 1;
            this.btnDBSetup.Text = "DATABASE SETUP";
            this.btnDBSetup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDBSetup.UseVisualStyleBackColor = false;
            this.btnDBSetup.Click += new System.EventHandler(this.btnDBSetup_Click);
            // 
            // btnDeviceMaster
            // 
            this.btnDeviceMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeviceMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnDeviceMaster.FlatAppearance.BorderSize = 0;
            this.btnDeviceMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeviceMaster.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeviceMaster.ForeColor = System.Drawing.Color.White;
            this.btnDeviceMaster.Image = ((System.Drawing.Image)(resources.GetObject("btnDeviceMaster.Image")));
            this.btnDeviceMaster.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeviceMaster.Location = new System.Drawing.Point(822, 193);
            this.btnDeviceMaster.Name = "btnDeviceMaster";
            this.btnDeviceMaster.Size = new System.Drawing.Size(262, 70);
            this.btnDeviceMaster.TabIndex = 1;
            this.btnDeviceMaster.Text = "DEVICE MASTER";
            this.btnDeviceMaster.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeviceMaster.UseVisualStyleBackColor = false;
            this.btnDeviceMaster.Click += new System.EventHandler(this.btnDeviceMaster_Click);
            // 
            // btnCompanySetup
            // 
            this.btnCompanySetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompanySetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnCompanySetup.FlatAppearance.BorderSize = 0;
            this.btnCompanySetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompanySetup.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompanySetup.ForeColor = System.Drawing.Color.White;
            this.btnCompanySetup.Image = ((System.Drawing.Image)(resources.GetObject("btnCompanySetup.Image")));
            this.btnCompanySetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompanySetup.Location = new System.Drawing.Point(822, 117);
            this.btnCompanySetup.Name = "btnCompanySetup";
            this.btnCompanySetup.Size = new System.Drawing.Size(262, 70);
            this.btnCompanySetup.TabIndex = 1;
            this.btnCompanySetup.Text = "COMPANY SETUP";
            this.btnCompanySetup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompanySetup.UseVisualStyleBackColor = false;
            this.btnCompanySetup.Click += new System.EventHandler(this.btnCompanySetup_Click);
            // 
            // btnLicenseInfo
            // 
            this.btnLicenseInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLicenseInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnLicenseInfo.FlatAppearance.BorderSize = 0;
            this.btnLicenseInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLicenseInfo.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLicenseInfo.ForeColor = System.Drawing.Color.White;
            this.btnLicenseInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnLicenseInfo.Image")));
            this.btnLicenseInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLicenseInfo.Location = new System.Drawing.Point(81, 134);
            this.btnLicenseInfo.Name = "btnLicenseInfo";
            this.btnLicenseInfo.Size = new System.Drawing.Size(262, 70);
            this.btnLicenseInfo.TabIndex = 1;
            this.btnLicenseInfo.Text = "LICENSE INFO";
            this.btnLicenseInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLicenseInfo.UseVisualStyleBackColor = false;
            this.btnLicenseInfo.Click += new System.EventHandler(this.btnLicenseInfo_Click);
            // 
            // pnlInformation
            // 
            this.pnlInformation.BackColor = System.Drawing.Color.Beige;
            this.pnlInformation.Controls.Add(this.lblType);
            this.pnlInformation.Controls.Add(this.label7);
            this.pnlInformation.Controls.Add(this.lblLicenseStatus);
            this.pnlInformation.Controls.Add(this.btnLicenseInfo);
            this.pnlInformation.Controls.Add(this.label5);
            this.pnlInformation.Controls.Add(this.lblLicenseExpiry);
            this.pnlInformation.Controls.Add(this.label6);
            this.pnlInformation.Location = new System.Drawing.Point(10, 120);
            this.pnlInformation.Margin = new System.Windows.Forms.Padding(4);
            this.pnlInformation.Name = "pnlInformation";
            this.pnlInformation.Size = new System.Drawing.Size(438, 219);
            this.pnlInformation.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.label7.Location = new System.Drawing.Point(13, 82);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "License Type : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.label5.Location = new System.Drawing.Point(83, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Status : ";
            // 
            // lblLicenseExpiry
            // 
            this.lblLicenseExpiry.AutoSize = true;
            this.lblLicenseExpiry.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseExpiry.Location = new System.Drawing.Point(175, 12);
            this.lblLicenseExpiry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicenseExpiry.Name = "lblLicenseExpiry";
            this.lblLicenseExpiry.Size = new System.Drawing.Size(67, 23);
            this.lblLicenseExpiry.TabIndex = 6;
            this.lblLicenseExpiry.Text = "Expiry";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.label6.Location = new System.Drawing.Point(82, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Expiry : ";
            // 
            // lblLicenseStatus
            // 
            this.lblLicenseStatus.AutoSize = true;
            this.lblLicenseStatus.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseStatus.Location = new System.Drawing.Point(175, 45);
            this.lblLicenseStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicenseStatus.Name = "lblLicenseStatus";
            this.lblLicenseStatus.Size = new System.Drawing.Size(66, 23);
            this.lblLicenseStatus.TabIndex = 8;
            this.lblLicenseStatus.Text = "Status";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(175, 82);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(89, 23);
            this.lblType.TabIndex = 12;
            this.lblType.Text = "Lic Type";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1120, 768);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlInformation.ResumeLayout(false);
            this.pnlInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeviceMaster;
        private System.Windows.Forms.Button btnCompanySetup;
        private System.Windows.Forms.Button btnAboutUs;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnDBSetup;
        private System.Windows.Forms.Button btnPLUMaster;
        private System.Windows.Forms.Button btnScaleUtility;
        private System.Windows.Forms.Button btnLicenseInfo;
        private System.Windows.Forms.Panel pnlInformation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLicenseExpiry;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblLicenseStatus;
    }
}