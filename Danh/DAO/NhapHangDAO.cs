﻿using Danh.DBC;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danh.DAO
{
    internal class NhapHangDAO
    {
        MongoDBConnect connect;
        private string collectionName = "DonDatHangNhaCungCap";
        public NhapHangDAO() {
            connect = new MongoDBConnect();
        }
        public DataTable getAll()
        {
            DataTable dt = connect.GetAllDocumentsWithDataTable(collectionName);
            return dt;
        }
        public DataTable getNhapHang()
        {
            List<BsonDocument> documents = connect.GetAllDocuments(collectionName);

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("maDonDatHang");
            dataTable.Columns.Add("tenNhaCungCap");
            dataTable.Columns.Add("ngayDatHang");
            dataTable.Columns.Add("tongTien");
            dataTable.Columns.Add("trangThai");

            foreach (var doc in documents)
            {
                DataRow row = dataTable.NewRow();

                if (doc.Contains("maDonDatHang"))
                    row["maDonDatHang"] = doc["maDonDatHang"].AsString;

                if (doc.Contains("nhaCungCap") && doc["nhaCungCap"].IsBsonDocument)
                {
                    var nhaCungCap = doc["nhaCungCap"].AsBsonDocument;
                    if (nhaCungCap.Contains("tenNhaCungCap"))
                        row["tenNhaCungCap"] = nhaCungCap["tenNhaCungCap"].AsString; 
                }

                if (doc.Contains("ngayDatHang"))
                    row["ngayDatHang"] = doc["ngayDatHang"].ToUniversalTime();
                if (doc.Contains("tongTien"))
                    row["tongTien"] = doc["tongTien"].AsInt32;
                if (doc.Contains("trangThai"))
                    row["trangThai"] = doc["trangThai"].AsString;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }



        public DataTable getChiTietNhapHang(string maDonDatHang)
        {
            var collection = connect.Database.GetCollection<BsonDocument>(collectionName);
            var filter = Builders<BsonDocument>.Filter.Eq("maDonDatHang", maDonDatHang);
            var document = collection.Find(filter).FirstOrDefault();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("maSanPham");
            dataTable.Columns.Add("tenSanPham");
            dataTable.Columns.Add("soLuong");
            dataTable.Columns.Add("donGia");
            dataTable.Columns.Add("thanhTien");

            if (document != null)
            {
                var chiTiet = document["chiTietDonDatHang"].AsBsonArray;
                foreach (var item in chiTiet)
                {
                    DataRow row = dataTable.NewRow();
                    row["maSanPham"] = item["maSanPham"].AsString;
                    row["tenSanPham"] = item["tenSanPham"].AsString;
                    row["soLuong"] = item["soLuong"].AsInt32;
                    row["donGia"] = item["donGia"].AsInt32;
                    row["thanhTien"] = item["thanhTien"].AsInt32;

                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }

        public bool AddDonNhapHang(string maDonDatHang, string maNhaCungCap, DateTime ngayDatHang)
        {
            try
            {
                var newDonDatHang = new BsonDocument
                {
                    {"maDonDatHang", maDonDatHang},
                    { "maNhaCungCap", maNhaCungCap},
                    { "ngayDatHang", ngayDatHang }
                };

                var collection = connect.Database.GetCollection<BsonDocument>(collectionName);
                collection.InsertOne(newDonDatHang);

                return true;  
            }
            catch (Exception ex)
            {
                return false; 
            }
        }
        public bool UpdateDonNhapHang(string maDonDatHang, string trangThai)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("maDonDatHang", maDonDatHang);

                var update = Builders<BsonDocument>.Update.Set("trangThai", trangThai);

                var collection = connect.Database.GetCollection<BsonDocument>(collectionName);
                var result = collection.UpdateOne(filter, update);

                return result.ModifiedCount > 0;  
            }
            catch (Exception ex)
            {
                return false;  
            }
        }
        public DataTable SearchDonNhapHang(string key)
        {
            try
            {
                // Tạo bộ lọc tìm kiếm
                var filter = Builders<BsonDocument>.Filter.Or(
                    Builders<BsonDocument>.Filter.Regex("maDonDatHang", new BsonRegularExpression(key, "i")),
                    Builders<BsonDocument>.Filter.Regex("nhaCungCap.maNhaCungCap", new BsonRegularExpression(key, "i")),
                    Builders<BsonDocument>.Filter.Regex("nhaCungCap.tenNhaCungCap", new BsonRegularExpression(key, "i")),
                    Builders<BsonDocument>.Filter.Regex("trangThai", new BsonRegularExpression(key, "i")),
                    Builders<BsonDocument>.Filter.ElemMatch<BsonDocument>("chiTietDonDatHang", Builders<BsonDocument>.Filter.Regex("tenSanPham", new BsonRegularExpression(key, "i")))
                );

                // Truy vấn MongoDB
                var collection = connect.Database.GetCollection<BsonDocument>("DonDatHangNhaCungCap");
                var result = collection.Find(filter).ToList();

                // Chuyển kết quả sang DataTable
                DataTable dt = new DataTable();
                dt.Columns.Add("maDonDatHang");
                dt.Columns.Add("maNhaCungCap");
                dt.Columns.Add("tenNhaCungCap");
                dt.Columns.Add("ngayDatHang");
                dt.Columns.Add("tongTien");
                dt.Columns.Add("trangThai");
                dt.Columns.Add("tenSanPham");

                foreach (var doc in result)
                {
                    DataRow row = dt.NewRow();
                    row["maDonDatHang"] = doc["maDonDatHang"].ToString();
                    row["maNhaCungCap"] = doc["nhaCungCap"]["maNhaCungCap"].ToString();
                    row["tenNhaCungCap"] = doc["nhaCungCap"]["tenNhaCungCap"].ToString();
                    row["ngayDatHang"] = doc["ngayDatHang"].ToUniversalTime().ToString("yyyy-MM-dd");
                    row["tongTien"] = doc.Contains("tongTien") ? doc["tongTien"].ToString() : "0";
                    row["trangThai"] = doc["trangThai"].ToString();

                    // Lấy danh sách tên sản phẩm
                    var chiTiet = doc["chiTietDonDatHang"].AsBsonArray;
                    string tenSanPham = string.Join(", ", chiTiet.Select(p => p["tenSanPham"].ToString()));
                    row["tenSanPham"] = tenSanPham;

                    dt.Rows.Add(row);
                }

                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm đơn nhập hàng: {ex.Message}");
                return null;
            }
        }

        public bool AddChiTietDonNhapHang(string maDonDatHang, string maSanPham, int soLuong, int donGia, out string errorMessage)
        {
            errorMessage = string.Empty;

            var filter = Builders<BsonDocument>.Filter.Eq("maDonDatHang", maDonDatHang);

            var collection = connect.Database.GetCollection<BsonDocument>("DonDatHangNhaCungCap");
            var donDatHang = collection.Find(filter).FirstOrDefault();

            if (donDatHang != null)
            {
                var chiTiet = donDatHang["chiTietDonDatHang"].AsBsonArray
                    .FirstOrDefault(sp => sp["maSanPham"] == maSanPham);

                if (chiTiet != null)
                {
                    if (chiTiet["donGia"].ToInt32() != donGia)
                    {
                        errorMessage = "Đơn giá không khớp với đơn giá đã lưu. Vui lòng kiểm tra lại.";
                        return false;
                    }

                    var update = Builders<BsonDocument>.Update
                        .Inc("chiTietDonDatHang.$.soLuong", soLuong)
                        .Set("chiTietDonDatHang.$.thanhTien", (chiTiet["soLuong"].ToInt32() + soLuong) * donGia);

                    collection.UpdateOne(filter, update);
                }
                else
                {
                    var newChiTiet = new BsonDocument
            {
                { "maSanPham", maSanPham },
                { "tenSanPham", "" }, 
                { "soLuong", soLuong },
                { "donGia", donGia },
                { "thanhTien", soLuong * donGia }
            };

                    var update = Builders<BsonDocument>.Update
                        .AddToSet("chiTietDonDatHang", newChiTiet);

                    collection.UpdateOne(filter, update);
                }

                return true;
            }
            else
            {
                errorMessage = "Không tìm thấy đơn đặt hàng.";
                return false;
            }
        }
        public DataTable getAllChiTiet(string maDonDatHang)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSanPham", typeof(string));
            dt.Columns.Add("TenSanPham", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("DonGia", typeof(int));
            dt.Columns.Add("ThanhTien", typeof(int));

            var filter = Builders<BsonDocument>.Filter.Eq("maDonDatHang", maDonDatHang);

            var collection = connect.Database.GetCollection<BsonDocument>(collectionName);
            var donDatHang = collection.Find(filter).FirstOrDefault();

            if (donDatHang != null && donDatHang.Contains("chiTietDonDatHang"))
            {
                var chiTietDonDatHang = donDatHang["chiTietDonDatHang"].AsBsonArray;

                foreach (var item in chiTietDonDatHang)
                {
                    var row = dt.NewRow();
                    row["MaSanPham"] = item["maSanPham"].AsString;
                    row["TenSanPham"] = item["tenSanPham"].AsString;
                    row["SoLuong"] = item["soLuong"].AsInt32;
                    row["DonGia"] = item["donGia"].AsInt32;
                    row["ThanhTien"] = item["thanhTien"].AsInt32;

                    dt.Rows.Add(row);
                }
            }

            return dt;
        }

        public string GetNextMaDonHang()
        {
            var maxDoc = connect.GetMaxDocument("DonDatHangNhaCungCap", "maDonDatHang");
            if (maxDoc == null)
            {
                return "DDH001";
            }

            string currentMax = maxDoc["maDonDatHang"].AsString;

            string numberPart = currentMax.Substring(2);
            int nextNumber = int.Parse(numberPart) + 1;
            return $"DDH{nextNumber:D3}";
        }
    }
}
