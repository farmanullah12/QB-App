namespace QBranchApp.Stock.Reports
{
    partial class frmPurchaseSummaryReport
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
            this.crPurchaseSummaryReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crPurchaseSummaryReport
            // 
            this.crPurchaseSummaryReport.ActiveViewIndex = -1;
            this.crPurchaseSummaryReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crPurchaseSummaryReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crPurchaseSummaryReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crPurchaseSummaryReport.Location = new System.Drawing.Point(0, 0);
            this.crPurchaseSummaryReport.Name = "crPurchaseSummaryReport";
            this.crPurchaseSummaryReport.Size = new System.Drawing.Size(1186, 723);
            this.crPurchaseSummaryReport.TabIndex = 0;
            this.crPurchaseSummaryReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmPurchaseSummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 723);
            this.Controls.Add(this.crPurchaseSummaryReport);
            this.Name = "frmPurchaseSummaryReport";
            this.Text = "HGML - QBRANCH PURCHASE SUMMARY REPORT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPurchaseSummaryReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crPurchaseSummaryReport;
    }
}