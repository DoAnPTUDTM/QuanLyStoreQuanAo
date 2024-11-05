using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class CategoryUI : UserControl
    {
        public event EventHandler onSelect = null;

        public CategoryUI()
        {
            InitializeComponent();
            btnSeen.Click += BtnSeen_Click;
        }

        private void BtnSeen_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private string pMaSP;
        private Image pAnh;
        private string pTenSP;
        private string pGiaSP;

        [Category("Custom Product")]
        public string PMaSP
        {
            get { return pMaSP; }
            set { pMaSP = value; }
        }

        [Category("Custom Product")]
        public Image PAnh
        {
            get { return pAnh; }
            set { pAnh = value; picProduct.Image = value; }
        }

        [Category("Custom Product")]
        public string PTenSp
        {
            get { return pTenSP; }
            set { pTenSP = value; lbTenSP.Text = value; }
        }

        [Category("Custom Product")]
        public string PGiaSP
        {
            get { return pGiaSP; }
            set { pGiaSP = value; lbGiaSP.Text = value; }
        }
    }
}
