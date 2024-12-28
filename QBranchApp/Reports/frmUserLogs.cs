using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QBranchApp.Reports.Dataset;
using System.Data.SqlClient;
using QBranchApp.DAL;

namespace QBranchApp.Reports
{
    public partial class frmUserLogs : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;

        public frmUserLogs()
        {
            InitializeComponent();
        }

        private dsUsreLog GetUserLogs()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from User_Logs"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dsUsreLog invDS = new dsUsreLog())
                        {
                            sda.Fill(invDS, "DataTable1");
                            return invDS;
                        }
                    }
                }
            }
        }

        private void frmUserLogs_Load(object sender, EventArgs e)
        {
            rptUserLogs crystalReport = new rptUserLogs();
            dsUsreLog dsCrSTOCK = GetUserLogs();
            crystalReport.SetDataSource(dsCrSTOCK);
            this.crystalReportViewer1.ReportSource = crystalReport;
        }
    }
}
