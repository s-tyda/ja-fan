using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ja_fan.Models;
using Microsoft.AspNetCore.Authorization;

namespace ja_fan.Controllers;

public class AdminPanelController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    public AdminPanelController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
    
    [Authorize]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}