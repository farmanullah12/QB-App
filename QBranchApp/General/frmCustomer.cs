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
    public partial class frmCustomer : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        public int inClientID = 0;

        public frmCustomer()
        {
            InitializeComponent();
        }


        private bool checkValidation()
        {
            if (txtBusinessName.Text == "")
            {
                MessageBox.Show("Please Enter Employee Full-Name!");
                txtBusinessName.Focus();
            }
            else if (cmbLeadSource.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Lead Source!");
                cmbLeadSource.Focus();
            }
            else if (txtStreetNumber.Text == "")
            {
                MessageBox.Show("Please Enter Street No.!");
                txtStreetNumber.Focus();
            }
            else if (txtCity.Text == "")
            {
                MessageBox.Show("Please Enter Client City!");
                txtCity.Focus();
            }
            else if (txtPhone.Text == "")
            {
                MessageBox.Show("Please Enter At least One Contact Number!");
                txtPhone.Focus();
            }
            else if (txtContactPerson.Text == "")
            {
                MessageBox.Show("Please Enter At least One Contact Person!");
                txtContactPerson.Focus();
            }


            if (txtBusinessName.Text != "" && cmbLeadSource.SelectedIndex != 0 && txtStreetNumber.Text != "" && txtCity.Text != "" && txtPhone.Text != "" && txtLeadSourceName.Text != "")
                return true;
            else
                return false;

        }
        void Clear()
        {
            txtBusinessName.Text = txtContactPerson.Text = txtLeadSourceName.Text = txtSourceContact.Text = txtFullName.Text = txtStreetNumber.Text = txtCity.Text = txtState.Text = txtZipCode.Text = txtEmailID.Text = txtPhone.Text = txtContact.Text = txtLeadSourceName.Text = txtRemarks.Text = "";
            cmbLeadSource.SelectedIndex = 0;
            btnSave.Text = "Save";
            inClientID = 0;
            dtRegistry.Value = DateTime.Now;
            btnDelete.Enabled = false;
        }
        public void cmbDocumentType()
        {
            DataTable dt = new DataTable();
            dt = obj.getData("usp_GetSharedLeadSource", null, null);
            DataRow TopItem = dt.NewRow();
            TopItem[0] = 0;
            TopItem[1] = "-Select-";
            dt.Rows.InsertAt(TopItem, 0);
            cmbLeadSource.DataSource = dt;
            cmbLeadSource.DisplayMember = "LeadSourceTitle";
            cmbLeadSource.ValueMember = "ID";
        }

        private void LoadClientList()
        {
            DataTable dt = new DataTable();
            dt = obj.getData("usp_GetClients", null, null);
            dgvClientDetailsList.DataSource = dt;

        }


        private void frmCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Enabled = false;
                cmbDocumentType();
                Clear();
                //pictureBox1.Visible = true;
                //ClientImg.Visible = true;

                LoadClientList();


                // webcame = new WebCam();
                //webcame.InitializeWebCam(ref pictureBox1);
                //webcame.Start();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Check Data Load Methods.!");
            }
        }

        public void SaveClient()
        {
            //try
            //{

            bool CheckEntry = checkValidation();
            if (CheckEntry == true)
            {
                //byte[] images = null;
                //FileStream Stream = new FileStream(imageLocation,FileMode.Open,FileAccess.Read);
                //BinaryReader br = new BinaryReader(Stream);
                //images = br.ReadBytes((int)Stream.Length);

                //MemoryStream mr = new MemoryStream();
                //ClientImg.Image.Save(mr, System.Drawing.Imaging.ImageFormat.Jpeg);
                //byte[] images = mr.ToArray();

                List<object> param = new List<object>();
                List<object> values = new List<object>();

                param.Add("@ClientID");
                param.Add("@FullName");
                param.Add("@BusinessName");
                param.Add("@ContactPerson");
                param.Add("@StreetNo");
                param.Add("@City");
                param.Add("@State");
                param.Add("@ZipCode");

                param.Add("@EmailID");
                param.Add("@PhoneNo");
                param.Add("@ContactNo");
                param.Add("@DateOfRegistry");
                param.Add("@Remarks");
                param.Add("@LeadSourceID");
                param.Add("@LeadSourceName");
                param.Add("@LeadSourceContact");
                param.Add("@User_ID");

                values.Add(inClientID);
                values.Add(txtFullName.Text);
                values.Add(txtBusinessName.Text);
                values.Add(txtContactPerson.Text);
                values.Add(txtStreetNumber.Text);
                values.Add(txtCity.Text);
                values.Add(txtState.Text);
                values.Add(txtZipCode.Text);
                values.Add(txtEmailID.Text);
                values.Add(txtPhone.Text);
                values.Add(txtContact.Text);
                values.Add(dtRegistry.Value.ToShortDateString());
                values.Add(txtRemarks.Text);
                values.Add(cmbLeadSource.SelectedValue);
                values.Add(txtLeadSourceName.Text);
                values.Add(txtSourceContact.Text);
                values.Add(currentUser.UserID);

                obj.dmloperation("usp_AddOrEditClientInfo", param, values);
                MessageBox.Show("Transaction Succeeded!");
                Clear();
                btnSave.Text = "Save";
                LoadClientList();
            }
            else
            { }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Something Goes Wrong Contact your Database Administration");
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClient();
        }

        private void dgvClientDetailsList_DoubleClick(object sender, EventArgs e)
        {
            inClientID = Convert.ToInt32(dgvClientDetailsList.SelectedRows[0].Cells[0].Value.ToString());
            txtFullName.Text = dgvClientDetailsList.SelectedRows[0].Cells[1].Value.ToString();
            txtBusinessName.Text = dgvClientDetailsList.SelectedRows[0].Cells[2].Value.ToString();
            txtContactPerson.Text = dgvClientDetailsList.SelectedRows[0].Cells[3].Value.ToString();
            txtStreetNumber.Text = dgvClientDetailsList.SelectedRows[0].Cells[4].Value.ToString();
            txtCity.Text = dgvClientDetailsList.SelectedRows[0].Cells[5].Value.ToString();
            txtState.Text = dgvClientDetailsList.SelectedRows[0].Cells[6].Value.ToString();
            txtZipCode.Text = dgvClientDetailsList.SelectedRows[0].Cells[7].Value.ToString();
            txtEmailID.Text = dgvClientDetailsList.SelectedRows[0].Cells[8].Value.ToString();
            txtPhone.Text = dgvClientDetailsList.SelectedRows[0].Cells[9].Value.ToString();
            txtContact.Text = dgvClientDetailsList.SelectedRows[0].Cells[10].Value.ToString();

            dtRegistry.Value = DateTime.Parse((dgvClientDetailsList.SelectedRows[0].Cells[11].Value.ToString()));
            txtRemarks.Text = dgvClientDetailsList.SelectedRows[0].Cells[12].Value.ToString();
            //Byte[] images = Encoding.ASCII.GetBytes(dgvClientDetailsList.SelectedRows[0].Cells[13].Value.ToString());
            //if (images == null)
            //{
            //    ClientImg.Image = null;
            //    ClientImg.Visible = true;
            //    pictureBox1.Visible = false;
            //}
            //else
            //{
            //    var DATA = (Byte[])(dgvClientDetailsList.SelectedRows[0].Cells[13].Value);
            //    var stream = new MemoryStream(DATA);
            //    ClientImg.Visible = true;
            //    ClientImg.Image = Image.FromStream(stream);
            //    pictureBox1.Visible = false;
            //}

            cmbLeadSource.Text = dgvClientDetailsList.SelectedRows[0].Cells[13].Value.ToString();
            txtLeadSourceName.Text = dgvClientDetailsList.SelectedRows[0].Cells[14].Value.ToString();
            txtSourceContact.Text = dgvClientDetailsList.SelectedRows[0].Cells[15].Value.ToString();

            btnDelete.Enabled = true;
            btnSave.Text = "Update";
            tbClientReg.SelectedIndex = 0;
        }

        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) != true && char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void SearchClient()
        {
            try
            {
                List<object> parameters = new List<object>();
                List<object> values = new List<object>();

                parameters.Add("@ClientTitle");
                values.Add(txtSearch.Text);

                DataTable dt = new DataTable();
                dt = obj.getData("usp_SearchClient", parameters, values);
                dgvClientDetailsList.DataSource = dt;
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchClient();
        }
    }
}
