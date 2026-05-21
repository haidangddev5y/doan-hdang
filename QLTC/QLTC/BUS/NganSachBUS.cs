using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NganSachBUS
{
    NganSachDAL dal = new NganSachDAL();


    public DataTable LoadDMChi(int maTK)
    {
        return dal.LoadDanhMuc(0, maTK);
    }

    public DataTable LoadNganSach(int maTK)
    {
        return dal.LoadNganSach(maTK);
    }

    public DataTable Load(int maTK, int thang, int nam)
    {
        return dal.Load(maTK, thang, nam);
    }

    public bool Them(int maDM, decimal gh, int thang, int nam, int maTK)
    {
        return dal.Them(maDM, gh, thang, nam, maTK) > 0;
    }

    public bool Sua(int maNS, int maDM, decimal gh, int thang, int nam, int maTK)
    {
        if (gh <= 0) throw new Exception("Giới hạn không hợp lệ");

        return dal.Sua(maNS,maDM,gh,thang,nam,maTK) > 0;
    }

    public bool Xoa(int maNS) => dal.Xoa(maNS) > 0;

}