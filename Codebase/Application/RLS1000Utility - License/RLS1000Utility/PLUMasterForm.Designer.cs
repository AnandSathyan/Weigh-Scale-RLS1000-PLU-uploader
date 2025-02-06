namespace RLS1000Utility
{
    partial class PLUMasterForm
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
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnSaveLocal = new System.Windows.Forms.Button();
            this.btnGetPLUFromLocal = new System.Windows.Forms.Button();
            this.brnCheckServerConnection = new System.Windows.Forms.Button();
            this.btnGetPLUFromServer = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPLUData = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLUData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClearList);
            this.panel1.Controls.Add(this.btnSaveLocal);
            this.panel1.Controls.Add(this.btnGetPLUFromLocal);
            this.panel1.Controls.Add(this.brnCheckServerConnection);
            this.panel1.Controls.Add(this.btnGetPLUFromServer);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(10, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 119);
            this.panel1.TabIndex = 0;
            // 
            // btnClearList
            // 
            this.btnClearList.BackColor = System.Drawing.Color.White;
            this.btnClearList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnClearList.FlatAppearance.BorderSize = 2;
            this.btnClearList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearList.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnClearList.Location = new System.Drawing.Point(315, 3);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(150, 50);
            this.btnClearList.TabIndex = 33;
            this.btnClearList.Text = "CLEAR";
            this.btnClearList.UseVisualStyleBackColor = false;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnSaveLocal
            // 
            this.btnSaveLocal.BackColor = System.Drawing.Color.White;
            this.btnSaveLocal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnSaveLocal.FlatAppearance.BorderSize = 2;
            this.btnSaveLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveLocal.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveLocal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnSaveLocal.Location = new System.Drawing.Point(515, 59);
            this.btnSaveLocal.Name = "btnSaveLocal";
            this.btnSaveLocal.Size = new System.Drawing.Size(150, 50);
            this.btnSaveLocal.TabIndex = 33;
            this.btnSaveLocal.Text = "SAVE";
            this.btnSaveLocal.UseVisualStyleBackColor = false;
            this.btnSaveLocal.Click += new System.EventHandler(this.btnSaveLocal_Click);
            // 
            // btnGetPLUFromLocal
            // 
            this.btnGetPLUFromLocal.BackColor = System.Drawing.Color.White;
            this.btnGetPLUFromLocal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnGetPLUFromLocal.FlatAppearance.BorderSize = 2;
            this.btnGetPLUFromLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetPLUFromLocal.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPLUFromLocal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnGetPLUFromLocal.Location = new System.Drawing.Point(259, 59);
            this.btnGetPLUFromLocal.Name = "btnGetPLUFromLocal";
            this.btnGetPLUFromLocal.Size = new System.Drawing.Size(250, 50);
            this.btnGetPLUFromLocal.TabIndex = 33;
            this.btnGetPLUFromLocal.Text = "PLU FROM LOCAL";
            this.btnGetPLUFromLocal.UseVisualStyleBackColor = false;
            this.btnGetPLUFromLocal.Click += new System.EventHandler(this.btnGetPLUFromLocal_Click);
            // 
            // brnCheckServerConnection
            // 
            this.brnCheckServerConnection.BackColor = System.Drawing.Color.White;
            this.brnCheckServerConnection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.brnCheckServerConnection.FlatAppearance.BorderSize = 2;
            this.brnCheckServerConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnCheckServerConnection.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnCheckServerConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.brnCheckServerConnection.Location = new System.Drawing.Point(3, 3);
            this.brnCheckServerConnection.Name = "brnCheckServerConnection";
            this.brnCheckServerConnection.Size = new System.Drawing.Size(306, 50);
            this.brnCheckServerConnection.TabIndex = 33;
            this.brnCheckServerConnection.Text = "CHECK CONNECTION";
            this.brnCheckServerConnection.UseVisualStyleBackColor = false;
            this.brnCheckServerConnection.Click += new System.EventHandler(this.brnCheckServerConnection_Click);
            // 
            // btnGetPLUFromServer
            // 
            this.btnGetPLUFromServer.BackColor = System.Drawing.Color.White;
            this.btnGetPLUFromServer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnGetPLUFromServer.FlatAppearance.BorderSize = 2;
            this.btnGetPLUFromServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetPLUFromServer.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPLUFromServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnGetPLUFromServer.Location = new System.Drawing.Point(3, 59);
            this.btnGetPLUFromServer.Name = "btnGetPLUFromServer";
            this.btnGetPLUFromServer.Size = new System.Drawing.Size(250, 50);
            this.btnGetPLUFromServer.TabIndex = 33;
            this.btnGetPLUFromServer.Text = "PLU FROM SERVER";
            this.btnGetPLUFromServer.UseVisualStyleBackColor = false;
            this.btnGetPLUFromServer.Click += new System.EventHandler(this.btnGetPLUFromServer_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(545, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 50);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvPLUData);
            this.panel2.Location = new System.Drawing.Point(10, 225);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(679, 463);
            this.panel2.TabIndex = 1;
            // 
            // dgvPLUData
            // 
            this.dgvPLUData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPLUData.Location = new System.Drawing.Point(5, 3);
            this.dgvPLUData.Name = "dgvPLUData";
            this.dgvPLUData.RowHeadersWidth = 51;
            this.dgvPLUData.RowTemplate.Height = 24;
            this.dgvPLUData.Size = new System.Drawing.Size(671, 457);
            this.dgvPLUData.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(11)))), ((int)(((byte)(7)))));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 40);
            this.label3.TabIndex = 5;
            this.label3.Text = "PLU Master";
            // 
            // PLUMasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 700);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PLUMasterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLUMasterForm";
            this.Load += new System.EventHandler(this.PLUMasterForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PLUMasterForm_Paint);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLUData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGetPLUFromLocal;
        private System.Windows.Forms.Button btnGetPLUFromServer;
        private System.Windows.Forms.Button brnCheckServerConnection;
        private System.Windows.Forms.DataGridView dgvPLUData;
        private System.Windows.Forms.Button btnSaveLocal;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Label label3;
    }
}