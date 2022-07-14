using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos;

namespace Business.Abstract
{
    public interface ITradeActivityService
    {
        Task<IDataResult<List<TradeActivity>>> GetAllAsync();
        Task<IDataResult<TradeActivity>> GetByIdAsync(int id);
        Task<IResult> AddAsync(TradeActivityAddDto tradeActivityAddDto);
        Task<IResult> UpdateAsync(TradeActivityUpdateDto tradeActivityUpdateDto);
        Task<IResult> DeleteAsync(int tradeActivityId);
    }
}
