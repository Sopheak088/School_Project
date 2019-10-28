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

namespace School.Class
{
    public partial class FrmClass : Form
    {
        private Guid ClassID = Guid.Empty;
        public bool SaveCompleted = false;
        public FrmClass(Guid? id = null, bool canEdit = true)
        {
            InitializeComponent();
            btnSaveNew.Enabled = btnSaveClose.Enabled = canEdit;
            if (!id.Equals(null))
            {
                ClassID = (Guid)id;
                string query = string.Format("SELECT * FROM tbClass WHERE ID='{0}'", id);
                SqlCommand cmd = new SqlCommand(query, Connect.ToDatabase());
                cmd.CommandTimeout = 10000;
                var reader = cmd.ExecuteReader();
                int i = reader.FieldCount;
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        txtClassName.Text = reader["Name"].ToString();
                    }
                reader.Close();
            }
        }
        private void Insert(string createBy)
        {
            try
            {
                var com = new SqlCommand("INSERT_CLASS", Connect.ToDatabase());
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@Id", Guid.NewGuid());
                com.Parameters.AddWithValue("@Name", txtClassName.Text);
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
                if (ClassID != Guid.Empty)
                {
                    var com = new SqlCommand("UPDATE_CLASS", Connect.ToDatabase());
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", ClassID);
                    com.Parameters.AddWithValue("@Name", txtClassName.Text);
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
            if (Helpers.CheckEmpty(errorProvider1, txtClassName))
            {
                return false;
            }
            else
            {
                SaveCompleted = true;
                errorProvider1.Clear();

                if (ClassID != Guid.Empty)
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
            ClassID = Guid.Empty;
            txtClassName.Text = null;
        }

        private void FrmClass_Load(object sender, EventArgs e)
        {

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
