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
        ChuDeDAL chudeDAL = new ChuDeDAL();

        [HttpGet]
        public ActionResult Sachtheloai(int? page,int id=1)
        {
            if(chudeDAL.GetbyID(id)==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            int Pagesize = 9;
            int PageNumber = (page ?? 1);

            if (Request.IsAjaxRequest())
            {
                
                    return PartialView("SachChuDePartial", sachDAL.SachTheLoai(id).OrderBy(x => x.MaSach).ToPagedList(PageNumber, Pagesize));
                
            }
            else
            {
                
                    return View(sachDAL.SachTheLoai(id).OrderBy(x => x.MaSach).ToPagedList(PageNumber, Pagesize));
                
            }
        }
    }
}