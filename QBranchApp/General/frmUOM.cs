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

namespace QBranchApp.General
{
    public partial class frmUOM : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        int inUnitID = 0;

        public frmUOM()
        {
            InitializeComponent();
        }

        private bool checkValidation()
        {
            if (txtUnit.Text == "")
            {
                MessageBox.Show("Unit Title is Required!");
                txtUnit.Focus();
            }

            if (txtUnit.Text != "")
                return true;
            else
                return false;

        }
        void Clear()
        {
            txtUnit.Text = "";
            btnSave.Text = "Save";
            inUnitID = 0;
            btnDelete.Enabled = false;
        }
        private void LoadUnit()
        {
            DataTable dt = new DataTable();
            dt = obj.getData("usp_GetSharedUnit", null, null);
            dgvUnit.DataSource = dt;

        }
        private void SearchUnit()
        {
            try
            {
                List<object> parameters = new List<object>();
                List<object> values = new List<object>();

                parameters.Add("@Unit");
                values.Add(txtSearch.Text);

                DataTable dt = new DataTable();
                dt = obj.getData("usp_SearchUnit", parameters, values);
                dgvUnit.DataSource = dt;
            }
            catch (Exception ex)
            { }

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
        private void frmUOM_Load(object sender, EventArgs e)
        {
            Clear();
            LoadUnit();

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
                    values.Add(Convert.ToInt32(inUnitID));
                    if (MessageBox.Show("Are you sure you want to delete this Transaction", "Transaction Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        obj.dmloperation("usp_DeleteUnit", param, values);
                        MessageBox.Show("Transaction Deleted Successfully...!");
                        Clear();
                        btnDelete.Enabled = false;
                        LoadUnit();
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

            try
            {

                bool CheckEntry = checkValidation();
                if (CheckEntry == true)
                {
                    List<object> param = new List<object>();
                    List<object> values = new List<object>();

                    param.Add("@UnitID");
                    param.Add("@Code");
                    param.Add("@Unit");
                    param.Add("@User_ID");

                    values.Add(inUnitID);
                    values.Add(txtCode.Text);
                    values.Add(txtUnit.Text);
                    values.Add(currentUser.UserID);

                    obj.dmloperation("usp_AddOrEditUnit", param, values);
                    MessageBox.Show("Transaction Succeeded!");
                    Clear();
                    LoadUnit();

                }
                else
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Goes Wrong Contact your Database Administration");
            }
        }

        private void txtUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) != true && char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void dgvUnit_DoubleClick(object sender, EventArgs e)
        {
            inUnitID = Convert.ToInt32(dgvUnit.SelectedRows[0].Cells[0].Value.ToString());
            txtCode.Text = dgvUnit.SelectedRows[0].Cells[1].Value.ToString();
            txtUnit.Text = dgvUnit.SelectedRows[0].Cells[2].Value.ToString();

            btnDelete.Enabled = true;
            btnSave.Text = "Update";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchUnit();
        }
    }
}
