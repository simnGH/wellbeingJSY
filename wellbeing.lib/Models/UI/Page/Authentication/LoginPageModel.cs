namespace wellbeing.Models.UI.Page.Authentication
{
    public class LoginPageModel : BasePageModel
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
