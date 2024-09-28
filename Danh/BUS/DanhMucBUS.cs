using Danh.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danh.BUS
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
    }
}
