using School.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.Company
{
    public partial class FrmCompany : Form
    {
        private Guid companyID = Guid.Empty;
        public bool SaveCompleted = false;

        public FrmCompany(Guid? id = null, bool canEdit = true)
        {
            InitializeComponent();
            btnSaveNew.Enabled = btnSaveClose.Enabled = canEdit;
            if (!id.Equals(null))
            {
                companyID = (Guid)id;
                string query = string.Format("SELECT * FROM COMPANY WHERE ID='{0}'", id);
                SqlCommand cmd = new SqlCommand(query, Connect.ToDatabase());
                cmd.CommandTimeout = 10000;
                var reader = cmd.ExecuteReader();
                int i = reader.FieldCount;
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        this.Text = this.Text + companyID;
                        txtNameInKhmer.Text = reader["NameInKhmer"].ToString();
                        txtNameInEnglish.Text = reader["NameInEnglish"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtPhone.Text = reader["Phone"].ToString();
                        txtLocation.Text = reader["Location"].ToString();
                        chkActive.Checked = bool.Parse(reader["Active"].ToString());
                        myPicture1.SetImage(Helpers.ByteArrayToImage(SelectPicture.GetPhoto("Logo", "COMPANY", companyID)));
                    }
                reader.Close();
            }
        }

        public void Insert(string createBy)
        {
            try
            {
                var com = new SqlCommand("INSERT_COMPANY", Connect.ToDatabase());
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Guid.NewGuid());
                com.Parameters.AddWithValue("@NameInKhmer", txtNameInKhmer.Text);
                com.Parameters.AddWithValue("@NameInEnglish", txtNameInEnglish.Text);
                com.Parameters.AddWithValue("@Email", txtEmail.Text);
                com.Parameters.AddWithValue("@Phone", txtPhone.Text);
                com.Parameters.AddWithValue("@Location", txtLocation.Text);
                com.Parameters.AddWithValue("@Active", chkActive.Checked);
                com.Parameters.AddWithValue("@Logo", myPicture1.GetByteArrayFromBrowse());
                com.Parameters.AddWithValue("@CreatedBy", createBy);
                com.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                com.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), @"Could not find Stored Procedure", MessageBoxButtons.RetryCancel);
            }
            finally
            {
                Connect.Close();
            }
        }

        public void Update(string updatedBy)
        {
            try
            {
                if (companyID != Guid.Empty)
                {
                    var com = new SqlCommand("UPDATE_COMPANY", Connect.ToDatabase());
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", companyID);
                    com.Parameters.AddWithValue("@NameInKhmer", txtNameInKhmer.Text);
                    com.Parameters.AddWithValue("@NameInEnglish", txtNameInEnglish.Text);
                    com.Parameters.AddWithValue("@Email", txtEmail.Text);
                    com.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    com.Parameters.AddWithValue("@Location", txtLocation.Text);
                    com.Parameters.AddWithValue("@Active", chkActive.Checked);
                    com.Parameters.AddWithValue("@Logo", myPicture1.GetByteArrayFromBrowse());
                    com.Parameters.AddWithValue("@UpdatedBy", updatedBy);
                    com.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                    com.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), @"Could not find Stored Procedure", MessageBoxButtons.RetryCancel);
            }
            finally
            {
                Connect.Close();
            }
        }

        private bool Save()
        {
            if (Helpers.CheckEmpty(errorProvider1, txtNameInKhmer, txtNameInEnglish, txtEmail,
                txtPhone, txtLocation))
            {
                return false;
            }
            else
            {
                SaveCompleted = true;
                errorProvider1.Clear();

                if (companyID != Guid.Empty)
                {
                    Update("Admin");
                }
                else
                {
                    Insert("Admin");
                }
                return true;
            }
        }

        private void ClearData()
        {
            companyID = Guid.Empty;
            txtPhone.Text = txtNameInEnglish.Text = txtNameInKhmer.Text = txtEmail.Text = txtLocation.Text = null;
            myPicture1.ClearImage();
        }

        private void BtnSaveNew_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                ClearData();
            }
        }

        private void BtnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
            { this.Close(); }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}