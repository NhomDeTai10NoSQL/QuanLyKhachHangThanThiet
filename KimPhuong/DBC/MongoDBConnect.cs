using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
namespace KimPhuong.DBC
{
    public class MongoDBConnect
    {
        private IMongoDatabase _database;
        public static string ConnectionString = "mongodb+srv://kimphuong8694:123@quanlykhachhang.khsds.mongodb.net/test?retryWrites=true&w=majority";
        public static string DatabaseName = "QuanLyKhachHangThanThiet";

        public IMongoDatabase Database
        {
            get { return _database; }
            set { _database = value; }
        }
        public MongoDBConnect()
        {
            var client = new MongoClient(ConnectionString);
            Database = client.GetDatabase(DatabaseName);
        }
        // Lấy tất cả dữ liệu từ một collection
        public List<BsonDocument> GetAllDocuments(string collectionName)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            return collection.Find(new BsonDocument()).ToList();
        }

        // Chèn một document vào collection
        public void InsertDocument(string collectionName, BsonDocument document)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(document);
        }

        // Cập nhật một document trong collection
        public void UpdateDocument(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.UpdateOne(filter, update);
        }

        // Xóa một document trong collection
        public void DeleteDocument(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.DeleteOne(filter);
        }

        public long CountDocuments(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            return collection.CountDocuments(filter);
        }
    }
}
