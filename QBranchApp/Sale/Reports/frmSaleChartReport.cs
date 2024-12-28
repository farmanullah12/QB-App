using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace QBranchApp.Sale.Reports
{
    public partial class frmSaleChartReport : Form
    {
        public frmSaleChartReport()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.; database=QBranch ;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Description,Sum(Qty) as [TotalQty],sum(TotalPrice) as Total from sale_collection group by description", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet st = new DataSet();
            sda.Fill(st, "Description");

            chart1.DataSource = st.Tables["Description"];
            chart1.Series["Description"].IsValueShownAsLabel = true;
            chart1.Series["Description"].XValueMember = "Description";
            chart1.Series["Description"].YValueMembers = "Total";
            this.chart1.Titles.Add("Sales Chart for PARTS TGMO");
            chart1.Series["Description"].ChartType = SeriesChartType.Pie;
            chart1.Series["Description"].IsValueShownAsLabel = true;
            con.Close();
        }

        private void frmSaleChartReport_Load(object sender, EventArgs e)
        {

        }
    }
}
