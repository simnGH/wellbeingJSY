using System;
using System.Data;
using System.Collections.Generic;

namespace wellbeing.survey
{
    public class Metric
    {
        public int MetricId { get; set; }

        public string MetricName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
