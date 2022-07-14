using Core.DataAccess.EntityFrameworkCore;
using Entities.Concrete;
using Entities.Concrete.Dtos;

namespace DataAccess.Abstract
{
    public interface ICustomerRepository:IEntityRepository<Customer>
    {
        Task<List<CustomerDto>> GetAllCustomersWithTradeActivityAsync();
        Task<List<CustomerCount>> GetAllWhoHaveSamePhoneAsync();
       
    }
}
