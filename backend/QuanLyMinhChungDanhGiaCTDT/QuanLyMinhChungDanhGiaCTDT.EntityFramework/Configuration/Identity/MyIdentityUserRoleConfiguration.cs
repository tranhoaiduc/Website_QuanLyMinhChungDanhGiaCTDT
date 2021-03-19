using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Configuration.Identity
{
    public class MyIdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.ToTable("IDENTITYUSERROLE");
            builder.HasKey(x => new { x.UserId, x.RoleId });
        }
    }
}