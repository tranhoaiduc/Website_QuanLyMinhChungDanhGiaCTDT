using System;

namespace QuanLyMinhChungDanhGiaCTDT.Models.EFModels.UserModel
{
    public class MyUserInfoModel
    {
        public string MaNguoiDung { get; set; }
        public string HoTen { get; set; }
        public string TenDangNhap { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
    }
}