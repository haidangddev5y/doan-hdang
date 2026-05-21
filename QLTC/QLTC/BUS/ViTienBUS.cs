using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ViTienBUS
{
    ViTienDAL dal = new ViTienDAL();

    public DataTable Load(int maTK) => dal.Load(maTK);

    public void Them(string ten, decimal sd, string gc, int maTK)
        => dal.Them(ten, sd, gc, maTK);

    public void Sua(int ma, string ten, decimal sd, string gc)
        => dal.Sua(ma, ten, sd, gc);

    public void Xoa(int ma) => dal.Xoa(ma);
}