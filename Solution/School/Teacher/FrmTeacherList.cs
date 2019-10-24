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

namespace School.Teacher
{
    public partial class FrmTeacherList : Form
    {
        private Guid getId = Guid.Empty;

        public FrmTeacherList()
        {
            InitializeComponent();
            LoadData();
            ctmMenu.Opening += CtmsMenuBarOnOpening;
        }

        private void CtmsMenuBarOnOpening(object sender, CancelEventArgs cancelEventArgs)
        {
            btnView.Enabled = btnEdit.Enabled = false;
            if (getId != Guid.Empty)
            {
                btnView.Enabled = btnEdit.Enabled = true;
            }
        }

        private void FrmTeacherList_Load(object sender, EventArgs e)
        {
            btnView.Enabled = btnEdit.Enabled = false;
            dgvList.Columns["ID"].Visible = false;
        }

        private void RdoAllDay_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = false;
        }

        private void RdoByDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = true;
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
            dgvList.DataSource = FilterListCompany(filterEntity);
        }

        public DataTable FilterListCompany(FilterEntity filterEntity)
        {
            DataTable dataTable = new DataTable();
            StringBuilder query = new StringBuilder();
            query.Append("SELECT t.ID, t.Name AS ឈ្មោះ​, t.Gender AS  ភេទ, s.Name AS ឯកទេស, t.Phone AS ទូរស័ព្ទ, t.Active AS មានសកម្មភាព,")
                .AppendFormat("t.[CreatedBy] AS បង្កើតដោយ,t.[CreatedDate] AS ថ្ងៃបង្កើត, t.[UpdatedBy] AS កែប្រែដោយ,t.[UpdatedDate] AS ថ្ងៃកែប្រែ ")
                .AppendFormat("FROM tbTeacher t INNER JOIN tbSubject s ON t.SubjectID=s.ID ")
                .AppendFormat("WHERE t.Active = '{0}'", filterEntity.Active);
            if (!string.IsNullOrWhiteSpace(filterEntity.Keyword))
            {
                query.AppendFormat(" AND (t.Name LIKE N'%{0}%' ", filterEntity.Keyword)
                .AppendFormat("OR s.Name LIKE '%{0}%') ", filterEntity.Keyword);
            }
            if (filterEntity.FromDate != null && filterEntity.ToDate != null)
            {
                query.AppendFormat("AND (CONVERT(DATE, t.CreatedDate) >= CONVERT(DATE, '{0}') ", filterEntity.FromDate)
                    .AppendFormat(" AND CONVERT(DATE, t.CreatedDate) <= CONVERT(DATE, '{0}')) ", filterEntity.ToDate);
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
            FrmTeacher frmCompany = new FrmTeacher();
            frmCompany.ShowDialog();
            if (frmCompany.SaveCompleted)
            {
                LoadData();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DgvCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            if (dgvList.RowCount > 0)
            {
                i = e.RowIndex;
                if (i < 0) return;
                DataGridViewRow row = dgvList.Rows[i];
                getId = Guid.Parse(row.Cells[0].Value.ToString());
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (getId != Guid.Empty)
            {
                FrmTeacher frmCompany = new FrmTeacher(getId);
                frmCompany.ShowDialog();
                if (frmCompany.SaveCompleted)
                {
                    LoadData();
                }
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if (getId != Guid.Empty)
            {
                FrmTeacher frmCompany = new FrmTeacher(getId, false);
                frmCompany.ShowDialog();
                if (frmCompany.SaveCompleted)
                {
                    LoadData();
                }
            }
        }
    }
}