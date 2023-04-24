using Potter.Domain.Entities;
using Potter.Repositories;

namespace Potter.Application;

public interface ICustomerService
{
    IEnumerable<Customer> GetAllActiveUsers();
}

public class CustomerService : ICustomerService
{
    private ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public IEnumerable<Customer> GetAllActiveUsers()
    {
        
    }
}