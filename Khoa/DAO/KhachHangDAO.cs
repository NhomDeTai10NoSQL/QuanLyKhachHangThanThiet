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
        string collection = "KhachHang";
        public KhachHangDAO() {
            connect = new MongoDBConnect();
        }
        public DataTable getAllKhachHang()
        {
            DataTable dt = connect.GetAllDocuments(collection);
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

                connect.InsertDocument(collection, newCustomer);

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

                connect.UpdateDocument(collection, filter, update);
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

                connect.UpdateDocument(collection, filter, update);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
