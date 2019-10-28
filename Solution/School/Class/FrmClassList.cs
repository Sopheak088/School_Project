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
    public partial class FrmClassList : Form
    {
        private Guid getId = Guid.Empty;
        public bool SaveCompleted = false;
        public FrmClassList()
        {
            InitializeComponent();
            cmsMenu.Opening += CmsMenu_Opening;
        }

        private void CmsMenu_Opening(object sender, CancelEventArgs e)
        {
            btnView.Enabled = btnEdit.Enabled = false;
            if (getId != Guid.Empty)
            {
                btnView.Enabled = btnEdit.Enabled = true;
            }
        }
        public void LoadData()
        {
            dgvClass.DataSource = FilterList();
        }
        public DataTable FilterList()
        {
            DataTable dataTable = new DataTable();
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ID, Name AS ឈ្មោះថ្នាក់,")
                .AppendFormat("[CreatedBy] AS បង្កើតដោយ,[CreatedDate] AS ថ្ងៃបង្កើត, [UpdatedBy] AS កែប្រែដោយ,[UpdatedDate] AS ថ្ងៃកែប្រែ ")
                .AppendFormat("FROM tbClass ORDER BY Name");
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


        private void FrmClassList_Load(object sender, EventArgs e)
        {
            
            LoadData();
            dgvClass.Columns["ID"].Visible = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmClass frmClass = new FrmClass();
            frmClass.ShowDialog();
            if (frmClass.SaveCompleted)
            {
                LoadData();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (getId != Guid.Empty)
            {
                FrmClass frmClass = new FrmClass(getId);
                frmClass.ShowDialog();
                if (frmClass.SaveCompleted)
                {
                    LoadData();
                }
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if (getId != Guid.Empty)
            {
                FrmClass frmClass = new FrmClass(getId, false);
                frmClass.ShowDialog();
                if (frmClass.SaveCompleted)
                {
                    LoadData();
                }
            }
        }

        private void DgvClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            if (dgvClass.RowCount > 0)
            {
                i = e.RowIndex;
                if (i < 0) return;
                DataGridViewRow row = dgvClass.Rows[i];
                getId = Guid.Parse(row.Cells["ID"].Value.ToString());
            }
        }
    }
}
