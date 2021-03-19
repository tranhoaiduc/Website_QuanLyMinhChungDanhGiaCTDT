using System;
using System.Collections.Generic;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity
{
    public class MinhChungEFEntity
    {
        public string MaMinhChung { get; set; }
        public string SoKyHieu { get; set; }
        public string TrichYeu { get; set; }
        public string CoQuanBanHanh { get; set; }
        public string NoiNhanCacVanBan { get; set; }
        public string NoiLuuBanChinh { get; set; }
        public int MucDo { get; set; }
        public string NguoiKyVanBan { get; set; }
        public string SoPhatHanh { get; set; }
        public string LinhVucVanBan { get; set; }
        public string LoaiVanBan { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayLuu { get; set; }

        public string MaNguoiTao { get; set; }

        public string MaTieuChi { get; set; }
        public TieuChiEFEntity TieuChiEFEntityObject { get; set; }

        public string MaTieuChuan { get; set; }
        public TieuChuanEFEntity TieuChuanEFEntityObject { get; set; }

        public IEnumerable<TepTinEFEntity> TepTinEFEntityList { get; set; }
    }
}