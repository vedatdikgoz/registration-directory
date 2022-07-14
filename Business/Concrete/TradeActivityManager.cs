using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos;

namespace Business.Concrete
{
    public class TradeActivityManager:ITradeActivityService
    {
        private readonly ITradeActivityRepository _tradeActivityRepository;
        private readonly IMapper _mapper;

        public TradeActivityManager(ITradeActivityRepository tradeActivityRepository, IMapper mapper)
        {
            _tradeActivityRepository=tradeActivityRepository;
            _mapper=mapper;
        }


        [SecuredOperation("admin,editor")]
        public async Task<IDataResult<List<TradeActivity>>> GetAllAsync()
        {
            var tradeActivities = await _tradeActivityRepository.GetAllAsync();
            return new SuccessDataResult<List<TradeActivity>>(tradeActivities, Messages.TradeActivitiesListed);
        }



        [SecuredOperation("admin,editor")]
        public async Task<IDataResult<TradeActivity>> GetByIdAsync(int id)
        {
            var tradeActivity = await _tradeActivityRepository.GetAsync(ta => ta.Id == id);
            return new SuccessDataResult<TradeActivity>(tradeActivity, Messages.TradeActivityListed);
        }


        [SecuredOperation("admin,editor")]
        public async Task<IResult> AddAsync(TradeActivityAddDto tradeActivityAddDto)
        {
            var tradeActivity = _mapper.Map<TradeActivity>(tradeActivityAddDto);
            await _tradeActivityRepository.AddAsync(tradeActivity);
            return new SuccessResult(Messages.TradeActivityAdded);
        }


        [SecuredOperation("admin,editor")]
        public async Task<IResult> UpdateAsync(TradeActivityUpdateDto tradeActivityUpdateDto)
        {
            var tradeActivity = _mapper.Map<TradeActivity>(tradeActivityUpdateDto);
            await _tradeActivityRepository.UpdateAsync(tradeActivity);
            return new SuccessResult(Messages.TradeActivityUpdated);
        }



        [SecuredOperation("admin")]
        public async Task<IResult> DeleteAsync(int tradeActivityId)
        {
            var tradeActivity = await _tradeActivityRepository.GetAsync(p => p.Id == tradeActivityId);
            if (tradeActivity != null)
            {
                await _tradeActivityRepository.DeleteAsync(tradeActivity);
                return new SuccessResult(Messages.TradeActivityDeleted);
            }
            return new ErrorResult(Messages.TradeActivityNotFound);
        }
    }
}
