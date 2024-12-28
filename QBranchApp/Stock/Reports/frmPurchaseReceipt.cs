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

namespace QBranchApp.Stock.Reports
{
    public partial class frmPurchaseReceipt : Form
    {
        DatabaseAccess obj = new DatabaseAccess();
        string strConnectionString = @"Data source=.;Database=QBranch; integrated security=true;";
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;


        public frmPurchaseReceipt()
        {
            InitializeComponent();
        }

        private dsPurchaseInvoice GetSupplierList()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Purchase_Report_Invoice where PartyNumber='" + txtBillNo.Text.Trim() + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dsPurchaseInvoice invDS = new dsPurchaseInvoice())
                        {
                            sda.Fill(invDS, "DataTable1");
                            return invDS;
                        }
                    }
                }
            }
        }

        private dsPurchaseInvoice SupplierBasedPurchaes()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Purchase_Report_Invoice where CompanyName='" + txtBillNo.Text.Trim() + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dsPurchaseInvoice invDS = new dsPurchaseInvoice())
                        {
                            sda.Fill(invDS, "DataTable1");
                            return invDS;
                        }
                    }
                }
            }
        }

        private dsPurchaseSummaryReport GetDateWisePurchase()
        {
            string constr = @"Data source=.;Database=QBranch; user id=sa; password=123";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select item_ID+' '+Item_Title as Description,CompanyName,FullName,PartyNumber,PurchaseDate,TotalAmount from Purchase_Report_Invoice where CompanyName='"+cmbSupplier.Text+"' "))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (dsPurchaseSummaryReport invDS = new dsPurchaseSummaryReport())
                        {
                            sda.Fill(invDS, "DataTable1");
                            return invDS;
                        }
                    }
                }
            }
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            rptPurchaseInvoice crystalReport = new rptPurchaseInvoice();
            dsPurchaseInvoice dsCrPrchList = GetSupplierList();
            crystalReport.SetDataSource(dsCrPrchList);
            this.crDATEWISEREPORT.ReportSource = crystalReport;
        }

        private void btnSupplierPurchase_Click(object sender, EventArgs e)
        {
            SupplierWisePurchase crystalReport = new SupplierWisePurchase();
            dsPurchaseSummaryReport lgr = GetDateWisePurchase();
            crystalReport.SetDataSource(lgr);
            this.crDATEWISEREPORT.ReportSource = crystalReport;
           
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

        private void frmPurchaseReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                SupplierComboFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Check Suppliers List Data or Contact your Database Administrator!");
            }
        }
    }
}
