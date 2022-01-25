namespace wellbeing.Models.UI.View.Accounts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AccountViewModel
    {
        public int AccountId { get; set; }

        public int UserId { get; set; }

        public string BusinessName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressLine4 { get; set; }

        public string PostCode { get; set; }

        public string Country { get; set; }
    }
}
