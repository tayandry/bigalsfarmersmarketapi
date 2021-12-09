using api.Models;
using api.Data;
using System.Collections.Generic;

namespace api.Interfaces
{
    public interface IBusinessData
    {
         public List<Business> Select();

        public List<Business> SingleSelect(string email);
         public void Delete(Business business);
         public void Insert(Business business);
         public void Update(Business business);
    }
}