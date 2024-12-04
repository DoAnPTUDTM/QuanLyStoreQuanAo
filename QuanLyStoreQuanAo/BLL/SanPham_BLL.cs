using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting.Contexts;

namespace BLL
{
    public class SanPham_BLL
    {
        SanPham_DAL dal = new SanPham_DAL();
        public  SanPham_BLL()
        {
            
        }
        //Xóa ảnh
        public bool XoaAnhSanPham(string id)
        {
            return dal.XoaSanPham(id);
        }
        //Lấy sản phẩm SanPhamDTO by id
        public SanPhamDTOWEB GetSanPhamDTOById(string id)
        {
            return dal.GetSanPhamDTOById(id);
        }
        //Lấy sản phẩm by id
        public SanPham GetSanPhamByIdAdmin(string id)
        {
            return dal.GetSanPhamByIdAdmin(id);
        }
       
        public List<SanPhamDTOWEB> GetDSSP()
        {
            return dal.GetDSSP();
        }

        public bool ThemSP(SanPham sp, List<HinhAnhSanPham> hinhanhs)
        {
            if(sp == null || hinhanhs == null)
            {
                return false;
            }
            else
            {
                dal.ThemSanPhamMoi(sp, hinhanhs);
                return true;
            }    
        }

        public bool XoaSP(string maSP)
        {
            if(maSP == null)
        {
                return false;
        }
            else
        {
                dal.XoaSanPham(maSP);
                return true;
        }
        }

        public bool SuaSP(SanPham sp, List<HinhAnhSanPham> hinhanhs)
        {
            if (sp == null || hinhanhs == null)
            {
                return false;
        }
            else
        {
                bool kq = dal.SuaSanPham(sp, hinhanhs);
                if(kq)
                {
                    return true;
                }    
                return false;
            }
        }

        //Lấy ds HinhAnh by id
        public List<HinhAnhSanPham> GetHinhAnhSanPham(string id)
        {
            return dal.GetHinhAnhSanPham(id);
        }

        //Tạo mã tự động
        public string TaoMaSPTuDong()
        {
            return dal.TaoMaSPTuDong();
        }
        //Tìm kiếm sản phẩm theo tên sp
        public List<SanPhamDTOWEB> SearchSanPhamByHoTen(string search)
        {
            return dal.SearchSanPhamByHoTen(search);
        }

        //Lấy tất cả sản phẩm
        public List<SanPhamDTO> GetAllSanPham()
        {
            return dal.GetAllSanPham();
        }
        //Lấy sản phẩm theo mã
        public SanPhamDTO GetSanPhamById(string MaSP)
        {
            return dal.GetSanPhamById(MaSP);
        }
        //Lấy sản phẩm theo danh mục
        public List<SanPhamDTO> GetSanPhamByCategory(string maDanhMuc)
        {
            return dal.GetSanPhamByCategory(maDanhMuc);
        }
        //Lấy sản phẩm theo search
        public List<SanPhamDTO> GetSanPhamBySearch(string Search)
        {
            return dal.GetSanPhamBySearch(Search);
        }
        //Lấy mã sản phẩm theo tên sản phẩm
        public string GetMaSPByTenSP(string tenSP)
        {
            return dal.GetMaSPByTenSP(tenSP);
        }
        //Cập nhật số lượng tồn 
        public void CapNhatSoLuongTon(string maSP, int soLuong)
        {
            dal.CapNhatSoLuongTon(maSP, soLuong);
        }
        //Lấy số lượng tồn
        public int GetSLT(string pMASP)
        {
            return dal.getSLT(pMASP);
        }
    }
}
