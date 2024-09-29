using Danh.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
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
    }
}
