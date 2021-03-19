using Microsoft.Extensions.Configuration;
using QuanLyMinhChungDanhGiaCTDT.Dapper.Dapper.Interface;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyMinhChungDanhGiaCTDT.Dapper.Dapper
{
    public class MyDapper : IMyDapper
    {
        public IDbConnection GetConnection()
        {
            IConfigurationRoot configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionStrings = configurationBuilder.GetConnectionString("Website_QuanLyMinhChungDanhGiaCTDT");
            return new SqlConnection(connectionStrings);
        }
    }
}