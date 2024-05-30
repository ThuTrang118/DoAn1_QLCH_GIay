using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_DangNhap
    {
        DataBase da = new DataBase();
        public DataTable checkTaiKhoan(string taikhoan, string matkhau)
        {
            string sql = "select * from TaiKhoan where TK= '" + taikhoan + "' and  MK='" + matkhau + "'";// ktra thong tin tk trg csdl
            DataTable dt = new DataTable();//tao mot datatable moi de chua kqua tra ve csdl
            dt = da.GetTable(sql);//truy van chuoi sql
            return dt; //va gan tra ve kqua cho dt
        }

    }
}
