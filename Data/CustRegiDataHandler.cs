using System.Collections.Generic;
using System.Dynamic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class CustRegiDataHandler : ICustRegiData
    {
        private Database db;

        public CustRegiDataHandler()
        {
            db = new Database();
        }

        public List<CustRegistration> Select()
        {
            List<CustRegistration> myCustRegistrations = new List<CustRegistration>();
            string sql = "SELECT * from customerregistration";
            db.Open();
            List<ExpandoObject> results = db.Select(sql);

            foreach(dynamic item in results)
            {
                CustRegistration temp = new CustRegistration(){Email = item.email, 
                EventID = item.eventid
                };

                myCustRegistrations.Add(temp);

            }

            db.Close();
            return myCustRegistrations;
        }

        public void Insert(CustRegistration custRegistration)
         {
             string sql = "INSERT INTO customerregistration (email, eventid)";
             sql += "VALUES (@email, @eventid);";

             var values = GetValues(custRegistration);
             db.Open();
             db.Insert(sql,values);
             db.Close();
         }
        public Dictionary<string,object> GetValues(CustRegistration custRegistration)
         {
             var values = new Dictionary<string,object>(){
                 {"@email", custRegistration.Email},
                 {"@eventid", custRegistration.EventID}
                 

             }; 

             return values;
         }
    }
}