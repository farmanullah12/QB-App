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

namespace QBranchApp.Stock
{
    public partial class frmRepairOrder : Form
    {
        int inSaleID = 0;
        //bool isDefaultImage = true;
        string strConnectionString = @"Data source=.;Database=QBranch; integrated security=true;";

        public frmRepairOrder()
        {
            InitializeComponent();
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
            dgvSaleList.Text = totalAmount.ToString();
        }

        private void frmRepairOrder_Load(object sender, EventArgs e)
        {
            try
            {
                AlphInvoiceNumber();
                disableCell();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Contact your database administrator!");
            }
        }

        private void dgvSaleList_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            calculateColumn();
        }

        private void dgvSaleList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvSaleList.Rows)
            {
                row.Cells["dgvTotalPrice"].Value = Convert.ToDecimal(row.Cells["dgvQTY"].Value) * Convert.ToDecimal(row.Cells["DGVPurchaseUnitPrice"].Value);

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
        private void AlphInvoiceNumber()
        {
            DatabaseAccess dc = new DatabaseAccess();
            DataTable dt = dc.Select_SP_Executer("usp_ROAlphaNumber");
            string r = dt.Rows[0][0].ToString();
            txtRoNum.Text = r.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int _PurchaseID = 0;
            using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
            {
                sqlCon.Open();
                //Master
                SqlCommand sqlCmd = new SqlCommand("usp_AddOrEditExternalSaleMaster", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", inSaleID);
                sqlCmd.Parameters.AddWithValue("@RONum", txtRoNum.Text);
                sqlCmd.Parameters.AddWithValue("@Date", dtTran.Value.ToShortDateString());
                sqlCmd.Parameters.AddWithValue("@DeliveryDate", deliveryDate.Value.ToShortDateString());
                sqlCmd.Parameters.AddWithValue("@NormalRo", rdNormalRo.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@ComBackRO", rdCombackRo.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@CWaiting", rdWaiting.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@CNonWating", rdNonWaiting.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Driver", txtDriver.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@CarID", Convert.ToDecimal(txtCarID.Text));
                sqlCmd.Parameters.AddWithValue("@Description", txtDesc.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Year", txtYear.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@ModelCode", txtModelCode.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@RegNo", txtRegNo.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@VNNo", txtVNno.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Kmtr", txtKmtr.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Color", txtColor.Text.Trim());
               
                //sqlCmd.Parameters.AddWithValue("@User_ID", currentUser.UserID);

                _PurchaseID = Convert.ToInt32(sqlCmd.ExecuteScalar());
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
                        SqlCommand sqlCmd = new SqlCommand("ExternalSaleDetailAddOrEdit", sqlC);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@SaleDetailID", Convert.ToInt32(dgvRow.Cells["dgvPurchaseDetailID"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvPurchaseDetailID"].Value));
                        sqlCmd.Parameters.AddWithValue("@Item_ID", dgvRow.Cells["dgvPartNumber"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvPartNumber"].Value);
                        sqlCmd.Parameters.AddWithValue("@Item_Title", dgvRow.Cells["dgvItemTitle"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvItemTitle"].Value);
                        sqlCmd.Parameters.AddWithValue("@ProductGroup", dgvRow.Cells["dgvCMBGroup"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvCMBGroup"].Value);
                        sqlCmd.Parameters.AddWithValue("@Qty", Convert.ToInt32(dgvRow.Cells["dgvQTY"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvQTY"].Value));
                        sqlCmd.Parameters.AddWithValue("@Rate", Convert.ToDecimal(dgvRow.Cells["DGVPurchaseUnitPrice"].Value == DBNull.Value ? "0" : dgvRow.Cells["DGVPurchaseUnitPrice"].Value));
                        sqlCmd.Parameters.AddWithValue("@TotalPrice", Convert.ToDecimal(dgvRow.Cells["dgvTotalPrice"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvTotalPrice"].Value));
                        sqlCmd.Parameters.AddWithValue("@ExternalSaleMasterID", _PurchaseID);
                        sqlCmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);

                        sqlCmd.ExecuteNonQuery();
                    }
                }
            }
            // FillEmployeeViewAll();
            //Clear();
            MessageBox.Show("Submitted Successfully");
        }

        private void frmRepairOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
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

        //private void SearchInvoiceDetail(int PID)
        //{

        //    DataGridViewRow _dgvCurrentRow = dgvFlexInvoice.CurrentRow;
        //    PID = Convert.ToInt32(txtSearch.Text);
        //    using (SqlConnection con = new SqlConnection(strConnectionString))
        //    {
        //        con.Open();
        //        SqlDataAdapter da = new SqlDataAdapter("usp_ViewEstimateByInvoiceNumber", con);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.AddWithValue("@InvoiceNumber", PID);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);

        //        //Master Fill
        //        DataRow dr = ds.Tables[0].Rows[0];

        //        inInvoiceID = Convert.ToInt32(dr["SaleID"]);
        //        txtInvoiceMaxID.Text = Convert.ToInt32(dr["SaleID"]).ToString();

        //        txtInvoiceNo.Text = dr["InvoiceNumber"].ToString();
        //        cmbCustomer.Text = dr["FullName"].ToString();
        //        dtSalesDate.Value = Convert.ToDateTime(dr["SaleDate"]);
        //        lblTotalQty.Text = dr["TotalQTY"].ToString();
        //        lblTotalAmount.Text = dr["TotalAmount"].ToString();
        //        txtLaborCost.Text = dr["LaborCost"].ToString();
        //        txtFittingCharges.Text = dr["FittingCharges"].ToString();
        //        txtFramingChargs.Text = dr["FramingCharges"].ToString();
        //        cmbInkType.Text = dr["DescriptionInkType"].ToString();
        //        txtInkToproduction.Text = dr["OutToProduction"].ToString();
        //        txtInkPurchasePrice.Text = dr["PurchasePerLtrPrice"].ToString();
        //        txtInkSalePrice.Text = dr["SalePrice"].ToString();
        //        txtInkTotalPrice.Text = dr["TotalSalePriceInk"].ToString();
        //        txtFinalTotal.Text = dr["FinalTotal"].ToString();
        //        txtPaid.Text = dr["Paid"].ToString();
        //        txtBalance.Text = dr["Balance"].ToString();

        //        dgvFlexInvoice.AutoGenerateColumns = false;
        //        dgvFlexInvoice.DataSource = ds.Tables[1];

        //        btnDelete.Enabled = true;
        //        btnSave.Text = "Update";
        //    }
        //}

        private void btnload_Click(object sender, EventArgs e)
        {

        }

    }
}
