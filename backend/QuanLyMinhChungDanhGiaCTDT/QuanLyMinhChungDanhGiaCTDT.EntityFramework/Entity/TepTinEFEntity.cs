using System;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity
{
    public class TepTinEFEntity
    {
        public string MaTepTin { get; set; }
        public string TenTepTin { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public string DuongDan { get; set; }
        public string MaTieuChi { get; set; }
        public TieuChiEFEntity TieuChiEFEntityObject { get; set; }
        public string MaTieuChuan { get; set; }
        public TieuChuanEFEntity TieuChuanEFEntityObject { get; set; }
        public string MaMinhChung { get; set; }
        public MinhChungEFEntity MinhChungEFEntityObject { get; set; }
    }
}