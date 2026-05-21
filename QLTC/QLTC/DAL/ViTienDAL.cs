using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ViTienDAL
{
    public DataTable Load(int maTK)
    {
        SqlParameter[] p = {
            new SqlParameter("@MaTK", maTK)
        };
        return DBConnect.ExecuteQuery("sp_LoadVi", p);
    }

    public void Them(string ten, decimal sodu, string gc, int maTK)
    {
        SqlParameter[] p = {
            new SqlParameter("@TenVi", ten),
            new SqlParameter("@SoDu", sodu),
            new SqlParameter("@GhiChu", gc),
            new SqlParameter("@MaTK", maTK)
        };
        DBConnect.ExecuteNonQuery("sp_ThemViTien", p);
    }

    public void Sua(int ma, string ten, decimal sodu, string gc)
    {
        SqlParameter[] p = {
            new SqlParameter("@MaVi", ma),
            new SqlParameter("@TenVi", ten),
            new SqlParameter("@SoDu", sodu),
            new SqlParameter("@GhiChu", gc)
        };
        DBConnect.ExecuteNonQuery("sp_SuaViTien", p);
    }

    public void Xoa(int ma)
    {
        SqlParameter[] p = {
            new SqlParameter("@MaVi", ma)
        };
        DBConnect.ExecuteNonQuery("sp_XoaViTien", p);
    }
}