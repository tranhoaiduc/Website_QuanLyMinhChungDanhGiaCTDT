using System.Collections.Generic;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity
{
    public class TieuChuanEFEntity
    {
        public string MaTieuChuan { get; set; }
        public string TenTieuChuan { get; set; }
        public string MoTa { get; set; }
        public string SoHopMinhChung { get; set; }

        public IEnumerable<TieuChiEFEntity> TieuChiEFEntityList { get; set; }

        public IEnumerable<MinhChungEFEntity> MinhChungEFEntityList { get; set; }

        public IEnumerable<TepTinEFEntity> TepTinEFEntityList { get; set; }
    }
}