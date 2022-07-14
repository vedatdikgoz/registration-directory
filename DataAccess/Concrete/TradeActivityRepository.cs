using Core.DataAccess.EntityFrameworkCore;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;


namespace DataAccess.Concrete
{
    public class TradeActivityRepository:EntityRepositoryBase<TradeActivity,DataContext>, ITradeActivityRepository
    {
    }
}
