using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
   public class ChuDeDAL
    {
         QuanLyBanSachEntities db=null;
         public ChuDeDAL()
         {
            db = new QuanLyBanSachEntities();
        }
         public List<ChuDe> GetAll()
         {
             return db.ChuDes.ToList();
         }
         public ChuDe GetbyID(int machude)
         {
             return db.ChuDes.Where(x => x.MaChuDe == machude).SingleOrDefault();
         }
    }
}
