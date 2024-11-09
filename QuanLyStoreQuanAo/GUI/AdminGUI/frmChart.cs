using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.AdminGUI
{
    public partial class frmChart : Form
    {

        HoaDon_BLL hoadon_bll = new HoaDon_BLL();
        public frmChart()
        {
            InitializeComponent();
            this.Load += FrmChart_Load;
        }

        private void FrmChart_Load(object sender, EventArgs e)
        {
            LoadBieuDo();
        }

        //private void LoadBieuDo()
        //{

        //    chartBill.Series.Clear();

        //    Series series = chartBill.Series.Add("Doanh thu");

        //    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

        //    series.Color = System.Drawing.Color.Blue;

        //    int currentYear = DateTime.Now.Year;

        //    for (int month = 1; month <= 12; month++)
        //    {
        //        //int doanhThu = hoadon_bll.TinhDoanhThuTheoThang(month, currentYear);
        //        //series.Points.AddXY(month, doanhThu);
        //    }
        //    chartBill.ChartAreas[0].AxisX.Title = "Tháng";
        //    chartBill.ChartAreas[0].AxisY.Title = "Doanh thu";
        //}

        private void LoadBieuDo()
        {
            chartBill.Series.Clear();

            Series series = chartBill.Series.Add("Doanh thu");

            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            series.Color = System.Drawing.Color.Blue;

            int currentYear = DateTime.Now.Year;

            for (int month = 1; month < 12; month++)
            {
                int doanhThu = hoadon_bll.TinhDoanhThuTheoThang(month, currentYear);

                int pointIndex = series.Points.AddXY(month, doanhThu);

                DataPoint point = series.Points[pointIndex];
                point.IsValueShownAsLabel = true; 
                point.Label = doanhThu.ToString(); 
                point.LabelForeColor = System.Drawing.Color.Black;
                point.LabelBackColor = System.Drawing.Color.Transparent; 
                point.LabelAngle = 0;
            }
            chartBill.ChartAreas[0].AxisX.Title = "Tháng";
            chartBill.ChartAreas[0].AxisY.Title = "Doanh thu";
        }
    }
}
