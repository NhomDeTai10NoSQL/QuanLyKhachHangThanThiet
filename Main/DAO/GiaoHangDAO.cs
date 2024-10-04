using Main.DBC;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DAO
{
    internal class GiaoHangDAO
    {
        MongoDBConnect dBConnect;
        public GiaoHangDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> GetAllGiaoHang()
        {
            return dBConnect.GetAllDocuments("GiaoHang");
        }
        //public string GetProductNameById(string maSanPham)
        //{
        //    var filter = Builders<BsonDocument>.Filter.Eq("MaSanPham", maSanPham);
        //    var product = _productCollection.Find(filter).FirstOrDefault();
        //    return product?["TenSanPham"]?.ToString() ?? "N/A"; // Adjust the field name accordingly
        //}
    }
}
