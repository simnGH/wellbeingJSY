using System;
using System.Data;
using System.Collections.Generic;
using wellbeing.Components;

namespace wellbeing.survey
{
    public class SurveyQuestion
    {
        public int SurveyQuestionId { get; set; }

        public int SurveyId { get; set; }

        public int QuestionId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
