using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
using System.Data;

namespace BUS_QuanLy
{
    public class BUS_TrangChu
    {
        public bool IsAdmin(string username)
        {
            string sql = $"SELECT COUNT(*) FROM TaiKhoan WHERE TK = '{username}' AND Quyen = 'QuanTriVien'";
            using (SqlConnection connection = new DataBase().getConnect())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
