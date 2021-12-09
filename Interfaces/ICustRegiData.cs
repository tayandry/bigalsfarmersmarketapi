using System.Collections.Generic;
using api.Models;
using api.Data;

namespace api.Interfaces
{
    public interface ICustRegiData
    {
         public List<CustRegistration> Select();

         public void Insert(CustRegistration custRegistration);
    }
}