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
    public partial class frmDateWiseReportPurchase : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        string strConnectionString = @"Data source=.;Database=QBranch; user id=sa; password=123";

        public frmDateWiseReportPurchase()
        {
            InitializeComponent();
        }

        private dsPurchaseSummaryReport GetDateWisePurchase()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select item_ID+' '+Item_Title as Description,CompanyName,FullName,PartyNumber,PurchaseDate,TotalAmount from Purchase_Report_Invoice where PurchaseDate  between '" + DtFrom.Value.ToShortDateString() + "' and '" + dtTo.Value.ToShortDateString() + "' "))
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


        private void btnPreview_Click(object sender, EventArgs e)
        {
            crDateWisePurchase crystalReport = new crDateWisePurchase();
            dsPurchaseSummaryReport lgr = GetDateWisePurchase();
            crystalReport.SetDataSource(lgr);
            this.crDATEWISEREPORT.ReportSource = crystalReport;
            crystalReport.SetParameterValue("DateFrom", DtFrom.Value.ToShortDateString());
            crystalReport.SetParameterValue("DateTo", dtTo.Value.ToShortDateString());
        }

        private void frmDateWiseReportPurchase_Load(object sender, EventArgs e)
        {

        }
    }
}
