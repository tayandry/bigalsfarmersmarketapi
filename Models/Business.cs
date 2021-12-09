using api.Interfaces;
using api.Data;

namespace api.Models
{
    public class Business
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int BusinessID { get; set; }

        public string BusinessName { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessType { get; set; }
        public string BusinessSummary { get; set; }


        public IBusinessData businessDataHandler {get; set;}

        public Business()
        {
            businessDataHandler = new BusinessDataHandler();
        }
    }
}