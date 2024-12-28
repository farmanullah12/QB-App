namespace QBranchApp.General
{
    partial class frmSupplier
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbSuppliers = new System.Windows.Forms.TabControl();
            this.tbSupplierReg = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtACnUMBER = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBillingAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmailID = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtPinCode = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.tbSupplierDetail = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvSupplierList = new System.Windows.Forms.DataGridView();
            this.dgvtxtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPINcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBankAccountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tbSuppliers.SuspendLayout();
            this.tbSupplierReg.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tbSupplierDetail.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierList)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSuppliers
            // 
            this.tbSuppliers.Controls.Add(this.tbSupplierReg);
            this.tbSuppliers.Controls.Add(this.tbSupplierDetail);
            this.tbSuppliers.Location = new System.Drawing.Point(6, 2);
            this.tbSuppliers.Margin = new System.Windows.Forms.Padding(4);
            this.tbSuppliers.Name = "tbSuppliers";
            this.tbSuppliers.SelectedIndex = 0;
            this.tbSuppliers.Size = new System.Drawing.Size(992, 544);
            this.tbSuppliers.TabIndex = 1;
            // 
            // tbSupplierReg
            // 
            this.tbSupplierReg.Controls.Add(this.groupBox2);
            this.tbSupplierReg.Location = new System.Drawing.Point(4, 25);
            this.tbSupplierReg.Margin = new System.Windows.Forms.Padding(4);
            this.tbSupplierReg.Name = "tbSupplierReg";
            this.tbSupplierReg.Padding = new System.Windows.Forms.Padding(4);
            this.tbSupplierReg.Size = new System.Drawing.Size(984, 515);
            this.tbSupplierReg.TabIndex = 0;
            this.tbSupplierReg.Text = "Supplier Registration";
            this.tbSupplierReg.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(9, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(959, 506);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Profile";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(761, 446);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 33);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(656, 444);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 33);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(517, 446);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 33);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtContactPerson);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtContactNumber);
            this.groupBox1.Location = new System.Drawing.Point(517, 169);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(415, 132);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contact Details";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(160, 36);
            this.txtContactPerson.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(235, 22);
            this.txtContactPerson.TabIndex = 1;
            this.txtContactPerson.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContactPerson_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 85);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Contact Number:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 39);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Contact Person:";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Location = new System.Drawing.Point(160, 85);
            this.txtContactNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(235, 22);
            this.txtContactNumber.TabIndex = 2;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.txtRemarks);
            this.groupBox6.Location = new System.Drawing.Point(517, 305);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(415, 134);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Other Details";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 38);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 17);
            this.label13.TabIndex = 12;
            this.label13.Text = "Remarks/Note:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(160, 38);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(235, 78);
            this.txtRemarks.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtBankName);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.txtACnUMBER);
            this.groupBox5.Location = new System.Drawing.Point(517, 32);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(415, 132);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Bank Details:";
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(160, 39);
            this.txtBankName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(235, 22);
            this.txtBankName.TabIndex = 0;
            this.txtBankName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBankName_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 85);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Bank A/c Number:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "Bank Name:";
            // 
            // txtACnUMBER
            // 
            this.txtACnUMBER.Location = new System.Drawing.Point(160, 85);
            this.txtACnUMBER.Margin = new System.Windows.Forms.Padding(4);
            this.txtACnUMBER.Name = "txtACnUMBER";
            this.txtACnUMBER.Size = new System.Drawing.Size(235, 22);
            this.txtACnUMBER.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBillingAddress);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtPhone);
            this.groupBox3.Controls.Add(this.txtEmailID);
            this.groupBox3.Controls.Add(this.txtCountry);
            this.groupBox3.Controls.Add(this.txtPinCode);
            this.groupBox3.Controls.Add(this.txtState);
            this.groupBox3.Controls.Add(this.txtCity);
            this.groupBox3.Controls.Add(this.txtCompany);
            this.groupBox3.Location = new System.Drawing.Point(19, 32);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(483, 465);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Supplier";
            // 
            // txtBillingAddress
            // 
            this.txtBillingAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBillingAddress.Location = new System.Drawing.Point(173, 85);
            this.txtBillingAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtBillingAddress.Multiline = true;
            this.txtBillingAddress.Name = "txtBillingAddress";
            this.txtBillingAddress.Size = new System.Drawing.Size(267, 102);
            this.txtBillingAddress.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 421);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Phone Number:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 380);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "E-mail ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 340);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Country:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 300);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "PIN Code:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 260);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "State:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 209);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "City:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Business Name:";
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(173, 414);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(267, 22);
            this.txtPhone.TabIndex = 7;
            // 
            // txtEmailID
            // 
            this.txtEmailID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailID.Location = new System.Drawing.Point(173, 373);
            this.txtEmailID.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.Size = new System.Drawing.Size(267, 22);
            this.txtEmailID.TabIndex = 6;
            // 
            // txtCountry
            // 
            this.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCountry.Location = new System.Drawing.Point(173, 331);
            this.txtCountry.Margin = new System.Windows.Forms.Padding(4);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(267, 22);
            this.txtCountry.TabIndex = 5;
            this.txtCountry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCountry_KeyPress);
            // 
            // txtPinCode
            // 
            this.txtPinCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPinCode.Location = new System.Drawing.Point(173, 292);
            this.txtPinCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtPinCode.Name = "txtPinCode";
            this.txtPinCode.Size = new System.Drawing.Size(267, 22);
            this.txtPinCode.TabIndex = 4;
            // 
            // txtState
            // 
            this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtState.Location = new System.Drawing.Point(173, 251);
            this.txtState.Margin = new System.Windows.Forms.Padding(4);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(267, 22);
            this.txtState.TabIndex = 3;
            // 
            // txtCity
            // 
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Location = new System.Drawing.Point(173, 209);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(267, 22);
            this.txtCity.TabIndex = 2;
            // 
            // txtCompany
            // 
            this.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompany.Location = new System.Drawing.Point(173, 41);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(267, 22);
            this.txtCompany.TabIndex = 0;
            this.txtCompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompany_KeyPress);
            // 
            // tbSupplierDetail
            // 
            this.tbSupplierDetail.Controls.Add(this.panel4);
            this.tbSupplierDetail.Controls.Add(this.panel3);
            this.tbSupplierDetail.Location = new System.Drawing.Point(4, 25);
            this.tbSupplierDetail.Margin = new System.Windows.Forms.Padding(4);
            this.tbSupplierDetail.Name = "tbSupplierDetail";
            this.tbSupplierDetail.Padding = new System.Windows.Forms.Padding(4);
            this.tbSupplierDetail.Size = new System.Drawing.Size(984, 515);
            this.tbSupplierDetail.TabIndex = 1;
            this.tbSupplierDetail.Text = "SupplierDetail";
            this.tbSupplierDetail.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvSupplierList);
            this.panel4.Location = new System.Drawing.Point(13, 74);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(960, 417);
            this.panel4.TabIndex = 5;
            // 
            // dgvSupplierList
            // 
            this.dgvSupplierList.AllowUserToAddRows = false;
            this.dgvSupplierList.AllowUserToDeleteRows = false;
            this.dgvSupplierList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSupplierList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplierList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtxtID,
            this.dgvCompanyName,
            this.dgvAddress,
            this.dgvCity,
            this.dgvState,
            this.dgvPINcode,
            this.dgvCountry,
            this.dgvEmail,
            this.dgvPhone,
            this.dgvBankName,
            this.dgvBankAccountNumber,
            this.dgvContactPerson,
            this.dgvContactNo,
            this.dgvRemarks});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSupplierList.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSupplierList.EnableHeadersVisualStyles = false;
            this.dgvSupplierList.Location = new System.Drawing.Point(4, 4);
            this.dgvSupplierList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSupplierList.Name = "dgvSupplierList";
            this.dgvSupplierList.ReadOnly = true;
            this.dgvSupplierList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupplierList.Size = new System.Drawing.Size(952, 400);
            this.dgvSupplierList.TabIndex = 0;
            this.dgvSupplierList.DoubleClick += new System.EventHandler(this.dgvSupplierList_DoubleClick);
            // 
            // dgvtxtID
            // 
            this.dgvtxtID.DataPropertyName = "SupplierID";
            this.dgvtxtID.HeaderText = "ID";
            this.dgvtxtID.Name = "dgvtxtID";
            this.dgvtxtID.ReadOnly = true;
            this.dgvtxtID.Visible = false;
            // 
            // dgvCompanyName
            // 
            this.dgvCompanyName.DataPropertyName = "CompanyName";
            this.dgvCompanyName.HeaderText = "Company Name";
            this.dgvCompanyName.Name = "dgvCompanyName";
            this.dgvCompanyName.ReadOnly = true;
            // 
            // dgvAddress
            // 
            this.dgvAddress.DataPropertyName = "Address";
            this.dgvAddress.HeaderText = "Address";
            this.dgvAddress.Name = "dgvAddress";
            this.dgvAddress.ReadOnly = true;
            // 
            // dgvCity
            // 
            this.dgvCity.DataPropertyName = "City";
            this.dgvCity.HeaderText = "City";
            this.dgvCity.Name = "dgvCity";
            this.dgvCity.ReadOnly = true;
            // 
            // dgvState
            // 
            this.dgvState.DataPropertyName = "State";
            this.dgvState.HeaderText = "State";
            this.dgvState.Name = "dgvState";
            this.dgvState.ReadOnly = true;
            // 
            // dgvPINcode
            // 
            this.dgvPINcode.DataPropertyName = "PINcode";
            this.dgvPINcode.HeaderText = "PIN Code";
            this.dgvPINcode.Name = "dgvPINcode";
            this.dgvPINcode.ReadOnly = true;
            // 
            // dgvCountry
            // 
            this.dgvCountry.DataPropertyName = "Country";
            this.dgvCountry.HeaderText = "Country";
            this.dgvCountry.Name = "dgvCountry";
            this.dgvCountry.ReadOnly = true;
            // 
            // dgvEmail
            // 
            this.dgvEmail.DataPropertyName = "Email";
            this.dgvEmail.HeaderText = "Email";
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.ReadOnly = true;
            // 
            // dgvPhone
            // 
            this.dgvPhone.DataPropertyName = "PhoneNo";
            this.dgvPhone.HeaderText = "Phone";
            this.dgvPhone.Name = "dgvPhone";
            this.dgvPhone.ReadOnly = true;
            // 
            // dgvBankName
            // 
            this.dgvBankName.DataPropertyName = "BankName";
            this.dgvBankName.HeaderText = "BankName";
            this.dgvBankName.Name = "dgvBankName";
            this.dgvBankName.ReadOnly = true;
            // 
            // dgvBankAccountNumber
            // 
            this.dgvBankAccountNumber.DataPropertyName = "BankAccountNumber";
            this.dgvBankAccountNumber.HeaderText = "Bank Account Number";
            this.dgvBankAccountNumber.Name = "dgvBankAccountNumber";
            this.dgvBankAccountNumber.ReadOnly = true;
            // 
            // dgvContactPerson
            // 
            this.dgvContactPerson.DataPropertyName = "ContactPerson";
            this.dgvContactPerson.HeaderText = "Contact Person";
            this.dgvContactPerson.Name = "dgvContactPerson";
            this.dgvContactPerson.ReadOnly = true;
            // 
            // dgvContactNo
            // 
            this.dgvContactNo.DataPropertyName = "ContactNo";
            this.dgvContactNo.HeaderText = "ContactNo";
            this.dgvContactNo.Name = "dgvContactNo";
            this.dgvContactNo.ReadOnly = true;
            // 
            // dgvRemarks
            // 
            this.dgvRemarks.DataPropertyName = "RemarkNote";
            this.dgvRemarks.HeaderText = "Remarks";
            this.dgvRemarks.Name = "dgvRemarks";
            this.dgvRemarks.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Location = new System.Drawing.Point(13, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(956, 66);
            this.panel3.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 14);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 17);
            this.label14.TabIndex = 1;
            this.label14.Text = "SEARCH:";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(121, 11);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(451, 40);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // frmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 548);
            this.Controls.Add(this.tbSuppliers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QBranch - Supplier";
            this.Load += new System.EventHandler(this.frmSupplier_Load);
            this.tbSuppliers.ResumeLayout(false);
            this.tbSupplierReg.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tbSupplierDetail.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbSuppliers;
        private System.Windows.Forms.TabPage tbSupplierReg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtACnUMBER;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBillingAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmailID;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtPinCode;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TabPage tbSupplierDetail;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvSupplierList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvState;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPINcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBankAccountNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRemarks;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSearch;
    }
}