using KimPhuong.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.BUS
{
    public class DatHangNCCBUS
    {
        DatHangNCCDAO datHangNCCDAO;
        public DatHangNCCBUS()
        {
            datHangNCCDAO = new DatHangNCCDAO();
        }
        public List<BsonDocument> getAllDonDatHang()
        {
            return datHangNCCDAO.getAllDonDatHang();
        }
    }
}
