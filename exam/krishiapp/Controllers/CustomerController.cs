using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using krishiapp.Models;
using BOL;
using BLL;

namespace krishiapp.Controllers;

public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
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

    public IActionResult Details(int id)
    {
        CustomerManager cm=new CustomerManager();
        Customer customer=cm.GetCustomerById(id);
        ViewData["customer"]=customer;
        return View();
    }

    public IActionResult Delete(int id)
    {
        CustomerManager cm=new CustomerManager();
        if(cm.deleteCustomerById(id)){
            return RedirectToAction("index");
        }
        return RedirectToAction("index");
    }

    public IActionResult Update(int id)
    {
        CustomerManager cm=new CustomerManager();
        Customer customer=cm.GetCustomerById(id);
        return View(customer);
    }

    [HttpPost]
    public IActionResult Update(Customer customer)
    {
        CustomerManager cm=new CustomerManager();
        cm.updateCustomer(customer);
        return RedirectToAction("index");
    }

  

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
