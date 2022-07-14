
namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult  //message ve success bilgisi IResult tan gelir.
    {
        T Data { get; }
    }
}
