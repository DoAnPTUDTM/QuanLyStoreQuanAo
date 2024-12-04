using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPham_BLL
    {
        SanPham_DAL sanpham_dal = new SanPham_DAL();
        public SanPham_BLL()
        {

        }

        //Lấy tất cả sản phẩm
        public List<SanPhamDTO> GetAllSanPham()
        {
            return sanpham_dal.GetAllSanPham();
        }
        //Lấy sản phẩm theo mã
        public SanPhamDTO GetSanPhamById(string MaSP)
        {
            return sanpham_dal.GetSanPhamById(MaSP);
        }
        //Lấy sản phẩm theo danh mục
        public List<SanPhamDTO> GetSanPhamByCategory(string maDanhMuc)
        {
            return sanpham_dal.GetSanPhamByCategory(maDanhMuc);
        }
        //Lấy sản phẩm theo search
        public List<SanPhamDTO> GetSanPhamBySearch(string Search)
        {
            return sanpham_dal.GetSanPhamBySearch(Search);
        }
        //Lấy mã sản phẩm theo tên sản phẩm
        public string GetMaSPByTenSP(string tenSP)
        {
            return sanpham_dal.GetMaSPByTenSP(tenSP);
        }
        //Cập nhật số lượng tồn 
        public void CapNhatSoLuongTon(string maSP, int soLuong)
        {
            sanpham_dal.CapNhatSoLuongTon(maSP, soLuong);
        }
        //Lấy số lượng tồn
        public int GetSLT(string pMASP)
        {
            return sanpham_dal.getSLT(pMASP);
        }
        //thêm sản phầm 
        public void addSP(SanPhamDTO sp)
        {
            sanpham_dal.addSP(sp);
        }

        // xóa sản phẩm
        public void removeSP(string  sp)
        {
            sanpham_dal.removeSP(sp);
        }

        public void editSP(SanPhamDTO sp)
        {
            sanpham_dal.editSP(sp);
        }
    }
}
