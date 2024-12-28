using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QBranchApp.DAL;
using System.IO;

namespace QBranchApp.Security
{
    public partial class frmAddUser : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        public int inUserID = 0;

        string imageLocation = "";

        public frmAddUser()
        {
            InitializeComponent();
        }

        public void cmbFillUserType()
        {
            DataTable dt = new DataTable();
            dt = obj.getData("usp_GetSharedUserType", null, null);
            DataRow TopItem = dt.NewRow();
            TopItem[0] = 0;
            TopItem[1] = "-Select-";
            dt.Rows.InsertAt(TopItem, 0);
            cmbUserType.DataSource = dt;
            cmbUserType.DisplayMember = "UserTypeTitle";
            cmbUserType.ValueMember = "UserTypeID";
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            ep.Clear();
            DataTable dt = new DataTable();
            dt = DatabaseAccess.Retrieve("select * from TBL_User where UserName='" + txtUserName.Text.Trim() + "'");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ep.SetError(txtUserName, "UserName Already Registered!");
                    txtUserName.Focus();
                    return;
                }
            }

            MemoryStream mr = new MemoryStream();
            UserImage.Image.Save(mr, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] images = mr.ToArray();

            string Password = Cryptography.Encrypt(txtPassword.Text.ToString());

            string Query = string.Format("insert into TBL_User (User_TypeID,FullName,ContactNo,EmailID,UserName,Password,UserImage) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", cmbUserType.SelectedValue, txtFullName.Text, txtContact.Text, txtEmail.Text, txtUserName.Text, Password, images);
            if (txtPassword.Text.Trim() == txtConfirmPassword.Text.Trim())
            {
                bool result = DatabaseAccess.Insert(Query);
                if (result)
                {

                    MessageBox.Show("Saved Succeed!");
                    //FillGrid("");
                    Clear();

                }
                else
                {
                    MessageBox.Show("Transaction Problem!");
                }
            }
            else
            {
                MessageBox.Show("Password Doesnt Match!");
            }

        }

        private void Clear() {
            txtConfirmPassword.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            try
            {
                cmbFillUserType();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check Data Parameter! or Contact your Database Administrator!");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName.ToString();
                UserImage.ImageLocation = imageLocation;
            }
        }



    }
}
