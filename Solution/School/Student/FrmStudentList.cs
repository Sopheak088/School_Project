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
            LoadData();
            .Opening += CtmsMenuBarOnOpening;
        }
        private void CtmsMenuBarOnOpening(object sender, CancelEventArgs cancelEventArgs)
        {
            btnView.Enabled = btnEdit.Enabled = false;
            if (getId != Guid.Empty)
            {
                btnView.Enabled = btnEdit.Enabled = true;
            }
        }

        private void RdoAllDay_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = false;
        }

        private void RdoByDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = true;
        }
        private void FrmStudentList_Load(object sender, EventArgs e)
        {
            dgvStudent.Columns["ថ្ងៃ ខែ ឆ្នាំកំណើត"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //define image size stretch
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img = (DataGridViewImageColumn)dgvStudent.Columns["រូប"];
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;
            foreach (DataGridViewColumn col in dgvStudent.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvStudent.ClearSelection(); //clear select item in datagridview
            
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
                .AppendFormat("[BirthDate] AS [ថ្ងៃ ខែ ឆ្នាំកំណើត],[BirthPlace] AS ទីកន្លៃងកំណើត,[FatherName] AS ឪពុកឈ្មោះ,")
                .AppendFormat("[FatherJob] AS មុនរបរ,[MotherName] AS ម្តាយឈ្មោះ,[MotherJob] AS មុខរបរ,[CurrentPlace] AS ទីលំនៅបច្ចុប្បន្ន,​​[Photo] AS រូប,[CreatedBy] AS បង្កើតដោយ,")
                .AppendFormat("[CreatedDate] AS ថ្ងៃបង្កើត,[UpdatedBy] AS កែប្រែដោយ,[UpdatedDate] AS ថ្ងៃកែប្រែ ")
                .AppendFormat("FROM [tbStudent] ")
                .AppendFormat("WHERE Active = '{0}'", filterEntity.Active);
            if (!string.IsNullOrWhiteSpace(filterEntity.Keyword))
            {
                query.AppendFormat(" AND (FullName LIKE N'%{0}%' ", filterEntity.Keyword)
                     .AppendFormat("OR StudentID LIKE '%{0}%') ", filterEntity.Keyword);

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
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmStudent frmStudent = new FrmStudent();
            frmStudent.ShowDialog();
            if (frmStudent.SaveCompleted)
            {
                LoadData();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (getId != Guid.Empty)
            {
                FrmStudent frmStudent = new FrmStudent(getId);
                frmStudent.ShowDialog();
                if (frmStudent.SaveCompleted)
                {
                    LoadData();
                }
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if (getId != Guid.Empty)
            {
                FrmStudent frmStudent = new FrmStudent(getId, false);
                frmStudent.ShowDialog();
                if (frmStudent.SaveCompleted)
                {
                    LoadData();
                }
            }
        }

        private void DgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
      
                int i;
                if (dgvStudent.RowCount > 0)
                {
                    i = e.RowIndex;
                    if (i < 0) return;
                    DataGridViewRow row = dgvStudent.Rows[i];
                    getId = Guid.Parse(row.Cells[0].Value.ToString());
                }
           
        }

        private void BtnSearch_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
