using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Potter.Application;
using Potter.Domain.Entities;
using Potter.Web.Models;

namespace Potter.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICustomerService _customerService;

    public HomeController(ILogger<HomeController> logger, ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    public async Task<IActionResult> Index()
    {
        var customers = await _customerService
            .GetAllActiveUsers(DateTimeOffset.Now);
        return View(model: customers);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}