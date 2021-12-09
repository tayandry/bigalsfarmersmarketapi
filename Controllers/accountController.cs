using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Interfaces;
using api.Data;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class accountController : ControllerBase
    {
        // GET: api/account
        [EnableCors("AnotherPolicy")]
        [HttpGet("business", Name = "BusinessGet")]
        public List<Business> Get()
        {
            IBusinessData dataHandler = new BusinessDataHandler();
            return dataHandler.Select();
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet("event", Name = "EventGet")]
        public List<Event> EventGet()
        {
            IEventData dataHandler = new EventDataHandler();
            return dataHandler.Select();
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet("businessRegistration", Name = "bRegistrationGet")]
        public List<BusinessRegistration> BRegistrationGet()
        {
            IBusinessRegiData dataHandler = new BusinessRegiDataHandler();
            return dataHandler.Select();
        }

        [EnableCors("AnotherPolicy")]
        [HttpGet("customerRegistration", Name = "cRegistrationGet")]
        public List<CustRegistration> CRegistrationGet()
        {
            ICustRegiData dataHandler = new CustRegiDataHandler();
            return dataHandler.Select();
        }

        // GET: api/account/customer
        [EnableCors("AnotherPolicy")]
        [HttpGet("customer", Name = "CustomerGet")]
        public List<Customer> CustomerGet()
        {
            ICustomerData dataHandler = new CustomerDataHandler();
            return dataHandler.Select();
        }

        // GET: api/account/business/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("business/{email}", Name = "GetBusinessAccount")]
        public List<Business> SingleGet(string email)
        {
            Business value = new Business(){Email = email};
            return value.businessDataHandler.SingleSelect(email);
        }
        // GET: api/account/customer/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("customer/{email}", Name = "GetCustomerAccount")]
        public List<Customer> SingleCustomerGet(string email)
        {
            Customer value = new Customer(){Email = email};
            return value.customerDataHandler.SingleCustomerSelect(email);
        }

        // POST: api/account/business
        [EnableCors("AnotherPolicy")]
        [HttpPost("business",Name = "BusinessPost")]
        public void Post([FromBody] Business value)
        {
            value.businessDataHandler = new BusinessDataHandler();
            value.businessDataHandler.Insert(value);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPost("customer",Name = "CustomerPost")]
        public void Post([FromBody] Customer value)
        {
            value.customerDataHandler = new CustomerDataHandler();
            value.customerDataHandler.Insert(value);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPost("businessregistration",Name = "BusinessRegistration")]
        public void Post([FromBody] BusinessRegistration value)
        {
            value.businessRegiDataHandler = new BusinessRegiDataHandler();
            value.businessRegiDataHandler.Insert(value);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPost("customerregistration",Name = "CustomerRegistration")]
        public void Post([FromBody] CustRegistration value)
        {
            value.custRegiDataHandler = new CustRegiDataHandler();
            value.custRegiDataHandler.Insert(value);
        }

        // PUT: api/account/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("business/{id}", Name = "BusinessPut" )]
        public void Put(int id, [FromBody] Business value)
        {
            value.businessDataHandler.Update(value);
        }

        [EnableCors("AnotherPolicy")]
        [HttpPut("customer/{id}", Name = "CustomerPut")]
        public void CustomerPut(int id, [FromBody] Customer value)
        {
            value.customerDataHandler.Update(value);
        }

        // DELETE: api/account/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("business/{id}" , Name = "BusinessDelete")]
        public void Delete(int id)
        {
            Business value = new Business(){BusinessID = id};
            value.businessDataHandler.Delete(value);
        }

        [EnableCors("AnotherPolicy")]
        [HttpDelete("customer/{id}", Name = "CustomerDelete")]
        public void CustomerDelete(int id)
        {
            Customer value = new Customer(){CustomerID = id};
            value.customerDataHandler.Delete(value);
        }
    }
}
