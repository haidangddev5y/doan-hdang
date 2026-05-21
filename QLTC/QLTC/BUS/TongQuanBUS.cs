using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TongQuanBUS
{
    TongQuanDAL dal = new TongQuanDAL();

    public DataTable Get6Thang(int maTK) => dal.Get6Thang(maTK);
    public DataTable GetTyLe(int maTK) => dal.GetTyLe(maTK);
    public DataTable GetTongQuan(int maTK) => dal.GetTongQuan(maTK);
    public DataTable GetGiaoDichGanDay(int maTK)
    {
        return dal.GetGiaoDichGanDay(maTK);
    }
}