using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace QuanLyMinhChungDanhGiaCTDT.Dapper.Dapper.Interface
{
    public interface IMyDapper
    {
        public IDbConnection GetConnection();
    }
}