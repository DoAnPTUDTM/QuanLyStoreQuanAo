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
    public partial class ProductsUI : UserControl
    {
        public event EventHandler onSelect = null;

        public ProductsUI()
        {
            InitializeComponent();
            this.Load += ProductsUI_Load;
            picAdd.Click += PicAdd_Click;
        }

        private void ProductsUI_Load(object sender, EventArgs e)
        {
            HideLabel();
        }

        private void PicAdd_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private string pMaSP;
        private Image pAnh;
        private string pTenSP;
        private string pGiaSP;
        private string pSLTon;

        [Category("Custom Product")]
        public string PMaSP
        {
            get { return pMaSP; }
            set { pMaSP = value; }
        }

        [Category("Custom Product")]
        public Image PAnh 
        {
            get { return  pAnh; }
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

        [Category("Custom Product")]
        public string PSLTon
        {
            get { return pSLTon; }
            set { pSLTon = value; lbSLT.Text = value; }
        }

        private void HideLabel()
        {
            if (string.IsNullOrEmpty(lbGiaSP.Text))
            {
                lbGiaSP.Visible = false;
            }
            else
            {
                lbGiaSP.Visible = true;
            }
        }
    }
}
