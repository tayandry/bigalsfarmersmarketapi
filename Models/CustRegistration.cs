using api.Interfaces;
using api.Data;

namespace api.Models
{
    public class CustRegistration
    {
        public string Email { get; set; }

        public int EventID { get; set; }

        public ICustRegiData custRegiDataHandler {get; set;}

        public CustRegistration()
        {
            custRegiDataHandler = new CustRegiDataHandler();
        }
    }
}