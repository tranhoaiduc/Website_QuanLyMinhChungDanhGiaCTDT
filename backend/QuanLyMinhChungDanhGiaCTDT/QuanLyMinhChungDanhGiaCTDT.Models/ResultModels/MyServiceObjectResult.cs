namespace QuanLyMinhChungDanhGiaCTDT.Models.ResultModels
{
    public class MyServiceObjectResult<T> : MyServiceResult
    {
        public T Object { get; set; }
    }
}