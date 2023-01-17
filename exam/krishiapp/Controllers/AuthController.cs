using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using krishiapp.Models;
using BOL;
using BLL;

namespace krishiapp.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        CustomerManager cm=new CustomerManager();
        List<Customer> allcustomer=cm.getAllCustomer();
        ViewData["customers"]=allcustomer;
        return View();
    }

    public IActionResult Login()
    {
        Customer customer=new Customer();
        return View(customer);
    }
    
    [HttpPost]
    public IActionResult Login(Customer customer)
    {
        Console.WriteLine(customer.email);
        CustomerManager cm=new CustomerManager();
        if(cm.authonticateCustomer(customer))
        {
            return RedirectToAction("index","customer");
        }
        return View();
    }

    public IActionResult Register()
    {
      
        List<Customer> customer=new List<Customer>();
      
        return View(customer);
    }
    
     [HttpPost]
    public IActionResult Register(Customer customer)
    {
        CustomerManager cm=new CustomerManager();
        if(cm.InsertCustomer(customer))
        {
            Console.WriteLine("Customer Enter successfully");
            return RedirectToAction("index");
        }
      
        return View();
    }


  

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
