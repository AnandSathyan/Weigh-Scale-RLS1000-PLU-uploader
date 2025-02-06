using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLS1000Utility
{
    public partial class LoadingForm : Form
    {
        public volatile bool ShouldCloseNow;
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            ShouldCloseNow = false;
            // Start the timer to check when to close the dialog
            tmrCheckIfNeedToCloseDialog.Start();
        }

        private void tmrCheckIfNeedToCloseDialog_Tick(object sender, EventArgs e)
        {
            //Thread.Sleep(2000);
            if (ShouldCloseNow)
                Close();
        }
    }
}
