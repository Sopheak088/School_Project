using School.Helper;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace School.Subject
{
    public partial class FrmSubjectList : Form
    {
        private Guid getId = Guid.Empty;

        public FrmSubjectList()
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

        private void FrmSubjectList_Load(object sender, EventArgs e)
        {
            btnView.Enabled = btnEdit.Enabled = false;
            dgvList.Columns["ID"].Visible = false;
        }

        public void LoadData()
        {
            dgvList.DataSource = FilterList();
        }

        public DataTable FilterList()
        {
            DataTable dataTable = new DataTable();
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ID, Name AS ឈ្មោះថ្នាក់,")
                .AppendFormat("[CreatedBy] AS បង្កើតដោយ,[CreatedDate] AS ថ្ងៃបង្កើត, [UpdatedBy] AS កែប្រែដោយ,[UpdatedDate] AS ថ្ងៃកែប្រែ ")
                .AppendFormat("FROM tbSubject ORDER BY Name");
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
            FrmSubject frm = new FrmSubject();
            frm.ShowDialog();
            if (frm.SaveCompleted)
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
                FrmSubject frm = new FrmSubject(getId);
                frm.ShowDialog();
                if (frm.SaveCompleted)
                {
                    LoadData();
                }
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if (getId != Guid.Empty)
            {
                FrmSubject frm = new FrmSubject(getId, false);
                frm.ShowDialog();
                if (frm.SaveCompleted)
                {
                    LoadData();
                }
            }
        }
    }
}