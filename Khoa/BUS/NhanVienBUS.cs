using Khoa.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khoa.BUS
{
    internal class NhanVienBUS
    {
        NhanVienDAO nhanVienDAO;
        public NhanVienBUS() {
            nhanVienDAO = new NhanVienDAO();
        }

        public DataTable getALlNhanVien ()
        {
            return nhanVienDAO.getALLNhanVien();
        }
    }
}
