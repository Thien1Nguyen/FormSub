using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormSub.Models;

namespace FormSub.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create(Form newForm)
    {
        if(!ModelState.IsValid){
            return View("Index");
        }
        return RedirectToAction("Success");
    }

    [HttpGet("Success")]
    public IActionResult Success()
    {
        return View();
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
