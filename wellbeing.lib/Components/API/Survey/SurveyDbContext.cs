namespace wellbeing.Components.API.Survey
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Codentia.Common.Data;

    public class SurveyDbContext : DatabaseContext, ISurveyDbContext
    {
        private const string COLS_SURVEY = "s.SurveyId, s.SurveyName, s.CreatedAt, s.UpdatedAt";

        private const string COLS_QUESTION = "q.QuestionId, q.QuestionText, q.MetricId, q.CreatedAt, q.UpdatedAt";

        private static readonly string GetSurveyIdQuery = $"SELECT {COLS_SURVEY} FROM survey s WHERE s.SurveyId = @SurveyId;";

        private static readonly string GetQuestionsForSurveyQuery = $"SELECT @QuestionText FROM question ORDER BY RAND() LIMIT 0, 3";


        public static ISurveyDbContext Current { get; set; }

        public async Task<DataRow> GetSurvey(int surveyId)
        {
            DbParameter[] parameters =
            {
                new DbParameter("@SurveyId", DbType.Int32, surveyId),
            };

            DataTable result = await this.Execute<DataTable>(GetSurveyIdQuery, parameters);
            return result.AsEnumerable().FirstOrDefault();
        }

        public async Task<DataRow> GetQuestionsForSurvey(string questionText)
        {
            DbParameter[] parameters =
            {
                new DbParameter("@QuestionText", DbType.String, questionText),
            };

            DataTable questions = await this.Execute<DataTable>(GetQuestionsForSurveyQuery, parameters);
            return questions.AsEnumerable().FirstOrDefault();
        }
    }
}