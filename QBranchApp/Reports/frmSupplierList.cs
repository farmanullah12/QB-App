using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using QBranchApp.DAL;
using QBranchApp.Reports.Dataset;

namespace QBranchApp.Reports
{
    public partial class frmSupplierList : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        public frmSupplierList()
        {
            InitializeComponent();
        }
        private dsSupplierList GetSupplierList()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from View_Supplier"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dsSupplierList invDS = new dsSupplierList())
                        {
                            sda.Fill(invDS, "DataTable1");
                            return invDS;
                        }
                    }
                }
            }
        }
        private void frmSupplierList_Load(object sender, EventArgs e)
        {
            rptSupplierList crystalReport = new rptSupplierList();
            dsSupplierList dsCrSTOCK = GetSupplierList();
            crystalReport.SetDataSource(dsCrSTOCK);
            this.crystalReportViewer1.ReportSource = crystalReport;
        }
    }
}
