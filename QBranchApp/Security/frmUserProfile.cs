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
using System.IO;
using QBranchApp.Helpers;

namespace QBranchApp.Security
{
    public partial class frmUserProfile : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        public int inUserID = 0;
        string imageLocation = "";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds; int rno = 0;
        MemoryStream ms;
        byte[] photo_aray;

        public frmUserProfile()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName.ToString();
                UserImage.ImageLocation = imageLocation;
            }
        }

        void loaddata()
        {
            adapter = new SqlDataAdapter("select * from View_GetUserProfileInfo where userID='" + currentUser.UserID + "'", con);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            ds = new DataSet(); adapter.Fill(ds, "View_GetUserProfileInfo");
        }

        void showdata()
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblUserType.Text = ds.Tables[0].Rows[rno][1].ToString();
                txtFullName.Text = ds.Tables[0].Rows[rno][2].ToString();
                txtContact.Text = ds.Tables[0].Rows[rno][3].ToString();
                txtEmail.Text = ds.Tables[0].Rows[rno][4].ToString();
                lblUserName.Text = ds.Tables[0].Rows[rno][5].ToString();

                //UserImage.Image = null;
                //if (ds.Tables[0].Rows[rno][6] != System.DBNull.Value)
                //{
                //    photo_aray = (byte[])ds.Tables[0].Rows[rno][6];
                //    MemoryStream ms = new MemoryStream(photo_aray);
                //    UserImage.Image = Image.FromStream(ms);
                //}
            }
            else
                MessageBox.Show("No Records");
        }  

        private void frmUserProfile_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("user id=sa;password=123;database=Qbranch");
            loaddata();
            showdata();

        }
        public int ValidateEmailId(string emailId)
        {
            /*Regular Expressions for email id*/
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (emailId.Length > 0)
            {
                if (!rEMail.IsMatch(emailId))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            return 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnEditProfile.Text == "Edit Profile")
            {
                txtFullName.Enabled = true;
                txtContact.Enabled = true;
                txtEmail.Enabled = true;
                btnEditProfile.Text = "Update";
            }
            else if (btnEditProfile.Text == "Update")
            {
                string query = string.Format("update TBL_User set FullName='" + txtFullName.Text.Trim() + "',ContactNo='" + txtContact.Text.Trim() + "',EmailID='" + txtEmail.Text.Trim() + "'");
                bool result = DatabaseAccess.Update(query);

                int status = ValidateEmailId(txtEmail.Text);
                if (status == 0)
                {
                    MessageBox.Show("Valid E-Mail ID expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (status == 1)
                {
                    MessageBox.Show("Thanks for ptoviding a valid E-mail Id. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result)
                    {

                        MessageBox.Show("Profile Information Succssfully Updated");
                        loaddata();
                        showdata();
                        txtFullName.Enabled = false;
                        txtContact.Enabled = false;
                        txtEmail.Enabled = false;
                        btnEditProfile.Text = "Edit Profile";
                    }
                    else
                    {
                        MessageBox.Show("Contact your database Administrator");
                    }
                
                }
                else if (status == 2)
                {
                    MessageBox.Show("Please enter E-mail Id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

       
                
            }
            //string constr = @"Data Source=.; Initial Catalog=QBranch; user ID=sa; password=123";
            //using (SqlConnection conn = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand("SELECT UserImage FROM View_GetUserProfileInfo WHERE UserID = @Id", conn))
            //    {
            //        cmd.Parameters.AddWithValue("@Id", currentUser.UserID);
            //        conn.Open();
            //        byte[] bytes = null;
            //        System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            //        // Convert Image DataType column value in Image type Object
            //        System.Drawing.Image img = (System.Drawing.Image)converter.ConvertFrom((byte[])cmd.ExecuteScalar());

            //        // using MemoryStream save it into byte format
            //        using (MemoryStream ms = new MemoryStream())
            //        {
            //            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //            bytes = ms.ToArray();
            //        }
            //        conn.Close();
            //        // assign bytes value converted to Image to the PictureBox
            //        UserImage.Image = Image.FromStream(new MemoryStream(bytes));
            //    }
            //}

        }
    }
}
