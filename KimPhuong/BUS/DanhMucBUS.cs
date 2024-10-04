using KimPhuong.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.BUS
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
            return danhMucDAO.getAllDanhMuc();
        }
    }
}
