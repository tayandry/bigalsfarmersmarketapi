using System.Collections.Generic;
using System.Dynamic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class BusinessRegiDataHandler : IBusinessRegiData
    {
        private Database db;

        public BusinessRegiDataHandler()
        {
            db = new Database();
        }

        public List<BusinessRegistration> Select()
        {
            List<BusinessRegistration> myBRegistrations = new List<BusinessRegistration>();
            string sql = "SELECT * from businessregistration";
            db.Open();
            List<ExpandoObject> results = db.Select(sql);

            foreach(dynamic item in results)
            {
                BusinessRegistration temp = new BusinessRegistration(){
                    Email = item.email, 
                    EventID = item.eventid, 
                    CreditCard =  item.creditcard};

                myBRegistrations.Add(temp);

            }

            db.Close();
            return myBRegistrations;
        }

        public void Insert(BusinessRegistration businessRegistration)
         {
             string sql = "INSERT INTO businessregistration (email, eventid, creditcard)";
             sql += "VALUES (@email, @eventid, @creditcard);";

             var values = GetValues(businessRegistration);
             db.Open();
             db.Insert(sql,values);
             db.Close();
         }

        public Dictionary<string,object> GetValues(BusinessRegistration businessRegistration)
         {
             var values = new Dictionary<string,object>(){
                 {"@email", businessRegistration.Email},
                 {"@eventid", businessRegistration.EventID},
                 {"@creditcard", businessRegistration.CreditCard}
             };

             return values;
         }
    }
}