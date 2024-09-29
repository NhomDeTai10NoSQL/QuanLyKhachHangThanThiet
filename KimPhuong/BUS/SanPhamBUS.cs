using KimPhuong.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.BUS
{
    public class SanPhamBUS
    {
        SanPhamDAO sanPhamDAO;
        public SanPhamBUS()
        {
            sanPhamDAO = new SanPhamDAO();
        }
        public List<BsonDocument> getAllSanPham()
        {
            return sanPhamDAO.getAllSanPham();
        }
        public List<BsonDocument> searchSanPham(string key)
        {
            return sanPhamDAO.searchSanPham(key);
        }
    }
}
