namespace wellbeing.Models.UI.View
{
    using System.Collections.Generic;
    using wellbeing.Models.UI.View.Accounts;
    using wellbeing.Models.UI.View.Users;

    public class BaseViewModel
    {
        public BaseViewModel()
        {
            this.ErrorMessages = new List<string>();
            this.AlertMessages = new List<string>();
        }

        public List<string> ErrorMessages { get; set; }

        public List<string> AlertMessages { get; set; }

        public AccountViewModel CurrentAccount { get; set; }

        public UserViewModel CurrentUser { get; set; }
    }
}
