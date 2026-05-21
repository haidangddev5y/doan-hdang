using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class QLNganSachBUS
{
    QLNganSachDAL dal = new QLNganSachDAL();

    public DataTable Load(int maTK, int thang, int nam)
    {
        return dal.Load(maTK, thang, nam);
    }
}