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

namespace School.Student
{
    public partial class FrmStudent : Form
    {
        private Guid StudentID = Guid.Empty;
        public bool SaveCompleted = false;
        private object exception;
        private object errorProvider1;

        public FrmStudent(Guid? id = null, bool canEdit = true)
        {
            InitializeComponent();
            btnSaveNew.Enabled = btnSaveClose.Enabled = canEdit;
            if (!id.Equals(null))
            {
                StudentID = (Guid)id;
                string query = string.Format("SELECT * FROM COMPANY WHERE ID='{0}'", id);
                SqlCommand cmd = new SqlCommand(query, Connect.ToDatabase());
                cmd.CommandTimeout = 10000;
                var reader = cmd.ExecuteReader();
                int i = reader.FieldCount;
                if (reader.HasRows)
                    while (reader.Read())
                    {


                        this.Text = this.Text + StudentID;
                        txtStudentID.Text = reader["StudentID"].ToString();
                        txtStudentName.Text = reader["FullName"].ToString();
                        if (rdWomen.Checked == true)
                        {
                            rdWomen.Text = reader["Gender"].ToString();
                        }
                        else
                        {
                            rdMan.Text = reader["Gender"].ToString();

                        }
                        dtpBirthDate.Text = reader["BirthDate"].ToString();
                        txtBirthPlace.Text = reader["BirthPlace"].ToString();
                        txtFatherName.Text = reader["FatherName"].ToString();
                        txtFatherName.Text = reader["FatherJob"].ToString();
                        txtMotherName.Text = reader["MotherName"].ToString();
                        txtMotherJob.Text = reader["MotherJob"].ToString();
                        txtCurrentPlace.Text = reader["CurrentPlace"].ToString();
                        txtContact.Text = reader["Contact"].ToString();
                        chkActive.Checked = bool.Parse(reader["Active"].ToString());
                        myPicture1.SetImage(Helpers.ByteArrayToImage(SelectPicture.GetPhoto("Photo", "tbStudent", StudentID)));

                    }
                reader.Close();
            }
        }
        public void Insert(string createBy)
        {
            try {
                var com = new SqlCommand("INSERT_STUDENT", Connect.ToDatabase());
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Guid.NewGuid());
                com.Parameters.AddWithValue("@StudentID", txtStudentID.Text);
                com.Parameters.AddWithValue("@FullName", txtStudentName.Text);
                if (rdWomen.Checked == true)
                {
                    com.Parameters.AddWithValue("@Gender", rdWomen.Text);
                }
                else if(rdMan.Checked==true)
                {
                    com.Parameters.AddWithValue("@Gender", rdMan.Text);
                }
                com.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value);
                com.Parameters.AddWithValue("@BirthPlace", txtBirthPlace.Text);
                com.Parameters.AddWithValue("@FatherName", txtFatherName.Text);
                com.Parameters.AddWithValue("@FatherJob", txtFatherJob.Text);
                com.Parameters.AddWithValue("@MotherName", txtMotherName.Text);
                com.Parameters.AddWithValue("@MotherJob", txtMotherJob.Text);
                com.Parameters.AddWithValue("@CurrentPlace", txtCurrentPlace.Text);
                com.Parameters.AddWithValue("@Photo", myPicture1.GetByteArrayFromBrowse());
                com.Parameters.AddWithValue("@CreatedBy", createBy);
                com.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                com.Parameters.AddWithValue("@Active", chkActive.Checked);
                com.ExecuteNonQuery();
            }
            catch {
                MessageBox.Show(exception.ToString(), @"Could not find Stored Procedure", MessageBoxButtons.RetryCancel);
                }
            finally
            {
                Connect.Close();
            }
        }

        public void Update(string UpdateBy)
        {
            try
            {
                var com = new SqlCommand("UPDATE_STUDENT", Connect.ToDatabase());
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Guid.NewGuid());
                com.Parameters.AddWithValue("@StudentID", txtStudentID.Text);
                com.Parameters.AddWithValue("@FullName", txtStudentName.Text);
                if (rdWomen.Checked == true)
                {
                    com.Parameters.AddWithValue("@Gender", rdWomen.Text);
                }
                else if (rdMan.Checked == true)
                {
                    com.Parameters.AddWithValue("@Gender", rdMan.Text);
                }
                com.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value);
                com.Parameters.AddWithValue("@BirthPlace", txtBirthPlace.Text);
                com.Parameters.AddWithValue("@FatherName", txtFatherName.Text);
                com.Parameters.AddWithValue("@FatherJob", txtFatherJob.Text);
                com.Parameters.AddWithValue("@MotherName", txtMotherName.Text);
                com.Parameters.AddWithValue("@MotherJob", txtMotherJob.Text);
                com.Parameters.AddWithValue("@CurrentPlace", txtCurrentPlace.Text);
                com.Parameters.AddWithValue("@Photo", myPicture1.GetByteArrayFromBrowse());
                com.Parameters.AddWithValue("@CreatedBy", UpdateBy);
                com.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                com.Parameters.AddWithValue("@Active", chkActive.Checked);
                com.ExecuteNonQuery();
            }
            catch
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
            if (Helpers.CheckEmpty(errorProvider2, txtStudentID, txtStudentName, txtFatherName, txtFatherJob, txtMotherName, txtMotherJob, txtCurrentPlace))
            {
                return false;
            }
            else
            {
                SaveCompleted = true;
                errorProvider2.Clear();

                if (StudentID != Guid.Empty)
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
            StudentID = Guid.Empty;

            txtStudentID.Text = txtStudentName.Text = txtBirthPlace.Text = txtFatherName.Text=txtFatherJob.Text=txtMotherName.Text=txtMotherJob.Text=txtContact.Text = txtCurrentPlace.Text=null;
            myPicture1.ClearImage();
        }

        private void FrmStudent_Load(object sender, EventArgs e)
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
