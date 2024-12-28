namespace QBranchApp.Stock
{
    partial class frmStockOpening
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPartNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStockQty = new System.Windows.Forms.TextBox();
            this.dgvItemListStockOpening = new System.Windows.Forms.DataGridView();
            this.dgvItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStockQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemListStockOpening)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.btnClear);
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtPartNo);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtStockQty);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(449, 164);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Item Master";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(264, 94);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(131, 33);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(111, 94);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 33);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.txtPartNo.Enabled = false;
            this.txtPartNo.Location = new System.Drawing.Point(111, 21);
            this.txtPartNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.ReadOnly = true;
            this.txtPartNo.Size = new System.Drawing.Size(284, 22);
            this.txtPartNo.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 51);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Stock Qty:";
            // 
            // txtStockQty
            // 
            this.txtStockQty.Location = new System.Drawing.Point(111, 51);
            this.txtStockQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtStockQty.Name = "txtStockQty";
            this.txtStockQty.Size = new System.Drawing.Size(284, 22);
            this.txtStockQty.TabIndex = 12;
            this.txtStockQty.Text = "0";
            // 
            // dgvItemListStockOpening
            // 
            this.dgvItemListStockOpening.AllowUserToAddRows = false;
            this.dgvItemListStockOpening.AllowUserToDeleteRows = false;
            this.dgvItemListStockOpening.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItemListStockOpening.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemListStockOpening.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvItemID,
            this.dgvPartNo,
            this.dgvStockQty});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemListStockOpening.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemListStockOpening.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvItemListStockOpening.EnableHeadersVisualStyles = false;
            this.dgvItemListStockOpening.Location = new System.Drawing.Point(0, 230);
            this.dgvItemListStockOpening.Margin = new System.Windows.Forms.Padding(4);
            this.dgvItemListStockOpening.Name = "dgvItemListStockOpening";
            this.dgvItemListStockOpening.ReadOnly = true;
            this.dgvItemListStockOpening.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemListStockOpening.Size = new System.Drawing.Size(449, 440);
            this.dgvItemListStockOpening.TabIndex = 4;
            this.dgvItemListStockOpening.DoubleClick += new System.EventHandler(this.dgvItemListStockOpening_DoubleClick);
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
            // dgvStockQty
            // 
            this.dgvStockQty.DataPropertyName = "StockQty";
            this.dgvStockQty.HeaderText = "Stock Qty";
            this.dgvStockQty.Name = "dgvStockQty";
            this.dgvStockQty.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(76, 181);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(373, 41);
            this.txtSearch.TabIndex = 20;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // frmStockOpening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 670);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvItemListStockOpening);
            this.Controls.Add(this.groupBox5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockOpening";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QBranch - Stock Opening";
            this.Load += new System.EventHandler(this.frmStockOpening_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemListStockOpening)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPartNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStockQty;
        private System.Windows.Forms.DataGridView dgvItemListStockOpening;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStockQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
    }
}