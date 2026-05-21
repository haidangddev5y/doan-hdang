using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DanhMucBUS
{
    DanhMucDAL dal = new DanhMucDAL();

    public DataTable LoadDanhMuc(int loai, int maTK)
    {
        return dal.LoadDanhMuc(loai, maTK);
    }

    public bool Them(string tenDM, int loaiDM, string ghiChu, int maTK)
    {
        return dal.ThemDanhMuc(tenDM, loaiDM, ghiChu, maTK);
    }

    public bool Sua(int maDM, string tenDM, int loaiDM, string ghiChu)
    {
        return dal.SuaDanhMuc(maDM, tenDM, loaiDM, ghiChu).result == 1;
    }

    public bool Xoa(int maDM)
    {
        return dal.XoaDanhMuc(maDM) > 0;
    }

    public bool CheckTrung(string tenDM, int maTK, int? maDM = null)
    {
        return dal.CheckTrung(tenDM, maTK, maDM) > 0;
    }
}
