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
        // Lấy tất cả dữ liệu từ một collection và trả về DataTable
        // Lấy tất cả dữ liệu từ một collection và trả về DataTable, loại bỏ trường _id
        public DataTable GetAllDocuments(string collectionName)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            var documents = collection.Find(new BsonDocument()).ToList(); // Lấy tất cả tài liệu

            DataTable dataTable = new DataTable();

            // Kiểm tra nếu có tài liệu
            if (documents.Count > 0)
            {
                // Lấy danh sách các cột từ tài liệu đầu tiên, loại bỏ trường _id
                foreach (var key in documents[0].Names)
                {
                    if (key != "_id") // Bỏ qua trường _id
                    {
                        dataTable.Columns.Add(new DataColumn(key));
                    }
                }

                // Thêm các hàng dữ liệu vào DataTable
                foreach (var doc in documents)
                {
                    DataRow row = dataTable.NewRow();
                    foreach (var key in doc.Names)
                    {
                        if (key != "_id") // Bỏ qua trường _id
                        {
                            row[key] = doc[key].ToString(); // Chuyển giá trị về string
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
