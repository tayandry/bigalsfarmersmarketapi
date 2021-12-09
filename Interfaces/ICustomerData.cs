using api.Models;
using api.Data;
using System.Collections.Generic;

namespace api.Interfaces
{
    public interface ICustomerData
    {
         public List<Customer> Select();

         public List<Customer> SingleCustomerSelect(string email);
         public void Delete(Customer customer);
         public void Insert(Customer customer);
         public void Update(Customer customer);
    }
}