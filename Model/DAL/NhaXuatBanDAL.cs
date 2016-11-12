using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
   public class NhaXuatBanDAL
    {
         QuanLyBanSachEntities db=null;
         public NhaXuatBanDAL()
         {
            db = new QuanLyBanSachEntities();
        }
         public List<NhaXuatBan> GetAll()
         {
             return db.NhaXuatBans.ToList();
         }
       public NhaXuatBan GetbyID(int manxb)
         {
             return db.NhaXuatBans.Where(x => x.MaNXB == manxb).SingleOrDefault();
         }
    }
}
