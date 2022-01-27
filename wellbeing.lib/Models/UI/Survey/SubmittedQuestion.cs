using System;
using System.Data;
using System.Collections.Generic;

namespace wellbeing.survey
{
    public class SubmittedQuestion
    {
        public int SubmittedQuestionId { get; set; }

        public int UserId { get; set; }

        public int SurveyId { get; set; }

        public int QuestionId { get; set; }
        public int ScoreId { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
