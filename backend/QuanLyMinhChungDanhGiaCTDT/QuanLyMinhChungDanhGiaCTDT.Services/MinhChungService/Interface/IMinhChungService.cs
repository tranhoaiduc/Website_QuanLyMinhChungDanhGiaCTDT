using QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.MinhChungModel;
using QuanLyMinhChungDanhGiaCTDT.Models.ResultModels;
using System.Threading.Tasks;

namespace QuanLyMinhChungDanhGiaCTDT.Services.MinhChungService.Interface
{
    public interface IMinhChungService
    {
        public Task<MyServiceResult> Tao(TaoMinhChungDPEntity model);

        public Task<MyServiceResult> CapNhat(string maMinhChung, CapNhatMinhChungDPEntity model);

        public Task<MyServiceResult> Xoa(string maMinhChung);

        public Task<MyServiceListObjectResult<MinhChungDPEntity>> LayDanhSach();

        public Task<MyServiceObjectResult<MinhChungDPEntity>> LayTheoMa(string maMinhChung);
    }
}