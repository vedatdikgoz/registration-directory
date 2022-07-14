using Core.DataAccess.EntityFrameworkCore;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class CustomerRepository:EntityRepositoryBase<Customer, DataContext>, ICustomerRepository
    {
        public async Task<List<CustomerDto>> GetAllCustomersWithTradeActivityAsync()
        {
            using (var context = new DataContext())
            {
               
                var result = from c in context.Customers
                    join ta in context.TradeActivities
                        on c.Id equals ta.CustomerId
                             select new CustomerDto
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Phone = c.Phone,
                        City = c.City,
                        TradeActivities = c.TradeActivities
                    };
                return await result.ToListAsync();
            }
        }


        public async Task<List<CustomerCount>> GetAllWhoHaveSamePhoneAsync()
        {
            using (var context = new DataContext())
            {
                var result = from c in context.Customers
                             group c by c.Phone into g
                             select new CustomerCount
                             {
                                 Phone = g.Key,
                                 CustomerNumber = g.Count(),
                                 Customer = (from c in context.Customers
                                           where c.Phone == g.Key
                                           select c.FirstName + " " + c.LastName).ToList()
                             };
                return await result.ToListAsync();
            }
        }

    }
}
