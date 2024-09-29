using KimPhuong.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.BUS
{
    public class NhaCungCapBUS
    {
        NhaCungCapDAO nhaCungCapDAO;
        public NhaCungCapBUS()
        {
            nhaCungCapDAO = new NhaCungCapDAO();
        }
        public List<BsonDocument> getAllNhaCungCap()
        {
            return nhaCungCapDAO.getAllNhaCungCap();
        }
    }
}
