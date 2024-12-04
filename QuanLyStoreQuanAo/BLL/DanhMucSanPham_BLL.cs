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

        public List<DanhMucSanPham_DTO> getDanhMucSanPhamID(string pMaLSP)
        {
            return dmsp_dal.getDanhMucSanPhamID(pMaLSP);
        }
        public List<DanhMucSanPham_DTO> getDanhMucSanPhamTen(string pMaLSP)
        {
            return dmsp_dal.getDanhMucSanPhamTen(pMaLSP);
        }
        public void addLSP(DanhMucSanPham_DTO lsp)
        {
            dmsp_dal.addLSP(lsp);
        }

      
        public bool removeLSP(string pMaLSP)
        {
            return dmsp_dal.removeLSP(pMaLSP);
        }

      
        public void editLSP(DanhMucSanPham_DTO lsp)
        {
            dmsp_dal.editLSP(lsp);
        }

        public int countCategory()
        {
            return dmsp_dal.countCategory();
        }

       
        public bool checkPK(string pCode)
        {
            return dmsp_dal.checkPK(pCode);
        }

    }
}
