namespace wellbeing.Components.API.Survey
{
    using System.Data;
    using System.Threading.Tasks;

    public interface ISurveyDbContext
    {
        Task<DataRow> GetSurvey(int surveyId);

    }
}
