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
    public partial class frmClosingInventory : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        string strConnectionString = @"Data source=.;Database=QBranch; user id=sa; password=123";


        public frmClosingInventory()
        {
            InitializeComponent();
        }

        private dsClosingInventory GetAllSaleCollection()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Closing_Inventory"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dsClosingInventory invDS = new dsClosingInventory())
                        {
                            sda.Fill(invDS, "DataTable1");
                            return invDS;
                        }
                    }
                }
            }
        }

        private void frmClosingInventory_Load(object sender, EventArgs e)
        {
            crClosingStock crystalReport = new crClosingStock();
            dsClosingInventory lgr = GetAllSaleCollection();
            crystalReport.SetDataSource(lgr);
            this.crystalReportViewer1.ReportSource = crystalReport;
        }
    }
}
