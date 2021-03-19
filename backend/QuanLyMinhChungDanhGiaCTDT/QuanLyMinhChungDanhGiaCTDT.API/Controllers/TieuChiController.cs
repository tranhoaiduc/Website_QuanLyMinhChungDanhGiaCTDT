using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.TieuChiModel;
using QuanLyMinhChungDanhGiaCTDT.Models.ResultModels;
using QuanLyMinhChungDanhGiaCTDT.Services.TieuChiService.Interface;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuanLyMinhChungDanhGiaCTDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/tieu-chi")]
    [ApiVersion("1.0", Deprecated = false)]
    [ApiController]
    public class TieuChiController : ControllerBase
    {
        private readonly ITieuChiService _ITieuChiService;

        public TieuChiController(ITieuChiService iTieuChiService)
        {
            this._ITieuChiService = iTieuChiService;
        }

        [HttpPost("tao")]
        [MapToApiVersion("1.0")]
        public async Task<ObjectResult> Create([FromBody] TaoTieuChiDPEntity model)
        {
            try
            {
                MyServiceResult objMyServiceResult = await this._ITieuChiService.Tao(model);
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<MyServiceResult>(objMyServiceResult));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<MyServiceResult>(new MyServiceResult
                {
                    Successed = false,
                    Content = ex.Message
                }));
            }
        }

        [HttpPut("cap-nhat")]
        [MapToApiVersion("1.0")]
        public async Task<ObjectResult> Update([FromQuery] string maTieuChi, [FromBody] CapNhatTieuChiDPEntity model)
        {
            try
            {
                MyServiceResult objMyServiceResult = await this._ITieuChiService.CapNhat(maTieuChi, model);
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<MyServiceResult>(objMyServiceResult));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<MyServiceResult>(new MyServiceResult
                {
                    Successed = false,
                    Content = ex.Message
                }));
            }
        }

        [HttpDelete("xoa")]
        [MapToApiVersion("1.0")]
        public async Task<ObjectResult> Delete([FromQuery] string maTieuChi)
        {
            try
            {
                MyServiceResult objMyServiceResult = await this._ITieuChiService.Xoa(maTieuChi);
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<MyServiceResult>(objMyServiceResult));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<MyServiceResult>(new MyServiceResult
                {
                    Successed = false,
                    Content = ex.Message
                }));
            }
        }

        [HttpGet("lay-danh-sach")]
        [MapToApiVersion("1.0")]
        public async Task<ObjectResult> GetAll()
        {
            try
            {
                MyServiceListObjectResult<TieuChiDPEntity> objMyServiceListObjectResult = await this._ITieuChiService.LayDanhSach();
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<MyServiceListObjectResult<TieuChiDPEntity>>(objMyServiceListObjectResult));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<MyServiceListObjectResult<TieuChiDPEntity>>(new MyServiceListObjectResult<TieuChiDPEntity>
                {
                    Successed = false,
                    Content = ex.Message
                }));
            }
        }

        [HttpGet("lay-theo-ma")]
        [MapToApiVersion("1.0")]
        public async Task<ObjectResult> GetById(string maTieuChi)
        {
            try
            {
                MyServiceObjectResult<TieuChiDPEntity> objMyServiceObjectResult = await this._ITieuChiService.LayTheoMa(maTieuChi);
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<MyServiceObjectResult<TieuChiDPEntity>>(objMyServiceObjectResult));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<MyServiceObjectResult<TieuChiDPEntity>>(new MyServiceObjectResult<TieuChiDPEntity>
                {
                    Successed = false,
                    Content = ex.Message
                }));
            }
        }
    }
}