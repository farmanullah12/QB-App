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
    public partial class frmLowStock : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        string strConnectionString = @"Data source=.;Database=QBranch; user id=sa; password=123";

        public frmLowStock()
        {
            InitializeComponent();
        }

        private dsLowStock GetLowStock()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Low_Stock where Partno='"+txtPartNo.Text.Trim()+"'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dsLowStock invDS = new dsLowStock())
                        {
                            sda.Fill(invDS, "DataTable1");
                            return invDS;
                        }
                    }
                }
            }
        }


        private void frmLowStock_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            crLowStock crystalReport = new crLowStock();
            dsLowStock lgr = GetLowStock();
            crystalReport.SetDataSource(lgr);
            this.crystalReportViewer1.ReportSource = crystalReport;
        }
    }
}
