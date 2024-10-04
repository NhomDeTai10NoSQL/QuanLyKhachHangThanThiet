using Khoa.DBC;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khoa.DAO
{
    public class KhachHangDAO
    {
        MongoDBConnect connect;
        string strcollection = "KhachHang";
        public KhachHangDAO() {
            connect = new MongoDBConnect();
        }
        public DataTable getAllKhachHang()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("TrangThai", "Hoạt động");

            DataTable dt = connect.GetDocumentsWithFilter(strcollection, filter);

            return dt;
        }
        public string GetNextMaKhachHang()
        {
            var sequenceDocument = connect.Database.GetCollection<BsonDocument>("counters")
                .FindOneAndUpdate(
                    Builders<BsonDocument>.Filter.Eq("_id", "khachhangid"), 
                    Builders<BsonDocument>.Update.Inc("sequence_value", 1),
                    new FindOneAndUpdateOptions<BsonDocument>
                    {
                        ReturnDocument = ReturnDocument.After, 
                        IsUpsert = true 
                    });

            return "KH" + sequenceDocument["sequence_value"].ToString().PadLeft(4, '0'); 
        }

        public bool AddKhachHang(string tenKhachHang, DateTime ngaySinh, string soDienThoai, int diemTichLuy, string trangThai, string loaiKhachHang)
        {
            try
            {
                var newCustomer = new BsonDocument
                {
                    { "MaKhachHang", GetNextMaKhachHang() },
                    { "TenKhachHang", tenKhachHang },
                    { "NgaySinh", ngaySinh },
                    { "SoDienThoai", soDienThoai },
                    { "DiemTichLuy", diemTichLuy },
                    { "TrangThai", trangThai },
                    { "LoaiKhachHang", loaiKhachHang }
                };

                connect.InsertDocument(strcollection, newCustomer);

                return true; 
            }
            catch (Exception ex)
            {
                return false; 
            }
        }
        public bool UpdateKhachHang(string maKhachHang, string tenkh, DateTime? ngaysinh, string sdt, int diem, string trangthai, string loaiKH)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("MaKhachHang", maKhachHang);
                var update = Builders<BsonDocument>.Update
                    .Set("TenKhachHang", tenkh)
                    .Set("NgaySinh", ngaysinh)
                    .Set("SoDienThoai", sdt)
                    .Set("DiemTichLuy", diem)
                    .Set("TrangThai", trangthai)
                    .Set("LoaiKhachHang", loaiKH);

                connect.UpdateDocument(strcollection, filter, update);
                return true; 
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool hideKhachHang(string maKhachHang)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("MaKhachHang", maKhachHang);
                var update = Builders<BsonDocument>.Update

                    .Set("TrangThai", "Ẩn");

                connect.UpdateDocument(strcollection, filter, update);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool showKhachHang(string maKhachHang)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("MaKhachHang", maKhachHang);
                var update = Builders<BsonDocument>.Update

                    .Set("TrangThai", "Hoạt động");

                connect.UpdateDocument(strcollection, filter, update);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public DataTable SearchKhachHang(string searchValue)
        {
            var collection = connect.Database.GetCollection<BsonDocument>(strcollection);

            var filter = Builders<BsonDocument>.Filter.Or(
                Builders<BsonDocument>.Filter.Regex("TenKhachHang", new BsonRegularExpression(searchValue, "i")),
                Builders<BsonDocument>.Filter.Regex("SoDienThoai", new BsonRegularExpression(searchValue, "i"))
            );

            var results = collection.Find(filter).ToList();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaKhachHang", typeof(string));
            dataTable.Columns.Add("TenKhachHang", typeof(string));
            dataTable.Columns.Add("NgaySinh", typeof(DateTime));
            dataTable.Columns.Add("SoDienThoai", typeof(string));
            dataTable.Columns.Add("DiemTichLuy", typeof(int));
            dataTable.Columns.Add("TrangThai", typeof(string));
            dataTable.Columns.Add("LoaiKhachHang", typeof(string));

            foreach (var customer in results)
            {
                dataTable.Rows.Add(
                    customer["MaKhachHang"].AsString,
                    customer["TenKhachHang"].AsString,
                    customer["NgaySinh"].ToUniversalTime(),
                    customer["SoDienThoai"].AsString,
                    customer["DiemTichLuy"].AsInt32,
                    customer["TrangThai"].AsString,
                    customer["LoaiKhachHang"].AsString
                );
            }

            return dataTable; 
        }
        public DataTable locKhachHang(string value)
        {
            var collection = connect.Database.GetCollection<BsonDocument>(strcollection);

            var filter = Builders<BsonDocument>.Filter.Or(
                Builders<BsonDocument>.Filter.Regex("TrangThai", new BsonRegularExpression(value, "i")),
                Builders<BsonDocument>.Filter.Regex("LoaiKhachHang", new BsonRegularExpression(value, "i"))
            );

            var results = collection.Find(filter).ToList();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaKhachHang", typeof(string));
            dataTable.Columns.Add("TenKhachHang", typeof(string));
            dataTable.Columns.Add("NgaySinh", typeof(DateTime));
            dataTable.Columns.Add("SoDienThoai", typeof(string));
            dataTable.Columns.Add("DiemTichLuy", typeof(int));
            dataTable.Columns.Add("TrangThai", typeof(string));
            dataTable.Columns.Add("LoaiKhachHang", typeof(string));

            foreach (var customer in results)
            {
                dataTable.Rows.Add(
                    customer["MaKhachHang"].AsString,
                    customer["TenKhachHang"].AsString,
                    customer["NgaySinh"].ToUniversalTime(),
                    customer["SoDienThoai"].AsString,
                    customer["DiemTichLuy"].AsInt32,
                    customer["TrangThai"].AsString,
                    customer["LoaiKhachHang"].AsString
                );
            }

            return dataTable;
        }
        public bool DeleteKhachHang(string maKhachHang)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("MaKhachHang", maKhachHang);

                connect.DeleteDocument("KhachHang", filter);

                return true;  
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

    }
}
