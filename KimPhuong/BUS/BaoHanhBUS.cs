using KimPhuong.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.BUS
{
    public class BaoHanhBUS
    {
        BaoHanhDAO baoHanhDAO;
        public BaoHanhBUS()
        {
            baoHanhDAO = new BaoHanhDAO();
        }
        public List<BsonDocument> getAllBaoHanh()
        {
            return baoHanhDAO.getAllBaoHanh();
        }
    }
}
