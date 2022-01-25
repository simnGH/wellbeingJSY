namespace wellbeing.Models.UI.View.Accounts
{
    using Microsoft.AspNetCore.Http;

    public class AccountsNewViewModel : BaseViewModel
    {
        public AccountsNewViewModel()
        {
            this.NewAccount = new AccountViewModel();
        }

        public AccountViewModel NewAccount { get; set; }
    }
}
