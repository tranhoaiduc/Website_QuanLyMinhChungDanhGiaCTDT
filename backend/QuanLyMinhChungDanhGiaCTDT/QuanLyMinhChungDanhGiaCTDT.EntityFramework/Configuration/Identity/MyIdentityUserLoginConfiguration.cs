using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Configuration.Identity
{
    public class MyIdentityUserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
        {
            builder.ToTable("IDENTITYUSERLOGIN");
            builder.HasKey(x => x.UserId);
        }
    }
}