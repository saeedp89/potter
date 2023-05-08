using Potter.Domain.Entities;

namespace Potter.Repositories;

public interface ICustomerRepository
{
    Task<Guid> AddEntityAsync(Customer customer);
    Task DeleteEntityAsync(Guid id);
    Task UpdateEntityAsync(Customer customer);
    Task<Customer> GetEntityByIdAsync(Guid id);
    Task<IEnumerable<Customer>> GetAllActiveCustomersAsync(DateTimeOffset expirationDate);
}