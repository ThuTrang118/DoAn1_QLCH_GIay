using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.RegularExpressions;

namespace BUS_QuanLy
{
    public class BUS_QuanLyLuong
    {
        DataBase da = new DataBase();
        public DataTable ShowLuong()
        {
            string sql = "select * from Luong";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public void InsertLuong(string MaLuong, string MaNV, float LuongCB, float DoanhSo, float Thuong, float ThucLinh)
        {
            string sql = "Insert into Luong values (@MaLuong, @MaNV, @LuongCB, @DoanhSo, @Thuong, @ThucLinh)";
            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaLuong", MaLuong);
                    command.Parameters.AddWithValue("@MaNV", MaNV);
                    command.Parameters.AddWithValue("@LuongCB", LuongCB);
                    command.Parameters.AddWithValue("@DoanhSo", DoanhSo);
                    command.Parameters.AddWithValue("@Thuong", Thuong);
                    command.Parameters.AddWithValue("@ThucLinh", ThucLinh);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thể thêm mã lương này!");
                    }
                }
            }
        }
        public void UpdateLuong(string MaLuong, string MaNV, float LuongCB, float DoanhSo, float Thuong, float ThucLinh)
        {
            string sql = "update Luong set MaNV ='" + MaNV + "',LuongCB='" + LuongCB + "', DoanhSo='" + DoanhSo + "',Thuong='" + Thuong + "',ThucLinh='" + ThucLinh + "' where MaLuong= '" + MaLuong + "' ";
            da.ExcuteNonQuery(sql);
        }
        public void DeleteLuong(string MaLuong)
        {
            string sql = "delete Luong where MaLuong='" + MaLuong + "'";
            da.ExcuteNonQuery(sql);
        }
        public DataTable LayDanhSachMaNV()
        {
            DataTable dt = new DataTable();
            string query = "SELECT MaNV FROM NhanVien";

            try
            {
                dt = DataBase.Instance.GetTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách mã nhân viên: " + ex.Message);
            }

            return dt;
        }
        public bool KiemTraMaLuongTonTai(string MaLuong)
        {
            string sql = "SELECT COUNT(*) FROM Luong WHERE MaLuong = @MaLuong";
            int count = 0;

            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaLuong", MaLuong);

                    try
                    {
                        connection.Open();
                        count = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi kiểm tra mã lương tồn tại: " + ex.Message);
                    }
                }
            }

            return count > 0;
        }
        public int GetDoanhSoByMaNV(string MaNV)
        {
            // Tính số hóa đơn bán
            string sqlBan = "SELECT COUNT(*) FROM HoaDonBan WHERE MaNV = @MaNV";
            int doanhSoBan = 0;

            // Tính số hóa đơn nhập
            string sqlNhap = "SELECT COUNT(*) FROM HoaDonNhap WHERE MaNV = @MaNV";
            int doanhSoNhap = 0;

            using (SqlConnection connection = da.getConnect())
            {
                using (SqlCommand commandBan = new SqlCommand(sqlBan, connection))
                {
                    commandBan.Parameters.AddWithValue("@MaNV", MaNV);
                    try
                    {
                        connection.Open();
                        doanhSoBan = (int)commandBan.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tính doanh số hóa đơn bán: " + ex.Message);
                    }
                }

                using (SqlCommand commandNhap = new SqlCommand(sqlNhap, connection))
                {
                    commandNhap.Parameters.AddWithValue("@MaNV", MaNV);
                    try
                    {
                        // Đang mở kết nối từ trước, không cần mở lại
                        doanhSoNhap = (int)commandNhap.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tính doanh số hóa đơn nhập: " + ex.Message);
                    }
                }
            }

            // Tổng số hóa đơn
            int totalDoanhSo = doanhSoBan + doanhSoNhap;

            return totalDoanhSo;
        }

    }
}
