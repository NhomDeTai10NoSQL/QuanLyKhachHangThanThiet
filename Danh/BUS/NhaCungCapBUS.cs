﻿using Danh.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danh.BUS
{
    internal class NhaCungCapBUS
    {
        NhaCungCapDAO nhaCungCapDAO;
        
        public NhaCungCapBUS()
        {
            nhaCungCapDAO = new NhaCungCapDAO();
        }
        public List<BsonDocument> GetAllNhaCungCap()
        {
            return nhaCungCapDAO.GetAllNhaCungCap();
        }
        public DataTable GetAll()
        {
            return nhaCungCapDAO.GetALl();
        }
        public bool ThemNhaCungCap(int maNhaCungCap, string tenNhaCungCap, string diaChi, string soDienThoai, string email, string nguoiDaiDien)
        {
            return nhaCungCapDAO.ThemNhaCungCap(maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai, email, nguoiDaiDien);
        }
        public bool XoaNhaCungCap(int maNhaCungCap)
        {
            return nhaCungCapDAO.XoaNhaCungCap(maNhaCungCap);
        }
        public bool SuaNhaCungCap(int maNhaCungCap, string tenNhaCungCap, string diaChi, string soDienThoai, string email, string nguoiDaiDien)
        {
            return nhaCungCapDAO.SuaNhaCungCap(maNhaCungCap, tenNhaCungCap, diaChi, soDienThoai, email, nguoiDaiDien);
        }
        public int GetMaxMaNhaCungCap()
        {
            return nhaCungCapDAO.GetMaxMaNhaCungCap();
        }
        public List<BsonDocument> searchNhaCungCap(string key)
        {
            return nhaCungCapDAO.searchNhaCungCap(key);
        }
    }
}
