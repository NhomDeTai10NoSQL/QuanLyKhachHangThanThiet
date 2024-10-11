using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KimPhuong
{
    public partial class frmInHoaDon : Form
    {
        private ReportDocument reportDocument;
        private string connectionString = "mongodb+srv://kimphuong8694:123@quanlykhachhang.khsds.mongodb.net/test?retryWrites=true&w=majority";
        private string databaseName = "QuanLyKhachHangThanThiet";
        private string maHoaDon;

        public frmInHoaDon(string maHoaDon)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
        }

        private DataTable GetDataFromMongoDB()
        {
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                var collection = database.GetCollection<BsonDocument>("HoaDon");

                // Tạo filter để lấy hóa đơn theo mã
                var filter = Builders<BsonDocument>.Filter.Eq("maHoaDon", maHoaDon);
                var document = collection.Find(filter).FirstOrDefault();

                if (document == null)
                {
                    throw new Exception($"Không tìm thấy hóa đơn với mã {maHoaDon}");
                }

                // Tạo DataTable với cấu trúc phù hợp
                DataTable dt = new DataTable();

                // Thông tin hóa đơn
                dt.Columns.Add("MaHoaDon", typeof(string));
                dt.Columns.Add("NgayLapHoaDon", typeof(DateTime));
                dt.Columns.Add("TongTien", typeof(int));
                dt.Columns.Add("DiemDaDung", typeof(int));
                dt.Columns.Add("DiemTichLuy", typeof(int));
                dt.Columns.Add("PhuongThucThanhToan", typeof(string));
                dt.Columns.Add("TongPhaiTra", typeof(int));

                // Thông tin nhân viên
                dt.Columns.Add("MaNhanVien", typeof(string));
                dt.Columns.Add("TenNhanVien", typeof(string));

                // Thông tin khách hàng
                dt.Columns.Add("MaKhachHang", typeof(string));
                dt.Columns.Add("TenKhachHang", typeof(string));

                // Thông tin sản phẩm
                dt.Columns.Add("MaSanPham", typeof(string));
                dt.Columns.Add("TenSanPham", typeof(string));
                dt.Columns.Add("SoLuong", typeof(int));
                dt.Columns.Add("DonGia", typeof(int));
                dt.Columns.Add("ThanhTien", typeof(int));

                // Thêm dữ liệu vào DataTable
                var chiTietHoaDon = document["chiTietHoaDon"].AsBsonArray;
                foreach (var chiTiet in chiTietHoaDon)
                {
                    DataRow row = dt.NewRow();

                    // Thông tin hóa đơn
                    row["MaHoaDon"] = document["maHoaDon"].AsString;
                    row["NgayLapHoaDon"] = document["ngayLapHoaDon"].ToUniversalTime();
                    row["TongTien"] = document["tongTien"].AsInt32;
                    row["DiemDaDung"] = document["diemDaDung"].AsInt32;
                    row["DiemTichLuy"] = document["diemTichLuy"].IsBsonNull ? 0 : document["diemTichLuy"].AsInt32;
                    row["PhuongThucThanhToan"] = document["phuongThucThanhToan"].AsString;
                    row["TongPhaiTra"] = document["tongPhaiTra"].AsInt32;

                    // Thông tin nhân viên
                    var nhanVien = document["nhanVien"].AsBsonDocument;
                    row["MaNhanVien"] = nhanVien["maNhanVien"].AsString;
                    row["TenNhanVien"] = nhanVien["tenNhanVien"].AsString;

                    // Thông tin khách hàng
                    var khachHang = document["khachHang"].AsBsonDocument;
                    row["MaKhachHang"] = khachHang["maKhachHang"].AsString;
                    row["TenKhachHang"] = khachHang["tenKhachHang"].AsString;

                    // Thông tin sản phẩm
                    row["MaSanPham"] = chiTiet["maSanPham"].AsString;
                    row["TenSanPham"] = chiTiet["tenSanPham"].AsString;
                    row["SoLuong"] = chiTiet["soLuong"].AsInt32;
                    row["DonGia"] = chiTiet["donGia"].AsInt32;
                    row["ThanhTien"] = chiTiet["thanhTien"].AsInt32;

                    dt.Rows.Add(row);
                }

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu từ MongoDB: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void GenerateReport()
        {
            try
            {
                reportDocument = new ReportDocument();
                reportDocument.Load(@"D:\KimPhuong\Desktop\HK7\NOSQL\DOAN2\KimPhuong\inHoaDon.rpt");

                DataTable dt = GetDataFromMongoDB();
                if (dt != null)
                {
                    reportDocument.SetDataSource(dt);
                    crystalReportViewer1.ReportSource = reportDocument;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo report: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (reportDocument != null)
            {
                reportDocument.Close();
                reportDocument.Dispose();
            }
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            GenerateReport();
        }
    }
}
