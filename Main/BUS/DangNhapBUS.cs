using Main.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
    public class DangNhapBUS
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
        public bool CheckDangNhap(string username, string password)
        {
            return dangNhapDAO.CheckDangNhap(username, password);
        }
    }
}
