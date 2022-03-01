namespace wellbeing.Models.UI.Page.Home
{
    using wellbeing.Models.UI.Survey;
    using wellbeing.Models.UI.View.Users;
    public class HomeIndexPageModel
    {
        public UserViewModel User { get; set; }

        public bool DisplayQuestions { get; set; }

        public QuestionModel Question {get; set; }
    }
}