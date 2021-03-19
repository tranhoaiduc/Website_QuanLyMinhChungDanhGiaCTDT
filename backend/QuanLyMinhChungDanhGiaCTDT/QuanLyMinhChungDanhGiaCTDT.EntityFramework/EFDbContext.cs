using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework.Configuration;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework.Configuration.Identity;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity.Identity;
using System;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework
{
    public class EFDbContext : IdentityDbContext<MyIdentityUser, MyIdentityRole, Guid>
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MyIdentityUserConfiguration());
            builder.ApplyConfiguration(new MyIdentityRoleConfiguration());
            builder.ApplyConfiguration(new MyIdentityUserLoginConfiguration());
            builder.ApplyConfiguration(new MyIdentityUserRoleConfiguration());
            builder.ApplyConfiguration(new MyIdentityUserTokenConfiguration());
            builder.ApplyConfiguration(new MyIdentityRoleClaimConfiguration());
            builder.ApplyConfiguration(new MyIdentityUserClaimsConfiguration());

            builder.ApplyConfiguration(new TieuChuanEFEntityConfiguration());
            builder.ApplyConfiguration(new TieuChiEFEntityConfiguration());
            builder.ApplyConfiguration(new MinhChungEFEntityConfiguration());
            builder.ApplyConfiguration(new TepTinEFEntityConfiguration());
        }
    }
}