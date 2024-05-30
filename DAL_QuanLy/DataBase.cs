using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DataBase
    {
        private static DataBase _instance;
        public static DataBase Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataBase();
                }
                return _instance;
            }
        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(@"Data Source=THUTRANG;Initial Catalog=cuahanggiaythutrang;Integrated Security=True");

        }
        //lệnh trả về 1 bảng
        public DataTable GetTable(string sql)
        {
            SqlConnection cn = getConnect();//Tạo một đối tượng SqlConnection và gán cho biến cn bằng cách gọi phương thức getConnect() để lấy thông tin kết nối.
            SqlDataAdapter ad = new SqlDataAdapter(sql, cn);//Đây là khai báo một đối tượng SqlDataAdapter để thực hiện truy vấn và lấy dữ liệu từ cơ sở dữ liệu. Đối tượng SqlDataAdapter này sẽ được khởi tạo với câu lệnh truy vấn "sql" và đối tượng kết nối SqlConnection "cn".
            DataTable dt = new DataTable();//Đây là khai báo một đối tượng DataTable rỗng và sử dụng phương thức Fill của đối tượng SqlDataAdapter để đổ dữ liệu từ cơ sở dữ liệu vào đối tượng DataTable "dt".
            ad.Fill(dt);
            return dt;
        }

        //lệnh ko trả về
        public void ExcuteNonQuery(string sql)
        {
            SqlConnection cn = getConnect();//gọi phương thức getConnect() để tạo và trả về một đối tượng SqlConnection. Phương thức này chứa thông tin kết nối cần thiết để kết nối tới cơ sở dữ liệu.
            cn.Open();
            SqlCommand cmd = new SqlCommand(sql, cn);//. Câu lệnh SQL được truyền vào đối tượng SqlCommand thông qua tham số đầu tiên, và đối tượng SqlConnection được truyền vào thông qua tham số thứ hai.
            cmd.ExecuteNonQuery();
            cmd.Dispose();//Sau khi câu lệnh SQL đã được thực thi, đối tượng SqlCommand không còn được sử dụng nữa và nó được giải phóng bằng phương thức Dispose().
            cn.Close();
        }
        public DataTable ExcuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = getConnect();
            cn.Open();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        public void ThucThiPKN(string sql)
        {
            SqlConnection cn = DataBase.Instance.getConnect();
            cn.Open();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
        }
        public DataTable GetTable(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = getConnect())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public void ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection cn = getConnect())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection connection = getConnect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    return dataTable;
                }
            }
        }
    }
}
