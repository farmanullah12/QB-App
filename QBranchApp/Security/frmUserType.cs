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

namespace QBranchApp.Security
{
    public partial class frmUserType : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        int inUserTypeID = 0;

        public frmUserType()
        {
            InitializeComponent();
        }


        private bool checkValidation()
        {
            if (txtFullName.Text == "")
            {
                MessageBox.Show("User Type is Required!");
                txtFullName.Focus();
            }

            if (txtFullName.Text != "")
                return true;
            else
                return false;

        }
        void Clear()
        {
            txtFullName.Text = "";
            btnRegister.Text = "Save";
            inUserTypeID = 0;
            //btnDelete.Enabled = false;
        }
        private void LoadUserType()
        {
            DataTable dt = new DataTable();
            dt = obj.getData("usp_GetUserType", null, null);
            dgvUserTypeList.DataSource = dt;

        }
        private void SearchUserType()
        {
            try
            {
                List<object> parameters = new List<object>();
                List<object> values = new List<object>();

                parameters.Add("@UserType");
                values.Add(txtSearch.Text);

                DataTable dt = new DataTable();
                dt = obj.getData("usp_SearchUserType", parameters, values);
                dgvUserTypeList.DataSource = dt;
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



        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                bool CheckEntry = checkValidation();
                if (CheckEntry == true)
                {
                    List<object> param = new List<object>();
                    List<object> values = new List<object>();

                    param.Add("@UserTypeID");
                    param.Add("@UserTypeTitle");
                    param.Add("@User_ID");

                    values.Add(inUserTypeID);
                    values.Add(txtFullName.Text);
                    values.Add(currentUser.UserID);


                    obj.dmloperation("[usp_AddOrEditUserType]", param, values);
                    MessageBox.Show("Transaction Succeeded!");
                    Clear();
                    LoadUserType();
                }
                else
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Goes Wrong Contact your Database Administration");
            }
        }

        private void dgvUserTypeList_DoubleClick(object sender, EventArgs e)
        {
            inUserTypeID = Convert.ToInt32(dgvUserTypeList.SelectedRows[0].Cells[0].Value.ToString());
            txtFullName.Text = dgvUserTypeList.SelectedRows[0].Cells[1].Value.ToString();
          
           
            btnRegister.Text = "Update";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchUserType();
        }

        private void frmUserType_Load(object sender, EventArgs e)
        {
            Clear();
            LoadUserType();
        }
    }
}
