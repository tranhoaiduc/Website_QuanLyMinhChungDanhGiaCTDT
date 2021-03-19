using Microsoft.AspNetCore.Identity;
using System;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Entity.Identity
{
    public class MyIdentityRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}