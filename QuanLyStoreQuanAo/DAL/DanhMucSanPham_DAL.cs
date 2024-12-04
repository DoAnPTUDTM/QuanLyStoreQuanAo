using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DanhMucSanPham_DAL
    {
        QLSHOPQUANAODataContext db = new QLSHOPQUANAODataContext();
        public DanhMucSanPham_DAL()
        {

        }
        //lấy toàn bộ danh mục sản phẩm
        public List<DanhMucSanPham> GetAllDanhMucSP()
        {
            return db.DanhMucSanPhams.Select(d => d).ToList();
        }

        //lấy danh mục theo mã danh mục
        public List<DanhMucSanPham_DTO> getDanhMucSanPhamID(string pMaLSP)
        {
            var query = from lsp in db.DanhMucSanPhams where lsp.MaDanhMuc == pMaLSP select lsp;

            var loaisanphams = query.ToList().ConvertAll(lsp => new DanhMucSanPham_DTO()
            {
                MaDanhMuc = lsp.MaDanhMuc,
                TenDanhMuc = lsp.TenDanhMuc,
                MoTa = lsp.MoTa
            });

            List<DanhMucSanPham_DTO> lst_lsp = loaisanphams.ToList();

            return lst_lsp;
        }

        //láy danh mục sản phẩm theo tên
        public List<DanhMucSanPham_DTO> getDanhMucSanPhamTen(string pValue)
        {
            var query = from lsp in db.DanhMucSanPhams where lsp.TenDanhMuc.Contains(pValue) select lsp;

            var loaisanphams = query.ToList().ConvertAll(lsp => new DanhMucSanPham_DTO()
            {
                MaDanhMuc = lsp.MaDanhMuc,
                TenDanhMuc = lsp.TenDanhMuc,
                MoTa = lsp.MoTa
            });

            List<DanhMucSanPham_DTO> lst_lsp = loaisanphams.ToList();

            return lst_lsp;
        }

        //thêm danh mục sản phẩm
        public void addLSP(DanhMucSanPham_DTO lsp)
        {
            DanhMucSanPham lsps = new DanhMucSanPham();

            lsps.MaDanhMuc = lsp.MaDanhMuc;
            lsps.TenDanhMuc = lsp.TenDanhMuc;
            lsps.MoTa = lsp.MoTa;
            db.DanhMucSanPhams.InsertOnSubmit(lsps);
            db.SubmitChanges();
        }

        // xóa DanhMucSanPham
        public bool removeLSP(string pMaLSP)
        {
            DanhMucSanPham lsp = db.DanhMucSanPhams.Where(t => t.MaDanhMuc == pMaLSP).FirstOrDefault();
            if (lsp != null)
            {
                db.DanhMucSanPhams.DeleteOnSubmit(lsp);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        //sửa DanhMucSanPham
        public void editLSP(DanhMucSanPham_DTO lsp)
        {
            DanhMucSanPham lsps = db.DanhMucSanPhams.Where(t => t.MaDanhMuc == lsp.MaDanhMuc).FirstOrDefault();

           lsps.MaDanhMuc = lsp.MaDanhMuc;
            lsps.TenDanhMuc = lsp.TenDanhMuc;
            lsps.MoTa = lsp.MoTa;

            db.SubmitChanges();
        }

        //đếm DanhMucSanPham
        public int countCategory()
        {
            var query = from lsp in db.DanhMucSanPhams select lsp;
            return query.Count();
        }

        //kiểm tra trùng mã danh  mục
        public bool checkPK(string pCode)
        {
            var query = from lsp in db.DanhMucSanPhams where lsp.MaDanhMuc == pCode select lsp;
            return query.Any();
        }

    }
}
