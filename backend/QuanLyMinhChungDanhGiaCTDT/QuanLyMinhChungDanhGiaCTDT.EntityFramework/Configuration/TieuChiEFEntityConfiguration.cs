using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Configuration
{
    public class TieuChiEFEntityConfiguration : IEntityTypeConfiguration<TieuChiEFEntity>
    {
        public void Configure(EntityTypeBuilder<TieuChiEFEntity> builder)
        {
            builder.ToTable("TIEUCHI");
            builder.HasKey(x => x.MaTieuChi);
            builder.Property(x => x.TenTieuChi).IsRequired(true).HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.YeuCauCuaTieuChi).IsRequired(true).HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.MocChuanThamChieuDeDanhGiaTieuChiDatMucBon).IsRequired(true).HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.GoiYNguonMinhChung).IsRequired(true).HasColumnType("NVARCHAR(MAX)");

            builder.HasOne<TieuChuanEFEntity>(x => x.TieuChuanEFEntityObject)
                .WithMany(x => x.TieuChiEFEntityList)
                .HasForeignKey(x => x.MaTieuChuan);
        }
    }
}