using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAL;
using Model.EF;

namespace BookShop.Controllers
{
    public class NhaXuatBanController : Controller
    {
        // GET: NhaXuatBan
        SachDAL sachDAL = new SachDAL();
        NhaXuatBanDAL nxbDAL = new NhaXuatBanDAL();
        public ActionResult SachNXB(int manxb=0)
        {
            if (manxb == 0)
            {
                return View(sachDAL.GetAll());
            }
            else
            {
                return View(sachDAL.SachNXB(manxb));
            }
        }
    }
}