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
    public partial class frmAllSaleCollection : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        string strConnectionString = @"Data source=.;Database=QBranch; user id=sa; password=123";

        public frmAllSaleCollection()
        {
            InitializeComponent();
        }

        private dsSaleCollection GetAllSaleCollection()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from sale_Collection"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dsSaleCollection invDS = new dsSaleCollection())
                        {
                            sda.Fill(invDS, "DataTable1");
                            return invDS;
                        }
                    }
                }
            }
        }



        private void frmAllSaleCollection_Load(object sender, EventArgs e)
        {
            crSaleCollection crystalReport = new crSaleCollection();
            dsSaleCollection lgr = GetAllSaleCollection();
            crystalReport.SetDataSource(lgr);
            this.crystalReportViewer1.ReportSource = crystalReport;
        }
    }
}
