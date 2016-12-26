using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.DAL;

namespace BookShop.Controllers
{
    public class SachController : Controller
    {
        
        // GET: Sach
        SachDAL sachDAL = new SachDAL();
        public ActionResult ChitietSach(int masach=0)
        {
            return View(sachDAL.GetBookbyIDView(masach));
        }
        public ActionResult SachlienquanPartial(int machude)
        {
            return PartialView(sachDAL.Sachlienquan(machude));
        }
        public ActionResult SachBanChay()
        {
            return View(sachDAL.SachBanChayAll());
        }
    }
}