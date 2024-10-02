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
    public class DanhMucDAO
    {
        MongoDBConnect dBConnect;
        public DanhMucDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> GetAllDanhMuc()
        {
            return dBConnect.GetAllDocuments("DanhMuc");
        }
        public long getSoSPTrongDanhMuc(int ma)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("danhMuc.maDanhMuc", ma);

            return dBConnect.CountDocuments("SanPham", filter);
        }
        public bool ThemDanhMuc(int maDanhMuc, string tenDanhMuc, string moTa)
        {
            try
            {
                var document = new BsonDocument
                {
                    { "maDanhMuc", maDanhMuc },
                    { "tenDanhMuc", tenDanhMuc },
                    {"moTa", moTa }
                };

                dBConnect.InsertDocument("DanhMuc", document);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaDanhMuc(int maDanhMuc)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maDanhMuc", maDanhMuc);
            var result = dBConnect.DeleteDocument("DanhMuc", filter);
            return result.DeletedCount > 0;
        }

        public bool SuaDanhMuc(int maDanhMuc, string tenDanhMuc, string moTa)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maDanhMuc", maDanhMuc);

            var update = Builders<BsonDocument>.Update
                .Set("tenDanhMuc", tenDanhMuc)
                .Set("moTa", moTa);

            var result = dBConnect.UpdateDocument("DanhMuc", filter, update);
            return result.ModifiedCount > 0;
        }

        public int GetMaxMaDanhMuc()
        {
            var maxDoc = dBConnect.GetMaxDocument("DanhMuc", "maDanhMuc");
            if (maxDoc == null)
            {
                return 100;
            }

            int currentMax = maxDoc["maDanhMuc"].ToInt32();

            int nextNumber = currentMax + 1;
            return nextNumber;
        }
        public List<BsonDocument> searchDanhMuc(string key)
        {
            return dBConnect.Search("DanhMuc", key, "tenDanhMuc");
        }

    }
}
