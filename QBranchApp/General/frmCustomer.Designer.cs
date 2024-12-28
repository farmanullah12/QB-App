namespace QBranchApp.General
{
    partial class frmCustomer
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
            this.tbClientReg = new System.Windows.Forms.TabControl();
            this.clientRegistration = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.dtRegistry = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSourceContact = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLeadSourceName = new System.Windows.Forms.TextBox();
            this.cmbLeadSource = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBusinessName = new System.Windows.Forms.TextBox();
            this.txtStreetNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmailID = new System.Windows.Forms.TextBox();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.tbClientDetail = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvClientDetailsList = new System.Windows.Forms.DataGridView();
            this.dgvtxtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBusinessNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStreetNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvZipCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhoneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDateOfRegistry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLeadSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLeadContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tbClientReg.SuspendLayout();
            this.clientRegistration.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tbClientDetail.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientDetailsList)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbClientReg
            // 
            this.tbClientReg.Controls.Add(this.clientRegistration);
            this.tbClientReg.Controls.Add(this.tbClientDetail);
            this.tbClientReg.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbClientReg.Location = new System.Drawing.Point(0, 0);
            this.tbClientReg.Margin = new System.Windows.Forms.Padding(4);
            this.tbClientReg.Name = "tbClientReg";
            this.tbClientReg.SelectedIndex = 0;
            this.tbClientReg.Size = new System.Drawing.Size(1328, 626);
            this.tbClientReg.TabIndex = 1;
            // 
            // clientRegistration
            // 
            this.clientRegistration.Controls.Add(this.groupBox2);
            this.clientRegistration.Location = new System.Drawing.Point(4, 25);
            this.clientRegistration.Margin = new System.Windows.Forms.Padding(4);
            this.clientRegistration.Name = "clientRegistration";
            this.clientRegistration.Padding = new System.Windows.Forms.Padding(4);
            this.clientRegistration.Size = new System.Drawing.Size(1320, 597);
            this.clientRegistration.TabIndex = 0;
            this.clientRegistration.Text = "Client Registration";
            this.clientRegistration.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(957, 519);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Profile";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDelete.Location = new System.Drawing.Point(729, 405);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(203, 48);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(517, 405);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(207, 48);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.txtRemarks);
            this.groupBox6.Controls.Add(this.dtRegistry);
            this.groupBox6.Location = new System.Drawing.Point(517, 225);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(415, 162);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Other Details";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 80);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 17);
            this.label13.TabIndex = 12;
            this.label13.Text = "Remarks:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 36);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "Date of Registry:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(160, 80);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(235, 64);
            this.txtRemarks.TabIndex = 1;
            // 
            // dtRegistry
            // 
            this.dtRegistry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRegistry.Location = new System.Drawing.Point(160, 36);
            this.dtRegistry.Margin = new System.Windows.Forms.Padding(4);
            this.dtRegistry.Name = "dtRegistry";
            this.dtRegistry.Size = new System.Drawing.Size(235, 22);
            this.dtRegistry.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtSourceContact);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.txtLeadSourceName);
            this.groupBox5.Controls.Add(this.cmbLeadSource);
            this.groupBox5.Location = new System.Drawing.Point(517, 32);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(415, 187);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Lead Source:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 132);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Contact Number:";
            // 
            // txtSourceContact
            // 
            this.txtSourceContact.Location = new System.Drawing.Point(160, 132);
            this.txtSourceContact.Margin = new System.Windows.Forms.Padding(4);
            this.txtSourceContact.Name = "txtSourceContact";
            this.txtSourceContact.Size = new System.Drawing.Size(235, 22);
            this.txtSourceContact.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 85);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "Lead Source:";
            // 
            // txtLeadSourceName
            // 
            this.txtLeadSourceName.Location = new System.Drawing.Point(160, 85);
            this.txtLeadSourceName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLeadSourceName.Name = "txtLeadSourceName";
            this.txtLeadSourceName.Size = new System.Drawing.Size(235, 22);
            this.txtLeadSourceName.TabIndex = 1;
            // 
            // cmbLeadSource
            // 
            this.cmbLeadSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeadSource.FormattingEnabled = true;
            this.cmbLeadSource.Location = new System.Drawing.Point(160, 39);
            this.cmbLeadSource.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLeadSource.Name = "cmbLeadSource";
            this.cmbLeadSource.Size = new System.Drawing.Size(235, 24);
            this.cmbLeadSource.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txtContactPerson);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtBusinessName);
            this.groupBox3.Controls.Add(this.txtStreetNumber);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtContact);
            this.groupBox3.Controls.Add(this.txtPhone);
            this.groupBox3.Controls.Add(this.txtEmailID);
            this.groupBox3.Controls.Add(this.txtZipCode);
            this.groupBox3.Controls.Add(this.txtState);
            this.groupBox3.Controls.Add(this.txtCity);
            this.groupBox3.Controls.Add(this.txtFullName);
            this.groupBox3.Location = new System.Drawing.Point(19, 32);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(483, 465);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Customer Details";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(49, 124);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 17);
            this.label16.TabIndex = 21;
            this.label16.Text = "Contact Person:";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactPerson.Location = new System.Drawing.Point(173, 122);
            this.txtContactPerson.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(267, 22);
            this.txtContactPerson.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(49, 87);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 17);
            this.label15.TabIndex = 19;
            this.label15.Text = "Business Name:";
            // 
            // txtBusinessName
            // 
            this.txtBusinessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusinessName.Location = new System.Drawing.Point(173, 85);
            this.txtBusinessName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBusinessName.Name = "txtBusinessName";
            this.txtBusinessName.Size = new System.Drawing.Size(267, 22);
            this.txtBusinessName.TabIndex = 18;
            // 
            // txtStreetNumber
            // 
            this.txtStreetNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStreetNumber.Location = new System.Drawing.Point(173, 172);
            this.txtStreetNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtStreetNumber.Name = "txtStreetNumber";
            this.txtStreetNumber.Size = new System.Drawing.Size(267, 22);
            this.txtStreetNumber.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 421);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Contact Number:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 379);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Phone Number:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 338);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "E-mail ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 300);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Zip Code:";
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
            this.label2.Location = new System.Drawing.Point(49, 172);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Street #:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Full Name:";
            // 
            // txtContact
            // 
            this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContact.Location = new System.Drawing.Point(173, 414);
            this.txtContact.Margin = new System.Windows.Forms.Padding(4);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(267, 22);
            this.txtContact.TabIndex = 8;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(173, 372);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(267, 22);
            this.txtPhone.TabIndex = 7;
            // 
            // txtEmailID
            // 
            this.txtEmailID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailID.Location = new System.Drawing.Point(173, 331);
            this.txtEmailID.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.Size = new System.Drawing.Size(267, 22);
            this.txtEmailID.TabIndex = 6;
            // 
            // txtZipCode
            // 
            this.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtZipCode.Location = new System.Drawing.Point(173, 292);
            this.txtZipCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(267, 22);
            this.txtZipCode.TabIndex = 4;
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
            // txtFullName
            // 
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullName.Location = new System.Drawing.Point(173, 41);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(267, 22);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFullName_KeyPress);
            // 
            // tbClientDetail
            // 
            this.tbClientDetail.Controls.Add(this.panel4);
            this.tbClientDetail.Controls.Add(this.panel3);
            this.tbClientDetail.Location = new System.Drawing.Point(4, 25);
            this.tbClientDetail.Margin = new System.Windows.Forms.Padding(4);
            this.tbClientDetail.Name = "tbClientDetail";
            this.tbClientDetail.Padding = new System.Windows.Forms.Padding(4);
            this.tbClientDetail.Size = new System.Drawing.Size(1320, 597);
            this.tbClientDetail.TabIndex = 1;
            this.tbClientDetail.Text = "Clients Detail";
            this.tbClientDetail.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvClientDetailsList);
            this.panel4.Location = new System.Drawing.Point(9, 66);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1299, 519);
            this.panel4.TabIndex = 3;
            // 
            // dgvClientDetailsList
            // 
            this.dgvClientDetailsList.AllowUserToAddRows = false;
            this.dgvClientDetailsList.AllowUserToDeleteRows = false;
            this.dgvClientDetailsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientDetailsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientDetailsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtxtID,
            this.dgvFullName,
            this.dgvBusinessNAME,
            this.dgvContactPerson,
            this.dgvStreetNo,
            this.dgvCity,
            this.dgvState,
            this.dgvZipCode,
            this.dgvEmail,
            this.dgvPhoneNo,
            this.dgvContactNo,
            this.dgvDateOfRegistry,
            this.dgvRemarks,
            this.dgvLeadSource,
            this.dgvName,
            this.dgvLeadContact});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientDetailsList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientDetailsList.EnableHeadersVisualStyles = false;
            this.dgvClientDetailsList.Location = new System.Drawing.Point(16, 15);
            this.dgvClientDetailsList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvClientDetailsList.Name = "dgvClientDetailsList";
            this.dgvClientDetailsList.ReadOnly = true;
            this.dgvClientDetailsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientDetailsList.Size = new System.Drawing.Size(1264, 484);
            this.dgvClientDetailsList.TabIndex = 0;
            this.dgvClientDetailsList.DoubleClick += new System.EventHandler(this.dgvClientDetailsList_DoubleClick);
            // 
            // dgvtxtID
            // 
            this.dgvtxtID.DataPropertyName = "ID";
            this.dgvtxtID.HeaderText = "ID";
            this.dgvtxtID.Name = "dgvtxtID";
            this.dgvtxtID.ReadOnly = true;
            this.dgvtxtID.Visible = false;
            // 
            // dgvFullName
            // 
            this.dgvFullName.DataPropertyName = "FullName";
            this.dgvFullName.HeaderText = "Full Name";
            this.dgvFullName.Name = "dgvFullName";
            this.dgvFullName.ReadOnly = true;
            // 
            // dgvBusinessNAME
            // 
            this.dgvBusinessNAME.DataPropertyName = "BusinessName";
            this.dgvBusinessNAME.HeaderText = "Business Name";
            this.dgvBusinessNAME.Name = "dgvBusinessNAME";
            this.dgvBusinessNAME.ReadOnly = true;
            // 
            // dgvContactPerson
            // 
            this.dgvContactPerson.DataPropertyName = "ContactPerson";
            this.dgvContactPerson.HeaderText = "Contact Person";
            this.dgvContactPerson.Name = "dgvContactPerson";
            this.dgvContactPerson.ReadOnly = true;
            // 
            // dgvStreetNo
            // 
            this.dgvStreetNo.DataPropertyName = "StreetNo";
            this.dgvStreetNo.HeaderText = "Street #";
            this.dgvStreetNo.Name = "dgvStreetNo";
            this.dgvStreetNo.ReadOnly = true;
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
            // dgvZipCode
            // 
            this.dgvZipCode.DataPropertyName = "ZipCode";
            this.dgvZipCode.HeaderText = "Zip Code";
            this.dgvZipCode.Name = "dgvZipCode";
            this.dgvZipCode.ReadOnly = true;
            // 
            // dgvEmail
            // 
            this.dgvEmail.DataPropertyName = "EmailID";
            this.dgvEmail.HeaderText = "Email";
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.ReadOnly = true;
            // 
            // dgvPhoneNo
            // 
            this.dgvPhoneNo.DataPropertyName = "PhoneNo";
            this.dgvPhoneNo.HeaderText = "Phone No";
            this.dgvPhoneNo.Name = "dgvPhoneNo";
            this.dgvPhoneNo.ReadOnly = true;
            // 
            // dgvContactNo
            // 
            this.dgvContactNo.DataPropertyName = "ContactNo";
            this.dgvContactNo.HeaderText = "Contact No";
            this.dgvContactNo.Name = "dgvContactNo";
            this.dgvContactNo.ReadOnly = true;
            // 
            // dgvDateOfRegistry
            // 
            this.dgvDateOfRegistry.DataPropertyName = "DateOfRegistry";
            this.dgvDateOfRegistry.HeaderText = "Date of Registry";
            this.dgvDateOfRegistry.Name = "dgvDateOfRegistry";
            this.dgvDateOfRegistry.ReadOnly = true;
            // 
            // dgvRemarks
            // 
            this.dgvRemarks.DataPropertyName = "Remarks";
            this.dgvRemarks.HeaderText = "Remarks";
            this.dgvRemarks.Name = "dgvRemarks";
            this.dgvRemarks.ReadOnly = true;
            // 
            // dgvLeadSource
            // 
            this.dgvLeadSource.DataPropertyName = "LeadSourceTitle";
            this.dgvLeadSource.HeaderText = "Lead Source";
            this.dgvLeadSource.Name = "dgvLeadSource";
            this.dgvLeadSource.ReadOnly = true;
            this.dgvLeadSource.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLeadSource.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvName
            // 
            this.dgvName.DataPropertyName = "LeadSourceName";
            this.dgvName.HeaderText = "Name";
            this.dgvName.Name = "dgvName";
            this.dgvName.ReadOnly = true;
            this.dgvName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvLeadContact
            // 
            this.dgvLeadContact.DataPropertyName = "LeadSourceContact";
            this.dgvLeadContact.HeaderText = "Lead source Contact";
            this.dgvLeadContact.Name = "dgvLeadContact";
            this.dgvLeadContact.ReadOnly = true;
            this.dgvLeadContact.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLeadContact.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Location = new System.Drawing.Point(9, 7);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1299, 66);
            this.panel3.TabIndex = 2;
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
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 625);
            this.Controls.Add(this.tbClientReg);
            this.Name = "frmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCustomer";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.tbClientReg.ResumeLayout(false);
            this.clientRegistration.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tbClientDetail.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientDetailsList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbClientReg;
        private System.Windows.Forms.TabPage clientRegistration;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.DateTimePicker dtRegistry;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSourceContact;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLeadSourceName;
        private System.Windows.Forms.ComboBox cmbLeadSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtBusinessName;
        private System.Windows.Forms.TextBox txtStreetNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmailID;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TabPage tbClientDetail;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvClientDetailsList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBusinessNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStreetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvState;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvZipCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhoneNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDateOfRegistry;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLeadSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLeadContact;
    }
}