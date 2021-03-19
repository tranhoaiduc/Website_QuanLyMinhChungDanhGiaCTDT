using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity.Identity;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Configuration.Identity
{
    public class MyIdentityUserConfiguration : IEntityTypeConfiguration<MyIdentityUser>
    {
        public void Configure(EntityTypeBuilder<MyIdentityUser> builder)
        {
            builder.ToTable("IDENTITYUSER");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired(true).HasColumnType("NVARCHAR(200)");
            builder.Property(x => x.Gender).IsRequired(true).HasColumnType("BIT");
            builder.Property(x => x.DateOfBirth).IsRequired(false).HasColumnType("DATE").HasDefaultValue(null);
            builder.Property(x => x.Address).IsRequired(true).HasColumnType("NVARCHAR(500)");
        }
    }
}