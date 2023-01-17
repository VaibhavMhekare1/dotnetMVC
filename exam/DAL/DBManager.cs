using BOL;
using MySql.Data.MySqlClient;
namespace DAL;
public class DBManager
{
   private static string constring=@"server=localhost;port=3306;user=root;password=hello@123;database=krishi";                                             
   public static List<Customer> getAllCustomer()
   {
    List<Customer> allcustomer=new List<Customer>();
     MySqlConnection con=new MySqlConnection();
     con.ConnectionString=constring;
     try{
       con.Open();
       string query="select * from customer";
       MySqlCommand cmd=new MySqlCommand(query,con);
       MySqlDataReader reader=cmd.ExecuteReader();
       while(reader.Read())
       {
        int id=int.Parse(reader["cid"].ToString());
        string name=reader["cname"].ToString();
        string address=reader["address"].ToString();
        string email=reader["email"].ToString();
        string password=reader["password"].ToString();

        Customer newcust=new Customer(id,name,address,email,password);
        allcustomer.Add(newcust);
       }
     }catch(Exception e){
      Console.WriteLine("error "+e.Message);
     }finally{
        con.Close();
     }
     return allcustomer;
   }

   public static bool InsertCustomer(Customer newcust)
   {         
    string newstr=@"server=localhost;port=3306;user=root;password=hello@123;database=krishi";
    MySqlConnection con=new MySqlConnection();
    con.ConnectionString=newstr;
    bool status=false;
    try{
          con.Open();
          string query="insert into customer(cname,address,email,password) values('"+newcust.cname+"','"+newcust.address+"','"+newcust.email+"','"+newcust.password+"')";
          MySqlCommand cmd=new MySqlCommand(query,con);
          cmd.ExecuteNonQuery();
          status=true;
    }catch(Exception e)
    {
          Console.WriteLine("error "+e.Message);
    }finally{
        con.Close();
    }
    return status;
   }


   public static Customer GetCustomerByID(int id)
   {
      Customer foundcustomer=new Customer();
      MySqlConnection con=new MySqlConnection();
      con.ConnectionString=constring;
      try{
         con.Open();
         string query="select * from customer where cid="+id+"";

         MySqlCommand cmd=new MySqlCommand(query,con);
         MySqlDataReader reader=cmd.ExecuteReader();
         while(reader.Read())
         {
            int cid=int.Parse(reader["cid"].ToString());
            string name=reader["cname"].ToString();
            string address=reader["address"].ToString();
            string email=reader["email"].ToString();
            string password=reader["password"].ToString();
            foundcustomer=new Customer(cid,name,address,email,password);
                     }
      }catch(Exception e)
      {
          Console.WriteLine("error "+e.Message);
      }finally{
        con.Close();
      }
      return foundcustomer;
   }


   public static bool deleteCustomerById(int id)
   {
    bool status=false;
    MySqlConnection con=new MySqlConnection();
    con.ConnectionString=constring;
    try{
        con.Open();
        string query="delete from customer where cid="+id+"";
        MySqlCommand cmd=new MySqlCommand(query,con);
        cmd.ExecuteNonQuery();
        status=true;
    }catch(Exception e){
          Console.WriteLine("error "+e.Message);
    }finally{
        con.Close();
    }

    return status;
   }


   public static bool authonticateCustomer(Customer loggedincust)
   {
    Customer found=new Customer();
    bool status=false;
    MySqlConnection con=new MySqlConnection();
    con.ConnectionString=constring;
    try{
        con.Open();
        string query="select * from customer where email='"+loggedincust.email+"' && password='"+loggedincust.password+"'";
        MySqlCommand cmd=new MySqlCommand(query,con);
        MySqlDataReader reader=cmd.ExecuteReader();
        while(reader.Read())
        {
            int id=int.Parse(reader["cid"].ToString());
            string name=reader["cname"].ToString();
            string address=reader["address"].ToString();
            string email=reader["email"].ToString();
            string password=reader["password"].ToString();
            found=new Customer(id,name,address,email,password);
        }
        
        if(found.cid!=0)
        {
            status=true;
        }
    }catch(Exception e)
    {
          Console.WriteLine("error "+e.Message);
    }finally{
         con.Close();
    }
    return status;
   }


   public static void updateCustomer(Customer updated)
   {

    MySqlConnection con=new MySqlConnection();
    con.ConnectionString=constring;
    try{

       con.Open();
       string query="update customer set cname='"+updated.cname+"', address='"+updated.address+"', email='"+updated.email+"', password='"+updated.password+"' where cid="+updated.cid+"";
        
       MySqlCommand cmd=new MySqlCommand(query,con);
       cmd.ExecuteNonQuery();
    }catch(Exception e)
    {
           Console.WriteLine("error "+e.Message);
    }finally{
        con.Close();
    }
 
   }
}
