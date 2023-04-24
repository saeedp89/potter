namespace Potter.Repositories;

public interface ICustomerRepository
{
}

public class CustomerRepository : ICustomerRepository
{
    private PotterDbContext _potterDbContext;

    public CustomerRepository(PotterDbContext potterDbContext)
    {
        _potterDbContext = potterDbContext;
    }
}