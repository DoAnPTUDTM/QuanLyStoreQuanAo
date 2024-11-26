using DTO;
using System.Linq;
using System.Data.Linq;
namespace DAL
{
    public class NhanVien_DAL
    {
        QLSHOPQUANAODataContext context = new QLSHOPQUANAODataContext();
        public NhanVien_DAL()
        {

        }
        public string dangNhap(string username)
        {
            var nv = context.NhanViens.Where(n => n.SoDienThoai == username).FirstOrDefault();
            if (nv == null)
            {
                return string.Empty;
            }
            else
            {

                return nv.MatKhau;

            }

        }
        public bool dangKi(NhanVien nv)
        {
            var nvvalid = context.NhanViens.Where(n => n.MaNhanVien == nv.MaNhanVien).FirstOrDefault();
            if (nvvalid != null)
            {
                return false;
            }
            else
            {
                try
                {
                    context.NhanViens.InsertOnSubmit(nv);
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
