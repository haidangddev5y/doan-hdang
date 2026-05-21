using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class QLGiaoDichBUS
{
    QLGiaoDichDAL dal = new QLGiaoDichDAL();

    public DataTable Load(DateTime tu, DateTime den, int loai, int maVi, int maTK)
    {
        return dal.Load(tu, den, loai, maVi, maTK);
    }

    public DataTable LoadVi(int maTK)
    {
        return dal.LoadVi(maTK);
    }
}
