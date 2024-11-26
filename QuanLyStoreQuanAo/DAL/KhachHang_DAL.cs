using DTO;
using System.Linq;

namespace DAL
{
    public class KhachHang_DAL
    {
        QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();
        public KhachHang_DAL()
        {

        }
        public string dangNhap(string username)
        {
            var nv = context.KhachHangs.Where(n => n.SoDienThoai == username).FirstOrDefault();
            if (nv == null)
            {
                return string.Empty;
            }
            else
            {

                return nv.MatKhau;

            }
            //return string.Empty;
        }
        public bool dangKi(KhachHang nv)
        {
            var nvvalid = context.KhachHangs.Where(n => n.MaKhachHang == nv.MaKhachHang).FirstOrDefault();
            if (nvvalid != null)
            {
                return false;
            }
            else
            {
                try
                {
                    context.KhachHangs.InsertOnSubmit(nv);
                    context.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
