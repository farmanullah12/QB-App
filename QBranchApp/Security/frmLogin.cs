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
using System.Data.SqlClient;

namespace QBranchApp.Security
{
    public partial class frmLogin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=QBranch;Integrated Security=True"); 

        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Password = "";
            string loginTime = Convert.ToString(DateTime.Now.ToLongTimeString()) + " " + Convert.ToString(DateTime.Now.ToLongDateString());
            bool IsExist = false;
            con.Open();
            SqlCommand cmd = new SqlCommand("select UserID,UserName,Password from TBL_User where UserName='" + txtUserName.Text + "'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Password = sdr.GetString(2); 
                currentUser.UserID = sdr.GetInt32(0);
                currentUser.UserName = sdr.GetString(1);

                IsExist = true;
            }
            con.Close();
            if (IsExist) 
            {
                if (Cryptography.Decrypt(Password).Equals(txtPassword.Text))
                {
                    string LogQuery = string.Format("insert into TBL_Audit_Log (User_ID,Login) values ('" + currentUser.UserID + "','" + loginTime + "')");
                    bool result = DatabaseAccess.Insert(LogQuery);

                    string query = string.Format("SELECT * FROM TBL_Audit_Log ORDER BY LOG_ID DESC");
                    DataTable dt = DatabaseAccess.Retrieve(query);
                    currentUser.Log_ID = Convert.ToInt32(dt.Rows[0]["Log_ID"]);
                    if (result)
                    {
                        //MessageBox.Show("Login Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Dashboard frm = new Dashboard();
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login Problem Check Audit Log Query!...", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Password is wrong!...", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else              {
                MessageBox.Show("Please enter the valid credentials", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    

            //string query = string.Format("select * from TBL_User where UserName='" + txtUserName.Text.Trim() + "' and password='" + txtPassword.Text.Trim() + "' COLLATE SQL_Latin1_General_Cp1_CS_AS");
            //DataTable dt = DatabaseAccess.Retrieve(query);
            //if (dt != null)
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        string password = Convert.ToString(dt.Rows[0]["Password"]);
            //        currentUser.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
            //        currentUser.UserName = Convert.ToString(dt.Rows[0]["UserName"]);

            //        //if (Cryptography.Decrypt(password).Equals(txtPassword.Text))
            //        //{
            //            Dashboard frm = new Dashboard();
            //            this.Hide();
            //            frm.Show();
            //        //}
            //        //else
            //        //{
            //        //    MessageBox.Show("Password is Wrong!", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        //}
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please enter the valid credentials", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
