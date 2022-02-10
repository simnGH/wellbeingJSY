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

        private const string COLS_SURVEYQUESTION = "sq.SurveyQuestionId, sq.SurveyId, sq.QuestionId, sq.CreatedAt, sq.UpdatedAt";

        private const string COLS_ANSWER = "a.AnswerId, a.UserId, a.QuestionId, a.Score, a.CreatedAt, a.UpdatedAt";

        //--- SQL QUERIES ---//

        private static readonly string GetSurveyIdQuery = $"SELECT {COLS_SURVEY} FROM survey s WHERE s.SurveyId = @SurveyId;";
        private static readonly string GetRandomQuestionsQuery = $"SELECT {COLS_QUESTION} FROM question q ORDER BY RAND() LIMIT 0, 5";
        private static readonly string AddQuestionIdToSurveyQuery = $"INSERT INTO surveyQuestion (sq.QuestionId) VALUES (@QuestionId)";
        private static readonly string RecordAnswerQuery = $"INSERT INTO {COLS_ANSWER} VALUES (@a.AnswerId, @a.UserId, @a.QuestionId, @a.Score, @a.CreatedAt, a.UpdatedAt)";


        //--- SQL QUERIES END ---//


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

        public async Task<DataTable> GetRandomQuestions()
        {
            DataTable questions = await this.Execute<DataTable>(GetRandomQuestionsQuery, null);
            return questions;
        }

        public async Task<DataTable> RecordAnswers()
        {
            DataTable questions = await this.Execute<DataTable>(GetRandomQuestionsQuery, null);
            return questions;
        }


    }
}