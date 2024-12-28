using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QBranchApp.DAL;

namespace QBranchApp.Stock
{
    public partial class frmPurchaseList : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        public string partyNumber="";

        public frmPurchaseList()
        {
            InitializeComponent();
        }


        private void LoadPurchase_List()
        {
            DataTable dt = new DataTable();
            dt = obj.getData("usp_GetPurchase_List", null, null);
            dgvPurchaseList.DataSource = dt;

        }

        private void frmPurchaseList_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPurchase_List();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong loading data from database!");
            }
        }


        private void Search_PurchaseInvoice()
        {
            try
            {
                List<object> parameters = new List<object>();
                List<object> values = new List<object>();

                parameters.Add("@InvoiceNumber");
                values.Add(txtSearch.Text);

                DataTable dt = new DataTable();
                dt = obj.getData("usp_SearchPurchase_Invoice", parameters, values);
                dgvPurchaseList.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Searching Parameter goes wrong! please contact your database Administrator!");
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search_PurchaseInvoice();
        }

        private void dgvPurchaseList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Reports.frmPurchaseBillPreview fm = new Reports.frmPurchaseBillPreview();

            if (dgvPurchaseList.Columns[e.ColumnIndex].Name == "DgvPartyNumber")
            {
                DataGridViewRow _dgvCurrentRow = dgvPurchaseList.CurrentRow;
                fm.partyNumber = Convert.ToString(_dgvCurrentRow.Cells[0].Value);
                
                fm.Show();
            }
        }


    }
}
