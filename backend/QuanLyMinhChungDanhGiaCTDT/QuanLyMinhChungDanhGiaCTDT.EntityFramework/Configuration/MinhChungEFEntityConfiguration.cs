using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Configuration
{
    public class MinhChungEFEntityConfiguration : IEntityTypeConfiguration<MinhChungEFEntity>
    {
        public void Configure(EntityTypeBuilder<MinhChungEFEntity> builder)
        {
            builder.ToTable("MINHCHUNG");
            builder.HasKey(x => x.MaMinhChung);
            builder.Property(x => x.SoKyHieu).IsRequired(true).HasColumnType("VARCHAR(200)");
            builder.Property(x => x.TrichYeu).IsRequired(true).HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.CoQuanBanHanh).IsRequired(true).HasColumnType("NVARCHAR(200)");
            builder.Property(x => x.NoiNhanCacVanBan).IsRequired(true).HasColumnType("NVARCHAR(200)");
            builder.Property(x => x.NoiLuuBanChinh).IsRequired(true).HasColumnType("NVARCHAR(200)");
            builder.Property(x => x.MucDo).IsRequired(true).HasColumnType("INTEGER");
            builder.Property(x => x.NguoiKyVanBan).IsRequired(true).HasColumnType("NVARCHAR(200)");
            builder.Property(x => x.SoPhatHanh).IsRequired(true).HasColumnType("VARCHAR(200)");
            builder.Property(x => x.LinhVucVanBan).IsRequired(true).HasColumnType("NVARCHAR(200)");
            builder.Property(x => x.LoaiVanBan).IsRequired(true).HasColumnType("NVARCHAR(200)");
            builder.Property(x => x.NgayTao).IsRequired(true).HasColumnType("DATE");
            builder.Property(x => x.NgayLuu).IsRequired(true).HasColumnType("DATE");
            builder.Property(x => x.MaNguoiTao).IsRequired(true).HasColumnType("VARCHAR(200)");

            builder.HasOne<TieuChiEFEntity>(x => x.TieuChiEFEntityObject)
                .WithMany(x => x.MinhChungEFEntityList)
                .HasForeignKey(x => x.MaTieuChi);
            builder.HasOne<TieuChuanEFEntity>(x => x.TieuChuanEFEntityObject)
                .WithMany(x => x.MinhChungEFEntityList)
                .HasForeignKey(x => x.MaTieuChuan);
        }
    }
}