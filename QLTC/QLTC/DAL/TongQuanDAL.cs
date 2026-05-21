using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TongQuanDAL
{
    public DataTable Get6Thang(int maTK)
    {
        return DBConnect.ExecuteQuery("sp_TQ_6ThangGanNhat",
            new SqlParameter[] { new SqlParameter("@MaTK", maTK) });
    }

    public DataTable GetTyLe(int maTK)
    {
        return DBConnect.ExecuteQuery("sp_TQ_TyLeDanhMuc",
            new SqlParameter[] { new SqlParameter("@MaTK", maTK) });
    }

    public DataTable GetTongQuan(int maTK)
    {
        return DBConnect.ExecuteQuery("sp_TQ_TongQuan",
            new SqlParameter[] { new SqlParameter("@MaTK", maTK) });
    }

    public DataTable GetGiaoDichGanDay(int maTK)
    {
        return DBConnect.ExecuteQuery("sp_TQ_GiaoDichGanDay",
            new SqlParameter[] { new SqlParameter("@MaTK", maTK) });
    }
}