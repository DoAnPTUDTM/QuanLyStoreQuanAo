using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
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
        public SanPhamDTO GetSanPhamDTOById(string id)
        {
            return dal.GetSanPhamDTOById(id);
        }
        //Lấy sản phẩm by id
        public SanPham GetSanPhamById(string id)
        {
            return dal.GetSanPhamById(id);
        }
       
        public List<SanPhamDTO> GetDSSP()
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
        public List<SanPhamDTO> SearchSanPhamByHoTen(string search)
        {
            return dal.SearchSanPhamByHoTen(search);
        }

        
    }
}
