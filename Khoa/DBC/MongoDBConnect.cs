using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khoa.DBC
{
    public class MongoDBConnect
    {
        private IMongoDatabase _database;
        public static string ConnectionString = "mongodb://localhost:27017";
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
        public DataTable GetAllDocuments(string collectionName)
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
        public DataTable GetDocumentsWithFilter(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);

            var documents = collection.Find(filter).ToList();

            DataTable dt = new DataTable();
            foreach (var doc in documents)
            {
                doc.Remove("_id");
                if (dt.Columns.Count == 0)
                {
                    foreach (var element in doc.Elements)
                    {
                        dt.Columns.Add(element.Name);
                    }
                }
                var row = dt.NewRow();
                foreach (var element in doc.Elements)
                {
                    row[element.Name] = element.Value;
                }
                dt.Rows.Add(row);
            }

            return dt;
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
    }
}
