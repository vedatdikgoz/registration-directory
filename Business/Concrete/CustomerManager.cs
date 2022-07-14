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
    
    public class CustomerManager:ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public CustomerManager(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;

        }


        [SecuredOperation("admin,editor")]
        public async Task<IDataResult<List<Customer>>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return new SuccessDataResult<List<Customer>>(customers, Messages.CustomersListed);
        }


        [SecuredOperation("admin,editor")]
        public async Task<IDataResult<Customer>> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.GetAsync(c => c.Id == id);
            return new SuccessDataResult<Customer>(customer, Messages.CustomerListed);
        }



        [SecuredOperation("admin,editor")]
        public async Task<IResult> AddAsync(CustomerAddDto customerAddDto)
        {
            var customer = _mapper.Map<Customer>(customerAddDto);
            await _customerRepository.AddAsync(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }


        [SecuredOperation("admin,editor")]
        public async Task<IResult> UpdateAsync(CustomerUpdateDto customerUpdateDto)
        {
            var customer = _mapper.Map<Customer>(customerUpdateDto);
            await _customerRepository.UpdateAsync(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }



        [SecuredOperation("admin")]
        public async Task<IResult> DeleteAsync(int customerId)
        {
            var customer = await _customerRepository.GetAsync(c => c.Id == customerId);

            if (customer != null)
            {
                await _customerRepository.DeleteAsync(customer);
                return new SuccessResult(Messages.CustomerDeleted);
            }

            return new ErrorResult(Messages.CustomerNotFound);
        }


        [SecuredOperation("admin")]
        public async Task<IResult> BulkDeleteAsync(List<int> customerIds)
        {
            foreach (var customerId in customerIds)
            {
                var customer = await _customerRepository.GetAsync(c => c.Id == customerId);
                if (customer != null)
                {
                    await _customerRepository.DeleteAsync(customer);
                }
                else
                {
                    return new ErrorResult(Messages.CustomerNotFound);
                }
                
            }
            return new SuccessResult(Messages.CustomerDeleted);
        }



        [SecuredOperation("admin,editor")]
        public async Task<IDataResult<List<CustomerDto>>> GetAllCustomersWithTradeActivityAsync()
        {
            var customers = await _customerRepository.GetAllCustomersWithTradeActivityAsync();
            return new SuccessDataResult<List<CustomerDto>>(customers, Messages.CustomersWithTradeActivityListed);
        }


        [SecuredOperation("admin,editor")]
        public async Task<IDataResult<List<CustomerCount>>> GetAllWhoHaveSamePhoneAsync()
        {
            var customers = await _customerRepository.GetAllWhoHaveSamePhoneAsync();
            return new SuccessDataResult<List<CustomerCount>>(customers, Messages.CustomersListed);
        }
    }
}
