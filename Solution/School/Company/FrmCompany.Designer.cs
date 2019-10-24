namespace School.Company
{
    partial class FrmCompany
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
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNameInEnglish = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameInKhmer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnSaveNew = new System.Windows.Forms.Button();
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
            this.chkActive.Location = new System.Drawing.Point(130, 227);
            this.chkActive.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(97, 26);
            this.chkActive.TabIndex = 18;
            this.chkActive.Text = "មានសកម្មភាព";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(130, 145);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(449, 77);
            this.txtLocation.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 22);
            this.label5.TabIndex = 25;
            this.label5.Text = "ទីតាំង";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(130, 112);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(336, 30);
            this.txtPhone.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 22);
            this.label4.TabIndex = 24;
            this.label4.Text = "ទូរស័ព្ទ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(130, 80);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(336, 30);
            this.txtEmail.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 22);
            this.label3.TabIndex = 21;
            this.label3.Text = "អ៊ីម៉ែល";
            // 
            // txtNameInEnglish
            // 
            this.txtNameInEnglish.Location = new System.Drawing.Point(130, 47);
            this.txtNameInEnglish.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNameInEnglish.Name = "txtNameInEnglish";
            this.txtNameInEnglish.Size = new System.Drawing.Size(336, 30);
            this.txtNameInEnglish.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 22);
            this.label2.TabIndex = 19;
            this.label2.Text = "ឈ្មោះជាអង់គ្លេស";
            // 
            // txtNameInKhmer
            // 
            this.txtNameInKhmer.Location = new System.Drawing.Point(130, 14);
            this.txtNameInKhmer.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNameInKhmer.Name = "txtNameInKhmer";
            this.txtNameInKhmer.Size = new System.Drawing.Size(336, 30);
            this.txtNameInKhmer.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "ឈ្មោះជាភាសាខ្មែរ ";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::School.Properties.Resources.DeleteRed;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(513, 243);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 27);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Image = global::School.Properties.Resources.cancelled_reservation_24x24;
            this.btnSaveClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveClose.Location = new System.Drawing.Point(410, 243);
            this.btnSaveClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(106, 27);
            this.btnSaveClose.TabIndex = 22;
            this.btnSaveClose.Text = "Save Close";
            this.btnSaveClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Click += new System.EventHandler(this.BtnSaveClose_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Image = global::School.Properties.Resources.accounting_interface_24x24;
            this.btnSaveNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveNew.Location = new System.Drawing.Point(307, 243);
            this.btnSaveNew.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(97, 27);
            this.btnSaveNew.TabIndex = 20;
            this.btnSaveNew.Text = "Save New";
            this.btnSaveNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Click += new System.EventHandler(this.BtnSaveNew_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // myPicture1
            // 
            this.myPicture1.BackColor = System.Drawing.Color.Transparent;
            this.myPicture1.Location = new System.Drawing.Point(470, 16);
            this.myPicture1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.myPicture1.Name = "myPicture1";
            this.myPicture1.Size = new System.Drawing.Size(108, 126);
            this.myPicture1.TabIndex = 26;
            // 
            // FrmCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 274);
            this.Controls.Add(this.myPicture1);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNameInEnglish);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.btnSaveNew);
            this.Controls.Add(this.txtNameInKhmer);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCompany_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNameInEnglish;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.TextBox txtNameInKhmer;
        private System.Windows.Forms.Label label1;
        private MyPicture myPicture1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}