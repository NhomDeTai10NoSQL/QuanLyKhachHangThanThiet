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



    }
}
