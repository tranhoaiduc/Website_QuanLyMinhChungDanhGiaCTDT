using System;

namespace QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.MinhChungModel
{
    public class MinhChungDPEntity
    {
        public string MaMinhChung { get; set; }
        public string SoKyHieu { get; set; }
        public string TrichYeu { get; set; }

        //public DateTime NgayNhan { get; set; }
        public string CoQuanBanHanh { get; set; }

        public string NoiNhanCacVanBan { get; set; }
        public string NoiLuuBanChinh { get; set; }
        public int MucDo { get; set; }
        public string NguoiKyVanBan { get; set; }
        public string SoPhatHanh { get; set; }
        public string LinhVucVanBan { get; set; }
        public string LoaiVanBan { get; set; }
        public string NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public string MaTieuChi { get; set; }
        public string TenTieuChi { get; set; }
        public string MaTieuChuan { get; set; }
        public string TenTieuChuan { get; set; }
    }
}