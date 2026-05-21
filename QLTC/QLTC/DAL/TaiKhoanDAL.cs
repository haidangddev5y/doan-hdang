using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TaiKhoanDAL
{
    public DataTable DangNhap(string tenDN, string matKhau)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@TenDangNhap", tenDN),
            new SqlParameter("@MatKhau", matKhau)
        };

        return DBConnect.ExecuteQuery("sp_DangNhap", param);
    }

    public int DangKy(string tenDN, string matKhau)
    {
        SqlParameter[] param = new SqlParameter[]
        {
        new SqlParameter("@TenDangNhap", tenDN),
        new SqlParameter("@MatKhau", matKhau)
        };

        DataTable dt = DBConnect.ExecuteQuery("sp_DangKy", param);

        if (dt.Rows.Count > 0)
            return Convert.ToInt32(dt.Rows[0]["Result"]);

        return 0;
    }
}