using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Data;

namespace Danh.DBC
{
    public class MongoDBConnect
    {
        private IMongoDatabase _database;
        public static string ConnectionString = "mongodb+srv://kimphuong8694:123@quanlykhachhang.khsds.mongodb.net/";
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
        public DataTable GetAllDocumentsWithDataTable(string collectionName)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var documents = collection.Find(new BsonDocument()).ToList();

            DataTable dataTable = new DataTable();

            if (documents.Count > 0)
            {
                foreach (var key in documents[0].Names)
                {
                    if (key != "_id")
                    {
                        dataTable.Columns.Add(new DataColumn(key));
                    }
                }
                foreach (var doc in documents)
                {
                    DataRow row = dataTable.NewRow();
                    foreach (var key in doc.Names)
                    {
                        if (key != "_id")
                        {
                            row[key] = doc[key].ToString();
                        }
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }
        // Chèn một document vào collection
        public void InsertDocument(string collectionName, BsonDocument document)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(document);
        }

        // Cập nhật một document trong collection
        public UpdateResult UpdateDocument(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            return collection.UpdateOne(filter, update);
        }

        // Xóa 
        public DeleteResult DeleteDocument(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            return collection.DeleteOne(filter);
        }

        //Đếm
        public long CountDocuments(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            return collection.CountDocuments(filter);
        }
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

        //Lấy lớn nhất
        public BsonDocument GetMaxDocument(string collectionName, string fieldName)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var sort = Builders<BsonDocument>.Sort.Descending(fieldName);
            return collection.Find(new BsonDocument()).Sort(sort).Limit(1).FirstOrDefault();
        }

        public List<BsonDocument> Search(string collectionName, string searchText, string searchField)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName); 
            var filter = Builders<BsonDocument>.Filter.Regex(searchField, new BsonRegularExpression(searchText, "i"));
            return collection.Find(filter).ToList();
        }

    }
}
