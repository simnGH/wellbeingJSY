using System;
using System.Data;
using System.Collections.Generic;

namespace wellbeing.survey
{
    public class SubmittedSurvey
    {
        public int SubmittedSurveyId { get; set; }

        public int UserId { get; set; }

        public int SurveyId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
