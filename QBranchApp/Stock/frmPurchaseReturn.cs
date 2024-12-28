using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QBranchApp.Stock
{
    public partial class frmPurchaseReturn : Form
    {
        public frmPurchaseReturn()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button4, 0, button4.Height);
        }
    }
}
