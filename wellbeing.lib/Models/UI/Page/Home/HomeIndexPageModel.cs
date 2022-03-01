namespace wellbeing.Models.UI.Page.Home
{
    using System;
    using System.Data;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using wellbeing.Models.UI.View.Users;
    using wellbeing.Components.API.Survey;
    public class HomeIndexPageModel
    {
        public UserViewModel User { get; set; }

        public bool DisplayQuestions { get; set; }

        public List <Question> Questions {get; set; }
    }
}