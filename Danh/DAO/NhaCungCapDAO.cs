using Danh.DBC;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danh.DAO
{
    internal class NhaCungCapDAO
    {
        MongoDBConnect dBConnect;
        public NhaCungCapDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> GetAllNhaCungCap()
        {
            return dBConnect.GetAllDocuments("NhaCungCap");
        }
        public bool ThemNhaCungCap(int maNhaCungCap, string tenNhaCungCap, string diaChi, string soDienThoai, string email, string nguoiDaiDien)
        {
            try
            {
                var document = new BsonDocument
            {
                { "maNhaCungCap", maNhaCungCap },
                { "tenNhaCungCap", tenNhaCungCap },
                { "diaChi", diaChi },
                { "soDienThoai", soDienThoai },
                { "email", email },
                { "nguoiDaiDien", nguoiDaiDien }
            };
                dBConnect.InsertDocument("NhaCungCap", document);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaNhaCungCap(int maNhaCungCap)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maNhaCungCap", maNhaCungCap);
            var result = dBConnect.DeleteDocument("NhaCungCap", filter);
            return result.DeletedCount > 0;
        }
        public bool SuaNhaCungCap(int maNhaCungCap, string tenNhaCungCap, string diaChi, string soDienThoai, string email, string nguoiDaiDien)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maNhaCungCap", maNhaCungCap);

            var update = Builders<BsonDocument>.Update
                .Set("tenNhaCungCap", tenNhaCungCap)
                .Set("diaChi", diaChi)
                .Set("soDienThoai", soDienThoai)
                .Set("email", email)
                .Set("nguoiDaiDien", nguoiDaiDien);

            var result = dBConnect.UpdateDocument("NhaCungCap", filter, update);
            return result.ModifiedCount > 0;
        }

        public int GetMaxMaNhaCungCap()
        {
            var maxDoc = dBConnect.GetMaxDocument("NhaCungCap", "maNhaCungCap");
            if (maxDoc == null)
            {
                return 100;
            }

            int currentMax = maxDoc["maNhaCungCap"].ToInt32();

            int nextNumber = currentMax + 1;
            return nextNumber;
        }
        public List<BsonDocument> searchNhaCungCap(string key)
        {
            return dBConnect.Search("NhaCungCap", key, "tenNhaCungCap");
        }
    }
}
