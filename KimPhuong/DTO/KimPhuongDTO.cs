using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.DTO
{
    public class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MaVach { get; set; }
        public int GiaBan { get; set; }
        public DateTime NgaySanXuat { get; set; }
        public string XuatXu { get; set; }
        public string MoTa { get; set; }
        public DanhMuc DanhMuc { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public BaoHanh BaoHanh { get; set; }
    }

    public class DanhMuc
    {
        public int MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
    }

    public class NhaCungCap
    {
        public int MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
    }

    public class BaoHanh
    {
        public string MaBaoHanh { get; set; }
        public int ThoiGianBaoHanh { get; set; }
        public string GhiChu { get; set; }
    }

}
