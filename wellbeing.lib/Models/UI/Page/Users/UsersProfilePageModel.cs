namespace wellbeing.Models.UI.Page.Users
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using Models.UI.View.Users;

    public class UsersProfilePageModel : BasePageModel
    {
        public UsersProfilePageModel()
        {
            this.Profile = new UserViewModel();
        }

        public UserViewModel Profile { get; set; }
    }
}
