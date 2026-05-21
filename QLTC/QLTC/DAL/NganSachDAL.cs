using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NganSachDAL
{
    // ================= LOAD =================
    public DataTable LoadDanhMuc(int loai, int maTK)
    {
        SqlParameter[] p =
        {
        new SqlParameter("@Loai", loai),
        new SqlParameter("@MaTK", maTK)
    };

        return DBConnect.ExecuteQuery("sp_LoadDanhMuc", p);
    }

    public DataTable LoadNganSach(int maTK)
    {
        SqlParameter[] p =
        {
        new SqlParameter("@MaTK", maTK)
    };

        return DBConnect.ExecuteQuery("sp_LoadNganSach", p);
    }

    public DataTable Load(int maTK, int thang, int nam)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@MaTK", maTK),
            new SqlParameter("@Thang", thang),
            new SqlParameter("@Nam", nam)
        };

        return DBConnect.ExecuteQuery("sp_LoadNganSach", p);
    }

    // ================= THÊM =================
    public int Them(int maDM, decimal gh, int thang, int nam, int maTK)
    {
        SqlParameter[] p =
        {
        new SqlParameter("@MaDM", maDM),
        new SqlParameter("@GioiHan", gh),
        new SqlParameter("@Thang", thang),
        new SqlParameter("@Nam", nam),
        new SqlParameter("@MaTK", maTK)
    };

        return DBConnect.ExecuteNonQuery("sp_ThemNganSach", p);
    }

    // ================= SỬA =================
    public int Sua(
        int maNS,
        int maDM,
        decimal gioiHan,
        int thang,
        int nam,
        int maTK)
    {
        SqlParameter[] p =
        {
        new SqlParameter("@MaNS", maNS),
        new SqlParameter("@MaDM", maDM),
        new SqlParameter("@GioiHan", gioiHan),
        new SqlParameter("@Thang", thang),
        new SqlParameter("@Nam", nam),
        new SqlParameter("@MaTK", maTK)
    };

        return DBConnect.ExecuteNonQuery("sp_SuaNganSach", p);
    }

    // ================= XÓA =================
    public int Xoa(int maNS)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@MaNS", maNS)
        };

        return DBConnect.ExecuteNonQuery("sp_XoaNganSach", p);
    }

    // ================= CHECK TRÙNG =================
    public int CheckTrung(int maDM, int thang, int nam, int maTK, int? maNS = null)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@MaDM", maDM),
            new SqlParameter("@Thang", thang),
            new SqlParameter("@Nam", nam),
            new SqlParameter("@MaTK", maTK),
            new SqlParameter("@MaNS", (object)maNS ?? DBNull.Value)
        };

        DataTable dt = DBConnect.ExecuteQuery("sp_CheckTrungNganSach", p);

        if (dt.Rows.Count == 0)
            return 0;

        return Convert.ToInt32(dt.Rows[0][0]);
    }
}