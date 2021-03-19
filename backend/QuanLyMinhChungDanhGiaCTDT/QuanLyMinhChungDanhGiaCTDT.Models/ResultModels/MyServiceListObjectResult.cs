using System.Collections.Generic;

namespace QuanLyMinhChungDanhGiaCTDT.Models.ResultModels
{
    public class MyServiceListObjectResult<T> : MyServiceResult
    {
        public IEnumerable<T> ListObject { get; set; }
    }
}