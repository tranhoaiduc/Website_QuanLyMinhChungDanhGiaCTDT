using QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.TieuChiModel;
using QuanLyMinhChungDanhGiaCTDT.Models.ResultModels;
using System.Threading.Tasks;

namespace QuanLyMinhChungDanhGiaCTDT.Services.TieuChiService.Interface
{
    public interface ITieuChiService
    {
        public Task<MyServiceResult> Tao(TaoTieuChiDPEntity model);

        public Task<MyServiceResult> CapNhat(string maTieuChi, CapNhatTieuChiDPEntity model);

        public Task<MyServiceResult> Xoa(string maTieuChi);

        public Task<MyServiceListObjectResult<TieuChiDPEntity>> LayDanhSach();

        public Task<MyServiceObjectResult<TieuChiDPEntity>> LayTheoMa(string maTieuChi);
    }
}