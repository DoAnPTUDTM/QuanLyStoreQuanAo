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

        public List<DanhMucSanPham> GetAllDanhMucSP()
        {
            return db.DanhMucSanPhams.Select(d => d).ToList();
        }
    }
}
