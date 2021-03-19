using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Configuration.Identity
{
    public class MyIdentityUserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
        {
            builder.ToTable("IDENTITYUSERCLAIMS");
        }
    }
}