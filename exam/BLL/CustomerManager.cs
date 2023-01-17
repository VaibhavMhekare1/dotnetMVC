using BOL;
using DAL;
namespace BLL;
public class CustomerManager
{
    public List<Customer> getAllCustomer()
    {
         List<Customer> allcustomer=DBManager.getAllCustomer();
         return allcustomer;
    }

    public bool InsertCustomer(Customer cust)
    {
        return DBManager.InsertCustomer(cust);
    }

    public Customer GetCustomerById(int id)
    {
        return DBManager.GetCustomerByID(id);
    }

    public bool deleteCustomerById(int id)
    {
        return DBManager.deleteCustomerById(id);
    }

     public bool authonticateCustomer(Customer cust)
    {
        return DBManager.authonticateCustomer(cust);
    }

    public void updateCustomer(Customer updated){
         DBManager.updateCustomer(updated);
    }


}