using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAL
{
    public class SachDAL
    {
        QuanLyBanSachEntities db = null;
        public SachDAL()
        {
            db = new QuanLyBanSachEntities();
        }
        public List<Sach> GetBookKM() {
            return db.Saches.Take(10).ToList();
        }
        public List<Sach> SachBanChay()
        {
            return db.Saches.Where(x => x.SoLanXem != 0).Take(3).OrderByDescending(x=>x.SoLanXem).ToList();
        }
        public List<Sach> SachBanChayAll()
        {
            return db.Saches.Where(x => x.SoLanXem != 0).OrderByDescending(x => x.SoLanXem).ToList();
        }
        public List<Sach> GetAll()
        {
            return db.Saches.ToList();
        }
        public bool Insert(Sach sach,string ImageName)
        {
            try
            {
                sach.NgayKhoiTao = DateTime.Now.Date;
                sach.SoLanXem = 0;
                sach.AnhBia = ImageName;
                db.Saches.Add(sach);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Sach GetBookbyID(int id)
        {
            return db.Saches.Where(x => x.MaSach == id).SingleOrDefault();
        }
        public Sach GetBookbyIDView(int id)
        {
            var sach = db.Saches.Where(x => x.MaSach == id).SingleOrDefault();
            if(sach!=null)
            {

                sach.SoLanXem += 1;
                db.SaveChanges();
                return sach;
            }
            else
            {
                return sach;
            }
        }
        public List<Sach> Sachlienquan(int machude)
        {
            return db.Saches.Where(x => x.MaChuDe == machude).Take(5).ToList();
        }
        public bool UpdateBook(Sach sachupdate,string fileanh)
        {
            Sach sach = new Sach();
            sach = db.Saches.Where(x => x.MaSach == sachupdate.MaSach).SingleOrDefault();
            if(sach!=null)
            {
                sach.TenSach = sachupdate.TenSach;
                sach.MaChuDe = sachupdate.MaChuDe;
                sach.MaNXB = sachupdate.MaNXB;
                sach.TenTacGia = sachupdate.TenTacGia;
                sach.GiaBan = sachupdate.GiaBan;
                sach.MoTa = sachupdate.MoTa;
                sach.NgayCapNhat = DateTime.Now.Date;
                if (fileanh != "")
                {
                    sach.AnhBia = fileanh;
                }
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public List<Sach> SachNXB(int maNXB)
        {
            return db.Saches.Where(x => x.MaNXB == maNXB).ToList();
        }
        public List<Sach> SachTheLoai(int matheloai)
        {
            return db.Saches.Where(x => x.MaChuDe == matheloai).ToList();
        }
    }
}
