using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QBranchApp.DAL;
using QBranchApp.Sale.Reports;

namespace QBranchApp.Sale
{
    public partial class frmSaleList : Form
    {
        DatabaseAccess obj = new DatabaseAccess();

        public frmSaleList()
        {
            InitializeComponent();
        }

        private void LoadSale_List()
        {
            DataTable dt = new DataTable();
            dt = obj.getData("usp_SaleList", null, null);
            dgvSaleList.DataSource = dt;

        }

        private void Search_SaleInvoice()
        {
            try
            {
                List<object> parameters = new List<object>();
                List<object> values = new List<object>();

                parameters.Add("@InvoiceNumber");
                values.Add(txtSearch.Text);

                DataTable dt = new DataTable();
                dt = obj.getData("usp_SearchSale_Invoice", parameters, values);
                dgvSaleList.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Searching Parameter goes wrong! please contact your database Administrator!");
            }

        }

        private void frmSaleList_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSale_List();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong loading data from database!");
            }
        }

        private void dgvSaleList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmPreviewSaleInvoice fm = new frmPreviewSaleInvoice();

            if (dgvSaleList.Columns[e.ColumnIndex].Name == "DgvInvoiceNumber")
            {
                DataGridViewRow _dgvCurrentRow = dgvSaleList.CurrentRow;
                fm.InvoiceNumber = Convert.ToString(_dgvCurrentRow.Cells[0].Value);

                fm.Show();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search_SaleInvoice();
        }
    }
}
