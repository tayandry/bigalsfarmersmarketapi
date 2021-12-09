using api.Interfaces;
using api.Data;

namespace api.Models
{
    public class Customer
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int CustomerID { get; set; }

        public ICustomerData customerDataHandler {get; set;}

        public Customer()
        {
            customerDataHandler = new CustomerDataHandler();
        }
    }
}