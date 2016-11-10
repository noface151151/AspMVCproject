using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BookShop.Controllers
{
    public class TheLoaiController : Controller
    {
        // GET: TheLoai
        SachDAL sachDAL = new SachDAL();
        public ActionResult Sachtheloai(int? page,int matheloai = 0)
        {
            int Pagesize = 15;
            int PageNumber = (page ?? 1);
            if (Request.IsAjaxRequest())
            {
                if (matheloai == 0)
                {
                    return PartialView("SachChuDePartial", sachDAL.GetAll().OrderBy(x => x.MaSach).ToPagedList(PageNumber, Pagesize));
                }
                else
                {
                    return PartialView("SachChuDePartial", sachDAL.SachTheLoai(matheloai).OrderBy(x => x.MaSach).ToPagedList(PageNumber, Pagesize));
                }
            }
            else
            {
                if (matheloai == 0)
                {
                    return View(sachDAL.GetAll().OrderBy(x => x.MaSach).ToPagedList(PageNumber,Pagesize));
                }
                else
                {
                    return View(sachDAL.SachTheLoai(matheloai).OrderBy(x => x.MaSach).ToPagedList(PageNumber, Pagesize));
                }
            }
        }
    }
}