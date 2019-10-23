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

namespace School.Company
{
    public partial class FrmCompanyList : Form
    {
        private Guid getId = Guid.Empty;

        public FrmCompanyList()
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

        private void FrmCompanyList_Load(object sender, EventArgs e)
        {
            dtpFrom.Enabled = dtpTo.Enabled = false;
            dgvCompany.Columns["ID"].Visible = false;
            //define image size stretch
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img = (DataGridViewImageColumn)dgvCompany.Columns["រូប"];
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;
            foreach (DataGridViewColumn col in dgvCompany.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvCompany.ClearSelection(); //clear select item in datagridview
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
            dgvCompany.DataSource = FilterListCompany(filterEntity);
        }

        public DataTable FilterListCompany(FilterEntity filterEntity)
        {
            DataTable dataTable = new DataTable();
            StringBuilder query = new StringBuilder();
            query.Append("SELECT [ID],[NameInKhmer] AS ឈ្មោះជាភាសាខ្មែរ,[NameInEnglish]​ AS ឈ្មោះជាអង់គ្លេស,")
                .AppendFormat("[Email] AS អ៊ីម៉ែល,[Phone] AS ទូរស័ព្ទ,[Location] AS ទីតាំង,")
                .AppendFormat("[Active] AS មានសកម្មភាព,[Logo] AS រូប,[CreatedBy] AS បង្កើតដោយ,")
                .AppendFormat("[CreatedDate] AS ថ្ងៃបង្កើត,[UpdatedBy] AS កែប្រែដោយ,[UpdatedDate] AS ថ្ងៃកែប្រែ ")
                .AppendFormat("FROM [COMPANY] ")
                .AppendFormat("WHERE Active = '{0}'", filterEntity.Active);
            if (!string.IsNullOrWhiteSpace(filterEntity.Keyword))
            {
                query.AppendFormat(" AND (NameInKhmer LIKE N'%{0}%' ", filterEntity.Keyword)
                .AppendFormat("OR NameInEnglish LIKE '%{0}%') ", filterEntity.Keyword);
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
            FrmCompany frmCompany = new FrmCompany();
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
            if (dgvCompany.RowCount > 0)
            {
                i = e.RowIndex;
                if (i < 0) return;
                DataGridViewRow row = dgvCompany.Rows[i];
                getId = Guid.Parse(row.Cells[0].Value.ToString());
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (getId != Guid.Empty)
            {
                FrmCompany frmCompany = new FrmCompany(getId);
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
                FrmCompany frmCompany = new FrmCompany(getId, false);
                frmCompany.ShowDialog();
                if (frmCompany.SaveCompleted)
                {
                    LoadData();
                }
            }
        }
    }
}