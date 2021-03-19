using Microsoft.AspNetCore.Identity;
using System;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity.Identity
{
    public class MyIdentityUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}