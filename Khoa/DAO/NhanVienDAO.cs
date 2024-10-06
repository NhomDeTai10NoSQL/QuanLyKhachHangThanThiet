using Khoa.DBC;
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
    }
}
