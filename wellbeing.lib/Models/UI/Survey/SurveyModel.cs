using System;
using System.Data;
using System.Collections.Generic;

namespace wellbeing.survey
{
    public class Survey
    {
        public int SurveyId { get; set; }

        public string SurveyName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
