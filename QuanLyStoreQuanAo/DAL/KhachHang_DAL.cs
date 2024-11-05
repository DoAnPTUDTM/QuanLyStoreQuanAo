using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhachHang_DAL
    {
        QLSHOPQUANAODataContext db = new QLSHOPQUANAODataContext();
        public KhachHang_DAL()
        {

        }

        public List<SanPham> GetSanPhamAll()
        {
            return db.SanPhams.Select(d => d).ToList();
        }
    }
}
