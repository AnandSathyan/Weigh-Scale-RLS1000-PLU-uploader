namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button3 = new System.Windows.Forms.Button();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnDownloadHead = new System.Windows.Forms.Button();
            this.btnDownLoadAdTail = new System.Windows.Forms.Button();
            this.btnUploadAdHead = new System.Windows.Forms.Button();
            this.btnTail = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnGetWeight = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnStopGetWev = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(276, 236);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Get Plu Weight";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtIp
            // 
            this.txtIp.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtIp.Location = new System.Drawing.Point(108, 21);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(107, 21);
            this.txtIp.TabIndex = 3;
            this.txtIp.Text = "192.168.3.163";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(87, 110);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(160, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "clearPludata";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(87, 236);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(160, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Download Message";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(85, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "注意:该接口dll只能用于x86,在32位平台编译";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(61, 443);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(473, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Note: This interface dll can only be used on x86, compiled on 32-bit platforms";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(276, 278);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(160, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Upload Sale Data";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(87, 194);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(160, 23);
            this.button8.TabIndex = 10;
            this.button8.Text = "Upload Plu Data";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(87, 278);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(160, 23);
            this.button7.TabIndex = 11;
            this.button7.Text = "Upload Message";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(87, 152);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(160, 23);
            this.button9.TabIndex = 12;
            this.button9.Text = "Download Plu";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // btnDownloadHead
            // 
            this.btnDownloadHead.Location = new System.Drawing.Point(276, 68);
            this.btnDownloadHead.Name = "btnDownloadHead";
            this.btnDownloadHead.Size = new System.Drawing.Size(144, 23);
            this.btnDownloadHead.TabIndex = 14;
            this.btnDownloadHead.Text = "DownLoad Ad Head";
            this.btnDownloadHead.UseVisualStyleBackColor = true;
            this.btnDownloadHead.Click += new System.EventHandler(this.btnDownloadHead_Click);
            // 
            // btnDownLoadAdTail
            // 
            this.btnDownLoadAdTail.Location = new System.Drawing.Point(276, 152);
            this.btnDownLoadAdTail.Name = "btnDownLoadAdTail";
            this.btnDownLoadAdTail.Size = new System.Drawing.Size(144, 23);
            this.btnDownLoadAdTail.TabIndex = 14;
            this.btnDownLoadAdTail.Text = "Download Ad Tail";
            this.btnDownLoadAdTail.UseVisualStyleBackColor = true;
            this.btnDownLoadAdTail.Click += new System.EventHandler(this.btnDownLoadAdTail_Click);
            // 
            // btnUploadAdHead
            // 
            this.btnUploadAdHead.Location = new System.Drawing.Point(276, 110);
            this.btnUploadAdHead.Name = "btnUploadAdHead";
            this.btnUploadAdHead.Size = new System.Drawing.Size(144, 23);
            this.btnUploadAdHead.TabIndex = 15;
            this.btnUploadAdHead.Text = "upload Ad Head";
            this.btnUploadAdHead.UseVisualStyleBackColor = true;
            this.btnUploadAdHead.Click += new System.EventHandler(this.btnUploadAdHead_Click);
            // 
            // btnTail
            // 
            this.btnTail.Location = new System.Drawing.Point(276, 194);
            this.btnTail.Name = "btnTail";
            this.btnTail.Size = new System.Drawing.Size(144, 23);
            this.btnTail.TabIndex = 15;
            this.btnTail.Text = "upload Ad Tail";
            this.btnTail.UseVisualStyleBackColor = true;
            this.btnTail.Click += new System.EventHandler(this.btnTail_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(87, 68);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(160, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnGetWeight
            // 
            this.btnGetWeight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetWeight.Location = new System.Drawing.Point(494, 56);
            this.btnGetWeight.Name = "btnGetWeight";
            this.btnGetWeight.Size = new System.Drawing.Size(89, 23);
            this.btnGetWeight.TabIndex = 16;
            this.btnGetWeight.Text = "Get Weight";
            this.btnGetWeight.UseVisualStyleBackColor = true;
            this.btnGetWeight.Click += new System.EventHandler(this.btnGetWeight_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(607, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(206, 280);
            this.listBox1.TabIndex = 17;
            // 
            // btnStopGetWev
            // 
            this.btnStopGetWev.Location = new System.Drawing.Point(494, 100);
            this.btnStopGetWev.Name = "btnStopGetWev";
            this.btnStopGetWev.Size = new System.Drawing.Size(107, 23);
            this.btnStopGetWev.TabIndex = 18;
            this.btnStopGetWev.Text = "Stop GetWeight";
            this.btnStopGetWev.UseVisualStyleBackColor = true;
            this.btnStopGetWev.Click += new System.EventHandler(this.btnStopGetWev_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 533);
            this.Controls.Add(this.btnStopGetWev);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnGetWeight);
            this.Controls.Add(this.btnTail);
            this.Controls.Add(this.btnUploadAdHead);
            this.Controls.Add(this.btnDownLoadAdTail);
            this.Controls.Add(this.btnDownloadHead);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.button3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnDownloadHead;
        private System.Windows.Forms.Button btnDownLoadAdTail;
        private System.Windows.Forms.Button btnUploadAdHead;
        private System.Windows.Forms.Button btnTail;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnGetWeight;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnStopGetWev;
    }
}

