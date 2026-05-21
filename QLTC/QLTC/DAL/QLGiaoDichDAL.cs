using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class QLGiaoDichDAL
{
    public DataTable Load(DateTime tu, DateTime den, int loai, int maVi, int maTK)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@TuNgay", tu),
            new SqlParameter("@DenNgay", den),
            new SqlParameter("@Loai", loai),
            new SqlParameter("@MaVi", maVi),
            new SqlParameter("@MaTK", maTK)
        };

        return DBConnect.ExecuteQuery("sp_LoadGiaoDich", p);
    }

    public DataTable LoadVi(int maTK)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@MaTK", maTK)
        };

        return DBConnect.ExecuteQuery("sp_LoadVi", p);
    }
}
