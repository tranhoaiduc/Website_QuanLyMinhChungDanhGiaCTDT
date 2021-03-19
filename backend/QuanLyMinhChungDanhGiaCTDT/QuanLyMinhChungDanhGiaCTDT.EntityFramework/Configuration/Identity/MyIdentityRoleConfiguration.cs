using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity.Identity;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Configuration.Identity
{
    public class MyIdentityRoleConfiguration : IEntityTypeConfiguration<MyIdentityRole>
    {
        public void Configure(EntityTypeBuilder<MyIdentityRole> builder)
        {
            builder.ToTable("IDENTITYROLE");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired(false).HasColumnType("NVARCHAR(MAX)");
        }
    }
}