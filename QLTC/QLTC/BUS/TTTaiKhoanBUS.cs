using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TTTaiKhoanBUS
{
    TTTaiKhoanDAL dal = new TTTaiKhoanDAL();

    public DataTable Load(int maTK)
    {
        return dal.Load(maTK);
    }

    public bool CapNhat(int maTK, string email, string sdt)
    {
        if (!string.IsNullOrEmpty(email) && !email.Contains("@"))
            throw new Exception("Email không hợp lệ!");

        if (!string.IsNullOrEmpty(sdt) && !sdt.All(char.IsDigit))
            throw new Exception("SĐT phải là số!");

        return dal.CapNhat(maTK, email, sdt) > 0;
    }
}