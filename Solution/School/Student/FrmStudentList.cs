using School.BaseObject;
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
    public partial class FrmStudentList : Form
    {
        private Guid getId = Guid.Empty;
        public FrmStudentList()
        {
            InitializeComponent();
        }

        private void FrmStudentList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            FilterEntity filterEntity = new FilterEntity();
            if (rdoAllDay.Checked)
            {
                filterEntity.FromDate = null;
                filterEntity.ToDate = null;
            }
            else if (rdoByDate.Checked)
            {
                filterEntity.FromDate = dtpFrom.Value;
                filterEntity.ToDate = dtpTo.Value;
            }
            if (rdoActive.Checked)
            {
                filterEntity.Active = true;
            }
            else if (rdoInactive.Checked)
            {
                filterEntity.Active = false;
            }
            filterEntity.Keyword = txtKeyword.Text;
            dgvStudent.DataSource = FilterListCompany(filterEntity);
        }
        public DataTable FilterListCompany(FilterEntity filterEntity)
        {
            DataTable dataTable = new DataTable();
            StringBuilder query = new StringBuilder();
            query.Append("SELECT [StudentID] AS អត្តលេខ,[FullName] AS ឈ្មោះពេញ,[Gender]​ AS ភេទ,")
                .AppendFormat("[BirthDate] AS ថ្ងៃខែឆ្នាំកំណើត,[BirthPlace] AS ទីកន្លៃងកំណើត,[FatherName] AS ឪពុកឈ្មោះ,")
                .AppendFormat("[FatherJob] AS មុនរបរ,[MotherName] AS ម្តាយឈ្មោះ,[MotherJob] AS មុខរបរ,[CurrentPlace] AS ទីលំនៅបច្ចុប្បន្ន​​,[CreatedBy] AS បង្កើតដោយ,")
                .AppendFormat("[CreatedDate] AS ថ្ងៃបង្កើត,[UpdatedBy] AS កែប្រែដោយ,[UpdatedDate] AS ថ្ងៃកែប្រែ ")
                .AppendFormat("FROM [tbStudent] ")
                .AppendFormat("WHERE Active = '{0}'", filterEntity.Active);
            if (!string.IsNullOrWhiteSpace(filterEntity.Keyword))
            {
                query.AppendFormat(" AND (FullName LIKE N'%{0}%' ", filterEntity.Keyword);
 
            }
            if (filterEntity.FromDate != null && filterEntity.ToDate != null)
            {
                query.AppendFormat("AND (CONVERT(DATE, CreatedDate) >= CONVERT(DATE, '{0}') ", filterEntity.FromDate)
                    .AppendFormat(" AND CONVERT(DATE, CreatedDate) <= CONVERT(DATE, '{0}')) ", filterEntity.ToDate);
            }
            try
            {
                SqlCommand cmd = new SqlCommand(query.ToString(), Connect.ToDatabase());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
                da.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), @"Check you SQL",
                    MessageBoxButtons.RetryCancel);
            }
            finally
            {
                Connect.Close();
            }
            return dataTable;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmStudent frmstudent = new FrmStudent();
            frmstudent.ShowDialog();
            if (frmstudent.SaveCompleted)
            {
                LoadData();
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
