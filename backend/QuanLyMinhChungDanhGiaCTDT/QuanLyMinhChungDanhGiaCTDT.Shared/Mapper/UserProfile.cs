using AutoMapper;
using QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity.Identity;
using QuanLyMinhChungDanhGiaCTDT.Models.EFModels.UserModel;

namespace QuanLyMinhChungDanhGiaCTDT.Shared.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<MyIdentityUser, MyUserInfoModel>()
                 .ForMember(x => x.MaNguoiDung, options => options.MapFrom(x => x.Id))
                 .ForMember(x => x.TenDangNhap, options => options.MapFrom(x => x.UserName))
                 .ForMember(x => x.HoTen, options => options.MapFrom(x => x.FullName))
                 .ForMember(x => x.SoDienThoai, options => options.MapFrom(x => x.PhoneNumber))
                 .ForMember(x => x.Email, options => options.MapFrom(x => x.Email))
                 .ForMember(x => x.NgaySinh, options => options.MapFrom(x => x.DateOfBirth))
                 .ForMember(x => x.DiaChi, options => options.MapFrom(x => x.Address))
                 .ReverseMap();
        }
    }
}