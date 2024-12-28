using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QBranchApp.DAL;
using System.Data.SqlClient;

namespace QBranchApp.Stock.Reports
{
    public partial class frmPurchaseBillPreview : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        public string partyNumber;

        public frmPurchaseBillPreview()
        {
            InitializeComponent();
        }

        private dsPurchaseInvoice GetSupplierList()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Purchase_Report_Invoice where PartyNumber='" + partyNumber + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dsPurchaseInvoice invDS = new dsPurchaseInvoice())
                        {
                            sda.Fill(invDS, "DataTable1");
                            return invDS;
                        }
                    }
                }
            }
        }

        private void frmPurchaseBillPreview_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = obj.fillcombo("select * from Purchase_Report_Invoice where PartyNumber='" + partyNumber + "'");
                rptPurchaseInvoice rpt = new rptPurchaseInvoice();
                rpt.SetDataSource(dt);
                crPrchBillPreview.ReportSource = rpt;
                this.crPrchBillPreview.RefreshReport();
            }
            catch (Exception ex)
            {

            }

            //rptPurchaseInvoice crystalReport = new rptPurchaseInvoice();
            //dsPurchaseInvoice dsCrPrchList = GetSupplierList();
            //crystalReport.SetDataSource(dsCrPrchList);
            //this.crPrchBillPreview.ReportSource = crystalReport;
        }
    }
}
