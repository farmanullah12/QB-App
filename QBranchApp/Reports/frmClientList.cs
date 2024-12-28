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
    public partial class frmClientList : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        //string strConnectionString = @"Data source=.;Database=QBranch; integrated security=true";

        public frmClientList()
        {
            InitializeComponent();
        }

        private dsClientList GetClientList()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from View_ClientInfo"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dsClientList invDS = new dsClientList())
                        {
                            sda.Fill(invDS, "DataTable1");
                            return invDS;
                        }
                    }
                }
            }
        }

        private void frmClientList_Load(object sender, EventArgs e)
        {
            rptClientList crystalReport = new rptClientList();
            dsClientList dsCrSTOCK = GetClientList();
            crystalReport.SetDataSource(dsCrSTOCK);
            this.crystalReportViewer1.ReportSource = crystalReport;
            //crystalReport.SetParameterValue("DateFrom", dateTimePicker1.Value.ToShortDateString());
            //crystalReport.SetParameterValue("DateTo", dateTimePicker2.Value.ToShortDateString());
        }
    }
}
