using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class QLTKBUS 
{
    QLTKDAL dal = new QLTKDAL();

    public DataTable Load()
    {
        return dal.Load();
    }

    public bool CheckTrung(string tenDN)
    {
        return dal.CheckTrung(tenDN) > 0;
    }

    public void Them(string tenDN, string mk, string vt)
    {
        if (string.IsNullOrWhiteSpace(tenDN))
            throw new Exception("Tên đăng nhập không được rỗng");

        if (string.IsNullOrWhiteSpace(mk))
            throw new Exception("Mật khẩu không được rỗng");

        dal.Them(tenDN.Trim(), mk.Trim(), vt);
    }

    public void Sua(int maTK, string mk, string vt)
    {
        if (maTK <= 0)
            throw new Exception("Chưa chọn tài khoản");

        dal.Sua(maTK, mk, vt);
    }

    public void Xoa(int maTK)
    {
        dal.Xoa(maTK);
    }

    public DataTable Tim(string tenDN)
    {
        return dal.Tim(tenDN.Trim());
    }
}