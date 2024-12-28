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
using QBranchApp.Helpers;
using QBranchApp.Sale.Reports;

namespace QBranchApp.Sale
{
    public partial class frmSale : Form
    {
        DatabaseAccess obj = new DatabaseAccess();

        int inInvoiceID = 0;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        string strConnectionString = @"Data source=.;Database=QBranch; user id=sa; password=123";

        int qty;
        int InvoicePrintID = 0;

        public frmSale()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (msg.WParam.ToInt32() == (int)Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AlphInvoiceNumber()
        {
            DatabaseAccess dc = new DatabaseAccess();
            DataTable dt = dc.Select_SP_Executer("usp_InvoiceAlphaNumber");
            string r = dt.Rows[0][0].ToString();
            txtInvoiceNo.Text = r.ToString();
        }



        void CustomerComboFill()
        {
            using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select ID,FullName from CRM_ClientInfo", sqlCon);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                DataRow TopItem = dt.NewRow();
                TopItem[0] = 0;
                TopItem[1] = "-Select-";
                dt.Rows.InsertAt(TopItem, 0);
                cmbCustomer.ValueMember = "ID";
                cmbCustomer.DisplayMember = "FullName";
                cmbCustomer.DataSource = dt;
                //dgvtxtPosition.DataSource = dt.Copy();
            }
        }

        private void disableCell()
        {
            int n = Convert.ToInt32(dgvSaleList.Rows.Count.ToString());
            for (int i = 0; i < n; i++)
            {
                dgvSaleList.Rows[i].Cells["dgvTotalPrice"].ReadOnly = true;
            }
        }

        void calculateColumn()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow item in dgvSaleList.Rows)
            {
                totalAmount += Convert.ToDecimal(item.Cells["dgvTotalPrice"].Value);
            }
            lblValueOfGoods.Text = totalAmount.ToString();
        }

        void PickCGS()
        {
            //decimal CGS = 0;
            string partNumber = "";
            using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
            {
                foreach (DataGridViewRow item in dgvSaleList.Rows)
                {
                    partNumber = Convert.ToString(item.Cells["dgvPartNumber"].Value);
                }
              
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select unitCost from pickcgscost WHERE PARTNO='" + partNumber + "'", sqlCon);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                decimal r = Convert.ToDecimal(dt.Rows[0][0]);
                //dgvRow.Cells["dgvItemCost"].Value = r;
                txtPaid.Text = r.ToString();
                //lblValueOfGoods.Text = CGS.ToString();

                sqlCon.Close();

            }

           
        }


        private void frmSale_Load(object sender, EventArgs e)
        {
            try
            {
                AlphInvoiceNumber();
                CustomerComboFill();
                calculateColumn();
                disableCell();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Check your Data Load Events with DB Parameters! or Contact your Database Administrator!");
            }
        }

        private void frmSale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

  


   

        private void button1_Click(object sender, EventArgs e)
        {
            int _SaleID = 0;
            using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
            {
                sqlCon.Open();
                //Master
                SqlCommand sqlCmd = new SqlCommand("SaleAddOrEdit", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SaleID", Convert.ToInt32(inInvoiceID));
                sqlCmd.Parameters.AddWithValue("@Customer_ID", cmbCustomer.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@BillNo", txtInvoiceNo.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@SaleDate", dtSale.Value.ToShortDateString());
                sqlCmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(lblValueOfGoods.Text));
                sqlCmd.Parameters.AddWithValue("@Paid", Convert.ToDecimal(txtPaid.Text.Trim()));
                sqlCmd.Parameters.AddWithValue("@Balance", Convert.ToDecimal(lblBalance.Text));
                sqlCmd.Parameters.AddWithValue("@User_ID", currentUser.UserID);
                sqlCmd.Parameters.AddWithValue("@EntryDate", DateTime.Now.ToShortDateString());

                _SaleID = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            //Details
            using (SqlConnection sqlC = new SqlConnection(strConnectionString))
            {
                sqlC.Open();
                foreach (DataGridViewRow dgvRow in dgvSaleList.Rows)
                {
                    if (dgvRow.IsNewRow) break;
                    else
                    {
                        SqlCommand sqlCmd = new SqlCommand("SaleDetailAddOrEdit", sqlC);
                        sqlCmd.CommandType = CommandType.StoredProcedure; 
                        sqlCmd.Parameters.AddWithValue("@SaleDetailID", Convert.ToInt32(dgvRow.Cells["dgvPurchaseDetailID"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvPurchaseDetailID"].Value));
                        sqlCmd.Parameters.AddWithValue("@Item_ID", dgvRow.Cells["dgvPartNumber"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvPartNumber"].Value);
                        sqlCmd.Parameters.AddWithValue("@Item_Title", dgvRow.Cells["dgvItemTitle"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvItemTitle"].Value);
                        sqlCmd.Parameters.AddWithValue("@ProductGroup", dgvRow.Cells["dgvcmbGroup"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvcmbGroup"].Value);
                        sqlCmd.Parameters.AddWithValue("@Qty", Convert.ToInt32(dgvRow.Cells["dgvQTY"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvQTY"].Value));
                        sqlCmd.Parameters.AddWithValue("@ItemCost", Convert.ToDecimal(dgvRow.Cells["dgvItemCost"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvItemCost"].Value));
                        
                        sqlCmd.Parameters.AddWithValue("@Rate", Convert.ToDecimal(dgvRow.Cells["DGVPurchaseUnitPrice"].Value == DBNull.Value ? "0" : dgvRow.Cells["DGVPurchaseUnitPrice"].Value));
                        sqlCmd.Parameters.AddWithValue("@TotalPrice", Convert.ToDecimal(dgvRow.Cells["dgvTotalPrice"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvTotalPrice"].Value));
                        
                        sqlCmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);
                        sqlCmd.Parameters.AddWithValue("@Sale_ID", _SaleID);


                        sqlCmd.ExecuteNonQuery();

                    }
                }
            }
            // FillEmployeeViewAll();
            //Clear();
            MessageBox.Show("Submitted Successfully");
            frmPreviewSaleInvoice fr = new frmPreviewSaleInvoice();
            fr.InvoiceNumber = txtInvoiceNo.Text;
            fr.Show();
        }

        private void txtPaid_Leave(object sender, EventArgs e)
        {
            if (txtPaid.Text == "")
            {
                txtPaid.Text = "0";
                lblBalance.Text = lblValueOfGoods.Text;
            }
            else
            {
                decimal FinalTotal = Convert.ToDecimal(lblValueOfGoods.Text);
                decimal paidamnt = Convert.ToDecimal(txtPaid.Text);

                decimal balance = Convert.ToDecimal(FinalTotal) - Convert.ToDecimal(paidamnt);
                lblBalance.Text = balance.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button5, 0, button5.Height);
        }

        private void showAllPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale.frmSaleList sl = new frmSaleList();
            sl.ShowDialog();
        }

        private void printPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale.Reports.frmSaleReceipt fsr = new Reports.frmSaleReceipt();
            fsr.Show();
        }

        private void saleReportsGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale.Reports.frmSaleChartReport schart = new Reports.frmSaleChartReport();
            schart.Show();
        }

        private void dgvSaleList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvSaleList.Rows)
            {
                row.Cells["dgvTotalPrice"].Value = Convert.ToDecimal(row.Cells["dgvQTY"].Value) * Convert.ToDecimal(row.Cells["DGVPurchaseUnitPrice"].Value);

            }

            if (e.ColumnIndex == 1)
            {
                using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
                {
                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter("select unitCost from pickcgscost WHERE PARTNO='" + dgvSaleList.Rows[e.RowIndex].Cells["dgvPartNumber"].Value + "'", sqlCon);
                        DataTable dt = new DataTable();
                        sqlDa.Fill(dt);

                        decimal r = Convert.ToDecimal(dt.Rows[0][0]);
                        //dgvRow.Cells["dgvItemCost"].Value = r;
                        //txtPaid.Text = r.ToString();
                       
                        dgvSaleList.Rows[e.RowIndex].Cells["dgvItemCost"].Value=r.ToString();

                        sqlCon.Close();
                    }
                
            }
        }

        private void dgvSaleList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 4) // 1 should be your column index
            {
                decimal i;

                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Enter Numeric Value");

                }
                else
                {
                    // the input is numeric 
                }
            }
            else if (e.ColumnIndex == 5)
            {
                decimal i;

                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Enter Numeric Value");

                }
                else
                {
                    // the input is numeric 
                }
            }
        }

        private void dgvSaleList_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            calculateColumn();
        }

        private void dgvSaleList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvSaleList_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
