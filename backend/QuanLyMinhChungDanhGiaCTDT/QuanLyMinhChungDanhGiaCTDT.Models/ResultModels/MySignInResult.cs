using QuanLyMinhChungDanhGiaCTDT.Models.EFModels.UserModel;

namespace QuanLyMinhChungDanhGiaCTDT.Models.ResultModels
{
    public class MySignInResult : MyServiceResult
    {
        public string? Tokens { get; set; }
        public MyUserInfoModel? UserInfo { get; set; }
    }
}

