using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QBranchApp.Helpers;
using QBranchApp.DAL;
using System.Data.SqlClient;
using System.IO;

namespace QBranchApp
{
    public partial class Dashboard : Form
    {
        MemoryStream ms;
        byte[] photo_aray;

        string GetDynamicMenuQry;
        SqlCommand cmd;
        SqlDataAdapter da;
        string menu_str;

        string strquery;


        public Dashboard()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblCurrentTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

    

        private void Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblCurrentTime.Text = DateTime.Now.ToLongTimeString();
            lblUserName.Text = currentUser.UserName;

            getdynamicmenu();
        }



        private void getdynamicmenu()
        {
            SqlConnection con = new SqlConnection("data source=.; database=QBranch; user id=sa; password=123");
            con.Open();
            strquery = "select menuid from UserMenuPermission where userID='" + currentUser.UserID + "'";
            cmd = new SqlCommand(strquery,con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            menu_str = ds.Tables[0].Rows[0][0].ToString();
            //int menuList = int.Parse(menu_str);

            string strquery1 = "select menuid,menuname,menuparent from MenuList where menuID  IN (SELECT * FROM dbo.CSVToTable('" + menu_str + "'))";
            SqlCommand cmd1 = new SqlCommand(strquery1, con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            DataTable table = new DataTable();
            table = ds1.Tables[0];
            DataView view = new DataView(table);
            view.RowFilter = "menuparent=0";

            foreach (DataRowView row in view)
            {
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    if (row["menuname"].ToString() == item.Name)
                    {
                        item.Visible = true;
                    }

                    AddChildForms(table, row["menuID"].ToString(), item);
                }
            }
        }

        private void AddChildForms(DataTable table, string id,ToolStripMenuItem ToolSMI) {

            DataView viewchild = new DataView(table);
            viewchild.RowFilter = "menuparent=0" + id;

            foreach (DataRowView cheildviewitem in viewchild)
            {
                foreach (ToolStripMenuItem item in ToolSMI.DropDownItems)
                {
                    if (cheildviewitem["MenuName"].ToString() == item.Name)
                    {
                        item.Visible = true;
                    }
                    AddChildForms(table, cheildviewitem["menuID"].ToString(), item);
                    
                }
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Security.frmAddUser frm = new Security.frmAddUser();
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string loginTime = Convert.ToString(DateTime.Now.ToLongTimeString()) + " " + Convert.ToString(DateTime.Now.ToLongDateString());
            string LogQuery = string.Format("UPDATE TBL_Audit_Log SET LOGOUT ='" + loginTime + "' WHERE  User_ID ='" + currentUser.UserID + "' AND  LOG_ID='" + currentUser.Log_ID + "'");
            bool result = DatabaseAccess.Insert(LogQuery);
            if (result)
            {
                this.Close();
                Security.frmLogin frm = new Security.frmLogin();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login Problem Check Audit Log Query!...", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
      
        }

        private void manageCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.frmCustomer frm = new General.frmCustomer();
            frm.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Security.frmBackup frm = new Security.frmBackup();
            frm.ShowDialog();
        }

        private void uoMUnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.frmUOM frm = new General.frmUOM();
            frm.ShowDialog();
        }

        private void manageSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.frmSupplier sf = new General.frmSupplier();
            sf.ShowDialog();
        }

        private void customerProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void supplierProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmSupplierList frm = new Reports.frmSupplierList();
            frm.Show();
        }

        private void auditLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmUserLogs frm = new Reports.frmUserLogs();
            frm.Show();
        }

        private void itemMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Stock.frmStock frm = new Stock.frmStock();
            frm.ShowDialog();
        }

        private void stockOpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.frmStockOpening so = new Stock.frmStockOpening();
            so.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.frmAboutSoftware abs = new General.frmAboutSoftware();
            abs.ShowDialog();
        }

        private void userTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Security.frmUserType ut = new Security.frmUserType();
            ut.ShowDialog();
        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Security.frmUserProfile prof = new Security.frmUserProfile();
            prof.ShowDialog();
        }

        private void retailPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.FrmPurchase prch = new Stock.FrmPurchase();
            prch.ShowDialog();
        }

        private void Dashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.P)
            {
                btnPurchase.PerformClick();
            }

            if (e.Control == true && e.KeyCode == Keys.C)
            {
                btnClient.PerformClick();
            }

            if (e.Control == true && e.KeyCode == Keys.S)
            {
                btnNewQuote.PerformClick();
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            Stock.FrmPurchase prch = new Stock.FrmPurchase();
            prch.ShowDialog();
        }

        private void retailSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale.frmSale fs = new Sale.frmSale();
            fs.ShowDialog();
        }

        private void purchaseSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.Reports.frmPurchaseSummaryReport frm = new Stock.Reports.frmPurchaseSummaryReport();
            frm.Show();
        }

        private void betweenDatePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.Reports.frmDateWiseReportPurchase frm = new Stock.Reports.frmDateWiseReportPurchase();
            frm.Show();
        }

        private void purchaseReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.Reports.frmPurchaseReceipt rec = new Stock.Reports.frmPurchaseReceipt();
            rec.Show();
        }

        private void salesCollectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale.Reports.frmAllSaleCollection sc = new Sale.Reports.frmAllSaleCollection();
            sc.Show();
        }

        private void salesReceiptReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale.Reports.frmSaleReceipt src = new Sale.Reports.frmSaleReceipt();
            src.Show();
        }

        private void collectionSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale.frmDateWiseSale fds = new Sale.frmDateWiseSale();
            fds.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            General.frmCustomer cust = new General.frmCustomer();
            cust.ShowDialog();
        }

        private void btnNewQuote_Click(object sender, EventArgs e)
        {
            Sale.frmSale sal = new Sale.frmSale();
            sal.ShowDialog();
        }

        private void btnLowStock_Click(object sender, EventArgs e)
        {
            Stock.Reports.frmLowStock fl = new Stock.Reports.frmLowStock();
            fl.Show();
        }

        private void btnReadyStock_Click(object sender, EventArgs e)
        {
            Stock.Reports.frmClosingInventory frm = new Stock.Reports.frmClosingInventory();
            frm.Show();
        }

        private void currentStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.Reports.frmClosingInventory ci = new Stock.Reports.frmClosingInventory();
            ci.Show();
        }

        private void repairOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.frmRepairOrder frm = new Stock.frmRepairOrder();
            frm.ShowDialog();
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frmClientList frm = new Reports.frmClientList();
            frm.Show();
        }

        private void byLeadSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.crmCustomerReports rp = new General.crmCustomerReports();
            rp.Show();
        }

    }
}
