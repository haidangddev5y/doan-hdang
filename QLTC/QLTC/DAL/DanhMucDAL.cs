using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class DanhMucDAL
{
    public DataTable LoadDanhMuc(int loai, int maTK)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@Loai", loai),
            new SqlParameter("@MaTK", maTK)
        };

        return DBConnect.ExecuteQuery("sp_LoadDanhMuc", para);
    }

    public DataTable Load(int maTK)
    {
        SqlParameter[] p =
        {
        new SqlParameter("@MaTK", maTK)
    };

        return DBConnect.ExecuteQuery("sp_LoadNganSach", p);
    }

    public bool ThemDanhMuc(string tenDM, int loaiDM, string ghiChu, int maTK)
    {
        SqlParameter[] para =
        {
        new SqlParameter("@TenDM", tenDM),
        new SqlParameter("@LoaiDM", loaiDM),
        new SqlParameter("@GhiChu", ghiChu),
        new SqlParameter("@MaTK", maTK)
    };

        DBConnect.ExecuteNonQuery("sp_ThemDanhMuc", para);
        return true; // ✔ vì SP đã tự check lỗi rồi
    }

    public (int result, string message) SuaDanhMuc(int maDM, string tenDM, int loaiDM, string ghiChu)
    {
        SqlParameter[] para =
        {
        new SqlParameter("@MaDM", maDM),
        new SqlParameter("@TenDM", tenDM),
        new SqlParameter("@LoaiDM", loaiDM),
        new SqlParameter("@GhiChu", ghiChu)
    };

        DataTable dt = DBConnect.ExecuteQuery("sp_SuaDanhMuc", para);

        int result = Convert.ToInt32(dt.Rows[0]["Result"]);
        string message = dt.Rows[0]["Message"].ToString();

        return (result, message);
    }

    public int XoaDanhMuc(int maDM)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@MaDM", maDM)
        };

        return DBConnect.ExecuteNonQuery("sp_XoaDanhMuc", para);
    }

    public int CheckTrung(string tenDM, int maTK, int? maDM = null)
    {
        SqlParameter[] p =
        {
        new SqlParameter("@TenDM", tenDM),
        new SqlParameter("@MaTK", maTK),
        new SqlParameter("@MaDM", (object)maDM ?? DBNull.Value)
    };

        DataTable dt = DBConnect.ExecuteQuery("sp_CheckTrungDanhMuc", p);

        return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
    }
}
