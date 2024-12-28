namespace QBranchApp.Stock
{
    partial class frmRepairOrder
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdWaiting = new System.Windows.Forms.RadioButton();
            this.rdNonWaiting = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.rdNormalRo = new System.Windows.Forms.RadioButton();
            this.rdCombackRo = new System.Windows.Forms.RadioButton();
            this.deliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtTran = new System.Windows.Forms.DateTimePicker();
            this.txtRoNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbCustomerInfo = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tbParts = new System.Windows.Forms.TabPage();
            this.dgvSaleList = new System.Windows.Forms.DataGridView();
            this.tbLabor = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvJobID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvJobDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvJobHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvJobAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvJobRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTechID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTechnicianName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtKmtr = new System.Windows.Forms.TextBox();
            this.txtVNno = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtRegNo = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtModelCode = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCarID = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvPurchaseDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItemTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcmbGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVPurchaseUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnload = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbCustomerInfo.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tbParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleList)).BeginInit();
            this.tbLabor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 50);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(47, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Q-Branch: Repair Order";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnload);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtDriver);
            this.panel2.Controls.Add(this.txtRemarks);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.deliveryDate);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dtTran);
            this.panel2.Controls.Add(this.txtRoNum);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(978, 150);
            this.panel2.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(641, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Driver:";
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(697, 110);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(271, 22);
            this.txtDriver.TabIndex = 4;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(111, 96);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(510, 42);
            this.txtRemarks.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Remarks:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdWaiting);
            this.panel4.Controls.Add(this.rdNonWaiting);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(821, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(147, 92);
            this.panel4.TabIndex = 3;
            this.panel4.Visible = false;
            // 
            // rdWaiting
            // 
            this.rdWaiting.AutoSize = true;
            this.rdWaiting.Checked = true;
            this.rdWaiting.Location = new System.Drawing.Point(18, 32);
            this.rdWaiting.Name = "rdWaiting";
            this.rdWaiting.Size = new System.Drawing.Size(76, 21);
            this.rdWaiting.TabIndex = 11;
            this.rdWaiting.TabStop = true;
            this.rdWaiting.Text = "Waiting";
            this.rdWaiting.UseVisualStyleBackColor = true;
            // 
            // rdNonWaiting
            // 
            this.rdNonWaiting.AutoSize = true;
            this.rdNonWaiting.Location = new System.Drawing.Point(18, 59);
            this.rdNonWaiting.Name = "rdNonWaiting";
            this.rdNonWaiting.Size = new System.Drawing.Size(103, 21);
            this.rdNonWaiting.TabIndex = 12;
            this.rdNonWaiting.Text = "Non-waiting";
            this.rdNonWaiting.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Customer Status";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.rdNormalRo);
            this.panel3.Controls.Add(this.rdCombackRo);
            this.panel3.Location = new System.Drawing.Point(644, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(171, 92);
            this.panel3.TabIndex = 14;
            this.panel3.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "R/O Status";
            // 
            // rdNormalRo
            // 
            this.rdNormalRo.AutoSize = true;
            this.rdNormalRo.Location = new System.Drawing.Point(16, 33);
            this.rdNormalRo.Name = "rdNormalRo";
            this.rdNormalRo.Size = new System.Drawing.Size(103, 21);
            this.rdNormalRo.TabIndex = 8;
            this.rdNormalRo.TabStop = true;
            this.rdNormalRo.Text = "Normal R/O";
            this.rdNormalRo.UseVisualStyleBackColor = true;
            // 
            // rdCombackRo
            // 
            this.rdCombackRo.AutoSize = true;
            this.rdCombackRo.Location = new System.Drawing.Point(16, 60);
            this.rdCombackRo.Name = "rdCombackRo";
            this.rdCombackRo.Size = new System.Drawing.Size(129, 21);
            this.rdCombackRo.TabIndex = 9;
            this.rdCombackRo.TabStop = true;
            this.rdCombackRo.Text = "Come Back R/O";
            this.rdCombackRo.UseVisualStyleBackColor = true;
            // 
            // deliveryDate
            // 
            this.deliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.deliveryDate.Location = new System.Drawing.Point(111, 57);
            this.deliveryDate.Name = "deliveryDate";
            this.deliveryDate.Size = new System.Drawing.Size(186, 22);
            this.deliveryDate.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Delivery Date:";
            // 
            // dtTran
            // 
            this.dtTran.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTran.Location = new System.Drawing.Point(433, 16);
            this.dtTran.Name = "dtTran";
            this.dtTran.Size = new System.Drawing.Size(188, 22);
            this.dtTran.TabIndex = 4;
            // 
            // txtRoNum
            // 
            this.txtRoNum.Location = new System.Drawing.Point(111, 15);
            this.txtRoNum.Name = "txtRoNum";
            this.txtRoNum.Size = new System.Drawing.Size(186, 22);
            this.txtRoNum.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(385, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "R.O. No:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbCustomerInfo);
            this.tabControl1.Location = new System.Drawing.Point(12, 226);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1101, 172);
            this.tabControl1.TabIndex = 3;
            // 
            // tbCustomerInfo
            // 
            this.tbCustomerInfo.Controls.Add(this.txtColor);
            this.tbCustomerInfo.Controls.Add(this.label25);
            this.tbCustomerInfo.Controls.Add(this.label24);
            this.tbCustomerInfo.Controls.Add(this.txtKmtr);
            this.tbCustomerInfo.Controls.Add(this.txtVNno);
            this.tbCustomerInfo.Controls.Add(this.label23);
            this.tbCustomerInfo.Controls.Add(this.txtRegNo);
            this.tbCustomerInfo.Controls.Add(this.label22);
            this.tbCustomerInfo.Controls.Add(this.label21);
            this.tbCustomerInfo.Controls.Add(this.label20);
            this.tbCustomerInfo.Controls.Add(this.txtModelCode);
            this.tbCustomerInfo.Controls.Add(this.txtYear);
            this.tbCustomerInfo.Controls.Add(this.txtDesc);
            this.tbCustomerInfo.Controls.Add(this.label19);
            this.tbCustomerInfo.Controls.Add(this.label18);
            this.tbCustomerInfo.Controls.Add(this.txtCarID);
            this.tbCustomerInfo.Controls.Add(this.label15);
            this.tbCustomerInfo.Controls.Add(this.txtCompanyName);
            this.tbCustomerInfo.Controls.Add(this.txtCustomerName);
            this.tbCustomerInfo.Controls.Add(this.label10);
            this.tbCustomerInfo.Location = new System.Drawing.Point(4, 25);
            this.tbCustomerInfo.Name = "tbCustomerInfo";
            this.tbCustomerInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbCustomerInfo.Size = new System.Drawing.Size(1093, 143);
            this.tbCustomerInfo.TabIndex = 0;
            this.tbCustomerInfo.Text = "Customer Info";
            this.tbCustomerInfo.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(536, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 17);
            this.label15.TabIndex = 14;
            this.label15.Text = "Company Name:";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.Location = new System.Drawing.Point(657, 23);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(391, 22);
            this.txtCompanyName.TabIndex = 12;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Location = new System.Drawing.Point(129, 23);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(391, 22);
            this.txtCustomerName.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Customer Name:";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tbParts);
            this.tabControl2.Controls.Add(this.tbLabor);
            this.tabControl2.Location = new System.Drawing.Point(16, 404);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1093, 274);
            this.tabControl2.TabIndex = 4;
            // 
            // tbParts
            // 
            this.tbParts.Controls.Add(this.dgvSaleList);
            this.tbParts.Location = new System.Drawing.Point(4, 25);
            this.tbParts.Name = "tbParts";
            this.tbParts.Padding = new System.Windows.Forms.Padding(3);
            this.tbParts.Size = new System.Drawing.Size(1085, 245);
            this.tbParts.TabIndex = 0;
            this.tbParts.Text = "Parts";
            this.tbParts.UseVisualStyleBackColor = true;
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
            this.dgvItemTitle,
            this.dgvcmbGroup,
            this.dgvQTY,
            this.DGVPurchaseUnitPrice,
            this.dgvTotalPrice});
            this.dgvSaleList.Location = new System.Drawing.Point(7, 7);
            this.dgvSaleList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSaleList.Name = "dgvSaleList";
            this.dgvSaleList.RowHeadersVisible = false;
            this.dgvSaleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSaleList.Size = new System.Drawing.Size(1071, 231);
            this.dgvSaleList.TabIndex = 1;
            this.dgvSaleList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleList_CellEndEdit);
            this.dgvSaleList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSaleList_CellValidating);
            this.dgvSaleList.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleList_RowLeave);
            // 
            // tbLabor
            // 
            this.tbLabor.Controls.Add(this.dataGridView1);
            this.tbLabor.Location = new System.Drawing.Point(4, 25);
            this.tbLabor.Name = "tbLabor";
            this.tbLabor.Padding = new System.Windows.Forms.Padding(3);
            this.tbLabor.Size = new System.Drawing.Size(1085, 245);
            this.tbLabor.TabIndex = 1;
            this.tbLabor.Text = "Labor";
            this.tbLabor.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvJobID,
            this.dgvJobDescription,
            this.dgvJobHours,
            this.dgvJobAmount,
            this.dgvJobRemarks,
            this.dgvTechID,
            this.dgvTechnicianName});
            this.dataGridView1.Location = new System.Drawing.Point(7, 7);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1071, 200);
            this.dataGridView1.TabIndex = 2;
            // 
            // dgvJobID
            // 
            this.dgvJobID.HeaderText = "Job ID";
            this.dgvJobID.Name = "dgvJobID";
            // 
            // dgvJobDescription
            // 
            this.dgvJobDescription.HeaderText = "Job Description";
            this.dgvJobDescription.Name = "dgvJobDescription";
            // 
            // dgvJobHours
            // 
            this.dgvJobHours.HeaderText = "Hours";
            this.dgvJobHours.Name = "dgvJobHours";
            // 
            // dgvJobAmount
            // 
            this.dgvJobAmount.HeaderText = "Amount";
            this.dgvJobAmount.Name = "dgvJobAmount";
            // 
            // dgvJobRemarks
            // 
            this.dgvJobRemarks.HeaderText = "Remarks";
            this.dgvJobRemarks.Name = "dgvJobRemarks";
            // 
            // dgvTechID
            // 
            this.dgvTechID.HeaderText = "Tech ID";
            this.dgvTechID.Name = "dgvTechID";
            // 
            // dgvTechnicianName
            // 
            this.dgvTechnicianName.HeaderText = "Tech.Name";
            this.dgvTechnicianName.Name = "dgvTechnicianName";
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::QBranchApp.Properties.Resources.clipboard;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel5.Location = new System.Drawing.Point(993, 59);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(116, 150);
            this.panel5.TabIndex = 5;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(738, 112);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(45, 17);
            this.label25.TabIndex = 48;
            this.label25.Text = "Color:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(556, 110);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 17);
            this.label24.TabIndex = 47;
            this.label24.Text = "K.Mtr:";
            // 
            // txtKmtr
            // 
            this.txtKmtr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKmtr.Location = new System.Drawing.Point(607, 108);
            this.txtKmtr.Name = "txtKmtr";
            this.txtKmtr.Size = new System.Drawing.Size(115, 22);
            this.txtKmtr.TabIndex = 46;
            // 
            // txtVNno
            // 
            this.txtVNno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVNno.Location = new System.Drawing.Point(349, 106);
            this.txtVNno.Name = "txtVNno";
            this.txtVNno.Size = new System.Drawing.Size(196, 22);
            this.txtVNno.TabIndex = 45;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(275, 108);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 17);
            this.label23.TabIndex = 44;
            this.label23.Text = "VIN No:";
            // 
            // txtRegNo
            // 
            this.txtRegNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegNo.Location = new System.Drawing.Point(129, 106);
            this.txtRegNo.Name = "txtRegNo";
            this.txtRegNo.Size = new System.Drawing.Size(130, 22);
            this.txtRegNo.TabIndex = 43;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(42, 108);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 17);
            this.label22.TabIndex = 42;
            this.label22.Text = "Reg No:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(739, 69);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 17);
            this.label21.TabIndex = 41;
            this.label21.Text = "Model Code:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(556, 66);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 17);
            this.label20.TabIndex = 40;
            this.label20.Text = "Year:";
            // 
            // txtModelCode
            // 
            this.txtModelCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelCode.Location = new System.Drawing.Point(832, 64);
            this.txtModelCode.Name = "txtModelCode";
            this.txtModelCode.Size = new System.Drawing.Size(117, 22);
            this.txtModelCode.TabIndex = 39;
            // 
            // txtYear
            // 
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.Location = new System.Drawing.Point(607, 64);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(115, 22);
            this.txtYear.TabIndex = 38;
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Location = new System.Drawing.Point(349, 64);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(196, 22);
            this.txtDesc.TabIndex = 37;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(275, 66);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 17);
            this.label19.TabIndex = 36;
            this.label19.Text = "Desc:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(43, 66);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 17);
            this.label18.TabIndex = 35;
            this.label18.Text = "Car ID:";
            // 
            // txtCarID
            // 
            this.txtCarID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCarID.Location = new System.Drawing.Point(129, 64);
            this.txtCarID.Name = "txtCarID";
            this.txtCarID.Size = new System.Drawing.Size(130, 22);
            this.txtCarID.TabIndex = 33;
            // 
            // txtColor
            // 
            this.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColor.Location = new System.Drawing.Point(830, 105);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(115, 22);
            this.txtColor.TabIndex = 49;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(993, 680);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 39);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.dgvPartNumber.HeaderText = "Part No";
            this.dgvPartNumber.Name = "dgvPartNumber";
            // 
            // dgvItemTitle
            // 
            this.dgvItemTitle.DataPropertyName = "item_title";
            this.dgvItemTitle.HeaderText = "Item";
            this.dgvItemTitle.Name = "dgvItemTitle";
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
            // dgvQTY
            // 
            this.dgvQTY.DataPropertyName = "qty";
            this.dgvQTY.HeaderText = "Qty";
            this.dgvQTY.Name = "dgvQTY";
            // 
            // DGVPurchaseUnitPrice
            // 
            this.DGVPurchaseUnitPrice.DataPropertyName = "Rate";
            this.DGVPurchaseUnitPrice.HeaderText = "Unit Price";
            this.DGVPurchaseUnitPrice.Name = "DGVPurchaseUnitPrice";
            // 
            // dgvTotalPrice
            // 
            this.dgvTotalPrice.DataPropertyName = "TotalPrice";
            this.dgvTotalPrice.HeaderText = "Total";
            this.dgvTotalPrice.Name = "dgvTotalPrice";
            // 
            // btnload
            // 
            this.btnload.Location = new System.Drawing.Point(304, 15);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(75, 26);
            this.btnload.TabIndex = 18;
            this.btnload.Text = "Load";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // frmRepairOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 726);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepairOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HGML - QBRANCH - REPAIR ORDER";
            this.Load += new System.EventHandler(this.frmRepairOrder_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRepairOrder_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tbCustomerInfo.ResumeLayout(false);
            this.tbCustomerInfo.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tbParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleList)).EndInit();
            this.tbLabor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtTran;
        private System.Windows.Forms.TextBox txtRoNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker deliveryDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdNormalRo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdWaiting;
        private System.Windows.Forms.RadioButton rdNonWaiting;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdCombackRo;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbCustomerInfo;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tbParts;
        private System.Windows.Forms.TabPage tbLabor;
        private System.Windows.Forms.DataGridView dgvSaleList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvJobID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvJobDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvJobHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvJobAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvJobRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTechID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTechnicianName;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtKmtr;
        private System.Windows.Forms.TextBox txtVNno;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtRegNo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtModelCode;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCarID;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPurchaseDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvItemTitle;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcmbGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVPurchaseUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTotalPrice;
        private System.Windows.Forms.Button btnload;
    }
}