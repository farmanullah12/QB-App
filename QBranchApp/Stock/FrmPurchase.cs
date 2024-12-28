using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QBranchApp.Helpers;
using QBranchApp.Stock.Reports;

namespace QBranchApp.Stock
{
    public partial class FrmPurchase : Form
    {
        int inPurchaseID = 0;
       //bool isDefaultImage = true;
        string strConnectionString = @"Data source=.;Database=QBranch; integrated security=true;";

        public FrmPurchase()
        {
            InitializeComponent();
        }

        private void FrmPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }


       
		protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
		{
			if(msg.WParam.ToInt32() == (int) Keys.Enter)
			{
				SendKeys.Send("{Tab}");
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}


        void SupplierComboFill()
        {
            using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select SupplierID,CompanyName from CRM_Supplier", sqlCon);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                DataRow TopItem = dt.NewRow();
                TopItem[0] = 0;
                TopItem[1] = "-Select-";
                dt.Rows.InsertAt(TopItem, 0);
                cmbSupplier.ValueMember = "SupplierID";
                cmbSupplier.DisplayMember = "CompanyName";
                cmbSupplier.DataSource = dt;
                //dgvtxtPosition.DataSource = dt.Copy();
            }
        }

        private void disableCell()
        {
            int n = Convert.ToInt32(dgvProductDetails.Rows.Count.ToString());
            for (int i = 0; i < n; i++)
            {
                dgvProductDetails.Rows[i].Cells["dgvTotalPrice"].ReadOnly = true;
            }
        }

        void calculateColumn()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow item in dgvProductDetails.Rows)
            {
                totalAmount += Convert.ToDecimal(item.Cells["dgvTotalPrice"].Value);
            }
            lblValueOfGoods.Text = totalAmount.ToString();
        }

        private void FrmPurchase_Load(object sender, EventArgs e)
        {
            cmbSupplier.Focus();
            SupplierComboFill();
            disableCell();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int _PurchaseID = 0;
            using (SqlConnection sqlCon = new SqlConnection(strConnectionString))
            {
                sqlCon.Open();
                //Master
                SqlCommand sqlCmd = new SqlCommand("PurchaseAddOrEdit", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@PurchaseID", inPurchaseID);
                sqlCmd.Parameters.AddWithValue("@SupplierID", cmbSupplier.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@PartyNumber", txtpartynumber.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@PurchaseDate", dtPurchaseDate.Value.ToShortDateString());
                sqlCmd.Parameters.AddWithValue("@TotalAmount", Convert.ToDecimal(lblValueOfGoods.Text));
                sqlCmd.Parameters.AddWithValue("@User_ID", currentUser.UserID);
              
                _PurchaseID = Convert.ToInt32(sqlCmd.ExecuteScalar());
            }
            //Details
            using (SqlConnection sqlC = new SqlConnection(strConnectionString))
            {
                sqlC.Open();
                foreach (DataGridViewRow dgvRow in dgvProductDetails.Rows)
                {
                    if (dgvRow.IsNewRow) break;
                    else
                    {
                        SqlCommand sqlCmd = new SqlCommand("PurchaseDetailAddOrEdit", sqlC);
                        sqlCmd.CommandType = CommandType.StoredProcedure;   
                        sqlCmd.Parameters.AddWithValue("@PurchaseDetailID", Convert.ToInt32(dgvRow.Cells["dgvPurchaseDetailID"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvPurchaseDetailID"].Value));
                        sqlCmd.Parameters.AddWithValue("@Item_ID", dgvRow.Cells["dgvPartNumber"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvPartNumber"].Value);
                        sqlCmd.Parameters.AddWithValue("@Item_Title", dgvRow.Cells["dgvItemTitle"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvItemTitle"].Value);
                        sqlCmd.Parameters.AddWithValue("@ProductGroup", dgvRow.Cells["dgvcmbGroup"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvcmbGroup"].Value);
                        sqlCmd.Parameters.AddWithValue("@Qty", Convert.ToInt32(dgvRow.Cells["dgvQTY"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvQTY"].Value));
                        sqlCmd.Parameters.AddWithValue("@PurchaseUnitPrice", Convert.ToDecimal(dgvRow.Cells["DGVPurchaseUnitPrice"].Value == DBNull.Value ? "0" : dgvRow.Cells["DGVPurchaseUnitPrice"].Value));
                        sqlCmd.Parameters.AddWithValue("@PurchaseTotalPrice", Convert.ToDecimal(dgvRow.Cells["dgvTotalPrice"].Value == DBNull.Value ? "0" : dgvRow.Cells["dgvTotalPrice"].Value));
                        sqlCmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);
                        sqlCmd.Parameters.AddWithValue("@Purchase_ID", _PurchaseID);
                        
                        sqlCmd.ExecuteNonQuery();
                    }
                }
            }
           // FillEmployeeViewAll();
            //Clear();
            MessageBox.Show("Submitted Successfully");
            frmPurchaseBillPreview fr = new frmPurchaseBillPreview();
            fr.partyNumber = txtpartynumber.Text;
            fr.Show();
        }

        private void dgvProductDetails_DoubleClick(object sender, EventArgs e)
        {
            //if (dataGridView1.CurrentRow.Index != -1)
            //{
            //    DataGridViewRow _dgvCurrentRow = dataGridView1.CurrentRow;
            //    inPurchaseID = Convert.ToInt32(_dgvCurrentRow.Cells[0].Value);
            //    using (SqlConnection con = new SqlConnection(strConnectionString))
            //    {
            //        con.Open();
            //        SqlDataAdapter da = new SqlDataAdapter("EmployeeViewAllByID", con);
            //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //        da.SelectCommand.Parameters.AddWithValue("@EmpID", inPurchaseID);
            //        DataSet ds = new DataSet();
            //        da.Fill(ds);

            //        //Master Fill
            //        DataRow dr = ds.Tables[0].Rows[0];
            //        txtCode.Text = dr["EmpCode"].ToString();
            //        txtName.Text = dr["EmpName"].ToString();
            //        cmbPosition.SelectedValue = Convert.ToInt32(dr["PositionID"].ToString());
            //        dtDOB.Value = Convert.ToDateTime(dr["DOB"].ToString());
            //        cmbGender.Text = dr["Gender"].ToString();
            //        if (dr["State"].ToString() == "Regular")
            //            rdReg.Checked = true;
            //        else
            //            rbContract.Checked = true;

            //        if (dr["ImagePath"] == DBNull.Value)
            //        {
            //            imgEmpImage.Image = new Bitmap(Application.StartupPath + "\\Images\\userimage.png");
            //            isDefaultImage = true;
            //        }
            //        else
            //        {
            //            imgEmpImage.Image = new Bitmap(Application.StartupPath + "\\Images\\" + dr["ImagePath"].ToString());
            //            strPreviousImage = dr["ImagePath"].ToString();
            //            isDefaultImage = false;
            //        }
            //        dgvEmployeeDetail.AutoGenerateColumns = false;
            //        dgvEmployeeDetail.DataSource = ds.Tables[1];
            //        btnDelete.Enabled = true;
            //        btnSave.Text = "Update";
            //        MasterDetail.SelectedIndex = 0;
            //    }

            //}
        }

        private void dgvProductDetails_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //DataGridViewRow dgvRow = dgvEmployeeDetail.CurrentRow;
            //if (dgvRow.Cells["dgvtxtEmpDetID"].Value != DBNull.Value)
            //{
            //    if (MessageBox.Show("Are You Sure you want to delete the current Record", "Master Detail CRUD", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        using (SqlConnection con = new SqlConnection(strConnectionString))
            //        {
            //            con.Open();
            //            SqlCommand cmd = new SqlCommand("usp_EmployeeDetailDelete", con);
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@EmpDetID", Convert.ToInt32(dgvRow.Cells["dgvtxtEmpDetID"].Value));
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //    else
            //        e.Cancel = true;
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are You Sure you want to delete the current Record", "Master Detail CRUD", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    using (SqlConnection con = new SqlConnection(strConnectionString))
            //    {
            //        con.Open();
            //        SqlCommand cmd = new SqlCommand("EmployeeDelete", con);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@EmpID", inPurchaseID);
            //        cmd.ExecuteNonQuery();
                   
            //        MessageBox.Show("Customer Record Deleted Successfully");
            //    }
            //}
        }

        private void dgvProductDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvProductDetails.Rows)
            {
                row.Cells["dgvTotalPrice"].Value = Convert.ToDecimal(row.Cells["dgvQTY"].Value) * Convert.ToDecimal(row.Cells["DGVPurchaseUnitPrice"].Value);
                
            }
            
        }

        private void dgvProductDetails_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            calculateColumn();
        }

        private void dgvProductDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button4, 0, button4.Height);
        }

        private void showAllPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.frmPurchaseList plist = new frmPurchaseList();
            plist.ShowDialog();
        }

        private void printPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock.frmPurchaseReturn frm = new frmPurchaseReturn();
            frm.ShowDialog();
        }


    }
}
