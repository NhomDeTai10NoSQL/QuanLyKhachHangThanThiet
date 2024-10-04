using Danh.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danh.BUS
{
    internal class DangNhapBUS
    {
        private DangNhapDAO dangNhapDAO;

        public DangNhapBUS()
        {
            dangNhapDAO = new DangNhapDAO();
        }

        public List<BsonDocument> GetAllDangNhap()
        {
            return dangNhapDAO.GetAllDangNhap();
        }
    }
}
