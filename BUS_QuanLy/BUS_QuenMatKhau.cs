using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_QuenMatKhau
    {
        DataBase da = new DataBase();
        public DataTable checkEmail(string email, string taikhoan)
        {
            string sql = "select * from TaiKhoan where Email= '" + email + "' and TK='" + taikhoan + "'";// ktra thong tin tk trg csdl
            DataTable dt = new DataTable();//tao mot datatable moi de chua kqua tra ve csdl
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Email", email);
            parameters[1] = new SqlParameter("@TaiKhoan", taikhoan);
            dt = da.GetTable(sql);//truy van chuoi sql
            return dt; //va gan tra ve kqua cho dt
        }
    }
}
