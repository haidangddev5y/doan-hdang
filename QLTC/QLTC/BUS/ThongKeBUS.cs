using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ThongKeBUS
{
    ThongKeDAL dal = new ThongKeDAL();

    public DataTable ThongKeTheoNgay(int thang, int nam, int maTK)
    {
        return dal.ThongKeTheoNgay(thang, nam, maTK);
    }

    public DataTable ThongKeTheoNgay_All(int maTK)
    {
        return dal.ThongKeTheoNgay_All(maTK);
    }

    public DataTable ThongKeDanhMuc(int thang,int nam, int maTK)
    {
        return dal.ThongKeDanhMuc(thang, nam,maTK);
    }

    public DataTable ThongKeDanhMuc_All(int maTK)
    {
        return dal.ThongKeDanhMuc_All(maTK);
    }

    public DataTable TongThuChi(int thang, int nam, int maTK)
    {
        return dal.TongThuChi(thang, nam, maTK);
    }

    public DataTable TongThuChi_All(int maTK)
    {
        return dal.TongThuChi_All(maTK);
    }
}
