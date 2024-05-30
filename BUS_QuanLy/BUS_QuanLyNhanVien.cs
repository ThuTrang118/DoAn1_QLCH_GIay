using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS_QuanLy
{
    public class BUS_QuanLyNhanVien
    {
        DataBase da = new DataBase();
        public DataTable ShowNhanVien()
        {
            string sql = "select * from NhanVien";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public void InsertNhanVien(string MaNV, string TenNV, DateTime NgaySinh, string GioiTinh, string DiaChi, string Email, int SDT, string TaiKhoan, string MatKhau)
        {
            string formattedNgaySinh = NgaySinh.ToString("dd/MM/yyyy");
            using (SqlConnection connection = new DataBase().getConnect())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert into NhanVien table
                        string sqlNhanVien = "Insert into NhanVien values (@MaNV, @TenNV, @NgaySinh, @GioiTinh, @DiaChi, @Email, @SDT, @TK, @MK)";
                        using (SqlCommand commandNhanVien = new SqlCommand(sqlNhanVien, connection, transaction))
                        {
                            commandNhanVien.Parameters.AddWithValue("@MaNV", MaNV);
                            commandNhanVien.Parameters.AddWithValue("@TenNV", TenNV);
                            commandNhanVien.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                            commandNhanVien.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                            commandNhanVien.Parameters.AddWithValue("@DiaChi", DiaChi);
                            commandNhanVien.Parameters.AddWithValue("@Email", Email);
                            commandNhanVien.Parameters.AddWithValue("@SDT", SDT);
                            commandNhanVien.Parameters.AddWithValue("@TK", TaiKhoan);
                            commandNhanVien.Parameters.AddWithValue("@MK", MatKhau);
                            commandNhanVien.ExecuteNonQuery();
                        }

                        // Insert into TaiKhoan table
                        string sqlTaiKhoan = "Insert into TaiKhoan values (@MaNV, 'DefaultRole', @TK, @MK, @Email)";
                        using (SqlCommand commandTaiKhoan = new SqlCommand(sqlTaiKhoan, connection, transaction))
                        {
                            commandTaiKhoan.Parameters.AddWithValue("@MaNV", MaNV);
                            commandTaiKhoan.Parameters.AddWithValue("@TK", TaiKhoan);
                            commandTaiKhoan.Parameters.AddWithValue("@MK", MatKhau);
                            commandTaiKhoan.Parameters.AddWithValue("@Email", Email);
                            commandTaiKhoan.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
                    }
                }
            }
        }
        public void UpdateNhanVien(string MaNV, string TenNV, DateTime NgaySinh, string GioiTinh, string DiaChi, string Email, int SDT, string TaiKhoan, string MatKhau)
        {
            using (SqlConnection connection = new DataBase().getConnect())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Update NhanVien table
                        string sqlNhanVien = "update NhanVien set TenNV=@TenNV, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, DiaChi=@DiaChi, Email=@Email, SDT=@SDT, TK=@TK, MK=@MK where MaNV=@MaNV";
                        using (SqlCommand commandNhanVien = new SqlCommand(sqlNhanVien, connection, transaction))
                        {
                            commandNhanVien.Parameters.AddWithValue("@MaNV", MaNV);
                            commandNhanVien.Parameters.AddWithValue("@TenNV", TenNV);
                            commandNhanVien.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                            commandNhanVien.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                            commandNhanVien.Parameters.AddWithValue("@DiaChi", DiaChi);
                            commandNhanVien.Parameters.AddWithValue("@Email", Email);
                            commandNhanVien.Parameters.AddWithValue("@SDT", SDT);
                            commandNhanVien.Parameters.AddWithValue("@TK", TaiKhoan);
                            commandNhanVien.Parameters.AddWithValue("@MK", MatKhau);
                            commandNhanVien.ExecuteNonQuery();
                        }

                        // Update TaiKhoan table
                        string sqlTaiKhoan = "update TaiKhoan set TK=@TK, MK=@MK, Email=@Email where MaTK=@MaNV";
                        using (SqlCommand commandTaiKhoan = new SqlCommand(sqlTaiKhoan, connection, transaction))
                        {
                            commandTaiKhoan.Parameters.AddWithValue("@MaNV", MaNV);
                            commandTaiKhoan.Parameters.AddWithValue("@TK", TaiKhoan);
                            commandTaiKhoan.Parameters.AddWithValue("@MK", MatKhau);
                            commandTaiKhoan.Parameters.AddWithValue("@Email", Email);
                            commandTaiKhoan.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message);
                    }
                }
            }
        }
        public void DeleteNhanVien(string MaNV)
        {
            using (SqlConnection connection = new DataBase().getConnect())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Delete from NhanVien table
                        string sqlNhanVien = "delete from NhanVien where MaNV=@MaNV";
                        using (SqlCommand commandNhanVien = new SqlCommand(sqlNhanVien, connection, transaction))
                        {
                            commandNhanVien.Parameters.AddWithValue("@MaNV", MaNV);
                            commandNhanVien.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        // Delete from TaiKhoan table
                        string sqlTaiKhoan = "delete from TaiKhoan where MaTK=@MaNV";
                        using (SqlCommand commandTaiKhoan = new SqlCommand(sqlTaiKhoan, connection, transaction))
                        {
                            commandTaiKhoan.Parameters.AddWithValue("@MaNV", MaNV);
                            commandTaiKhoan.ExecuteNonQuery();
                        }

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
                    }
                }
            }
        }
        public DataTable LookNhanVien(string dk)
        {
            try
            {
                string sql = "SELECT * FROM NhanVien WHERE " +
                             "MaNV LIKE @dk " +
                             "OR TenNV LIKE @dk " +
                             "OR DiaChi LIKE @dk " +
                             "OR Email LIKE @dk " +
                             "OR SDT LIKE @dk ";

                DataTable dt = da.GetTable(sql);
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
                MessageBox.Show("Lỗi khi lấy danh sách mã nhân viên : " + ex.Message);
            }

            return dt;
        }
        public bool KiemTraMaNhanVienTonTai(string manv)
        {
            string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
            int count = 0;

            try
            {
                using (SqlConnection connection = new DataBase().getConnect())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaNV", manv);
                        connection.Open();
                        count = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra mã nhân viên trong bảng lương: " + ex.Message);
            }

            return count > 0;
        }
    }
}

