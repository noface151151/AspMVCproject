using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAL;

namespace BookShop.Controllers
{
    public class HomeClientController : Controller
    {
        // GET: HomeClient
        public ActionResult Index()
        {
            return View();
        }
        SachDAL sachDAL = new SachDAL();
        NhaXuatBanDAL nxbDAL = new NhaXuatBanDAL();
        ChuDeDAL chudeDAL = new ChuDeDAL();
        public ActionResult SanPhamKhuyenMaiPartial()
        {
            return PartialView(sachDAL.GetBookKM());
        }
        public ActionResult NXBPartial()
        {
            return PartialView(nxbDAL.GetAll());
        }
        public ActionResult ChudePartial()
        {
            return PartialView(chudeDAL.GetAll());
        }
        public ActionResult SachBanChayPartial()
        {
            return PartialView(sachDAL.SachBanChay());
        }
    }
}