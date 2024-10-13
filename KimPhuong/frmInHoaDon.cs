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

        private DataSet GetDataFromMongoDB()
        {
            try
            {
                DataSet dsQLKHTT = new DataSet();
                dsQLKHTT.ReadXmlSchema(@"D:\KimPhuong\Desktop\HK7\NOSQL\DOAN2\KimPhuong\QLKHTT.xsd");

                DataTable dtHoaDon = dsQLKHTT.Tables["HoaDon"];
                DataTable dtChiTietHoaDon = dsQLKHTT.Tables["ChiTietHoaDon"];

                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                var collection = database.GetCollection<BsonDocument>("HoaDon");

                var filter = Builders<BsonDocument>.Filter.Eq("maHoaDon", maHoaDon);
                var document = collection.Find(filter).FirstOrDefault();

                if (document == null)
                {
                    throw new Exception($"Không tìm thấy hóa đơn với mã {maHoaDon}");
                }
                int tongtien = document["tongTien"].AsInt32;
                int tongPhaiTra = document["tongPhaiTra"].AsInt32;

                DataRow rowHoaDon = dtHoaDon.NewRow();
                rowHoaDon["maHoaDon"] = document["maHoaDon"].AsString;
                rowHoaDon["ngayLapHoaDon"] = document["ngayLapHoaDon"].ToUniversalTime();
                rowHoaDon["tongTien"] = document["tongTien"].AsInt32;
                rowHoaDon["diemDaDung"] = document["diemDaDung"].AsInt32;
                rowHoaDon["phuongThucThanhToan"] = document["phuongThucThanhToan"].AsString;
                rowHoaDon["maNhanVien"] = document["nhanVien"]["maNhanVien"].AsString;
                rowHoaDon["tenNhanVien"] = document["nhanVien"]["tenNhanVien"].AsString;
                rowHoaDon["maKhachHang"] = document["khachHang"]["maKhachHang"].AsString;
                rowHoaDon["tenKhachHang"] = document["khachHang"]["tenKhachHang"].AsString;
                rowHoaDon["tongPhaiTra"] = document["tongPhaiTra"].AsInt32;
                rowHoaDon["tongGiamGia"]= tongtien - tongPhaiTra;
                dtHoaDon.Rows.Add(rowHoaDon);

                var chiTietHoaDon = document["chiTietHoaDon"].AsBsonArray;
                foreach (var chiTiet in chiTietHoaDon)
                {
                    DataRow rowChiTiet = dtChiTietHoaDon.NewRow();
                    rowChiTiet["maHoaDon"] = document["maHoaDon"].AsString;
                    rowChiTiet["maSanPham"] = chiTiet["maSanPham"].AsString;
                    rowChiTiet["tenSanPham"] = chiTiet["tenSanPham"].AsString;
                    rowChiTiet["soLuong"] = chiTiet["soLuong"].AsInt32;
                    rowChiTiet["donGia"] = chiTiet["donGia"].AsInt32;
                    rowChiTiet["thanhTien"] = chiTiet["thanhTien"].AsInt32;
                    dtChiTietHoaDon.Rows.Add(rowChiTiet);
                }

                return dsQLKHTT;
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

                DataSet ds = GetDataFromMongoDB();
                if (ds != null)
                {
                    reportDocument.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = reportDocument;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo report: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            GenerateReport();
        }
    }
}
