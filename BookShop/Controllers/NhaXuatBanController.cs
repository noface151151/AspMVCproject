using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAL;
using Model.EF;
using PagedList;
using PagedList.Mvc;

namespace BookShop.Controllers
{
    public class NhaXuatBanController : Controller
    {
        // GET: NhaXuatBan
        SachDAL sachDAL = new SachDAL();
        NhaXuatBanDAL nxbDAL = new NhaXuatBanDAL();
        public ActionResult SachNXB(int? page, int manxb = 1)
        {
            if (nxbDAL.GetbyID(manxb) == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            int Pagesize = 9;
            int PageNumber = (page ?? 1);
            var sachnxb = sachDAL.SachNXB(manxb).OrderBy(x => x.MaSach);
            if (Request.IsAjaxRequest())
            {

                return PartialView("SachChuDePartial", sachDAL.SachNXB(manxb).OrderBy(x => x.MaSach).ToPagedList(PageNumber, Pagesize));

            }
            else
            {

                return View(sachDAL.SachNXB(manxb).OrderBy(x => x.MaSach).ToPagedList(PageNumber, Pagesize));

            }
        }
    }
}