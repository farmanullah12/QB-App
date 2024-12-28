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
using QBranchApp.Reports;

namespace QBranchApp.General
{
    public partial class crmCustomerReports : Form
    {
        DatabaseAccess obj = new DatabaseAccess();

        public crmCustomerReports()
        {
            InitializeComponent();
        }

        public void cmbDocumentType()
        {
            DataTable dt = new DataTable();
            dt = obj.getData("usp_GetSharedLeadSource", null, null);
            DataRow TopItem = dt.NewRow();
            TopItem[0] = 0;
            TopItem[1] = "-Select-";
            dt.Rows.InsertAt(TopItem, 0);
            cmbLeadSource.DataSource = dt;
            cmbLeadSource.DisplayMember = "LeadSourceTitle";
            cmbLeadSource.ValueMember = "ID";
        }

        private void crmCustomerReports_Load(object sender, EventArgs e)
        {
            try
            {
                cmbDocumentType();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem in Loading Lead Source List! Contact Your Database Administrator.");
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = obj.fillcombo("select * from View_ClientInfo where LeadSourceTitle='" + cmbLeadSource.Text + "'");
                LeadBasedrptClientList rpt = new LeadBasedrptClientList();
                rpt.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rpt;
                this.crystalReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
