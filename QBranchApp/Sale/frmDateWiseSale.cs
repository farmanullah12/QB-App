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
using QBranchApp.Sale.Reports;

namespace QBranchApp.Sale
{
    public partial class frmDateWiseSale : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        string strConnectionString = @"Data source=.;Database=QBranch; user id=sa; password=123";

        public frmDateWiseSale()
        {
            InitializeComponent();
        }


        private dsSaleCollection GetDateWiseSale()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from sale_Collection where SaleDate  between '" + DtFrom.Value.ToShortDateString() + "' and '" + dtTo.Value.ToShortDateString() + "'"))
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


        private dsSaleCollection GetDateWiseCategorySale()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from sale_Collection where SaleDate  between '" + dateTimePickerFrom.Value.ToShortDateString() + "' and '" + dateTimePickerTo.Value.ToShortDateString() + "' and productGroup='" + comboBox1.Text + "'"))
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

        private void frmDateWiseSale_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            crDateWiseSale crystalReport = new crDateWiseSale();
            dsSaleCollection lgr = GetDateWiseSale();
            crystalReport.SetDataSource(lgr);
            this.crystalReportViewer1.ReportSource = crystalReport;
            crystalReport.SetParameterValue("DateFrom", DtFrom.Value.ToShortDateString());
            crystalReport.SetParameterValue("DateTo", dtTo.Value.ToShortDateString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CategorycrDateWiseSale crystalReport = new CategorycrDateWiseSale();
            dsSaleCollection lgr = GetDateWiseCategorySale();
            crystalReport.SetDataSource(lgr);
            this.crystalReportViewer1.ReportSource = crystalReport;
            crystalReport.SetParameterValue("DateFrom", dateTimePickerFrom.Value.ToShortDateString());
            crystalReport.SetParameterValue("DateTo", dateTimePickerTo.Value.ToShortDateString());
        }
    }
}
