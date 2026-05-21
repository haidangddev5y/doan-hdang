using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GiaoDichBUS
{
    GiaoDichDAL dal = new GiaoDichDAL();

    public DataTable LoadVi(int maTK) => dal.LoadVi(maTK);

    public DataTable LoadDanhMuc(int loai, int maTK)
        => dal.LoadDanhMuc(loai, maTK);

    public decimal SoDuVi(int maVi)
        => dal.GetSoDuVi(maVi);

    public bool Them(decimal tien, DateTime ngay, string nd, int loai, int maDM, int maVi)
    {
        return dal.Them(tien, ngay, nd, loai, maDM, maVi);
    }
}