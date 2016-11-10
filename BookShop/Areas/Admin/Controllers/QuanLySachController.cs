using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAL;
using Model.EF;
using System.IO;
using System.Text.RegularExpressions;

namespace BookShop.Areas.Admin.Controllers
{
    public class QuanLySachController : Controller
    {
        // GET: Admin/QuanLySach
        SachDAL sachDAL = new SachDAL();
        ChuDeDAL chudeDAL = new ChuDeDAL();
        NhaXuatBanDAL nxbDAL = new NhaXuatBanDAL();
        public ActionResult Index()
        {
            
            return View(sachDAL.GetAll());
        }

        [HttpGet]
        public ActionResult ThemSach()
        {
            ViewBag.Chude = new SelectList(chudeDAL.GetAll().OrderBy(x => x.MaChuDe), "MaChuDe", "TenChuDe");
            ViewBag.NhaXuatBan = new SelectList(nxbDAL.GetAll().OrderBy(x => x.MaNXB), "MaNXB", "TenNXB");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemSach(Sach sach, HttpPostedFileBase fileUpload)
        {
            ViewBag.Chude = new SelectList(chudeDAL.GetAll().OrderBy(x => x.MaChuDe), "MaChuDe", "TenChuDe");
            ViewBag.NhaXuatBan = new SelectList(nxbDAL.GetAll().OrderBy(x => x.MaNXB), "MaNXB", "TenNXB");
            //thêm vào CSDL
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chưa chọn hình ảnh";
                return View();
            }
            if (ModelState.IsValid)
            {
                //Lưu tên file
                var fileName = Path.GetFileName(fileUpload.FileName);
                Regex rgx = new Regex(@"^[\w,\s-]+\.[A-Za-z]{3}$");
                if (!rgx.IsMatch(fileName))
                {
                    ViewBag.ThongBao = "Định dạng tên tập tin hình ảnh không đúng.(Tên tập tin không có ký tự đăc biệt như # $ %...) ";
                    return View();
                }
                else
                {
                    //Lưu đường dẫn của file
                    var path = Path.Combine(Server.MapPath("~/Image"), fileName);
                    //kiểm trả hình ảnh đã tồn tại chưa

                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                        return View();
                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }

                    // sach.AnhBia = fileUpload.FileName;
                    if (!sachDAL.Insert(sach, fileUpload.FileName))
                    {
                        ModelState.AddModelError("", "Thêm thất bại");

                    }
                    else
                    {
                        ModelState.Clear();
                        ViewBag.ThanhCong = "Sản phẩm được thêm thành công";
                    }

                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult ChitietSach(int id = 0)
        {
            if (sachDAL.GetBookbyID(id) != null)
            {
                return View(sachDAL.GetBookbyID(id));
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Không tồn tại sách!'); window.location.href = 'Index';</script>");
            }
        }
        [HttpGet]
        public ActionResult Suasach(int masach = 0)
        {
            Sach sach = sachDAL.GetBookbyID(masach);
            if (sach == null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Không tồn tại sách!'); window.location.href = 'Index';</script>");
            }
            else
            {
                ViewBag.Chude = new SelectList(chudeDAL.GetAll().OrderBy(x => x.MaChuDe), "MaChuDe", "TenChuDe", sach.ChuDe.TenChuDe);
                ViewBag.NhaXuatBan = new SelectList(nxbDAL.GetAll().OrderBy(x => x.MaNXB), "MaNXB", "TenNXB", sach.NhaXuatBan.TenNXB);
                return View(sach);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Suasach(Sach sachupdate, HttpPostedFileBase fileUpload)
        {
            Sach sachold = sachDAL.GetBookbyID(sachupdate.MaSach);
            ViewBag.Chude = new SelectList(chudeDAL.GetAll().OrderBy(x => x.MaChuDe), "MaChuDe", "TenChuDe", sachold.ChuDe.TenChuDe);
            ViewBag.NhaXuatBan = new SelectList(nxbDAL.GetAll().OrderBy(x => x.MaNXB), "MaNXB", "TenNXB", sachold.NhaXuatBan.TenNXB);
            if (ModelState.IsValid)
            {
                if (fileUpload != null)
                {
                    //Lưu tên file
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    Regex rgx = new Regex(@"^[\w,\s-]+\.[A-Za-z]{3}$");
                    if (!rgx.IsMatch(fileName))
                    {
                        ViewBag.ThongBao = "Định dạng tên tập tin hình ảnh không đúng.(Tên tập tin không có ký tự đăc biệt như # $ %...) ";
                        return View();
                    }
                    else
                    {
                        //Lưu đường dẫn của file
                        var path = Path.Combine(Server.MapPath("~/Image"), fileName);
                        //kiểm trả hình ảnh đã tồn tại chưa

                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                            fileUpload.SaveAs(path);
                        }
                        else
                        {
                            string hinhcu = sachDAL.GetBookbyID(sachupdate.MaSach).AnhBia;
                            var pathcu = Path.Combine(Server.MapPath("~/Image"), hinhcu);
                            if (System.IO.File.Exists(pathcu))
                            {
                                System.IO.File.Delete(pathcu);
                            }
                            fileUpload.SaveAs(path);
                        }
                    }

                    // sach.AnhBia = fileUpload.FileName;
                    if (!sachDAL.UpdateBook(sachupdate, fileUpload.FileName))
                    {
                        ModelState.AddModelError("", "Sửa sản phẩm thất bại");

                    }
                    else
                    {
                        ModelState.Clear();
                        ViewBag.ThanhCong = "Sản phẩm được chỉnh sửa thành công";
                    }

                }
                else
                {
                    if (!sachDAL.UpdateBook(sachupdate, ""))
                    {
                        ModelState.AddModelError("", "Sửa sản phẩm thất bại");

                    }
                }
                
            }
            else
            {
                return View(sachold);
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Sửa sản phẩm thành công');window.location.href = 'Index'</script>");
        }
        public PartialViewResult TimKiem(FormCollection form)
        {
            List<Sach> listSearch = new List<Sach>();
            int giatu = 0;
                try{
                    giatu=int.Parse(Request.Form["giatu"]);
                }
            catch{
                giatu = 0;
            }
                int giaden = 0;
                try
                {
                    giaden=int.Parse(Request.Form["giaden"]);
                }
                catch
                {
                    giaden = 0;
                }
            int maChude = 0;
                try{
               maChude = int.Parse(Request.Form["maChude"]);
                }catch{
                    maChude = 0;
                }
            int maNXB = 0 ;
            try{
                maNXB = int.Parse(Request.Form["maNXB"]);
            }catch{
                maNXB=0;
            };
            
            
            listSearch = sachDAL.GetAll();
            if(maNXB!=0)
            {
                listSearch = listSearch.Where(x => x.MaNXB == maNXB).ToList();
            }
            if (maChude != 0)
            {
                listSearch = listSearch.Where(x => x.MaChuDe == maChude).ToList();
            }
            if (giatu != 0 && giaden == 0)
            {
                listSearch = listSearch.Where(x => x.GiaBan >= giatu).ToList();
            }
            if (giatu == 0 && giaden != 0)
            {
                listSearch = listSearch.Where(x => x.GiaBan <= giaden).ToList();
            }
            if (giatu != 0 && giaden != 0)
            {
                listSearch = listSearch.Where(x => x.GiaBan >= giatu && x.GiaBan <= giaden).ToList();
            }
            return PartialView(listSearch);
        }
    }
}

    
    

    
