﻿namespace QuanLyMinhChungDanhGiaCTDT.Models.EFModels.UserModel
{
    public class MyUpdateUserModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public string Role { get; set; }
    }
}