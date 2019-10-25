using School.Helper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace School.Subject
{
    public partial class FrmSubject : Form
    {
        private Guid subjectID = Guid.Empty;
        public bool SaveCompleted = false;

        public FrmSubject(Guid? id = null, bool canEdit = true)
        {
            InitializeComponent();
            btnSaveNew.Enabled = btnSaveClose.Enabled = canEdit;
            if (!id.Equals(null))
            {
                subjectID = (Guid)id;
                string query = string.Format("SELECT * FROM tbSubject WHERE ID='{0}'", id);
                SqlCommand cmd = new SqlCommand(query, Connect.ToDatabase());
                cmd.CommandTimeout = 10000;
                var reader = cmd.ExecuteReader();
                int i = reader.FieldCount;
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        txtName.Text = reader["Name"].ToString();
                    }
                reader.Close();
            }
        }

        private void Insert(string createBy)
        {
            try
            {
                var com = new SqlCommand("INSERT_SUBJECT", Connect.ToDatabase());
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@Id", Guid.NewGuid());
                com.Parameters.AddWithValue("@Name", txtName.Text);
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
                if (subjectID != Guid.Empty)
                {
                    var com = new SqlCommand("UPDATE_SUBJECT", Connect.ToDatabase());
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", subjectID);
                    com.Parameters.AddWithValue("@Name", txtName.Text);
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
            if (Helpers.CheckEmpty(errorProvider1, txtName))
            {
                return false;
            }
            else
            {
                SaveCompleted = true;
                errorProvider1.Clear();

                if (subjectID != Guid.Empty)
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
            subjectID = Guid.Empty;
            txtName.Text = null;
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