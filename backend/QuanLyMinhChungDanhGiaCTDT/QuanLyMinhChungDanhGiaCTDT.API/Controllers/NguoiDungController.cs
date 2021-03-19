using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyMinhChungDanhGiaCTDT.Models.EFModels.UserModel;
using QuanLyMinhChungDanhGiaCTDT.Models.ResultModels;
using QuanLyMinhChungDanhGiaCTDT.Services.UserService.Interface;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuanLyMinhChungDanhGiaCTDT.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/nguoi-dung")]
    public class NguoiDungController : ControllerBase
    {
        private readonly IUserService _IUserService;

        public NguoiDungController(IUserService iUserService)
        {
            this._IUserService = iUserService;
        }

        [HttpPost("dang-nhap")]
        [MapToApiVersion("1.0")]
        [AllowAnonymous]
        public async Task<ObjectResult> SignIn([FromBody] MySignInModel model)
        {
            try
            {
                MySignInResult objMySignInResult = await this._IUserService.SignIn(model);

                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<MySignInResult>(objMySignInResult));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<MySignInResult>(new MySignInResult
                {
                    Successed = false,
                    Content = ex.Message,
                    Tokens = "",
                    UserInfo = null
                }));
            }
        }

        [HttpPost("dang-ky")]
        [MapToApiVersion("1.0")]
        [Authorize()]
        public async Task<ObjectResult> SignUp([FromBody] MySignUpModel model)
        {
            try
            {
                MyServiceResult objMyServiceResult = await this._IUserService.SignUp(model);

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

        //[HttpPut("change-active")]
        //[MapToApiVersion("1.0")]
        //[Authorize(Roles = "Administrator")]
        //public async Task<ObjectResult> ChangeActive([FromQuery] string userId, [FromQuery] bool isActive)
        //{
        //    try
        //    {
        //        ServerBaseResult objServerBaseResult = await this._IUserService.ChangeActiveUser(userId, isActive);
        //        return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<ServerBaseResult>(objServerBaseResult));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<ServerBaseResult>(new ServerBaseResult
        //        {
        //            Successed = false,
        //            Content = ex.Message
        //        }));
        //    }
        //}

        [HttpDelete("xoa")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = "Administrator")]
        public async Task<ObjectResult> Delete([FromQuery] string userId)
        {
            try
            {
                MyServiceResult objMyServiceResult = await this._IUserService.Delete(userId);
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

        [HttpPut("khoi-phuc-mat-khau")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = "Administrator")]
        public async Task<ObjectResult> ResetPassword([FromQuery] string userId, [FromBody] string newPassword)
        {
            try
            {
                MyServiceResult objMyServiceResult = await this._IUserService.ResetPassword(userId, newPassword);
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

        [HttpPut("cap-nhat-thong-tin")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = "Administrator")]
        public async Task<ObjectResult> UpdateInformation([FromQuery] string userId, [FromBody] MyUpdateUserModel model)
        {
            try
            {
                MyServiceResult objMyServiceResult = await this._IUserService.UpdateInformation(userId, model);
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
        [Authorize(Roles = "Administrator")]
        public async Task<ObjectResult> GetAll()
        {
            try
            {
                MyServiceListObjectResult<MyUserInfoModel> objMyServiceListObjectResult = await this._IUserService.GetAll();
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<MyServiceListObjectResult<MyUserInfoModel>>(objMyServiceListObjectResult));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<MyServiceListObjectResult<MyUserInfoModel>>(new MyServiceListObjectResult<MyUserInfoModel>
                {
                    Successed = false,
                    Content = ex.Message
                }));
            }
        }

        [HttpGet("lay-thong-tin")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = "Administrator")]
        public async Task<ObjectResult> GetInformation([FromQuery] string userId)
        {
            try
            {
                MyServiceObjectResult<MyUserInfoModel> objMyServiceObjectResult = await this._IUserService.GetInformation(userId);
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<MyServiceObjectResult<MyUserInfoModel>>(objMyServiceObjectResult));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<MyServiceObjectResult<MyUserInfoModel>>(new MyServiceObjectResult<MyUserInfoModel>
                {
                    Successed = false,
                    Content = ex.Message
                }));
            }
        }

        [HttpGet("lay-danh-sach-chuc-vu")]
        [MapToApiVersion("1.0")]
        [Authorize(Roles = "Administrator")]
        public async Task<ObjectResult> GetAllRole()
        {
            try
            {
                MyServiceListObjectResult<MyRoleInfoModel> objMyServiceListObjectResult = await this._IUserService.GetAllRole();
                return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize<MyServiceListObjectResult<MyRoleInfoModel>>(objMyServiceListObjectResult));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, JsonSerializer.Serialize<MyServiceListObjectResult<MyRoleInfoModel>>(new MyServiceListObjectResult<MyRoleInfoModel>
                {
                    Successed = false,
                    Content = ex.Message
                }));
            }
        }
    }
}