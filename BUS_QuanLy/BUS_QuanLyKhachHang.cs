using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;

namespace BUS_QuanLy
{
    public class BUS_QuanLyKhachHang
    {
        DataBase da = new DataBase();
        public DataTable ShowKhachHang()
        {
            string sql = "select * from KhachHang";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public void InsertKhachHang(string MaKH, string TenKH, string GioiTinh, string DiaChi, string SDT, string Email)
        {
            string sql = "INSERT INTO KhachHang VALUES (@MaKH, @TenKH, @GioiTinh, @DiaChi, @SDT, @Email)";
            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", MaKH);
                    command.Parameters.AddWithValue("@TenKH", TenKH);
                    command.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                    command.Parameters.AddWithValue("@DiaChi", DiaChi);
                    command.Parameters.AddWithValue("@SDT", SDT);
                    command.Parameters.AddWithValue("@Email", Email);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
                    }
                }
            }
        }
        public void UpdateKhachHang(string MaKH, string TenKH, string GioiTinh, string DiaChi, string SDT, string Email)
        {
            string sql = "UPDATE KhachHang set TenKH=N'" + TenKH + "',GioiTinh='" + GioiTinh + "',DiaChi='" + DiaChi + "',SDT='" + SDT + "', Email=N'" + Email + "' where MaKH= '" + MaKH + "' ";
            da.ExcuteNonQuery(sql);
        }
        public void DeleteKhachHang(string MaKH)
        {
            string sql = "DELETE KhachHang WHERE MaKH='" + MaKH + "'";
            da.ExcuteNonQuery(sql);
        }
        public DataTable LookKhachHang(string dk)
        {
            try
            {
                string sql = "SELECT * FROM KhachHang WHERE " +
                             "MaKH LIKE @dk " +
                             "OR TenKH LIKE @dk " +
                             "OR SDT LIKE @dk " +
                             "OR Email LIKE @dk " +
                             "OR DiaChi LIKE @dk ";

                DataTable dt = new DataTable();
                using (SqlConnection connection = da.getConnect())
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@dk", "%" + dk + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }

                return dt;
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi SQL
                Console.WriteLine("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Xử lý các loại lỗi khác
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return null;
        }
        public bool KiemTraMaKhachHangTonTai(string MaKH)
        {
            string sql = "SELECT COUNT(*) FROM KhachHang WHERE MaKH = @MaKH";
            int count = 0;

            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", MaKH);

                    try
                    {
                        connection.Open();
                        count = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi kiểm tra mã khách hàng tồn tại: " + ex.Message);
                    }
                }
            }

            return count > 0;
        }
    }
}
