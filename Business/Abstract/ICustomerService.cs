using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<List<Customer>>> GetAllAsync();
        Task<IDataResult<Customer>> GetByIdAsync(int id);
        Task<IResult> AddAsync(CustomerAddDto customerAddDto);
        Task<IResult> UpdateAsync(CustomerUpdateDto customerUpdateDto);
        Task<IResult> DeleteAsync(int customerId);
        Task<IResult> BulkDeleteAsync(List<int> customerIds);
        Task<IDataResult<List<CustomerDto>>> GetAllCustomersWithTradeActivityAsync();
        Task<IDataResult<List<CustomerCount>>> GetAllWhoHaveSamePhoneAsync();


    }
}
