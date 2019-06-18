using DAL.Model.Tables;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class ApplicationDbContext : IdentityDbContext<Tbl_Users>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Booking;User Id=pe2131;Password =2131; MultipleActiveResultSets =true");
            //optionsBuilder.UseSqlServer("Data Source=SQL6001.site4now.net;Initial Catalog=DB_A48CF1_booking1;User Id=DB_A48CF1_booking1_admin;Password= KnBccxdFreTo0oxXx;"); //for server cccdevelopers
            //optionsBuilder.UseSqlServer("Data Source=plesk2500a.trouble-free.net;Initial Catalog=bookingw_vip;User Id=peymandb1;Password= kM9uc04_;"); //for server vip.webiim
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Tbl_Users> tbl_Users { get; set; }
        public DbSet<Tbl_Setting> Tbl_Settings { get; set; }
        public DbSet<Tbl_Factore> tbl_Factores { get; set; }
        public DbSet<Tbl_PathWay> tbl_PathWays { get; set; }
        public DbSet<Tbl_Country> tbl_Countries { get; set; }
        public DbSet<Tbl_City> tbl_Cities { get; set; }
        public DbSet<Tbl_Discount> tbl_Discounts { get; set; }
        public DbSet<Tbl_Reserve> Tbl_Reserve { get; set; }
        public DbSet<Tbl_Weblog> tbl_Weblogs { get; set; }
        public DbSet<Tbl_NewsLetter> tbl_NewsLetters { get; set; }
        public DbSet<Tbl_Contact> tbl_Contacts { get; set; }
        public DbSet<Tbl_Routes> tbl_Routes { get; set; }


    }
}
