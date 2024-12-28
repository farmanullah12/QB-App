using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace QBranchApp.Security
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            try
            {
                Server dbserver = new Server(new ServerConnection(txtServer.Text, txtuser.Text, txtpassword.Text));
                Backup dbBackup = new Backup() { Action = BackupActionType.Database, Database = txtDatabase.Text };
                dbBackup.Devices.AddDevice(@"C:\Data\GSNAccount6.bak", DeviceType.File);
                dbBackup.Initialize = true;
                dbBackup.PercentComplete += DbBackup_PercentComplete;
                dbBackup.Complete += DbBackup_Complete;
                dbBackup.SqlBackupAsync(dbserver);
            }
            catch (Exception ex)
            {

            }
        }

  

        private void DbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if (e.Error != null)
            {
                lblstatus.Invoke((MethodInvoker)delegate
                {
                    lblstatus.Text = e.Error.Message;
                });
            }
        }



        private void DbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = e.Percent;
                progressBar1.Update();
            });
            lblpercent.Invoke((MethodInvoker)delegate
            {
                lblpercent.Text = e.Percent.ToString() + "%";
            });    

            
        }
    }
}
