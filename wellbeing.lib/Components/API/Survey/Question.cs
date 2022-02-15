namespace wellbeing.Components.API.Survey
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;


    public class Question
    {

        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public int MetricId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


        public static async Task<List<Question>> GetRandom()
        {
            DataTable table = await SurveyDbContext.Current.GetRandomQuestions();

            return Question.FromDataTable(table);
        }

        public static List<Question> FromDataTable(DataTable table)
        {
            List<Question> questions = new List<Question>();

            foreach (DataRow row in table.Rows)
            {
                Question q = Question.FromDataRow(row);
                questions.Add(q);
            }

            return questions;
        }

        public static Question FromDataRow(DataRow row)
        {
            return new Question()
            {
                QuestionId = Convert.ToInt32(row["QuestionId"]),
                QuestionText = Convert.ToString(row["QuestionText"])
            };
        }
    }
}
