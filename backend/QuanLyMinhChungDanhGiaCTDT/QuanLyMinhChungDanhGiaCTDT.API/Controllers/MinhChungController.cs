using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyMinhChungDanhGiaCTDT.Models.DapperModels.MinhChungModel;
using QuanLyMinhChungDanhGiaCTDT.Models.ResultModels;
using QuanLyMinhChungDanhGiaCTDT.Services.MinhChungService.Interface;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuanLyMinhChungDanhGiaCTDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/minh-chung")]
    [ApiVersion("1.0", Deprecated = false)]
    [ApiController]
    public class MinhChungController : ControllerBase
    {
        private readonly IMinhChungService _IMinhChungService;

        public MinhChungController(IMinhChungService iMinhChungService)
        {
            this._IMinhChungService = iMinhChungService;
        }

        [HttpPost("tao")]
        [MapToApiVersion("1.0")]
        public async Task<ObjectResult> Create([FromBody] TaoMinhChungDPEntity model)
        {
            try
            {
                MyServiceResult objMyServiceResult = await this._IMinhChungService.Tao(model);
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
        public async Task<ObjectResult> Update([FromQuery] string maMinhChung, [FromBody] CapNhatMinhChungDPEntity model)
        {
            try
            {
                MyServiceResult objMyServiceResult = await this._IMinhChungService.CapNhat(maMinhChung, model);
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
        public async Task<ObjectResult> Delete([FromQuery] string maMinhChung)
        {
            try
            {
                MyServiceResult objMyServiceResult = await this._IMinhChungService.Xoa(maMinhChung);
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
                MyServiceListObjectResult<MinhChungDPEntity> objMyServiceListObjectResult = await this._IMinhChungService.LayDanhSach();
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<MyServiceListObjectResult<MinhChungDPEntity>>(objMyServiceListObjectResult));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<MyServiceListObjectResult<MinhChungDPEntity>>(new MyServiceListObjectResult<MinhChungDPEntity>
                {
                    Successed = false,
                    Content = ex.Message
                }));
            }
        }

        [HttpGet("lay-theo-ma")]
        [MapToApiVersion("1.0")]
        public async Task<ObjectResult> GetById(string maMinhChung)
        {
            try
            {
                MyServiceObjectResult<MinhChungDPEntity> objMyServiceObjectResult = await this._IMinhChungService.LayTheoMa(maMinhChung);
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<MyServiceObjectResult<MinhChungDPEntity>>(objMyServiceObjectResult));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<MyServiceObjectResult<MinhChungDPEntity>>(new MyServiceObjectResult<MinhChungDPEntity>
                {
                    Successed = false,
                    Content = ex.Message
                }));
            }
        }
    }
}