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
    internal class NhanVienDAO
    {
        MongoDBConnect connect;
        DataTable dtNhanVien = new DataTable();
        public string collectionName = "NhanVien";
        public NhanVienDAO() {
            connect = new MongoDBConnect();
        }

        public DataTable getALLNhanVien()
        {
            DataTable dtNhanVien = connect.GetAllDocuments(collectionName);
            return dtNhanVien;
        }
        public string GetNextMaNhanVien()
        {
            try
            {
                var collection = connect.Database.GetCollection<BsonDocument>(collectionName);
                var sort = Builders<BsonDocument>.Sort.Descending("maNhanVien");

                var lastCustomer = collection.Find(new BsonDocument()).Sort(sort).Limit(1).FirstOrDefault();

                if (lastCustomer != null)
                {
                    string lastMaKhachHang = lastCustomer["maNhanVien"].AsString;
                    int lastNumber = int.Parse(lastMaKhachHang.Substring(2));
                    int nextNumber = lastNumber + 1;

                    return "NV" + nextNumber.ToString().PadLeft(4, '0');
                }
                else
                {
                    return "NV0001";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo mã tự động: " + ex.Message);
            }
        }


        public bool AddNhanVien(string tenNhanVien, string gioiTinh, DateTime ngaySinh, string soDienThoai, string email, string chucVu, int mucLuong, string taiKhoan, string matKhau)
        {
            try
            {
                var newEmployee = new BsonDocument
                {
                    { "maNhanVien", GetNextMaNhanVien() },  
                    { "tenNhanVien", tenNhanVien },
                    { "gioiTinh", gioiTinh },
                    { "ngaySinh", ngaySinh },
                    { "soDienThoai", soDienThoai },
                    { "email", email },
                    { "chucVu", chucVu },
                    { "mucLuong", mucLuong },
                    { "taiKhoan", taiKhoan },
                    { "matKhau", matKhau }  
                };

                connect.InsertDocument("NhanVien", newEmployee);

                return true;  
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm nhân viên: " + ex.Message);
                return false; 
            }
        }
        public bool UpdateNhanVien(string maNhanVien, string tenNhanVien, string gioiTinh, DateTime? ngaySinh, string soDienThoai, string email, string chucVu, int mucLuong)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("maNhanVien", maNhanVien);
                var update = Builders<BsonDocument>.Update
                    .Set("tenNhanVien", tenNhanVien)
                    .Set("gioiTinh", gioiTinh)
                    .Set("ngaySinh", ngaySinh)
                    .Set("soDienThoai", soDienThoai)
                    .Set("email", email)
                    .Set("chucVu", chucVu)
                    .Set("mucLuong", mucLuong);
                    
                connect.UpdateDocument(collectionName, filter, update);

                return true;  
            }
            catch (Exception e)
            {
                return false;  
            }
        }

        public bool DeleteNhanVien(string maNhanVien)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("maNhanVien", maNhanVien);

                connect.DeleteDocument(collectionName, filter);

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
                var filter = Builders<BsonDocument>.Filter.Eq("soDienThoai", soDienThoai);
                var count = connect.Database.GetCollection<BsonDocument>(collectionName).CountDocuments(filter);

                return count > 0;
            }
            catch (Exception e)
            {
                return false; 
            }
        }
        public BsonDocument GetNhanVienBySDT(string soDienThoai)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("soDienThoai", soDienThoai);
            var collection = connect.Database.GetCollection<BsonDocument>(collectionName);
            return collection.Find(filter).FirstOrDefault();
        }

        public BsonDocument GetNhanVienByTaiKhoan(string taiKhoan)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("taiKhoan", taiKhoan);
            var collection = connect.Database.GetCollection<BsonDocument>(collectionName);
            return collection.Find(filter).FirstOrDefault();
        }
        public bool UpdateMatKhau(string taiKhoan, string matKhau)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("taiKhoan", taiKhoan);
                var update = Builders<BsonDocument>.Update
                    .Set("matKhau", matKhau);

                connect.UpdateDocument(collectionName, filter, update);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
