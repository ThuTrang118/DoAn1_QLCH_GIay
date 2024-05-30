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
    public class BUS_QuanLySanPham
    {
        DataBase da = new DataBase();

        public DataTable ShowSanPham()
        {
            string sql = "select * from SanPham";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return dt;
        }
        public void InsertSanPham(string MaSP, string TenSP, int Size, string MauSac, string MaNCC, float GiaNhap, float GiaBan, int SL, int SLDaBan)
        {
            string sql = "insert into SanPham values (@MaSP, @TenSP, @Size, @MauSac, @MaNCC, @GiaNhap, @GiaBan, @SL, @SLDaBan)";
            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaSP", MaSP);
                    command.Parameters.AddWithValue("@TenSP", TenSP);
                    command.Parameters.AddWithValue("@Size", Size);
                    command.Parameters.AddWithValue("@MauSac", MauSac);
                    command.Parameters.AddWithValue("@MaNCC", MaNCC);
                    command.Parameters.AddWithValue("@GiaNhap", GiaNhap);
                    command.Parameters.AddWithValue("@GiaBan", GiaBan);
                    command.Parameters.AddWithValue("@SL", SL);
                    command.Parameters.AddWithValue("@SLDaBan", SLDaBan);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
                    }
                }
            }
        }
        public void UpdateSanPham(string MaSP, string TenSP, int Size, string MauSac, string MaNCC, float GiaNhap, float GiaBan, int SL, int SLDaBan)
        {
            string sql = "update SanPham set TenSP= N'" + TenSP + "', Size = '" + Size + "', MauSac = N'" + MauSac + "',MaNCC = '" + MaNCC + "',GiaNhap = '" + GiaNhap + "',GiaBan = " + GiaBan + ",SL = " + SL + ",SLDaBan= " + SLDaBan + " where MaSP = '" + MaSP + "'";
            da.ExcuteNonQuery(sql);
        }
        public void DeleteSanPham(string MaSP)
        {
            string sql = "delete SanPham where MaSP='" + MaSP + "'";
            da.ExcuteNonQuery(sql);
        }
        public DataTable LookSanPham(string dk)
        {
            string sql = "SELECT * FROM sanpham " +
                         "WHERE MaSP LIKE '%' + @dk + '%' " +
                         "OR TenSP LIKE N'%' + @dk + '%' " +
                         "OR Size LIKE N'%' + @dk + '%' " +
                         "OR MauSac LIKE N'%' + @dk + '%' " +
                         "OR SL LIKE N'%' + @dk + '%' ";

            DataTable dt = new DataTable();
            using (SqlConnection connection = da.getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@dk", dk);
                    int dk_int;
                    if (int.TryParse(dk, out dk_int))
                    {
                        command.Parameters.AddWithValue("@dk_int", dk_int);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@dk_int", -1); // Giá trị không hợp lệ
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
        public DataTable LayDanhSachMaNCC()
        {
            DataTable dt = new DataTable();
            string query = "SELECT MaNCC FROM NhaCungCap";

            try
            {
                dt = DataBase.Instance.GetTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách mã nhà cung cấp: " + ex.Message);
            }

            return dt;
        }
        public bool KiemTraMaSanPhamTonTai(string MaSP)
        {
            string sql = "SELECT COUNT(*) FROM SanPham WHERE MaSP = @MaSP";
            int count = 0;

            using (SqlConnection connection = new DataBase().getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaSP", MaSP);

                    try
                    {
                        connection.Open();
                        count = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi kiểm tra mã sản phẩm tồn tại: " + ex.Message);
                    }
                }
            }

            return count > 0;
        }

    }
}

