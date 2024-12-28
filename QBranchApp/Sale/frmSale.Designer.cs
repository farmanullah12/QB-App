namespace QBranchApp.Sale
{
    partial class frmSale
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
            this.lblValueOfGoods = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvSaleList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtSale = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showAllPurchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPurchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleReportsGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.dgvPurchaseDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcmbGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvItemTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItemCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVPurchaseUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblValueOfGoods
            // 
            this.lblValueOfGoods.AutoSize = true;
            this.lblValueOfGoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueOfGoods.Location = new System.Drawing.Point(662, 601);
            this.lblValueOfGoods.Name = "lblValueOfGoods";
            this.lblValueOfGoods.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblValueOfGoods.Size = new System.Drawing.Size(16, 18);
            this.lblValueOfGoods.TabIndex = 16;
            this.lblValueOfGoods.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(530, 604);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Sub Total:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(380, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 44);
            this.button3.TabIndex = 2;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvSaleList);
            this.groupBox3.Location = new System.Drawing.Point(52, 223);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(743, 374);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Product Details";
            // 
            // dgvSaleList
            // 
            this.dgvSaleList.AllowUserToDeleteRows = false;
            this.dgvSaleList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSaleList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvSaleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPurchaseDetailID,
            this.dgvPartNumber,
            this.dgvcmbGroup,
            this.dgvItemTitle,
            this.dgvQTY,
            this.dgvItemCost,
            this.DGVPurchaseUnitPrice,
            this.dgvTotalPrice});
            this.dgvSaleList.Location = new System.Drawing.Point(7, 22);
            this.dgvSaleList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSaleList.Name = "dgvSaleList";
            this.dgvSaleList.RowHeadersVisible = false;
            this.dgvSaleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSaleList.Size = new System.Drawing.Size(729, 338);
            this.dgvSaleList.TabIndex = 1;
            this.dgvSaleList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleList_CellEndEdit);
            this.dgvSaleList.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleList_CellLeave);
            this.dgvSaleList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSaleList_CellMouseClick);
            this.dgvSaleList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSaleList_CellValidating);
            this.dgvSaleList.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleList_RowLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.cmbCustomer);
            this.groupBox1.Controls.Add(this.txtInvoiceNo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtSale);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(52, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 129);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Detail";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.RoyalBlue;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(512, 73);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(224, 42);
            this.button4.TabIndex = 3;
            this.button4.Text = "Check Stock Availability";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(148, 38);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(221, 24);
            this.cmbCustomer.TabIndex = 8;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Location = new System.Drawing.Point(512, 38);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(224, 22);
            this.txtInvoiceNo.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(380, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Invoice Number:";
            // 
            // dtSale
            // 
            this.dtSale.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSale.Location = new System.Drawing.Point(148, 79);
            this.dtSale.Name = "dtSale";
            this.dtSale.Size = new System.Drawing.Size(221, 22);
            this.dtSale.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Sale Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Select Customer:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 668);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(851, 69);
            this.panel2.TabIndex = 12;
            // 
            // button5
            // 
            this.button5.ContextMenuStrip = this.contextMenuStrip1;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(12, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 44);
            this.button5.TabIndex = 21;
            this.button5.Text = "Options";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.contextMenuStrip1.AllowDrop = true;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllPurchaseToolStripMenuItem,
            this.printPurchaseToolStripMenuItem,
            this.saleReportsGraphToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(206, 76);
            // 
            // showAllPurchaseToolStripMenuItem
            // 
            this.showAllPurchaseToolStripMenuItem.Name = "showAllPurchaseToolStripMenuItem";
            this.showAllPurchaseToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.showAllPurchaseToolStripMenuItem.Text = "Show All Invoices";
            this.showAllPurchaseToolStripMenuItem.Click += new System.EventHandler(this.showAllPurchaseToolStripMenuItem_Click);
            // 
            // printPurchaseToolStripMenuItem
            // 
            this.printPurchaseToolStripMenuItem.Name = "printPurchaseToolStripMenuItem";
            this.printPurchaseToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.printPurchaseToolStripMenuItem.Text = "Sale Report";
            this.printPurchaseToolStripMenuItem.Click += new System.EventHandler(this.printPurchaseToolStripMenuItem_Click);
            // 
            // saleReportsGraphToolStripMenuItem
            // 
            this.saleReportsGraphToolStripMenuItem.Name = "saleReportsGraphToolStripMenuItem";
            this.saleReportsGraphToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.saleReportsGraphToolStripMenuItem.Text = "Sale Reports Graph";
            this.saleReportsGraphToolStripMenuItem.Click += new System.EventHandler(this.saleReportsGraphToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(528, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.button2.Location = new System.Drawing.Point(663, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 44);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(47, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SALE TGMO / BS/ PARTS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 69);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QBranchApp.Properties.Resources.statistitcs;
            this.pictureBox1.Location = new System.Drawing.Point(736, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(129, 603);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(373, 59);
            this.txtRemarks.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 600);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Remarks:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(563, 624);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Paid:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(540, 644);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Balance:";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(662, 647);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBalance.Size = new System.Drawing.Size(16, 18);
            this.lblBalance.TabIndex = 19;
            this.lblBalance.Text = "0";
            // 
            // txtPaid
            // 
            this.txtPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaid.Location = new System.Drawing.Point(663, 622);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(119, 22);
            this.txtPaid.TabIndex = 8;
            this.txtPaid.Leave += new System.EventHandler(this.txtPaid_Leave);
            // 
            // dgvPurchaseDetailID
            // 
            this.dgvPurchaseDetailID.DataPropertyName = "PurchaseDetailID";
            this.dgvPurchaseDetailID.HeaderText = "DetailID";
            this.dgvPurchaseDetailID.Name = "dgvPurchaseDetailID";
            this.dgvPurchaseDetailID.Visible = false;
            // 
            // dgvPartNumber
            // 
            this.dgvPartNumber.DataPropertyName = "item_id";
            this.dgvPartNumber.HeaderText = "Description";
            this.dgvPartNumber.Name = "dgvPartNumber";
            // 
            // dgvcmbGroup
            // 
            this.dgvcmbGroup.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvcmbGroup.HeaderText = "Group";
            this.dgvcmbGroup.Items.AddRange(new object[] {
            "TGMO",
            "TGP",
            "BS",
            "DUNLOP"});
            this.dgvcmbGroup.Name = "dgvcmbGroup";
            // 
            // dgvItemTitle
            // 
            this.dgvItemTitle.DataPropertyName = "item_title";
            this.dgvItemTitle.HeaderText = "Item";
            this.dgvItemTitle.Name = "dgvItemTitle";
            // 
            // dgvQTY
            // 
            this.dgvQTY.DataPropertyName = "qty";
            this.dgvQTY.HeaderText = "Qty";
            this.dgvQTY.Name = "dgvQTY";
            // 
            // dgvItemCost
            // 
            this.dgvItemCost.DataPropertyName = "ItemCost";
            this.dgvItemCost.HeaderText = "Cost";
            this.dgvItemCost.Name = "dgvItemCost";
            // 
            // DGVPurchaseUnitPrice
            // 
            this.DGVPurchaseUnitPrice.DataPropertyName = "PurchaseUnitPrice";
            this.DGVPurchaseUnitPrice.HeaderText = "Unit Price";
            this.DGVPurchaseUnitPrice.Name = "DGVPurchaseUnitPrice";
            // 
            // dgvTotalPrice
            // 
            this.dgvTotalPrice.DataPropertyName = "PurchaseTotalPrice";
            this.dgvTotalPrice.HeaderText = "Total";
            this.dgvTotalPrice.Name = "dgvTotalPrice";
            // 
            // frmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(851, 737);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblValueOfGoods);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HGML - QBranch Sale Invoice";
            this.Load += new System.EventHandler(this.frmSale_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSale_KeyDown);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValueOfGoods;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtSale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showAllPurchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPurchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleReportsGraphToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvSaleList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPurchaseDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPartNumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcmbGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItemTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItemCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVPurchaseUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTotalPrice;
    }
}