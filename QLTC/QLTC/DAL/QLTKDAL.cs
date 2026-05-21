using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class QLTKDAL
{
    public DataTable Load()
    {
        return DBConnect.ExecuteQuery("sp_LoadTaiKhoan", null);
    }

    public int CheckTrung(string tenDN)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@TenDN", tenDN)
        };

        DataTable dt = DBConnect.ExecuteQuery("sp_CheckTenDN", p);
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    public void Them(string tenDN, string mk, string vt)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@TenDN", tenDN),
            new SqlParameter("@MatKhau", mk),
            new SqlParameter("@VaiTro", vt)
        };

        DBConnect.ExecuteNonQuery("sp_ThemTaiKhoan", p);
    }

    public void Sua(int maTK, string mk, string vt)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@MaTK", maTK),
            new SqlParameter("@MatKhau", mk),
            new SqlParameter("@VaiTro", vt)
        };

        DBConnect.ExecuteNonQuery("sp_SuaTaiKhoan", p);
    }

    public void Xoa(int maTK)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@MaTK", maTK)
        };

        DBConnect.ExecuteNonQuery("sp_XoaTaiKhoan", p);
    }

    public DataTable Tim(string tenDN)
    {
        SqlParameter[] p =
        {
        new SqlParameter("@TenDN", tenDN)
    };

        return DBConnect.ExecuteQuery("sp_TimTaiKhoan", p);
    }
}