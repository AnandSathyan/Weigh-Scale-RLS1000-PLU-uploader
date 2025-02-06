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
    public partial class AboutUsForm : Form
    {
        public AboutUsForm()
        {
            InitializeComponent();
        }

        private void AboutUsForm_Load(object sender, EventArgs e)
        {
            txtDisclaimer.Text = "This Computer Program is protected by copyright law and international treaties. Unauthorised reproduction or distribution of this program or any portion of it may result in severe Civil and Criminal Penalties and will be prosecuted to the maximum extent possible under the law.";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutUsForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(198, 11, 7), ButtonBorderStyle.Solid);
        }
    }
}
