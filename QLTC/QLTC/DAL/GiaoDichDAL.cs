using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GiaoDichDAL
{
    public DataTable LoadVi(int maTK)
    {
        SqlParameter[] p = { new SqlParameter("@MaTK", maTK) };
        return DBConnect.ExecuteQuery("sp_LoadVi", p);
    }

    public DataTable LoadDanhMuc(int loai, int maTK)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@Loai", loai),
            new SqlParameter("@MaTK", maTK)
        };
        return DBConnect.ExecuteQuery("sp_LoadDanhMuc", p);
    }

    public decimal GetSoDuVi(int maVi)
    {
        SqlParameter[] p = { new SqlParameter("@MaVi", maVi) };
        DataTable dt = DBConnect.ExecuteQuery("sp_GetSoDuVi", p);

        return dt.Rows.Count > 0 ? Convert.ToDecimal(dt.Rows[0][0]) : 0;
    }

    public bool Them(decimal tien, DateTime ngay, string nd, int loai, int maDM, int maVi)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@SoTien", tien),
            new SqlParameter("@Ngay", ngay),
            new SqlParameter("@NoiDung", nd),
            new SqlParameter("@Loai", loai),
            new SqlParameter("@MaDM", maDM),
            new SqlParameter("@MaVi", maVi)
        };

        DBConnect.ExecuteNonQuery("sp_ThemGiaoDich", p);
        return true;
    }
}