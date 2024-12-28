using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QBranchApp.DAL;
using QBranchApp.Helpers;

namespace QBranchApp.Stock
{
    public partial class frmStock : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        public int inStockID = 0;

        public frmStock()
        {
            InitializeComponent();
        }

        public void cmbFillUnitOM()
        {
            DataTable dt = new DataTable();
            dt = obj.getData("getSharedUnits", null, null);
            DataRow TopItem = dt.NewRow();
            TopItem[0] = 0;
            TopItem[1] = "-Select-";
            dt.Rows.InsertAt(TopItem, 0);
            CMBUNIT.DataSource = dt;
            CMBUNIT.DisplayMember = "UnitTitle";
            CMBUNIT.ValueMember = "UnitID";
        }
        private void SearchItemMaster()
        {
            try
            {
                List<object> parameters = new List<object>();
                List<object> values = new List<object>();

                parameters.Add("@PartNo");
                values.Add(txtSearch.Text);

                DataTable dt = new DataTable();
                dt = obj.getData("usp_SearchItem", parameters, values);
                dgvSupplierList.DataSource = dt;
            }
            catch (Exception ex)
            { }

        }

        private bool checkValidation()
        {
            if (txtPartNo.Text == "")
            {
                MessageBox.Show("Please Enter Part No");
                txtPartNo.Focus();
            }
            else if (txtDescription.Text == "")
            {
                MessageBox.Show("Please Enter Item Description!");
                txtDescription.Focus();
            }
            else if (txtCost.Text == "")
            {
                MessageBox.Show("Please Enter Item Cost (Rate)!");
                txtCost.Focus();
            }
            else if (txtStockQty.Text == "")
            {
                MessageBox.Show("Please Enter At least One Qty!");
                txtStockQty.Focus();
            }


            if (txtPartNo.Text != "" && txtDescription.Text != "" && txtCost.Text != "" && txtStockQty.Text != "" )
                return true;
            else
                return false;

        }
        void Clear()
        {
            txtStockQty.Text = txtPartNo.Text = txtCost.Text = txtDescription.Text = "";
            CMBUNIT.SelectedIndex = 0;
            btnSave.Text = "Save";
            inStockID = 0;
        }


        public void SaveItemMaster()
        {
            try
            {

                bool CheckEntry = checkValidation();
                if (CheckEntry == true)
                {
                    List<object> param = new List<object>();
                    List<object> values = new List<object>();

                    param.Add("@ItemID");
                    param.Add("@TranDate");
                    param.Add("@PartNo");
                    param.Add("@Description");
                    param.Add("@StockQty");
                    param.Add("@Unit_ID");
                    param.Add("@Cost");
                    param.Add("@ThrashHoldQty");
                    param.Add("@Category");
                    param.Add("@User_ID");
                    param.Add("@TransactionType");
      
                    values.Add(inStockID);
                    values.Add(DateTime.Now);
                    values.Add(txtPartNo.Text);
                    values.Add(txtDescription.Text);
                    values.Add(txtStockQty.Text);
                    values.Add(CMBUNIT.SelectedValue);
                    values.Add(txtCost.Text.Trim());
                    values.Add(txtThrashHoldQty.Text.Trim());
                    values.Add(cmbCategory.Text.Trim());
                    values.Add(currentUser.UserID);
                    values.Add("Purchase");

                    obj.dmloperation("usp_AddOrEditItemMaster", param, values);
                    MessageBox.Show("Transaction Succeeded!");
                    Clear();
                    btnSave.Text = "Save";
                    LoadiTEMmASTER();
                }
                else
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Goes Wrong Contact your Database Administration");
            }
        }

        private void LoadiTEMmASTER()
        {
            DataTable dt = new DataTable();
            dt = obj.getData("[usp_GetItemMaster]", null, null);
            dgvSupplierList.DataSource = dt;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if ((keyData == Keys.Down || keyData == Keys.Up))
                    return true;
                if (msg.WParam.ToInt32() == (int)Keys.Escape)
                {
                    string message = "Are you sure to close...!";
                    string title = "User Alert";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else
                    { }
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            catch { MessageBox.Show("Key Press Error...!"); }

            return false;
        }
        
        
        private void frmStock_Load(object sender, EventArgs e)
        {
            try
            {
                cmbFillUnitOM();
                LoadiTEMmASTER();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check your data parameters or contact your database administrator!!!!");
            }
        }

        private void dgvSupplierList_DoubleClick(object sender, EventArgs e)
        {
            inStockID = Convert.ToInt32(dgvSupplierList.SelectedRows[0].Cells[0].Value.ToString());
            txtPartNo.Text = dgvSupplierList.SelectedRows[0].Cells[1].Value.ToString();
            txtDescription.Text = dgvSupplierList.SelectedRows[0].Cells[2].Value.ToString();
            txtStockQty.Text = dgvSupplierList.SelectedRows[0].Cells[3].Value.ToString();
            CMBUNIT.Text = dgvSupplierList.SelectedRows[0].Cells[4].Value.ToString();
           
            txtCost.Text = dgvSupplierList.SelectedRows[0].Cells[5].Value.ToString();
            txtThrashHoldQty.Text = dgvSupplierList.SelectedRows[0].Cells[6].Value.ToString();

            btnDelete.Enabled = true;
            btnSave.Text = "Update";
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool CheckEntry = checkValidation();
                if (CheckEntry == true)
                {
                    List<object> param = new List<object>();
                    List<object> values = new List<object>();

                    param.Add("@ID");
                    values.Add(Convert.ToInt32(inStockID));
                    if (MessageBox.Show("Are you sure you want to delete this Transaction", "Transaction Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        obj.dmloperation("usp_DeleteItem", param, values);
                        MessageBox.Show("Transaction Deleted Successfully...!");
                        Clear();
                        btnDelete.Enabled = false;
                        LoadiTEMmASTER();
                    }
                }
                else
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Goes Wrong Contact your Database Administration");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveItemMaster();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchItemMaster();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
