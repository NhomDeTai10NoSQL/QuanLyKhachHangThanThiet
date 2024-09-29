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
        // Lấy 
        public List<BsonDocument> GetAllDocuments(string collectionName)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            return collection.Find(new BsonDocument()).ToList();
        }

        // Thêm
        public void InsertDocument(string collectionName, BsonDocument document)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(document);
        }

        // Cập nhật
        public void UpdateDocument(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.UpdateOne(filter, update);
        }

        // Xóa 
        public void DeleteDocument(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.DeleteOne(filter);
        }

        //Đếm
        public long CountDocuments(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            return collection.CountDocuments(filter);
        }

        //Tìm
        public List<BsonDocument> SearchDocuments(string collectionName, string searchText, string[] searchFields, string indexName)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);

            var searchStage = new BsonDocument
    {
        {
            "$search", new BsonDocument
            {
                {
                    "index", indexName
                },
                {
                    "text", new BsonDocument
                    {
                        { "query", searchText },
                        { "path", new BsonArray(searchFields) }
                    }
                }
            }
        }
    };

            var pipeline = new[] { searchStage };
            return collection.Aggregate<BsonDocument>(pipeline).ToList();
        }
    }
}
