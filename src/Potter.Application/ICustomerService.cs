using AutoMapper;
using Potter.Domain.Entities;
using Potter.Repositories;

namespace Potter.Application;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllActiveUsers(DateTimeOffset exDate);
    Task<Guid> AddCustomer(CustomerDto customerDto);
}

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllActiveUsers(DateTimeOffset exDate)
    {
        var customers = await _customerRepository.GetAllActiveCustomersAsync(exDate);
        var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
        return customerDtos;
    }

    public async Task<Guid> AddCustomer(CustomerDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        return await _customerRepository.AddEntityAsync(customer);
    }
}