using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI.SalesGUI
{
    public partial class frmBill : Form
    {
        
        HoaDon_BLL hoadon_bll = new HoaDon_BLL();
        public frmBill()
        {
            InitializeComponent();
            this.Load += FrmBill_Load;
        }

        private void FrmBill_Load(object sender, EventArgs e)
        {
            LoadAllHoaDon();
        }
        private void LoadAllHoaDon()
        {
            dgvBill.DataSource = hoadon_bll.getAllHoaDon();

            dgvBill.Columns[0].HeaderText = "MÃ HÓA ĐƠN";
            dgvBill.Columns[1].HeaderText = "MÃ KHÁCH HÀNG";
            dgvBill.Columns[2].HeaderText = "MÃ NHÂN VIÊN";
            dgvBill.Columns[3].HeaderText = "NGÀY XUẤT HĐ";
            dgvBill.Columns[4].HeaderText = "TỔNG TIỀN";

            
            dgvBill.Columns[6].Visible = false;
            dgvBill.Columns[7].Visible = false;

            
            dgvBill.Columns.RemoveAt(5);

            
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "TRẠNG THÁI";
            checkBoxColumn.DataPropertyName = "TrangThai";
            checkBoxColumn.TrueValue = true;
            checkBoxColumn.FalseValue = false;
            dgvBill.Columns.Insert(5, checkBoxColumn);
        }
    }
}
