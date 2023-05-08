using Microsoft.AspNetCore.Mvc;
using Potter.Application;

namespace Potter.Web.Controllers;
[Route("customers")]
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("add")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(CustomerDto customerDto)
    {
        await _customerService.AddCustomer(customerDto);
        return RedirectToAction("Index","Home");
    }
}