namespace QBranchApp.Stock.Reports
{
    partial class frmPurchaseBillPreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crPrchBillPreview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crPrchBillPreview
            // 
            this.crPrchBillPreview.ActiveViewIndex = -1;
            this.crPrchBillPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crPrchBillPreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.crPrchBillPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crPrchBillPreview.Location = new System.Drawing.Point(0, 0);
            this.crPrchBillPreview.Name = "crPrchBillPreview";
            this.crPrchBillPreview.Size = new System.Drawing.Size(1246, 709);
            this.crPrchBillPreview.TabIndex = 0;
            this.crPrchBillPreview.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmPurchaseBillPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 709);
            this.Controls.Add(this.crPrchBillPreview);
            this.Name = "frmPurchaseBillPreview";
            this.Text = "QBRANCH - HGML PURCHASE BILL PREVIEW";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPurchaseBillPreview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crPrchBillPreview;
    }
}