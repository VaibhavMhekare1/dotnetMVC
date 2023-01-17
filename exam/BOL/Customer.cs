namespace BOL;
public class Customer
{
    public int cid{get;set;}
    public string cname{get;set;}
    public string address{get;set;}
    public string email{get;set;}
    public string password{get;set;}

    public Customer()
    {

    }
    public Customer(int id,string name,string addr,string em,string pass)
    {
        this.cid=id;
        this.cname=name;
        this.address=addr;
        this.email=em;
        this.password=pass;
    }

    public Customer(string name,string addr,string em,string pass)
    {
        this.cname=name;
        this.address=addr;
        this.email=em;
        this.password=pass;
    }
}
