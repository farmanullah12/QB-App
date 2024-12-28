using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QBranchApp.DAL;

namespace QBranchApp.Stock
{
    public partial class frmStockOpening : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        public int inPartID = 0;


        string QueryString;

        public frmStockOpening()
        {
            InitializeComponent();
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
                dt = obj.getData("[usp_SearchOpeningStock]", parameters, values);
                dgvItemListStockOpening.DataSource = dt;
            }
            catch (Exception ex)
            { }

        }
        void Clear()
        {
            txtStockQty.Text = txtPartNo.Text = "";
            
            btnSave.Text = "Save";
            inPartID = 0;
        }

        private void LoadiTEMmASTER()
        {
            DataTable dt = new DataTable();
            dt = obj.getData("[usp_GetItemOpening]", null, null);
            dgvItemListStockOpening.DataSource = dt;

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
        

        private void frmStockOpening_Load(object sender, EventArgs e)
        {
            try
            {
                Clear();
                LoadiTEMmASTER();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check Data Parameters! or contact your database administrator!");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchItemMaster();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvItemListStockOpening_DoubleClick(object sender, EventArgs e)
        {
            inPartID = Convert.ToInt32(dgvItemListStockOpening.SelectedRows[0].Cells[0].Value.ToString());
            txtPartNo.Text = dgvItemListStockOpening.SelectedRows[0].Cells[1].Value.ToString();
            txtStockQty.Text = dgvItemListStockOpening.SelectedRows[0].Cells[2].Value.ToString();
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string QueryString = string.Format("update Item_Master set StockQty='" + txtStockQty.Text.Trim() + "' where itemID='" + inPartID + "' and PartNo='" + txtPartNo.Text.Trim() + "'");
            string QueryString1 = string.Format("update stock_Master set StockQty='" + txtStockQty.Text.Trim() + "' where itemID='" + inPartID + "' and PartNo='" + txtPartNo.Text.Trim() + "'");

            bool result = DatabaseAccess.Update(QueryString);
            bool result1 = DatabaseAccess.Update(QueryString1);
            if (result)
            {
                MessageBox.Show("Quantity for Part Number:" + " " + txtPartNo.Text.Trim() + " " + "Successfully Added", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                btnSave.Enabled = false;
                LoadiTEMmASTER();
            }
            else
            {
                MessageBox.Show("Please Select Valid Part No and Quantity!", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (result1)
            {
                MessageBox.Show("Quantity for Part Number:" + " " + txtPartNo.Text.Trim() + " " + "Successfully Added", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                btnSave.Enabled = false;
                LoadiTEMmASTER();
            }
            else
            {
                MessageBox.Show("Please Select Valid Part No and Quantity!", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
