using QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.MinhChungModel;
using QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.TieuChuanModel;
using QuanLyMinhChungDanhGiaCTDT.Models.ResultModels;
using System.Threading.Tasks;

namespace QuanLyMinhChungDanhGiaCTDT.Dapper.DapperServices.TieuChuanService.Interface
{
    public interface ITieuChuanService
    {
        public Task<MyServiceResult> Tao(TaoTieuChuanDPEntity model);

        public Task<MyServiceResult> CapNhat(string maTieuChuan, CapNhatTieuChuanDPEntity model);

        public Task<MyServiceResult> Xoa(string maTieuChuan);

        public Task<MyServiceListObjectResult<TieuChuanDPEntity>> LayDanhSach();

        public Task<MyServiceObjectResult<TieuChuanDPEntity>> LayTheoMa(string maTieuChuan);
    }
}