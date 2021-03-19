using System.Collections.Generic;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity
{
    public class TieuChiEFEntity
    {
        public string MaTieuChi { get; set; }
        public string TenTieuChi { get; set; }
        public string YeuCauCuaTieuChi { get; set; }
        public string MocChuanThamChieuDeDanhGiaTieuChiDatMucBon { get; set; }
        public string GoiYNguonMinhChung { get; set; }
        public string MaTieuChuan { get; set; }
        public TieuChuanEFEntity TieuChuanEFEntityObject { get; set; }

        public IEnumerable<MinhChungEFEntity> MinhChungEFEntityList { get; set; }

        public IEnumerable<TepTinEFEntity> TepTinEFEntityList { get; set; }
    }
}