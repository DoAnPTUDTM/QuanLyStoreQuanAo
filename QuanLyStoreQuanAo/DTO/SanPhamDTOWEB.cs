﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTOWEB  {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MaDanhMuc { get; set; }
        public int SoLuongTon { get; set; }
        public int GiaBan { get; set; }
        public string HangSanXuat { get; set; }
        public string MoTa { get; set; }
        public List<string> HinhAnhSanPhams { get; set; }
    }
}