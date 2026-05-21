using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TTTaiKhoanDAL
{
    public DataTable Load(int maTK)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@MaTK", maTK)
        };

        return DBConnect.ExecuteQuery("sp_LoadThongTinTK", p);
    }

    public int CapNhat(int maTK, string email, string sdt)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@MaTK", maTK),
            new SqlParameter("@Email", (object)email ?? DBNull.Value),
            new SqlParameter("@SDT", (object)sdt ?? DBNull.Value)
        };

        return DBConnect.ExecuteNonQuery("sp_CapNhatThongTinTK", p);
    }
}