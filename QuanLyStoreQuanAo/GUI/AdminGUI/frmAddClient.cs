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

namespace GUI.AdminGUI
{
    public partial class frmAddClient : Form
    {
       

        public frmAddClient()
        {
            InitializeComponent();
            this.Load += FrmAddClient_Load;
        }

        private void FrmAddClient_Load(object sender, EventArgs e)
        {
            lblemail.Visible = false;
            lblsdt.Visible = false;
            label1.Visible = false; 

        }
    }
}
