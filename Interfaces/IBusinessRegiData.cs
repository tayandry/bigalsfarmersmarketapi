using System.Collections.Generic;
using api.Models;
using api.Data;

namespace api.Interfaces
{
    public interface IBusinessRegiData
    {

        public void Insert(BusinessRegistration businessRegistration);
         public List<BusinessRegistration> Select();
    }
}