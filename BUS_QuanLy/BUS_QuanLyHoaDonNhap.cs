using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_QuanLyHoaDonNhap
    {
        DataBase da = new DataBase();
        public DataTable ShowHoaDonNhap()
        {
            string sql = "SELECT * FROM HoaDonNhap";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public void InsertHoaDonNhap(string MaHDN, string MaNV, string TenNV, string MaNCC, string TenNCC, string GioiTinh, string DiaChi, string SDT, string Email, DateTime NgayMua, float ThanhTien)
        {
            string formattedNgayMua = NgayMua.ToString("dd/MM/yyyy");
            string sqlCheckExistence = "SELECT COUNT(*) FROM HoaDonNhap WHERE MaHDN = @MaHDN";
            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand commandCheckExistence = new SqlCommand(sqlCheckExistence, connection))
                {
                    commandCheckExistence.Parameters.AddWithValue("@MaHDN", MaHDN);

                    connection.Open();
                    int count = (int)commandCheckExistence.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Hóa đơn có mã: " + MaHDN + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string sqlInsert = "INSERT INTO HoaDonNhap (MaHDN, MaNV, TenNV, MaNCC, TenNCC, GioiTinh, DiaChi, SDT, Email, NgayMua, ThanhTien) VALUES (@MaHDN, @MaNV, @TenNV, @MaNCC, @TenNCC, @GioiTinh, @DiaChi, @SDT, @Email, @NgayMua, @ThanhTien)";
                        using (SqlCommand commandInsert = new SqlCommand(sqlInsert, connection))
                        {
                            commandInsert.Parameters.AddWithValue("@MaHDN", MaHDN);
                            commandInsert.Parameters.AddWithValue("@MaNV", MaNV);
                            commandInsert.Parameters.AddWithValue("@TenNV", TenNV);
                            commandInsert.Parameters.AddWithValue("@MaNCC", MaNCC);
                            commandInsert.Parameters.AddWithValue("@TenNCC", TenNCC);
                            commandInsert.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                            commandInsert.Parameters.AddWithValue("@DiaChi", DiaChi);
                            commandInsert.Parameters.AddWithValue("@SDT", SDT);
                            commandInsert.Parameters.AddWithValue("@Email", Email);
                            commandInsert.Parameters.AddWithValue("@NgayMua", NgayMua);
                            commandInsert.Parameters.AddWithValue("@ThanhTien", ThanhTien);

                            commandInsert.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public int GetChiTietHoaDonNhapCount()
        {
            string query = "SELECT COUNT(*) FROM ChiTietHoaDonNhap";
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
                MessageBox.Show("Lỗi khi lấy số lượng Chi Tiết Hóa Đơn Nhập: " + ex.Message);
            }

            return count;
        }

        public void InsertChiTietHoaDonNhap(string MaCTHDN, string MaHDN, string MaSP, string TenSP, int SoLuong, float GiaNhap, float ThanhTien)
        {
            string sqlInsert = "INSERT INTO ChiTietHoaDonNhap (MaCTHDN, MaHDN, MaSP, TenSP, SoLuong, GiaNhap, ThanhTien) VALUES (@MaCTHDN, @MaHDN, @MaSP, @TenSP, @SoLuong, @GiaNhap, @ThanhTien)";
            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand commandInsert = new SqlCommand(sqlInsert, connection))
                {
                    commandInsert.Parameters.AddWithValue("@MaCTHDN", MaCTHDN);
                    commandInsert.Parameters.AddWithValue("@MaHDN", MaHDN);
                    commandInsert.Parameters.AddWithValue("@MaSP", MaSP);
                    commandInsert.Parameters.AddWithValue("@TenSP", TenSP);
                    commandInsert.Parameters.AddWithValue("@SoLuong", SoLuong);
                    commandInsert.Parameters.AddWithValue("@GiaNhap", GiaNhap);
                    commandInsert.Parameters.AddWithValue("@ThanhTien", ThanhTien);

                    connection.Open();
                    commandInsert.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSanPham(string maSP, int soLuong)
        {
            string sql = "UPDATE SanPham SET SL = SL + @SoLuong WHERE MaSP = @MaSP";
            try
            {
                using (SqlConnection connection = DataBase.Instance.getConnect())
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@SoLuong", soLuong);
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
        public DataTable LookHoaDonNhap(string dk)
        {
            try
            {
                string sql = "SELECT * FROM HoaDonNhap WHERE " +
                             "MaHDN LIKE @dk " +
                             "OR MaNV LIKE @dk " +
                             "OR TenNV LIKE @dk " +
                             "OR MaNCC LIKE @dk " +
                             "OR SDT LIKE @dk " +
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
        public bool KiemTraMaHoaDonNhapTonTai(string MaHDN)
        {
            string query = "SELECT COUNT(*) FROM HoaDonNhap WHERE MaHDN = @MaHDN";
            int count = 0;

            try
            {
                using (SqlConnection connection = DataBase.Instance.getConnect())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaHDN", MaHDN);

                        connection.Open();
                        count = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra mã hóa đơn nhập tồn tại: " + ex.Message);
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
        public DataTable LayDanhSachSanPhamTheoNhaCungCap(string maNCC)
        {
            string query = "SELECT MaSP, TenSP FROM SanPham WHERE MaNCC = @MaNCC";
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = da.getConnect())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaNCC", maNCC);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách sản phẩm theo nhà cung cấp: " + ex.Message);
            }

            return dt;
        }

        public DataTable LayDanhSachMaNCC()
        {
            string query = "SELECT MaNCC FROM NhaCungCap";
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
        public DataTable TimKiemNhaCungCap(string input)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM NhaCungCap WHERE MaNCC LIKE @input OR TenNCC LIKE @input OR GioiTinh LIKE @input OR DiaChiNCC LIKE @input OR SDTNCC LIKE @input OR Email LIKE @input";

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
        public void DeleteHoaDonNhap(string MaHDN)
        {
            string sql = "DELETE FROM HoaDonNhap WHERE MaHDN = @MaHDN";
            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaHDN", MaHDN);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteChiTietHoaDonNhap(string MaCTHDN)
        {
            string sql = "DELETE FROM ChiTietHoaDonNhap WHERE MaHDN = @MaHDN";
            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaHDN", MaCTHDN);

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
                string query = "SELECT * FROM SanPham WHERE MaSP LIKE @input OR TenSP LIKE @input OR GiaNhap LIKE @input";

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
        public DataTable GetChiTietHoaDonNhap(string MaHDN)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT * FROM ChiTietHoaDonNhap WHERE MaHDN = @MaHDN";
                using (SqlConnection connection = da.getConnect())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaHDN", MaHDN);
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
        public void CapNhatMaNhaCungCapSanPham(string maSP, string maNCC)
        {
            string sql = "UPDATE SanPham SET MaNCC = @MaNCC WHERE MaSP = @MaSP";
            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaSP", maSP);
                    command.Parameters.AddWithValue("@MaNCC", maNCC);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật mã nhà cung cấp cho sản phẩm: " + ex.Message);
                    }
                }
            }
        }

    }
}
