namespace QBranchApp.Stock
{
    partial class FrmPurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPurchase));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showAllPurchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPurchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datewisePurchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.dtPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtpartynumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvProductDetails = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValueOfGoods = new System.Windows.Forms.Label();
            this.dgvPurchaseDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcmbGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvItemTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVPurchaseUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductDetails)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QBranchApp.Properties.Resources.stockReady1;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(736, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(47, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Purchase TGMO / BS/ PARTS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 668);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(851, 69);
            this.panel2.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.ContextMenuStrip = this.contextMenuStrip1;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(33, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 44);
            this.button4.TabIndex = 3;
            this.button4.Text = "Options";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.contextMenuStrip1.AllowDrop = true;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllPurchaseToolStripMenuItem,
            this.printPurchaseToolStripMenuItem,
            this.datewisePurchaseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(208, 76);
            // 
            // showAllPurchaseToolStripMenuItem
            // 
            this.showAllPurchaseToolStripMenuItem.Name = "showAllPurchaseToolStripMenuItem";
            this.showAllPurchaseToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.showAllPurchaseToolStripMenuItem.Text = "Show All Purchase";
            this.showAllPurchaseToolStripMenuItem.Click += new System.EventHandler(this.showAllPurchaseToolStripMenuItem_Click);
            // 
            // printPurchaseToolStripMenuItem
            // 
            this.printPurchaseToolStripMenuItem.Name = "printPurchaseToolStripMenuItem";
            this.printPurchaseToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.printPurchaseToolStripMenuItem.Text = "Purchase Return";
            this.printPurchaseToolStripMenuItem.Click += new System.EventHandler(this.printPurchaseToolStripMenuItem_Click);
            // 
            // datewisePurchaseToolStripMenuItem
            // 
            this.datewisePurchaseToolStripMenuItem.Name = "datewisePurchaseToolStripMenuItem";
            this.datewisePurchaseToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.datewisePurchaseToolStripMenuItem.Text = "Date-wise Purchase";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(380, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 44);
            this.button3.TabIndex = 2;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSupplier);
            this.groupBox1.Controls.Add(this.dtPurchaseDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtpartynumber);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(52, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplier Detail";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(145, 34);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(224, 24);
            this.cmbSupplier.TabIndex = 6;
            // 
            // dtPurchaseDate
            // 
            this.dtPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPurchaseDate.Location = new System.Drawing.Point(145, 79);
            this.dtPurchaseDate.Name = "dtPurchaseDate";
            this.dtPurchaseDate.Size = new System.Drawing.Size(224, 22);
            this.dtPurchaseDate.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Purchase Date:";
            // 
            // txtpartynumber
            // 
            this.txtpartynumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpartynumber.Location = new System.Drawing.Point(510, 38);
            this.txtpartynumber.Name = "txtpartynumber";
            this.txtpartynumber.Size = new System.Drawing.Size(224, 22);
            this.txtpartynumber.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(378, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Party Number:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Select Supplier:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvProductDetails);
            this.groupBox3.Location = new System.Drawing.Point(52, 223);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(743, 374);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Product Details";
            // 
            // dgvProductDetails
            // 
            this.dgvProductDetails.AllowUserToDeleteRows = false;
            this.dgvProductDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvProductDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPurchaseDetailID,
            this.dgvPartNumber,
            this.dgvcmbGroup,
            this.dgvItemTitle,
            this.dgvQTY,
            this.DGVPurchaseUnitPrice,
            this.dgvTotalPrice});
            this.dgvProductDetails.Location = new System.Drawing.Point(7, 20);
            this.dgvProductDetails.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProductDetails.Name = "dgvProductDetails";
            this.dgvProductDetails.RowHeadersVisible = false;
            this.dgvProductDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvProductDetails.Size = new System.Drawing.Size(729, 345);
            this.dgvProductDetails.TabIndex = 0;
            this.dgvProductDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductDetails_CellEndEdit);
            this.dgvProductDetails.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvProductDetails_CellValidating);
            this.dgvProductDetails.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductDetails_RowLeave);
            this.dgvProductDetails.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvProductDetails_UserDeletingRow);
            this.dgvProductDetails.DoubleClick += new System.EventHandler(this.dgvProductDetails_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(485, 612);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Value of Goods:";
            // 
            // lblValueOfGoods
            // 
            this.lblValueOfGoods.AutoSize = true;
            this.lblValueOfGoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueOfGoods.Location = new System.Drawing.Point(650, 612);
            this.lblValueOfGoods.Name = "lblValueOfGoods";
            this.lblValueOfGoods.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblValueOfGoods.Size = new System.Drawing.Size(18, 20);
            this.lblValueOfGoods.TabIndex = 6;
            this.lblValueOfGoods.Text = "0";
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
            // FrmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(851, 737);
            this.Controls.Add(this.lblValueOfGoods);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HGML - QBRANCH - PURCHASE";
            this.Load += new System.EventHandler(this.FrmPurchase_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPurchase_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValueOfGoods;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtpartynumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvProductDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtPurchaseDate;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showAllPurchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPurchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datewisePurchaseToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPurchaseDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPartNumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcmbGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItemTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVPurchaseUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTotalPrice;
    }
}