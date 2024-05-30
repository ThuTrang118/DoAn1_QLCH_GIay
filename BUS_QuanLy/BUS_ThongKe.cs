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
    public class BUS_ThongKe
    {
        DataBase da = new DataBase();

        public DataTable ThongKeSanPhamBanChay(DateTime tuNgay, DateTime denNgay)
        {
            string sql = @"SELECT SP.MaSP, SP.TenSP, SUM(CTHDB.SoLuong) AS SoLuongBan
                           FROM ChiTietHoaDonBan CTHDB
                           JOIN HoaDonBan HDB ON CTHDB.MaHDB = HDB.MaHDB
                           JOIN SanPham SP ON CTHDB.MaSP = SP.MaSP
                           WHERE HDB.NgayMua BETWEEN @TuNgay AND @DenNgay
                           GROUP BY SP.MaSP, SP.TenSP
                           ORDER BY SoLuongBan DESC";

            DataTable dt = new DataTable();
            using (SqlConnection connection = da.getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TuNgay", tuNgay);
                    command.Parameters.AddWithValue("@DenNgay", denNgay);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable ThongKeNhanVienBanHang(DateTime tuNgay, DateTime denNgay)
        {
            string sql = @"SELECT NV.MaNV, NV.TenNV, 
                                  COUNT(HDN.MaHDN) AS SoDonNhap,
                                  COUNT(HDB.MaHDB) AS SoDonBan
                           FROM NhanVien NV
                           LEFT JOIN HoaDonNhap HDN ON NV.MaNV = HDN.MaNV AND HDN.NgayMua BETWEEN @TuNgay AND @DenNgay
                           LEFT JOIN HoaDonBan HDB ON NV.MaNV = HDB.MaNV AND HDB.NgayMua BETWEEN @TuNgay AND @DenNgay
                           GROUP BY NV.MaNV, NV.TenNV
                           ORDER BY (COUNT(HDN.MaHDN) + COUNT(HDB.MaHDB)) DESC";

            DataTable dt = new DataTable();
            using (SqlConnection connection = da.getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TuNgay", tuNgay);
                    command.Parameters.AddWithValue("@DenNgay", denNgay);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable ThongKeSanPhamTonKho(DateTime tuNgay, DateTime denNgay)
        {
            string sql = @"SELECT SP.MaSP, SP.TenSP, 
                          (ISNULL(Nhap.SoLuongNhap, 0) - ISNULL(Ban.SoLuongBan, 0)) AS SoLuongTon,
                          ((ISNULL(Nhap.SoLuongNhap, 0) - ISNULL(Ban.SoLuongBan, 0)) * SP.GiaNhap) AS TongTienTon
                   FROM SanPham SP
                   LEFT JOIN (
                       SELECT CT.MaSP, SUM(CT.SoLuong) AS SoLuongNhap
                       FROM ChiTietHoaDonNhap CT
                       INNER JOIN HoaDonNhap H ON CT.MaHDN = H.MaHDN
                       WHERE H.NgayMua BETWEEN @TuNgay AND @DenNgay
                       GROUP BY CT.MaSP
                   ) Nhap ON SP.MaSP = Nhap.MaSP
                   LEFT JOIN (
                       SELECT CT.MaSP, SUM(CT.SoLuong) AS SoLuongBan
                       FROM ChiTietHoaDonBan CT
                       INNER JOIN HoaDonBan H ON CT.MaHDB = H.MaHDB
                       WHERE H.NgayMua BETWEEN @TuNgay AND @DenNgay
                       GROUP BY CT.MaSP
                   ) Ban ON SP.MaSP = Ban.MaSP
                   WHERE (ISNULL(Nhap.SoLuongNhap, 0) - ISNULL(Ban.SoLuongBan, 0)) > 0";

            DataTable dt = new DataTable();
            using (SqlConnection connection = da.getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TuNgay", tuNgay);
                    command.Parameters.AddWithValue("@DenNgay", denNgay);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable ThongKeHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            string sql = @"SELECT 
                       N'Bán' AS LoaiHD, 
                       COUNT(DISTINCT HDB.MaHDB) AS SoHoaDon, 
                       SUM(CTHDB.SoLuong) AS SoLuongSanPham,
                       SUM(CTHDB.SoLuong * CTHDB.GiaBan) AS TongTien
                   FROM HoaDonBan HDB
                   JOIN ChiTietHoaDonBan CTHDB ON HDB.MaHDB = CTHDB.MaHDB
                   WHERE HDB.NgayMua BETWEEN @TuNgay AND @DenNgay
                   UNION ALL
                   SELECT 
                       N'Nhập' AS LoaiHD, 
                       COUNT(DISTINCT HDN.MaHDN) AS SoHoaDon, 
                       SUM(CTHDN.SoLuong) AS SoLuongSanPham,
                       SUM(CTHDN.SoLuong * CTHDN.GiaNhap) AS TongTien
                   FROM HoaDonNhap HDN
                   JOIN ChiTietHoaDonNhap CTHDN ON HDN.MaHDN = CTHDN.MaHDN
                   WHERE HDN.NgayMua BETWEEN @TuNgay AND @DenNgay";

            DataTable dt = new DataTable();
            using (SqlConnection connection = da.getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TuNgay", tuNgay);
                    command.Parameters.AddWithValue("@DenNgay", denNgay);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable ThongKeTongChiPhiVaLoiNhuan(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = new DataTable();
            // Thực hiện truy vấn SQL để lấy thông tin hóa đơn bán và chi tiết hóa đơn bán
            string sql = @"
            SELECT HDB.MaHDB, SUM(CTHDB.SoLuong * SP.GiaNhap) AS TongChiPhi, SUM(CTHDB.SoLuong * CTHDB.GiaBan) AS TongTienBan
            FROM HoaDonBan HDB
            JOIN ChiTietHoaDonBan CTHDB ON HDB.MaHDB = CTHDB.MaHDB
            JOIN SanPham SP ON CTHDB.MaSP = SP.MaSP
            WHERE HDB.NgayMua BETWEEN @TuNgay AND @DenNgay
            GROUP BY HDB.MaHDB";

            using (SqlConnection connection = da.getConnect())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TuNgay", tuNgay);
                    command.Parameters.AddWithValue("@DenNgay", denNgay);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}
