using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework
{
    public class EFDbContextFactory : IDesignTimeDbContextFactory<EFDbContext>
    {
        public EFDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionStrings = configBuilder.GetConnectionString("Website_QuanLyMinhChungDanhGiaCTDT");
            DbContextOptionsBuilder<EFDbContext> builder = new DbContextOptionsBuilder<EFDbContext>()
                .UseSqlServer(connectionStrings);
            return new EFDbContext(builder.Options);
        }
    }
}