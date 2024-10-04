using Main.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.BUS
{
    internal class GiaoHangBUS
    {
        GiaoHangDAO giaoHangDAO;
        public GiaoHangBUS()
        {
            giaoHangDAO = new GiaoHangDAO();
        }
        public List<BsonDocument> GetAllGiaoHang()
        {
            return giaoHangDAO.GetAllGiaoHang();
        }
    }
}
