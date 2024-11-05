using BLL;
using GUI.AdminGUI;
using GUI.SalesGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLoading : MetroFramework.Forms.MetroForm
    {
        string pPassword;
        string pRoleValue;

        frmMainSales fMainSales = new frmMainSales();
        frmMainAdmin fMainAdmin = new frmMainAdmin();
        

        //public frmLoading(string _role, string _pass)
        //{
        //    InitializeComponent();
        //    pRoleValue = _role;
        //    pPassword = _pass;
        //    timerLoading = new Timer();
        //    timerLoading.Interval = 1;
        //    timerLoading.Enabled = true;
        //    timerLoading.Tick += TimerLoading_Tick;
        //}

        //private void TimerLoading_Tick(object sender, EventArgs e)
        //{
        //    timeLine.Width += 3;
        //    if(timeLine.Width >= 686)
        //    {
        //        if (nhanvien_bll.getMaTaiKhoan(pRoleValue, pPassword) == "TK001")
        //        {
        //            timerLoading.Stop();
        //            fMainAdmin.Show();
        //            this.Close();
        //        }
        //        else if(nhanvien_bll.getMaTaiKhoan(pRoleValue, pPassword) == "TK002")
        //        {
        //            timerLoading.Stop();
        //            fMainSales.Show();
        //            this.Close();
        //        }
        //    }
        //}
    }
}
