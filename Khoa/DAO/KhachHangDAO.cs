using Khoa.DBC;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
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
        public KhachHangDAO()
        {
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
            try
            {
                var collection = connect.Database.GetCollection<BsonDocument>("KhachHang");
                var sort = Builders<BsonDocument>.Sort.Descending("MaKhachHang");

                var lastCustomer = collection.Find(new BsonDocument()).Sort(sort).Limit(1).FirstOrDefault();

                if (lastCustomer != null)
                {
                    string lastMaKhachHang = lastCustomer["MaKhachHang"].AsString;
                    int lastNumber = int.Parse(lastMaKhachHang.Substring(2));
                    int nextNumber = lastNumber + 1;

                    return "KH" + nextNumber.ToString().PadLeft(4, '0');
                }
                else
                {
                    return "KH0001";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo mã khách hàng tự động: " + ex.Message);
            }
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
                    { "DiemTichLuyCon", 0 },
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
        public bool KiemTraTrungSDT(string soDienThoai)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("SoDienThoai", soDienThoai);
                var count = connect.Database.GetCollection<BsonDocument>(strcollection).CountDocuments(filter);

                return count > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public BsonDocument GetKhachHangBySDT(string soDienThoai)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("SoDienThoai", soDienThoai);
            var collection = connect.Database.GetCollection<BsonDocument>(strcollection);
            return collection.Find(filter).FirstOrDefault();
        }
        

    }
}
