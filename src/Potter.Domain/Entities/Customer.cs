using System.Security.AccessControl;

namespace Potter.Domain.Entities;

public class Customer : PotterBaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Server { get; set; }
    public DateTimeOffset LastPaidDate { get; set; }
    public DateTimeOffset ExpirationDate { get; set; }


}