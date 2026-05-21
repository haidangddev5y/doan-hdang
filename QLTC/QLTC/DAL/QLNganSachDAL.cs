using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class QLNganSachDAL
{
    public DataTable Load(int maTK, int thang, int nam)
    {
        SqlParameter[] p =
        {
            new SqlParameter("@MaTK", maTK),
            new SqlParameter("@Thang", thang),
            new SqlParameter("@Nam", nam)
        };

        return DBConnect.ExecuteQuery("sp_ThongKeNganSach", p);
    }
}
