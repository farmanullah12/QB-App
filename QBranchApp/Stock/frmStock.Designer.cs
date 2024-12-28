namespace QBranchApp.Stock
{
    partial class frmStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtThrashHoldQty = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPartNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStockQty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.CMBUNIT = new System.Windows.Forms.ComboBox();
            this.dgvSupplierList = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStockQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUnitTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvThrashHoldQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.cmbCategory);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtThrashHoldQty);
            this.groupBox5.Controls.Add(this.btnDelete);
            this.groupBox5.Controls.Add(this.btnClear);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Controls.Add(this.txtDescription);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtPartNo);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtStockQty);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.txtCost);
            this.groupBox5.Controls.Add(this.CMBUNIT);
            this.groupBox5.Location = new System.Drawing.Point(12, 11);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(980, 185);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Item Master";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "TGMO",
            "TGP",
            "BS",
            "DUNLOP"});
            this.cmbCategory.Location = new System.Drawing.Point(111, 134);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(284, 24);
            this.cmbCategory.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 104);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Thrash. Qty:";
            // 
            // txtThrashHoldQty
            // 
            this.txtThrashHoldQty.Location = new System.Drawing.Point(529, 101);
            this.txtThrashHoldQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtThrashHoldQty.Name = "txtThrashHoldQty";
            this.txtThrashHoldQty.Size = new System.Drawing.Size(290, 22);
            this.txtThrashHoldQty.TabIndex = 18;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(838, 101);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(131, 33);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(838, 60);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(131, 33);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Description:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(838, 19);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 33);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(111, 60);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(284, 22);
            this.txtDescription.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Part No:";
            // 
            // txtPartNo
            // 
            this.txtPartNo.Location = new System.Drawing.Point(111, 21);
            this.txtPartNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.Size = new System.Drawing.Size(284, 22);
            this.txtPartNo.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(442, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Stock Qty:";
            // 
            // txtStockQty
            // 
            this.txtStockQty.Enabled = false;
            this.txtStockQty.Location = new System.Drawing.Point(529, 19);
            this.txtStockQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtStockQty.Name = "txtStockQty";
            this.txtStockQty.ReadOnly = true;
            this.txtStockQty.Size = new System.Drawing.Size(290, 22);
            this.txtStockQty.TabIndex = 12;
            this.txtStockQty.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(442, 57);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Cost (Rate):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 101);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "Unit:";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(529, 55);
            this.txtCost.Margin = new System.Windows.Forms.Padding(4);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(290, 22);
            this.txtCost.TabIndex = 1;
            // 
            // CMBUNIT
            // 
            this.CMBUNIT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBUNIT.FormattingEnabled = true;
            this.CMBUNIT.Location = new System.Drawing.Point(111, 101);
            this.CMBUNIT.Margin = new System.Windows.Forms.Padding(4);
            this.CMBUNIT.Name = "CMBUNIT";
            this.CMBUNIT.Size = new System.Drawing.Size(284, 24);
            this.CMBUNIT.TabIndex = 0;
            // 
            // dgvSupplierList
            // 
            this.dgvSupplierList.AllowUserToAddRows = false;
            this.dgvSupplierList.AllowUserToDeleteRows = false;
            this.dgvSupplierList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSupplierList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplierList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvItemID,
            this.dgvPartNo,
            this.dgvDescription,
            this.dgvStockQty,
            this.dgvUnitTitle,
            this.dgvCost,
            this.dgvThrashHoldQty,
            this.dgvCategory});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSupplierList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSupplierList.EnableHeadersVisualStyles = false;
            this.dgvSupplierList.Location = new System.Drawing.Point(13, 232);
            this.dgvSupplierList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSupplierList.Name = "dgvSupplierList";
            this.dgvSupplierList.ReadOnly = true;
            this.dgvSupplierList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupplierList.Size = new System.Drawing.Size(979, 248);
            this.dgvSupplierList.TabIndex = 3;
            this.dgvSupplierList.DoubleClick += new System.EventHandler(this.dgvSupplierList_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 202);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(123, 202);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(284, 22);
            this.txtSearch.TabIndex = 18;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvItemID
            // 
            this.dgvItemID.DataPropertyName = "ItemID";
            this.dgvItemID.HeaderText = "ID";
            this.dgvItemID.Name = "dgvItemID";
            this.dgvItemID.ReadOnly = true;
            this.dgvItemID.Visible = false;
            // 
            // dgvPartNo
            // 
            this.dgvPartNo.DataPropertyName = "PartNo";
            this.dgvPartNo.HeaderText = "Part No";
            this.dgvPartNo.Name = "dgvPartNo";
            this.dgvPartNo.ReadOnly = true;
            // 
            // dgvDescription
            // 
            this.dgvDescription.DataPropertyName = "Description";
            this.dgvDescription.HeaderText = "Description";
            this.dgvDescription.Name = "dgvDescription";
            this.dgvDescription.ReadOnly = true;
            // 
            // dgvStockQty
            // 
            this.dgvStockQty.DataPropertyName = "StockQty";
            this.dgvStockQty.HeaderText = "Stock Qty";
            this.dgvStockQty.Name = "dgvStockQty";
            this.dgvStockQty.ReadOnly = true;
            // 
            // dgvUnitTitle
            // 
            this.dgvUnitTitle.DataPropertyName = "UnitTitle";
            this.dgvUnitTitle.HeaderText = "Unit";
            this.dgvUnitTitle.Name = "dgvUnitTitle";
            this.dgvUnitTitle.ReadOnly = true;
            // 
            // dgvCost
            // 
            this.dgvCost.DataPropertyName = "Cost";
            this.dgvCost.HeaderText = "Cost (Rate)";
            this.dgvCost.Name = "dgvCost";
            this.dgvCost.ReadOnly = true;
            // 
            // dgvThrashHoldQty
            // 
            this.dgvThrashHoldQty.DataPropertyName = "thrashHoldqty";
            this.dgvThrashHoldQty.HeaderText = "Thrash. Qty";
            this.dgvThrashHoldQty.Name = "dgvThrashHoldQty";
            this.dgvThrashHoldQty.ReadOnly = true;
            // 
            // dgvCategory
            // 
            this.dgvCategory.DataPropertyName = "Category";
            this.dgvCategory.HeaderText = "Category";
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.ReadOnly = true;
            // 
            // frmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 493);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvSupplierList);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.groupBox5);
            this.Name = "frmStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QBRANCH - ITEM MASTER";
            this.Load += new System.EventHandler(this.frmStock_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPartNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStockQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.ComboBox CMBUNIT;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvSupplierList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtThrashHoldQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStockQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUnitTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvThrashHoldQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCategory;
    }
}