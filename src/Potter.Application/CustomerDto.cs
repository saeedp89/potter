using System.ComponentModel.DataAnnotations;
using Potter.Domain.Entities;

namespace Potter.Application;

public class CustomerDto
{
    [Required] public string? Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required] public string? Server { get; set; }
    [Required] public DateTimeOffset? LastPaidDate { get; set; }
    [Required] public DateTimeOffset? ExpirationDate { get; set; }
}