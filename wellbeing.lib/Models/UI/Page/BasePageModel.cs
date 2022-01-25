namespace wellbeing.Models.UI.Page 
{
    using System.Collections.Generic;
    using wellbeing.Models.UI.View.Accounts;
    using wellbeing.Models.UI.View.Users;
    using wellbeing.Models.UI.Page.Authentication;
    using wellbeing.Models.UI.Page.Users;

    public class BasePageModel
    {
        public BasePageModel()
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
