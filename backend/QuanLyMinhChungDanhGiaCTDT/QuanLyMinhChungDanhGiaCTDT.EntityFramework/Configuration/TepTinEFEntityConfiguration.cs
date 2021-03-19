using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Configuration
{
    public class TepTinEFEntityConfiguration : IEntityTypeConfiguration<TepTinEFEntity>
    {
        public void Configure(EntityTypeBuilder<TepTinEFEntity> builder)
        {
            builder.ToTable("TEPTIN");
            builder.HasKey(x => x.MaTepTin);
            builder.Property(x => x.TenTepTin).IsRequired(true).HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.ThoiGianTao).IsRequired(true).HasColumnType("DATE");
            builder.Property(x => x.DuongDan).IsRequired(true).HasColumnType("NVARCHAR(MAX)");

            builder.HasOne<TieuChiEFEntity>(x => x.TieuChiEFEntityObject)
                .WithMany(x => x.TepTinEFEntityList)
                .HasForeignKey(x => x.MaTieuChi);

            builder.HasOne<TieuChuanEFEntity>(x => x.TieuChuanEFEntityObject)
                .WithMany(x => x.TepTinEFEntityList)
                .HasForeignKey(x => x.MaTieuChuan);

            builder.HasOne<MinhChungEFEntity>(x => x.MinhChungEFEntityObject)
                .WithMany(x => x.TepTinEFEntityList)
                .HasForeignKey(x => x.MaMinhChung);
        }
    }
}