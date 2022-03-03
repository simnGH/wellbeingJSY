namespace wellbeing.Components.API.Survey
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;


    public class Answer

    {

        public int AnswerId { get; set; }

        public int UserId { get; set; }

        public int QuestionId { get; set; }

        public int Score { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

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

        public async Task Save()
        {
            if (this.AnswerId == 0)
            {
                this.AnswerId = await SurveyDbContext.Current.SubmitAnswer(this.UserId, this.QuestionId, this.Score);
            }
        }


        public static async Task<DateTime> GetLastAnswerDateForUser(int userId)
        {
            DateTime? date = await SurveyDbContext.Current.GetLastAnswerDateForUser(userId);

            return date == null ? DateTime.MinValue : (DateTime)date;
        }

        public static async Task UpdateScoreForUser(int userId)
        {
            await Task.Delay(0);
        }
    }
}