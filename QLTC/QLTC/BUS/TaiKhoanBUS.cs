using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TaiKhoanBUS
{
    TaiKhoanDAL dal = new TaiKhoanDAL();

    public DataTable DangNhap(string tenDN, string matKhau)
    {
        return dal.DangNhap(tenDN, matKhau);
    }

    public int DangKy(string tenDN, string matKhau)
    {
        return dal.DangKy(tenDN, matKhau);
    }
}
