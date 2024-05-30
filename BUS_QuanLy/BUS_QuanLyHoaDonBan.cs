using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BUS_QuanLy
{
    public class BUS_QuanLyHoaDonBan
    {
        DataBase da = new DataBase();
        public DataTable ShowHoaDonBan()
        {
            string sql = "SELECT * FROM HoaDonBan";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public void InsertHoaDonBan(string MaHDB, string MaNV, string TenNV, string MaKH, string TenKH, string GioiTinh, string DiaChi, string SDT, string Email, DateTime NgayMua, float ThanhTien, float KhachTra, float TienThua)
        {

            float tienThua = KhachTra - ThanhTien;
            string formattedNgayMua = NgayMua.ToString("dd/MM/yyyy");
            string sqlCheckExistence = "SELECT COUNT(*) FROM HoaDonBan WHERE MaHDB = @MaHDB";
            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand commandCheckExistence = new SqlCommand(sqlCheckExistence, connection))
                {
                    commandCheckExistence.Parameters.AddWithValue("@MaHDB", MaHDB);

                    connection.Open();
                    int count = (int)commandCheckExistence.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Hóa đơn có mã: " + MaHDB + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Nếu hóa đơn không tồn tại, thêm mới vào cơ sở dữ liệu
                        string sqlInsert = "INSERT INTO HoaDonBan (MaHDB, MaNV, TenNV, MaKH, TenKH, GioiTinh, DiaChi, SDT, Email, NgayMua, ThanhTien, KhachTra, TienThua) VALUES (@MaHDB, @MaNV, @TenNV, @MaKH, @TenKH, @GioiTinh, @DiaChi, @SDT, @Email, @NgayMua, @ThanhTien, @KhachTra, @TienThua)";

                        using (SqlCommand commandInsert = new SqlCommand(sqlInsert, connection))
                        {
                            commandInsert.Parameters.AddWithValue("@MaHDB", MaHDB);
                            commandInsert.Parameters.AddWithValue("@MaNV", MaNV);
                            commandInsert.Parameters.AddWithValue("@TenNV", TenNV);
                            commandInsert.Parameters.AddWithValue("@MaKH", MaKH);
                            commandInsert.Parameters.AddWithValue("@TenKH", TenKH);
                            commandInsert.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                            commandInsert.Parameters.AddWithValue("@DiaChi", DiaChi);
                            commandInsert.Parameters.AddWithValue("@SDT", SDT);
                            commandInsert.Parameters.AddWithValue("@Email", Email);
                            commandInsert.Parameters.AddWithValue("@NgayMua", NgayMua);
                            commandInsert.Parameters.AddWithValue("@ThanhTien", ThanhTien);
                            commandInsert.Parameters.AddWithValue("@KhachTra", KhachTra);
                            commandInsert.Parameters.AddWithValue("@TienThua", tienThua);

                            commandInsert.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public int GetChiTietHoaDonBanCount()
        {
            string query = "SELECT COUNT(*) FROM ChiTietHoaDonBan";
            int count = 0;
            try
            {
                using (SqlConnection connection = DataBase.Instance.getConnect())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        count = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy số lượng Chi Tiết Hóa Đơn Bán: " + ex.Message);
            }

            return count;
        }
        public void InsertChiTietHoaDonBan(string MaCTHDB, string MaHDB, string MaSP, string TenSP, int SoLuong, float GiaBan)
        {
            float ThanhTien = SoLuong * GiaBan; // Tính toán ThanhTien dựa trên Số Lượng và Giá Bán
            string sqlInsert = "INSERT INTO ChiTietHoaDonBan (MaCTHDB, MaHDB, MaSP, TenSP, SoLuong, GiaBan, ThanhTien) VALUES (@MaCTHDB, @MaHDB, @MaSP, @TenSP, @SoLuong, @GiaBan, @ThanhTien)";
            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand commandInsert = new SqlCommand(sqlInsert, connection))
                {
                    commandInsert.Parameters.AddWithValue("@MaCTHDB", MaCTHDB);
                    commandInsert.Parameters.AddWithValue("@MaHDB", MaHDB);
                    commandInsert.Parameters.AddWithValue("@MaSP", MaSP);
                    commandInsert.Parameters.AddWithValue("@TenSP", TenSP);
                    commandInsert.Parameters.AddWithValue("@SoLuong", SoLuong);
                    commandInsert.Parameters.AddWithValue("@GiaBan", GiaBan);
                    commandInsert.Parameters.AddWithValue("@ThanhTien", ThanhTien); // Sử dụng giá trị tính được cho ThanhTien
                    connection.Open();
                    commandInsert.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSanPham(string maSP, int slDaBan, int soLuong)
        {
            string sql = "UPDATE SanPham SET SLDaBan = SLDaBan + @SLDaBan, SL = SL - @SoLuong WHERE MaSP = @MaSP";
            try
            {
                using (SqlConnection connection = DataBase.Instance.getConnect())
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@SoLuong", soLuong);
                        command.Parameters.AddWithValue("@SLDaBan", slDaBan);
                        command.Parameters.AddWithValue("@MaSP", maSP);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message);
            }
        }

        public DataTable LookHoaDonBan(string dk)
        {
            try
            {
                string sql = "SELECT * FROM HoaDonBan WHERE " +
                             "MaHDB LIKE @dk " +
                             "OR MaNV LIKE @dk " +
                             "OR TenNV LIKE @dk " +
                             "OR MaKH LIKE @dk " +
                             "OR SDT LIKE @dk "+
                              "OR CONVERT(VARCHAR(10), NgayMua, 103) LIKE @dk";
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
                Console.WriteLine("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return null;
        }
        public bool KiemTraMaHoaDonBanTonTai(string MaHDN)
        {
            string query = "SELECT COUNT(*) FROM HoaDonBan WHERE MaHDB = @MaHDB";
            int count = 0;

            try
            {
                using (SqlConnection connection = DataBase.Instance.getConnect())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaHDB", MaHDN);

                        connection.Open();
                        count = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra mã hóa đơn bán tồn tại: " + ex.Message);
            }

            return count > 0;
        }
        public DataTable LayDanhSachMaNV()
        {
            string query = "SELECT MaNV FROM NhanVien";
            return DataBase.Instance.GetTable(query);
        }

        public DataTable LayDanhSachTenNV()
        {
            string query = "SELECT TenNV FROM NhanVien";
            return DataBase.Instance.GetTable(query);
        }
        public DataTable LayDanhSachMaKH()
        {
            string query = "SELECT MaKH FROM KhachHang";
            return DataBase.Instance.GetTable(query);
        }
        public DataTable LayDanhSachMaSP()
        {
            string query = "SELECT MaSP FROM SanPham";
            return DataBase.Instance.GetTable(query);
        }
        public DataTable TimKiemNhanVien(string input)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM NhanVien WHERE MaNV LIKE @input OR TenNV LIKE @input";

                using (SqlConnection connection = da.getConnect())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@input", "%" + input + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
            }

            return dt;
        }
        public DataTable TimKiemKhachHang(string input)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM KhachHang WHERE MaKH LIKE @input OR TenKH LIKE @input OR GioiTinh LIKE @input OR DiaChi LIKE @input OR SDT LIKE @input OR Email LIKE @input";

                using (SqlConnection connection = da.getConnect())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@input", "%" + input + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhà cung cấp: " + ex.Message);
            }

            return dt;
        }
        public void DeleteHoaDonBan(string MaHDB)
        {
            string sql = "DELETE FROM HoaDonBan WHERE MaHDB = @MaHDB";
            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaHDB", MaHDB);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteChiTietHoaDonBan(string MaCTHDB)
        {
            string sql = "DELETE FROM ChiTietHoaDonBan WHERE MaHDB = @MaHDB";
            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaHDB", MaCTHDB);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable TimKiemSanPham(string input)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM SanPham WHERE MaSP LIKE @input OR TenSP LIKE @input OR GiaBan LIKE @input";

                using (SqlConnection connection = da.getConnect())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@input", "%" + input + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sản phẩm: " + ex.Message);
            }

            return dt;
        }
        public DataTable GetChiTietHoaDonBan(string MaHDB)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM ChiTietHoaDonBan WHERE MaHDB = @MaHDB";
                using (SqlConnection connection = da.getConnect())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaHDB", MaHDB);
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy chi tiết hóa đơn nhập: " + ex.Message);
            }

            return dt;
        }
        
    }
}
