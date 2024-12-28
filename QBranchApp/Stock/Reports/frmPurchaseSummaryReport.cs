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
    public partial class frmPurchaseSummaryReport : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;


        public frmPurchaseSummaryReport()
        {
            InitializeComponent();
        }

        private dsPurchaseSummaryReport GetSupplierList()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select item_ID+' '+Item_Title as Description,CompanyName,FullName,PartyNumber,PurchaseDate,TotalAmount from Purchase_Report_Invoice"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dsPurchaseSummaryReport invDS = new dsPurchaseSummaryReport())
                        {
                            sda.Fill(invDS, "DataTable1");
                            return invDS;
                        }
                    }
                }
            }
        }


        private void frmPurchaseSummaryReport_Load(object sender, EventArgs e)
        {
            crPurchaseSummaryList crystalReport = new crPurchaseSummaryList();
            dsPurchaseSummaryReport dsCrPrchList = GetSupplierList();
            crystalReport.SetDataSource(dsCrPrchList);
            this.crPurchaseSummaryReport.ReportSource = crystalReport;
        }
    }
}
