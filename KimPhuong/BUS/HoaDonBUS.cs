using KimPhuong.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.BUS
{
    public class HoaDonBUS
    {
        HoaDonDAO hoaDonDAO;
        public HoaDonBUS()
        {
            hoaDonDAO = new HoaDonDAO();
        }
        public List<BsonDocument> getAllHoaDon()
        {
            return hoaDonDAO.getAllHoaDon();
        }
        public BsonDocument getHoaDonByMa(string maHoaDon)
        {
            return hoaDonDAO.getHoaDonByMa(maHoaDon);
        }
    }
}
