using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS_QuanLy
{
    public class BUS_QuanLyNhaCungCap
    {
        DataBase da = new DataBase();
        public DataTable ShowNhaCungCap()
        {
            string sql = "SELECT * FROM NhaCungCap";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public void InsertNhaCungCap(string MaNCC, string TenNCC, string GioiTinh, string DiaChi, string SDT, string Email)
        {
            string sql = "INSERT INTO NhaCungCap VALUES (@MaNCC, @TenNCC, @GioiTinh, @DiaChiNCC, @SDTNCC, @Email)";

            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaNCC", MaNCC);
                    command.Parameters.AddWithValue("@TenNCC", TenNCC);
                    command.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                    command.Parameters.AddWithValue("@DiaChiNCC", DiaChi);
                    command.Parameters.AddWithValue("@SDTNCC", SDT);
                    command.Parameters.AddWithValue("@Email", Email);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm nhà cung cấp: " + ex.Message);
                    }
                }
            }
        }
        public void Updatenhacc(string MaNCC, string TenNCC, string GioiTinh, string DiaChi, string SDT, string Email)
        {
            string sql = "update NhaCungCap set TenNCC=N'" + TenNCC + "',GioiTinh=N'" + GioiTinh + "',DiaChiNCC=N'" + DiaChi + "',SDTNCC='" + SDT + "',Email='" + Email + "' where MaNCC = '" + MaNCC + "' ";
            da.ExcuteNonQuery(sql);
        }
        public void Deletenhacc(string MaNCC)
        {
            string sql = "delete  NhaCungCap where MaNCC='" + MaNCC + "'";
            da.ExcuteNonQuery(sql);
        }
        public DataTable LookNhaCungCap(string dk)
        {
            try
            {
                string sql = "SELECT * FROM NhaCungCap WHERE " +
                             "MaNCC LIKE @dk " +
                             "OR TenNCC LIKE @dk " +
                             "OR DiaChiNCC LIKE @dk " +
                             "OR Email LIKE @dk " +
                             "OR SDTNCC LIKE @dk ";

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
        public bool KiemTraMaNhaCungCapTonTai(string MaNCC)
        {
            string sql = "SELECT COUNT(*) FROM NhaCungCap WHERE MaNCC = @MaNCC";
            int count = 0;

            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaNCC", MaNCC);

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
