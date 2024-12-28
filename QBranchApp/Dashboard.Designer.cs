namespace QBranchApp
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uoMUnitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMasterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stockOpeningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSuppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retailPurchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retailSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repairOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byLeadSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.betweenDatePurchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointOfPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesCollectionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectionSummaryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesReceiptReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockValuationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockBetweenDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.securityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.softwareManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLowStock = new System.Windows.Forms.Button();
            this.btnReadyStock = new System.Windows.Forms.Button();
            this.btnNewQuote = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.securityToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1470, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMasterToolStripMenuItem,
            this.auditLogToolStripMenuItem,
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.masterToolStripMenuItem.Text = "Master";
            this.masterToolStripMenuItem.Visible = false;
            // 
            // itemMasterToolStripMenuItem
            // 
            this.itemMasterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uoMUnitsToolStripMenuItem,
            this.itemMasterToolStripMenuItem1,
            this.stockOpeningToolStripMenuItem,
            this.manageSuppliersToolStripMenuItem,
            this.manageCustomersToolStripMenuItem});
            this.itemMasterToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.InventoryFile;
            this.itemMasterToolStripMenuItem.Name = "itemMasterToolStripMenuItem";
            this.itemMasterToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.itemMasterToolStripMenuItem.Text = "Inventory";
            this.itemMasterToolStripMenuItem.Visible = false;
            // 
            // uoMUnitsToolStripMenuItem
            // 
            this.uoMUnitsToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.document_library1;
            this.uoMUnitsToolStripMenuItem.Name = "uoMUnitsToolStripMenuItem";
            this.uoMUnitsToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.uoMUnitsToolStripMenuItem.Text = "UoM - Units";
            this.uoMUnitsToolStripMenuItem.Click += new System.EventHandler(this.uoMUnitsToolStripMenuItem_Click);
            // 
            // itemMasterToolStripMenuItem1
            // 
            this.itemMasterToolStripMenuItem1.Image = global::QBranchApp.Properties.Resources.bag2_48;
            this.itemMasterToolStripMenuItem1.Name = "itemMasterToolStripMenuItem1";
            this.itemMasterToolStripMenuItem1.Size = new System.Drawing.Size(205, 24);
            this.itemMasterToolStripMenuItem1.Text = "Item Master";
            this.itemMasterToolStripMenuItem1.Click += new System.EventHandler(this.itemMasterToolStripMenuItem1_Click);
            // 
            // stockOpeningToolStripMenuItem
            // 
            this.stockOpeningToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.box_481;
            this.stockOpeningToolStripMenuItem.Name = "stockOpeningToolStripMenuItem";
            this.stockOpeningToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.stockOpeningToolStripMenuItem.Text = "Stock Opening";
            this.stockOpeningToolStripMenuItem.Click += new System.EventHandler(this.stockOpeningToolStripMenuItem_Click);
            // 
            // manageSuppliersToolStripMenuItem
            // 
            this.manageSuppliersToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Supplier_Profile1;
            this.manageSuppliersToolStripMenuItem.Name = "manageSuppliersToolStripMenuItem";
            this.manageSuppliersToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.manageSuppliersToolStripMenuItem.Text = "Manage Suppliers";
            this.manageSuppliersToolStripMenuItem.Click += new System.EventHandler(this.manageSuppliersToolStripMenuItem_Click);
            // 
            // manageCustomersToolStripMenuItem
            // 
            this.manageCustomersToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Supplier_Profile1;
            this.manageCustomersToolStripMenuItem.Name = "manageCustomersToolStripMenuItem";
            this.manageCustomersToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.manageCustomersToolStripMenuItem.Text = "Manage Customers";
            this.manageCustomersToolStripMenuItem.Click += new System.EventHandler(this.manageCustomersToolStripMenuItem_Click);
            // 
            // auditLogToolStripMenuItem
            // 
            this.auditLogToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Supplier_Profile1;
            this.auditLogToolStripMenuItem.Name = "auditLogToolStripMenuItem";
            this.auditLogToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.auditLogToolStripMenuItem.Text = "Users Log";
            this.auditLogToolStripMenuItem.Click += new System.EventHandler(this.auditLogToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Logout_icon;
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.logOutToolStripMenuItem.Text = "Log-Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retailPurchaseToolStripMenuItem,
            this.retailSaleToolStripMenuItem,
            this.repairOrderToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            this.transactionsToolStripMenuItem.Visible = false;
            // 
            // retailPurchaseToolStripMenuItem
            // 
            this.retailPurchaseToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Purchase;
            this.retailPurchaseToolStripMenuItem.Name = "retailPurchaseToolStripMenuItem";
            this.retailPurchaseToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.retailPurchaseToolStripMenuItem.Text = "Retail - Purchase";
            this.retailPurchaseToolStripMenuItem.Visible = false;
            this.retailPurchaseToolStripMenuItem.Click += new System.EventHandler(this.retailPurchaseToolStripMenuItem_Click);
            // 
            // retailSaleToolStripMenuItem
            // 
            this.retailSaleToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.sale;
            this.retailSaleToolStripMenuItem.Name = "retailSaleToolStripMenuItem";
            this.retailSaleToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.retailSaleToolStripMenuItem.Text = "Retail - Sale";
            this.retailSaleToolStripMenuItem.Visible = false;
            this.retailSaleToolStripMenuItem.Click += new System.EventHandler(this.retailSaleToolStripMenuItem_Click);
            // 
            // repairOrderToolStripMenuItem
            // 
            this.repairOrderToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.clipboard;
            this.repairOrderToolStripMenuItem.Name = "repairOrderToolStripMenuItem";
            this.repairOrderToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.repairOrderToolStripMenuItem.Text = "Repair Order";
            this.repairOrderToolStripMenuItem.Click += new System.EventHandler(this.repairOrderToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supplierProfileToolStripMenuItem,
            this.customerProfileToolStripMenuItem,
            this.purchaseToolStripMenuItem,
            this.salesReportsToolStripMenuItem,
            this.pointOfPaymentToolStripMenuItem,
            this.stockReportsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Visible = false;
            // 
            // supplierProfileToolStripMenuItem
            // 
            this.supplierProfileToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Supplier;
            this.supplierProfileToolStripMenuItem.Name = "supplierProfileToolStripMenuItem";
            this.supplierProfileToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.supplierProfileToolStripMenuItem.Text = "Supplier List";
            this.supplierProfileToolStripMenuItem.Visible = false;
            this.supplierProfileToolStripMenuItem.Click += new System.EventHandler(this.supplierProfileToolStripMenuItem_Click);
            // 
            // customerProfileToolStripMenuItem
            // 
            this.customerProfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.byLeadSourceToolStripMenuItem});
            this.customerProfileToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Customer;
            this.customerProfileToolStripMenuItem.Name = "customerProfileToolStripMenuItem";
            this.customerProfileToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.customerProfileToolStripMenuItem.Text = "Customer";
            this.customerProfileToolStripMenuItem.Visible = false;
            this.customerProfileToolStripMenuItem.Click += new System.EventHandler(this.customerProfileToolStripMenuItem_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // byLeadSourceToolStripMenuItem
            // 
            this.byLeadSourceToolStripMenuItem.Name = "byLeadSourceToolStripMenuItem";
            this.byLeadSourceToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.byLeadSourceToolStripMenuItem.Text = "By Lead Source";
            this.byLeadSourceToolStripMenuItem.Click += new System.EventHandler(this.byLeadSourceToolStripMenuItem_Click);
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseReceiptToolStripMenuItem,
            this.betweenDatePurchaseToolStripMenuItem,
            this.purchaseSummaryToolStripMenuItem});
            this.purchaseToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.archives;
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.purchaseToolStripMenuItem.Text = "Purchase";
            this.purchaseToolStripMenuItem.Visible = false;
            // 
            // purchaseReceiptToolStripMenuItem
            // 
            this.purchaseReceiptToolStripMenuItem.Name = "purchaseReceiptToolStripMenuItem";
            this.purchaseReceiptToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.purchaseReceiptToolStripMenuItem.Text = "Purchase Receipt";
            this.purchaseReceiptToolStripMenuItem.Click += new System.EventHandler(this.purchaseReceiptToolStripMenuItem_Click);
            // 
            // betweenDatePurchaseToolStripMenuItem
            // 
            this.betweenDatePurchaseToolStripMenuItem.Name = "betweenDatePurchaseToolStripMenuItem";
            this.betweenDatePurchaseToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.betweenDatePurchaseToolStripMenuItem.Text = "Between Date Purchase";
            this.betweenDatePurchaseToolStripMenuItem.Click += new System.EventHandler(this.betweenDatePurchaseToolStripMenuItem_Click);
            // 
            // purchaseSummaryToolStripMenuItem
            // 
            this.purchaseSummaryToolStripMenuItem.Name = "purchaseSummaryToolStripMenuItem";
            this.purchaseSummaryToolStripMenuItem.Size = new System.Drawing.Size(233, 24);
            this.purchaseSummaryToolStripMenuItem.Text = "Purchase Summary";
            this.purchaseSummaryToolStripMenuItem.Click += new System.EventHandler(this.purchaseSummaryToolStripMenuItem_Click);
            // 
            // salesReportsToolStripMenuItem
            // 
            this.salesReportsToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.statistitcs;
            this.salesReportsToolStripMenuItem.Name = "salesReportsToolStripMenuItem";
            this.salesReportsToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.salesReportsToolStripMenuItem.Text = "Sales Reports";
            this.salesReportsToolStripMenuItem.Visible = false;
            // 
            // pointOfPaymentToolStripMenuItem
            // 
            this.pointOfPaymentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesCollectionReportToolStripMenuItem,
            this.collectionSummaryReportToolStripMenuItem,
            this.salesReceiptReportToolStripMenuItem});
            this.pointOfPaymentToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Purchase;
            this.pointOfPaymentToolStripMenuItem.Name = "pointOfPaymentToolStripMenuItem";
            this.pointOfPaymentToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.pointOfPaymentToolStripMenuItem.Text = "Point of Payment";
            this.pointOfPaymentToolStripMenuItem.Visible = false;
            // 
            // salesCollectionReportToolStripMenuItem
            // 
            this.salesCollectionReportToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.statistitcs;
            this.salesCollectionReportToolStripMenuItem.Name = "salesCollectionReportToolStripMenuItem";
            this.salesCollectionReportToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.salesCollectionReportToolStripMenuItem.Text = "Sales Collection Report";
            this.salesCollectionReportToolStripMenuItem.Visible = false;
            this.salesCollectionReportToolStripMenuItem.Click += new System.EventHandler(this.salesCollectionReportToolStripMenuItem_Click);
            // 
            // collectionSummaryReportToolStripMenuItem
            // 
            this.collectionSummaryReportToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.statistitcs;
            this.collectionSummaryReportToolStripMenuItem.Name = "collectionSummaryReportToolStripMenuItem";
            this.collectionSummaryReportToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.collectionSummaryReportToolStripMenuItem.Text = "Between Date Sale";
            this.collectionSummaryReportToolStripMenuItem.Visible = false;
            this.collectionSummaryReportToolStripMenuItem.Click += new System.EventHandler(this.collectionSummaryReportToolStripMenuItem_Click);
            // 
            // salesReceiptReportToolStripMenuItem
            // 
            this.salesReceiptReportToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.statistitcs;
            this.salesReceiptReportToolStripMenuItem.Name = "salesReceiptReportToolStripMenuItem";
            this.salesReceiptReportToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.salesReceiptReportToolStripMenuItem.Text = "Sales Receipt Report";
            this.salesReceiptReportToolStripMenuItem.Visible = false;
            this.salesReceiptReportToolStripMenuItem.Click += new System.EventHandler(this.salesReceiptReportToolStripMenuItem_Click);
            // 
            // stockReportsToolStripMenuItem
            // 
            this.stockReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStockToolStripMenuItem,
            this.stockValuationToolStripMenuItem,
            this.stockBetweenDateToolStripMenuItem});
            this.stockReportsToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.document_library;
            this.stockReportsToolStripMenuItem.Name = "stockReportsToolStripMenuItem";
            this.stockReportsToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.stockReportsToolStripMenuItem.Text = "Stock Reports";
            // 
            // currentStockToolStripMenuItem
            // 
            this.currentStockToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.box_48;
            this.currentStockToolStripMenuItem.Name = "currentStockToolStripMenuItem";
            this.currentStockToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.currentStockToolStripMenuItem.Text = "Current Stock";
            this.currentStockToolStripMenuItem.Click += new System.EventHandler(this.currentStockToolStripMenuItem_Click);
            // 
            // stockValuationToolStripMenuItem
            // 
            this.stockValuationToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.statistics_48;
            this.stockValuationToolStripMenuItem.Name = "stockValuationToolStripMenuItem";
            this.stockValuationToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.stockValuationToolStripMenuItem.Text = "Stock Valuation";
            // 
            // stockBetweenDateToolStripMenuItem
            // 
            this.stockBetweenDateToolStripMenuItem.Name = "stockBetweenDateToolStripMenuItem";
            this.stockBetweenDateToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.stockBetweenDateToolStripMenuItem.Text = "All";
            this.stockBetweenDateToolStripMenuItem.Visible = false;
            // 
            // securityToolStripMenuItem
            // 
            this.securityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersManagementToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.addUserToolStripMenuItem,
            this.userTypeToolStripMenuItem,
            this.userProfileToolStripMenuItem});
            this.securityToolStripMenuItem.Name = "securityToolStripMenuItem";
            this.securityToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.securityToolStripMenuItem.Text = "Security";
            this.securityToolStripMenuItem.Visible = false;
            // 
            // usersManagementToolStripMenuItem
            // 
            this.usersManagementToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Supplier_Profile;
            this.usersManagementToolStripMenuItem.Name = "usersManagementToolStripMenuItem";
            this.usersManagementToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.usersManagementToolStripMenuItem.Text = "Users Management";
            this.usersManagementToolStripMenuItem.Visible = false;
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Backup;
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Visible = false;
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Customer;
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Visible = false;
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // userTypeToolStripMenuItem
            // 
            this.userTypeToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Supplier;
            this.userTypeToolStripMenuItem.Name = "userTypeToolStripMenuItem";
            this.userTypeToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.userTypeToolStripMenuItem.Text = "User Type";
            this.userTypeToolStripMenuItem.Visible = false;
            this.userTypeToolStripMenuItem.Click += new System.EventHandler(this.userTypeToolStripMenuItem_Click);
            // 
            // userProfileToolStripMenuItem
            // 
            this.userProfileToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.Supplier_Profile2;
            this.userProfileToolStripMenuItem.Name = "userProfileToolStripMenuItem";
            this.userProfileToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.userProfileToolStripMenuItem.Text = "User Profile";
            this.userProfileToolStripMenuItem.Visible = false;
            this.userProfileToolStripMenuItem.Click += new System.EventHandler(this.userProfileToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.softwareManualToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Visible = false;
            // 
            // softwareManualToolStripMenuItem
            // 
            this.softwareManualToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.help_icon;
            this.softwareManualToolStripMenuItem.Name = "softwareManualToolStripMenuItem";
            this.softwareManualToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.softwareManualToolStripMenuItem.Text = "Software Manual";
            this.softwareManualToolStripMenuItem.Visible = false;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::QBranchApp.Properties.Resources.help_icon;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Visible = false;
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTime.Location = new System.Drawing.Point(10, 246);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(124, 25);
            this.lblCurrentTime.TabIndex = 1;
            this.lblCurrentTime.Text = "Currenttime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(131, 203);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(105, 25);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "UserName";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLowStock);
            this.panel2.Controls.Add(this.btnReadyStock);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblUserName);
            this.panel2.Controls.Add(this.btnNewQuote);
            this.panel2.Controls.Add(this.lblCurrentTime);
            this.panel2.Controls.Add(this.btnClient);
            this.panel2.Controls.Add(this.btnPurchase);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 654);
            this.panel2.TabIndex = 5;
            // 
            // btnLowStock
            // 
            this.btnLowStock.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLowStock.FlatAppearance.BorderSize = 0;
            this.btnLowStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLowStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLowStock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLowStock.Image = global::QBranchApp.Properties.Resources.statistitcs1;
            this.btnLowStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLowStock.Location = new System.Drawing.Point(7, 367);
            this.btnLowStock.Margin = new System.Windows.Forms.Padding(4);
            this.btnLowStock.Name = "btnLowStock";
            this.btnLowStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLowStock.Size = new System.Drawing.Size(281, 60);
            this.btnLowStock.TabIndex = 17;
            this.btnLowStock.Text = "Low Stock - (Ctrl + L)";
            this.btnLowStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLowStock.UseVisualStyleBackColor = false;
            this.btnLowStock.Click += new System.EventHandler(this.btnLowStock_Click);
            // 
            // btnReadyStock
            // 
            this.btnReadyStock.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnReadyStock.FlatAppearance.BorderSize = 0;
            this.btnReadyStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadyStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadyStock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReadyStock.Image = global::QBranchApp.Properties.Resources.box_482;
            this.btnReadyStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReadyStock.Location = new System.Drawing.Point(7, 299);
            this.btnReadyStock.Margin = new System.Windows.Forms.Padding(4);
            this.btnReadyStock.Name = "btnReadyStock";
            this.btnReadyStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnReadyStock.Size = new System.Drawing.Size(281, 60);
            this.btnReadyStock.TabIndex = 16;
            this.btnReadyStock.Text = "Ready Stock - (Ctrl + I)";
            this.btnReadyStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReadyStock.UseVisualStyleBackColor = false;
            this.btnReadyStock.Click += new System.EventHandler(this.btnReadyStock_Click);
            // 
            // btnNewQuote
            // 
            this.btnNewQuote.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnNewQuote.FlatAppearance.BorderSize = 0;
            this.btnNewQuote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewQuote.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewQuote.Image = ((System.Drawing.Image)(resources.GetObject("btnNewQuote.Image")));
            this.btnNewQuote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewQuote.Location = new System.Drawing.Point(7, 119);
            this.btnNewQuote.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewQuote.Name = "btnNewQuote";
            this.btnNewQuote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNewQuote.Size = new System.Drawing.Size(281, 50);
            this.btnNewQuote.TabIndex = 15;
            this.btnNewQuote.Text = "New Sale - (Ctrl+S)";
            this.btnNewQuote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewQuote.UseVisualStyleBackColor = false;
            this.btnNewQuote.Click += new System.EventHandler(this.btnNewQuote_Click);
            // 
            // btnClient
            // 
            this.btnClient.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClient.FlatAppearance.BorderSize = 0;
            this.btnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClient.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClient.Image = ((System.Drawing.Image)(resources.GetObject("btnClient.Image")));
            this.btnClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClient.Location = new System.Drawing.Point(7, 60);
            this.btnClient.Margin = new System.Windows.Forms.Padding(4);
            this.btnClient.Name = "btnClient";
            this.btnClient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClient.Size = new System.Drawing.Size(281, 50);
            this.btnClient.TabIndex = 14;
            this.btnClient.Text = "Add Customer - (Ctrl + C)";
            this.btnClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClient.UseVisualStyleBackColor = false;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPurchase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPurchase.FlatAppearance.BorderSize = 0;
            this.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPurchase.Image = ((System.Drawing.Image)(resources.GetObject("btnPurchase.Image")));
            this.btnPurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurchase.Location = new System.Drawing.Point(7, 1);
            this.btnPurchase.Margin = new System.Windows.Forms.Padding(4);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(281, 50);
            this.btnPurchase.TabIndex = 13;
            this.btnPurchase.Text = "New Purchase - (Ctrl + P)";
            this.btnPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QBranchApp.Properties.Resources.BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1470, 678);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dashboard";
            this.Text = "HGML - QBranch - Application Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dashboard_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retailPurchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retailSaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem securityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem softwareManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uoMUnitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMasterToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageSuppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointOfPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesCollectionReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectionSummaryReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesReceiptReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockValuationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockOpeningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userProfileToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnNewQuote;
        private System.Windows.Forms.Button btnReadyStock;
        private System.Windows.Forms.Button btnLowStock;
        private System.Windows.Forms.ToolStripMenuItem purchaseReceiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem betweenDatePurchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repairOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byLeadSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockBetweenDateToolStripMenuItem;
    }
}

