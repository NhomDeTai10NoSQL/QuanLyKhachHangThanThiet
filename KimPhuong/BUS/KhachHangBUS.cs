using KimPhuong.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.BUS
{
    public class KhachHangBUS
    {
        KhachHangDAO khachHangDAO;
        public KhachHangBUS()
        {
            khachHangDAO = new KhachHangDAO();
        }
        public BsonDocument getKHBySDT(string sodt)
        {
            return khachHangDAO.getKHBySDT(sodt);
        }
        
    }
}
