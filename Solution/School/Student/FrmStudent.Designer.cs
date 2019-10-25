namespace School.Student
{
    partial class FrmStudent
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
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBirthPlace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdMan = new System.Windows.Forms.RadioButton();
            this.rdWomen = new System.Windows.Forms.RadioButton();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMotherName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFatherJob = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMotherJob = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCurrentPlace = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.myPicture1 = new School.MyPicture();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(116, 466);
            this.chkActive.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(104, 28);
            this.chkActive.TabIndex = 32;
            this.chkActive.Text = "មានសកម្មភាព";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(116, 384);
            this.txtContact.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtContact.Multiline = true;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(480, 77);
            this.txtContact.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 24);
            this.label5.TabIndex = 39;
            this.label5.Text = "ទីកន្លៃងកំណើត";
            // 
            // txtBirthPlace
            // 
            this.txtBirthPlace.Location = new System.Drawing.Point(116, 161);
            this.txtBirthPlace.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtBirthPlace.Name = "txtBirthPlace";
            this.txtBirthPlace.Size = new System.Drawing.Size(336, 32);
            this.txtBirthPlace.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 24);
            this.label4.TabIndex = 38;
            this.label4.Text = "ថ្ងៃខែឆ្នាំកំណើត";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 24);
            this.label3.TabIndex = 35;
            this.label3.Text = "ភេទ";
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(116, 51);
            this.txtStudentName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(336, 32);
            this.txtStudentName.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 24);
            this.label2.TabIndex = 33;
            this.label2.Text = "ឈ្មោះសិស្ស";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::School.Properties.Resources.DeleteRed;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(484, 467);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 27);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Image = global::School.Properties.Resources.cancelled_reservation_24x24;
            this.btnSaveClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveClose.Location = new System.Drawing.Point(372, 467);
            this.btnSaveClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(106, 27);
            this.btnSaveClose.TabIndex = 36;
            this.btnSaveClose.Text = "Save Close";
            this.btnSaveClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.BtnSaveClose_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Image = global::School.Properties.Resources.accounting_interface_24x24;
            this.btnSaveNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveNew.Location = new System.Drawing.Point(260, 467);
            this.btnSaveNew.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(106, 27);
            this.btnSaveNew.TabIndex = 34;
            this.btnSaveNew.Text = "Save New";
            this.btnSaveNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Click += new System.EventHandler(this.BtnSaveNew_Click);
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(116, 14);
            this.txtStudentID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(336, 32);
            this.txtStudentID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "អត្តលេខ";
            // 
            // rdMan
            // 
            this.rdMan.AutoSize = true;
            this.rdMan.Checked = true;
            this.rdMan.Location = new System.Drawing.Point(116, 89);
            this.rdMan.Name = "rdMan";
            this.rdMan.Size = new System.Drawing.Size(54, 28);
            this.rdMan.TabIndex = 40;
            this.rdMan.TabStop = true;
            this.rdMan.Text = "ប្រុស";
            this.rdMan.UseVisualStyleBackColor = true;
            // 
            // rdWomen
            // 
            this.rdWomen.AutoSize = true;
            this.rdWomen.Location = new System.Drawing.Point(238, 89);
            this.rdWomen.Name = "rdWomen";
            this.rdWomen.Size = new System.Drawing.Size(49, 28);
            this.rdWomen.TabIndex = 41;
            this.rdWomen.TabStop = true;
            this.rdWomen.Text = " ស្រី";
            this.rdWomen.UseVisualStyleBackColor = true;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.Location = new System.Drawing.Point(116, 123);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(336, 32);
            this.dtpBirthDate.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 24);
            this.label6.TabIndex = 44;
            this.label6.Text = "ឪពុកឈ្មោះ";
            // 
            // txtFatherName
            // 
            this.txtFatherName.Location = new System.Drawing.Point(116, 199);
            this.txtFatherName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(480, 32);
            this.txtFatherName.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 24);
            this.label7.TabIndex = 48;
            this.label7.Text = "ម្តាយឈ្មោះ";
            // 
            // txtMotherName
            // 
            this.txtMotherName.Location = new System.Drawing.Point(116, 273);
            this.txtMotherName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtMotherName.Name = "txtMotherName";
            this.txtMotherName.Size = new System.Drawing.Size(480, 32);
            this.txtMotherName.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 24);
            this.label8.TabIndex = 46;
            this.label8.Text = "មុខរបរ";
            // 
            // txtFatherJob
            // 
            this.txtFatherJob.Location = new System.Drawing.Point(116, 236);
            this.txtFatherJob.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtFatherJob.Name = "txtFatherJob";
            this.txtFatherJob.Size = new System.Drawing.Size(480, 32);
            this.txtFatherJob.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 315);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 24);
            this.label9.TabIndex = 50;
            this.label9.Text = "មុខរបរ";
            // 
            // txtMotherJob
            // 
            this.txtMotherJob.Location = new System.Drawing.Point(116, 310);
            this.txtMotherJob.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtMotherJob.Name = "txtMotherJob";
            this.txtMotherJob.Size = new System.Drawing.Size(480, 32);
            this.txtMotherJob.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 24);
            this.label10.TabIndex = 52;
            this.label10.Text = "ទីលំនៅបច្ចុប្បន្ន";
            // 
            // txtCurrentPlace
            // 
            this.txtCurrentPlace.Location = new System.Drawing.Point(116, 347);
            this.txtCurrentPlace.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCurrentPlace.Name = "txtCurrentPlace";
            this.txtCurrentPlace.Size = new System.Drawing.Size(480, 32);
            this.txtCurrentPlace.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 412);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 24);
            this.label11.TabIndex = 53;
            this.label11.Text = "ទាក់ទងបន្ទាន់";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // myPicture1
            // 
            this.myPicture1.BackColor = System.Drawing.Color.Transparent;
            this.myPicture1.Location = new System.Drawing.Point(468, 14);
            this.myPicture1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.myPicture1.Name = "myPicture1";
            this.myPicture1.Size = new System.Drawing.Size(122, 156);
            this.myPicture1.TabIndex = 54;
            // 
            // FrmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 504);
            this.Controls.Add(this.myPicture1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCurrentPlace);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMotherJob);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMotherName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFatherJob);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFatherName);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.rdWomen);
            this.Controls.Add(this.rdMan);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBirthPlace);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.btnSaveNew);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ព័ត៌មានសិស្ស";
            this.Load += new System.EventHandler(this.FrmStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBirthPlace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdMan;
        private System.Windows.Forms.RadioButton rdWomen;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMotherName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFatherJob;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMotherJob;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCurrentPlace;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private MyPicture myPicture1;
    }
}