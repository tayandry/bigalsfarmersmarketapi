using api.Interfaces;
using api.Data;

namespace api.Models
{
    public class BusinessRegistration
    {
        public string Email { get; set; }

        public int EventID { get; set; }

        public int CreditCard { get; set; }

        public IBusinessRegiData businessRegiDataHandler {get; set;}

        public BusinessRegistration()
        {
            businessRegiDataHandler = new BusinessRegiDataHandler();
        }
    }
}