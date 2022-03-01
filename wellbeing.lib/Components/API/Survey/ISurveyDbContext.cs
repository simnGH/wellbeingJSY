namespace wellbeing.Components.API.Survey
{
    using System;
    using System.Data;
    using System.Threading.Tasks;

    public interface ISurveyDbContext
    {
        Task<DataRow> GetSurvey(int surveyId);
        Task<DataTable> GetRandomQuestions();
        Task<int> SubmitAnswer(int userId, int questionId, int score);

        Task<DateTime> GetLastAnswerDateForUser(int userId);
    }
}