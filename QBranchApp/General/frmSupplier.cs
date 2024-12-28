using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QBranchApp.DAL;

namespace QBranchApp.General
{
    public partial class frmSupplier : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        public int inSupplierID = 0;

        public frmSupplier()
        {
            InitializeComponent();
        }

        private void SearchSupplier()
        {
            try
            {
                List<object> parameters = new List<object>();
                List<object> values = new List<object>();

                parameters.Add("@CompanyName");
                values.Add(txtSearch.Text);

                DataTable dt = new DataTable();
                dt = obj.getData("usp_SearchSupplier", parameters, values);
                dgvSupplierList.DataSource = dt;
            }
            catch (Exception ex)
            { }

        }

        private bool checkValidation()
        {
            if (txtCompany.Text == "")
            {
                MessageBox.Show("Please Enter Company or Supplier Name!");
                txtCompany.Focus();
            }
            else if (txtBillingAddress.Text == "")
            {
                MessageBox.Show("Please Enter Billing Address!");
                txtBillingAddress.Focus();
            }
            else if (txtCity.Text == "")
            {
                MessageBox.Show("Please Enter Client City!");
                txtCity.Focus();
            }
            else if (txtPhone.Text == "")
            {
                MessageBox.Show("Please Enter At least One Phone Number!");
                txtPhone.Focus();
            }
            else if (txtACnUMBER.Text == "")
            {
                MessageBox.Show("Please Enter Bank Account Number!");
                txtACnUMBER.Focus();
            }
            else if (txtContactPerson.Text == "")
            {
                MessageBox.Show("Please Enter At least One Contact Person!");
                txtContactPerson.Focus();
            }
            else if (txtContactNumber.Text == "")
            {
                MessageBox.Show("Please Enter At least One Contact Number!");
                txtContactNumber.Focus();
            }

            if (txtCompany.Text != "" && txtBillingAddress.Text != "" && txtCity.Text != "" && txtPhone.Text != "" && txtACnUMBER.Text != "" && txtContactPerson.Text != "" && txtContactNumber.Text != "")
                return true;
            else
                return false;

        }
        void Clear()
        {
            txtCompany.Text = txtBillingAddress.Text = txtCity.Text = txtState.Text = txtPinCode.Text = txtCountry.Text = txtEmailID.Text = txtPhone.Text = txtContactNumber.Text = txtContactPerson.Text = txtACnUMBER.Text = txtRemarks.Text = txtBankName.Text = txtACnUMBER.Text = "";

            btnSave.Text = "Save";
            inSupplierID = 0;
        }


        public void SaveSupplier()
        {
            try
            {

                bool CheckEntry = checkValidation();
                if (CheckEntry == true)
                {
                    List<object> param = new List<object>();
                    List<object> values = new List<object>();

                    param.Add("@SupplierID");
                    param.Add("@CompanyName");
                    param.Add("@Address");
                    param.Add("@City");
                    param.Add("@State");
                    param.Add("@PinCode");
                    param.Add("@Country");
                    param.Add("@EmailID");
                    param.Add("@PhoneNo");
                    param.Add("@BankName");
                    param.Add("@BankAccountNumber");
                    param.Add("@ContactPerson");
                    param.Add("@ContactNo");
                    param.Add("@Remarks");


                    values.Add(inSupplierID);
                    values.Add(txtCompany.Text);
                    values.Add(txtBillingAddress.Text);
                    values.Add(txtCity.Text);
                    values.Add(txtState.Text);
                    values.Add(txtPinCode.Text);
                    values.Add(txtCountry.Text);
                    values.Add(txtEmailID.Text);
                    values.Add(txtPhone.Text);
                    values.Add(txtBankName.Text);
                    values.Add(txtACnUMBER.Text);
                    values.Add(txtContactPerson.Text);
                    values.Add(txtContactNumber.Text);
                    values.Add(txtRemarks.Text);

                    obj.dmloperation("usp_AddOrEditSupplier", param, values);
                    MessageBox.Show("Transaction Succeeded!");
                    Clear();
                    btnSave.Text = "Save";
                    LoadSupplierList();
                }
                else
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Goes Wrong Contact your Database Administration");
            }
        }

        private void LoadSupplierList()
        {
            DataTable dt = new DataTable();
            dt = obj.getData("usp_GetSupplier", null, null);
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

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            LoadSupplierList();
        }

        private void dgvSupplierList_DoubleClick(object sender, EventArgs e)
        {
            inSupplierID = Convert.ToInt32(dgvSupplierList.SelectedRows[0].Cells[0].Value.ToString());
            txtCompany.Text = dgvSupplierList.SelectedRows[0].Cells[1].Value.ToString();
            txtBillingAddress.Text = dgvSupplierList.SelectedRows[0].Cells[2].Value.ToString();
            txtCity.Text = dgvSupplierList.SelectedRows[0].Cells[3].Value.ToString();
            txtState.Text = dgvSupplierList.SelectedRows[0].Cells[4].Value.ToString();
            txtPinCode.Text = dgvSupplierList.SelectedRows[0].Cells[5].Value.ToString();
            txtCountry.Text = dgvSupplierList.SelectedRows[0].Cells[6].Value.ToString();
            txtEmailID.Text = dgvSupplierList.SelectedRows[0].Cells[7].Value.ToString();
            txtPhone.Text = dgvSupplierList.SelectedRows[0].Cells[8].Value.ToString();
            txtBankName.Text = dgvSupplierList.SelectedRows[0].Cells[9].Value.ToString();
            txtACnUMBER.Text = dgvSupplierList.SelectedRows[0].Cells[10].Value.ToString();
            txtContactPerson.Text = dgvSupplierList.SelectedRows[0].Cells[11].Value.ToString();
            txtContactNumber.Text = dgvSupplierList.SelectedRows[0].Cells[12].Value.ToString();
            txtRemarks.Text = dgvSupplierList.SelectedRows[0].Cells[13].Value.ToString();
            btnDelete.Enabled = true;
            btnSave.Text = "Update";
            tbSuppliers.SelectedIndex = 0;
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

                    param.Add("@SupplierID");
                    values.Add(Convert.ToInt32(inSupplierID));
                    if (MessageBox.Show("Are you sure you want to delete this Transaction", "Transaction Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        obj.dmloperation("usp_DeleteSupplier", param, values);
                        MessageBox.Show("Transaction Deleted Successfully...!");
                        Clear();
                        btnDelete.Enabled = false;
                        LoadSupplierList();
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

        private void txtContactPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) != true && char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void txtCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) != true && char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void txtCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) != true && char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void txtBankName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) != true && char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSupplier();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchSupplier();
        }
    }
}
