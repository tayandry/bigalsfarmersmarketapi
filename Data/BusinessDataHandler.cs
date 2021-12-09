using System.Data.Common;
using System.Collections.Generic;
using System.Dynamic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class BusinessDataHandler : IBusinessData
    {
        private Database db;
        public BusinessDataHandler()
        {
            db = new Database();

        }
        public List<Business> Select()
        {
            List<Business> myBusinesses = new List<Business>();
            string sql = "SELECT * from businessaccount;";
            db.Open();
            List<ExpandoObject> results = db.Select(sql);

            foreach(dynamic item in results)
            {
                Business temp = new Business(){
                Email = item.email, 
                Password = item.password,
                FullName = item.fullname,
                Address = item.address,
                BusinessID = item.businessid,
                BusinessName = item.businessName,
                BusinessAddress = item.businessAddress,
                BusinessType = item.businessType,
                BusinessSummary = item.businessSummary};
                

                myBusinesses.Add(temp);

            }

            db.Close();
            return myBusinesses;
        }

        public List<Business> SingleSelect(string email)
        {
            List<Business> myBusinesses = new List<Business>();
            string sql = "SELECT * from businessaccount WHERE email = '" + email + "';";
            db.Open();
            List<ExpandoObject> results = db.Select(sql);

            foreach(dynamic item in results)
            {
                Business temp = new Business(){
                Email = item.email, 
                Password = item.password,
                FullName = item.fullname,
                Address = item.address,
                BusinessID = item.businessid,
                BusinessName = item.businessName,
                BusinessAddress = item.businessAddress,
                BusinessType = item.businessType,
                BusinessSummary = item.businessSummary};
                

               myBusinesses.Add(temp);

            }

            db.Close();
            return myBusinesses;
        }

         public void Delete(Business business)
         {
            string sql = "DELETE FROM businessaccount WHERE (businessid = @id);";
             var values = GetValues(business);
             db.Open();
             db.Insert(sql,values);
             db.Close();
         }
         public void Insert(Business business)
         {
             string sql = "INSERT INTO businessaccount (email, password, fullname, address, businessName, businessAddress, businessType, businessSummary)";
             sql += "VALUES (@email, @password, @fullname, @address, @businessName, @businessAddress, @businessType, @businessSummary);";

             var values = GetValues(business);
             db.Open();
             db.Insert(sql,values);
             db.Close();
         }
         public void Update(Business business)
         {
            string sql = "UPDATE businessaccount SET (email=@email, password=@password, fullname=@fullname, address=@address)";
            sql += "WHERE businessid = @businessid;";

             var values = GetValues(business);
             db.Open();
             db.Insert(sql,values);
             db.Close();
         }

         public Dictionary<string,object> GetValues(Business business)
         {
             var values = new Dictionary<string,object>(){
                 {"@email", business.Email},
                 {"@password", business.Password},
                 {"@fullname", business.FullName},
                 {"@address", business.Address},
                {"@businessName", business.BusinessName},
                {"@businessAddress", business.BusinessAddress},
                {"@businessType", business.BusinessType},
                {"@businessSummary", business.BusinessSummary},
                {"@businessid", business.BusinessID}

             }; 

             return values;
         }
    }
}