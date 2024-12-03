using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class DanhMucSanPham_BLL
    {
        DanhMucSanPham_DAL dal = new DanhMucSanPham_DAL();
        public DanhMucSanPham_BLL()
        {
            
        }

        //Lấy danh mục sản phẩm by id
        public DanhMucSanPham GetDanhMucSanPham(string id)
        {
            return dal.GetDanhMucSanPhamById(id);
        }
        public List<DanhMucSanPham> GetDSDanhMuc()
        {
            return dal.GetDanhSachDM();
        }

        public bool ThemDMSP(DanhMucSanPham dm)
        {
            if(dm == null)
            {
                return false;
            }
            else
            {
                dal.ThemDanhMucSanPhamMoi(dm);
                return true;
            }      
        }

        public bool XoaDMSP(string maDMSP)
        {
            if(maDMSP == null)
            {
                return false;
            }
            else
            {
                dal.XoaDanhMucSanPham(maDMSP);
                return true;
            }
        }

        public bool SuaDMSP(DanhMucSanPham dm)
        {
            if(dm == null)
            {
                return false;
            }
            else
            {
                dal.SuaDanhMucSanPham(dm);
                return true;
            }    
        }

        //Tìm kiếm danh mục theo tên danh mục
        public List<DanhMucSanPham> SearchDanhMucByTenDanhMuc(string search)
        {
            return dal.SearchDanhMucByTenDanhMuc(search);
        }
    }
}
