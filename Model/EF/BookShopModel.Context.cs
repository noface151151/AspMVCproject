﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyBanSachEntities : DbContext
    {
        public QuanLyBanSachEntities()
            : base("name=QuanLyBanSachEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<ChuDe> ChuDes { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public DbSet<Sach> Saches { get; set; }
    }
}
