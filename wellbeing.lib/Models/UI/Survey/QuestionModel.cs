using System;

namespace wellbeing.Models.UI.Survey
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }

        public int MetricId { get; set; }

        public string QuestionText { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
