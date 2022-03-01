namespace wellbeing.Models.UI.View.Accounts
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using wellbeing.Models.UI.Page.Authentication;
    using wellbeing.Models.UI.View.Accounts;
    using wellbeing.Models.UI.View.Users;

    public class AccountsEditViewModel : BaseViewModel
    {
        public AccountsEditViewModel()
        {
        }

        public AccountViewModel Account { get; set; }

        
    }
}



