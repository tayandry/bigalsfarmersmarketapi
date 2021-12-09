using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Dynamic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class CustomerDataHandler : ICustomerData
    {
        private Database db;
        public CustomerDataHandler()
        {
            db = new Database();

        }
        public List<Customer> Select()
        {
            List<Customer> myCustomers = new List<Customer>();
            string sql = "SELECT * from customeraccount";
            db.Open();
            List<ExpandoObject> results = db.Select(sql);

            foreach(dynamic item in results)
            {
                Customer temp = new Customer(){Email = item.email, 
                Password = item.password,
                FullName = item.fullname,
                Address = item.address,
                CustomerID = item.customerid};

                myCustomers.Add(temp);

            }

            db.Close();
            return myCustomers;
        }

        public List<Customer> SingleCustomerSelect(string email)
        {
            List<Customer> myCustomers = new List<Customer>();
            string sql = "SELECT * from customeraccount WHERE email = '" + email + "';";
            db.Open();
            List<ExpandoObject> results = db.Select(sql);

            foreach(dynamic item in results)
            {
                Customer temp = new Customer(){
                Email = item.email, 
                Password = item.password,
                FullName = item.fullname,
                Address = item.address,
                CustomerID = item.customerid
                };
                

               myCustomers.Add(temp);

            }

            db.Close();
            return myCustomers;
        }
        

         public void Delete(Customer customer)
         {
             string sql = "DELETE FROM customeraccount WHERE (id = @id)";
             var values = GetValues(customer);
             db.Open();
             db.Insert(sql,values);
             db.Close();
         }
         public void Insert(Customer customer)
         {
             string sql = "INSERT INTO customeraccount (email, password, fullname, address)";
             sql += "VALUES (@email, @password, @fullname, @address);";

             var values = GetValues(customer);
             db.Open();
             db.Insert(sql,values);
             db.Close();
         }
         public void Update(Customer customer)
         {
             string sql = "UPDATE customeraccount SET (email=@email, password=@password, fullname=@fullname, address=@address)";
             sql += "WHERE customerid = @customerid";

             var values = GetValues(customer);
             db.Open();
             db.Insert(sql,values);
             db.Close();
         }

         public Dictionary<string,object> GetValues(Customer customer)
        {
             var values = new Dictionary<string,object>(){
                 {"@email", customer.Email},
                 {"@password", customer.Password},
                 {"@fullname", customer.FullName},
                 {"@address", customer.Address}
             };

             return values;
        }
    }
}