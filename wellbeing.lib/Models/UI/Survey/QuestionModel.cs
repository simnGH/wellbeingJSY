using System;
using System.Data;
using System.Collections.Generic;

namespace wellbeing.survey
{
    public class Question
    {
        public int QuestionId { get; set; }

        public int MetricId { get; set; }

        public string QuestionText { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
