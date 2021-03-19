using QuanLyMinhChungDanhGiaCTDT.Models.EFModels.UserModel;
using QuanLyMinhChungDanhGiaCTDT.Models.ResultModels;
using System.Threading.Tasks;

namespace QuanLyMinhChungDanhGiaCTDT.Services.UserService.Interface
{
    public interface IUserService
    {
        public Task<MySignInResult> SignIn(MySignInModel model);

        public Task<MyServiceResult> SignUp(MySignUpModel model);


        public Task<MyServiceResult> Delete(string userId);

        public Task<MyServiceResult> ResetPassword(string userId, string password);

        public Task<MyServiceResult> UpdateInformation(string userId, MyUpdateUserModel model);

        public Task<MyServiceListObjectResult<MyUserInfoModel>> GetAll();

        public Task<MyServiceObjectResult<MyUserInfoModel>> GetInformation(string userId);

        public Task<MyServiceListObjectResult<MyRoleInfoModel>> GetAllRole();
    }
}
