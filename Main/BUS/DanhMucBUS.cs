using Main.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
    public class DanhMucBUS
    {
        DanhMucDAO danhMucDAO;
        public DanhMucBUS()
        {
            danhMucDAO = new DanhMucDAO();
        }
        public List<BsonDocument> GetAllDanhMuc()
        {
            return danhMucDAO.GetAllDanhMuc();
        }
        public long getSoSPTrongDanhMuc(int ma)
        {
            return danhMucDAO.getSoSPTrongDanhMuc(ma);
        }
        public bool ThemDanhMuc(int maDanhMuc, string tenDanhMuc, string moTa)
        {
            return danhMucDAO.ThemDanhMuc(maDanhMuc, tenDanhMuc, moTa);
        }
        public bool XoaDanhMuc(int maDanhMuc)
        {
            return danhMucDAO.XoaDanhMuc(maDanhMuc);
        }
        public bool SuaDanhMuc(int maDanhMuc, string tenDanhMuc, string moTa)
        {
            return danhMucDAO.SuaDanhMuc(maDanhMuc , tenDanhMuc, moTa);
        }
        public int GetMaxMaDanhMuc()
        {
            return danhMucDAO.GetMaxMaDanhMuc();
        }
        public List<BsonDocument> searchDanhMuc(string key)
        {
            return danhMucDAO.searchDanhMuc(key);
        }
    }
}
