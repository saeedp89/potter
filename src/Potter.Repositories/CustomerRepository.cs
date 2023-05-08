using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Potter.Domain.Entities;

namespace Potter.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly PotterDbContext _potterDbContext;

    public CustomerRepository(PotterDbContext potterDbContext)
    {
        _potterDbContext = potterDbContext;
    }

    public async Task<Guid> AddEntityAsync(Customer customer)
    {
        await _potterDbContext.Customers.AddAsync(customer);
        await _potterDbContext.SaveChangesAsync();
        return customer.Id;
    }

    public async Task DeleteEntityAsync(Guid id)
    {
        var customer = await GetEntityByIdAsync(id);
        if (customer == null)
            throw new Exception("No customer found with this id");
        _potterDbContext.Customers.Remove(customer);
        await _potterDbContext.SaveChangesAsync();
    }

    public async Task UpdateEntityAsync(Customer customer)
    {
        _potterDbContext.Customers.Update(customer);
        await _potterDbContext.SaveChangesAsync();
    }

    public async Task<Customer> GetEntityByIdAsync(Guid id)
    {
        return await _potterDbContext.Customers.FindAsync(id) ??
               throw new Exception("No customer found with this id");
    }

    public async Task<IEnumerable<Customer>> GetAllActiveCustomersAsync(DateTimeOffset expirationDate)
    {
        var customers = _potterDbContext.Customers
            .Where(x =>
                x.ExpirationDate > expirationDate &&
                (x.IsDeleted == null || !x.IsDeleted.Value));
        return await customers.ToListAsync();
    }
}