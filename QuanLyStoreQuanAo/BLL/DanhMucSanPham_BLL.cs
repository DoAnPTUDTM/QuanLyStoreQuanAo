using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DanhMucSanPham_BLL
    {
        DanhMucSanPham_DAL dmsp_dal = new DanhMucSanPham_DAL();
        public DanhMucSanPham_BLL()
        {

        }

        public List<DanhMucSanPham> GetAllDanhMucSP()
        {
            return dmsp_dal.GetAllDanhMucSP();
        }
    }
}
