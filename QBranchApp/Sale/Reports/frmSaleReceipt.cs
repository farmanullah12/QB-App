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

namespace QBranchApp.Sale.Reports
{
    public partial class frmSaleReceipt : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        public frmSaleReceipt()
        {
            InitializeComponent();
        }

        private dsSaleInvoice GetSaleReceipt()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Sale_Invoice_Preview where BillNo='" + txtBillNo.Text.Trim() + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dsSaleInvoice invDS = new dsSaleInvoice())
                        {
                            sda.Fill(invDS, "DataTable1");
                            return invDS;
                        }
                    }
                }
            }
        }

        private void frmSaleReceipt_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            rptSaleInvoice crystalReport = new rptSaleInvoice();
            dsSaleInvoice dsCrPrchList = GetSaleReceipt();
            crystalReport.SetDataSource(dsCrPrchList);
            this.crystalReportViewer1.ReportSource = crystalReport;
        }
    }
}
