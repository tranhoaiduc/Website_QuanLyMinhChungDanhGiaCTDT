using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Configuration
{
    public class TieuChuanEFEntityConfiguration : IEntityTypeConfiguration<TieuChuanEFEntity>
    {
        public void Configure(EntityTypeBuilder<TieuChuanEFEntity> builder)
        {
            builder.ToTable("TIEUCHUAN");
            builder.HasKey(x => x.MaTieuChuan);
            builder.Property(x => x.TenTieuChuan).IsRequired(true).HasColumnType("NVARCHAR(500)");
            builder.Property(x => x.SoHopMinhChung).IsRequired(true).HasColumnType("INTEGER");
        }
    }
}