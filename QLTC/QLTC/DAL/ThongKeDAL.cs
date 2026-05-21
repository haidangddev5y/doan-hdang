using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class ThongKeDAL
{
    public DataTable ThongKeTheoNgay(int thang, int nam, int maTK)
    {
        SqlParameter[] p = {
            new SqlParameter("@Thang", thang),
            new SqlParameter("@Nam", nam),
            new SqlParameter("@MaTK", maTK)
        };
        return DBConnect.ExecuteQuery("sp_ThongKeTheoNgay", p);
    }

    public DataTable ThongKeTheoNgay_All(int maTK)
    {
        SqlParameter[] p = {
        new SqlParameter("@MaTK", maTK)
    };
        return DBConnect.ExecuteQuery("sp_ThongKeTheoNgay_All", p);
    }

    public DataTable ThongKeDanhMuc(int thang, int nam, int maTK)
    {
        SqlParameter[] p = {
            new SqlParameter("@Thang", thang),
            new SqlParameter("@Nam", nam),
            new SqlParameter("@MaTK", maTK)
        };
        return DBConnect.ExecuteQuery("sp_ThongKeDanhMuc", p);
    }

    public DataTable ThongKeDanhMuc_All(int maTK)
    {
        SqlParameter[] p = {
        new SqlParameter("@MaTK", maTK)
    };
        return DBConnect.ExecuteQuery("sp_ThongKeDanhMuc_All", p);
    }

    public DataTable TongThuChi(int thang, int nam, int maTK)
    {
        SqlParameter[] p = {
            new SqlParameter("@Thang", thang),
            new SqlParameter("@Nam", nam),
            new SqlParameter("@MaTK", maTK)
        };
        return DBConnect.ExecuteQuery("sp_TongThuChi", p);
    }

    public DataTable TongThuChi_All(int maTK)
    {
        SqlParameter[] p = {
        new SqlParameter("@MaTK", maTK)
    };
        return DBConnect.ExecuteQuery("sp_TongThuChi_All", p);
    }
}
