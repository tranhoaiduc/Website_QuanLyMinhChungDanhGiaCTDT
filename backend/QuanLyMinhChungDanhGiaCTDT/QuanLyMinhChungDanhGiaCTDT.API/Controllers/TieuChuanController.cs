using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.MinhChungModel;
using QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.TieuChuanModel;
using QuanLyMinhChungDanhGiaCTDT.Models.ResultModels;
using QuanLyMinhChungDanhGiaCTDT.Services.TieuChuanService.Interface;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuanLyMinhChungDanhGiaCTDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/tieu-chuan")]
    [ApiVersion("1.0", Deprecated = false)]
    [ApiController]
    public class TieuChuanController : ControllerBase
    {
        private readonly ITieuChuanService _ITieuChuanService;

        public TieuChuanController(ITieuChuanService iTieuChuanService)
        {
            this._ITieuChuanService = iTieuChuanService;
        }

        [HttpPost("tao")]
        [MapToApiVersion("1.0")]
        public async Task<ObjectResult> Create([FromBody] TaoTieuChuanDPEntity model)
        {
            try
            {
                MyServiceResult objMyServiceResult = await this._ITieuChuanService.Tao(model);
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
        public async Task<ObjectResult> Update([FromQuery] string maTieuChuan, [FromBody] CapNhatTieuChuanDPEntity model)
        {
            try
            {
                MyServiceResult objMyServiceResult = await this._ITieuChuanService.CapNhat(maTieuChuan, model);
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
        public async Task<ObjectResult> Delete([FromQuery] string maTieuChuan)
        {
            try
            {
                MyServiceResult objMyServiceResult = await this._ITieuChuanService.Xoa(maTieuChuan);
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
                MyServiceListObjectResult<TieuChuanDPEntity> objMyServiceListObjectResult = await this._ITieuChuanService.LayDanhSach();
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<MyServiceListObjectResult<TieuChuanDPEntity>>(objMyServiceListObjectResult));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<MyServiceListObjectResult<TieuChuanDPEntity>>(new MyServiceListObjectResult<TieuChuanDPEntity>
                {
                    Successed = false,
                    Content = ex.Message
                }));
            }
        }

        [HttpGet("lay-theo-ma")]
        [MapToApiVersion("1.0")]
        public async Task<ObjectResult> GetById(string maTieuChuan)
        {
            try
            {
                MyServiceObjectResult<TieuChuanDPEntity> objMyServiceObjectResult = await this._ITieuChuanService.LayTheoMa(maTieuChuan);
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<MyServiceObjectResult<TieuChuanDPEntity>>(objMyServiceObjectResult));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<MyServiceObjectResult<TieuChuanDPEntity>>(new MyServiceObjectResult<TieuChuanDPEntity>
                {
                    Successed = false,
                    Content = ex.Message
                }));
            }
        }
    }
}