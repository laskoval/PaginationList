using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ch6Lab.Models;

namespace Ch6Lab.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult List(UserField field, int currentPage = 1, int pageSize = 10)
    {
        if (currentPage < 1 || pageSize < 1) 
        {
            return View("Index");
        }

        int skip = (currentPage - 1) * pageSize;
        var users = SortedUsers(field).Skip(skip).Take(pageSize).ToList();
        return View(users);
    }

    private IOrderedEnumerable<User> SortedUsers(UserField field)
    {
        switch (field) {
            default:
            case UserField.Name: 
                return Data.Users.OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName);
            case UserField.Phone:
                return Data.Users.OrderBy(u => u.Phone);
            case UserField.EMail:
                return Data.Users.OrderBy(u => u.EMail);
            case UserField.Address:
                return Data.Users.OrderBy(u => u.Street)
                    .ThenBy(u => u.City)
                    .ThenBy(u => u.RegionCode)
                    .ThenBy(u => u.PostalCode);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
