using System;
using System.Data;
using System.Collections.Generic;

namespace wellbeing.content
{
    public class ContentTagModel
    {
        public int ContentTagId { get; set; }
        public int ContentId { get; set; }
        public int TagId { get; set; }

        public int Relevance { get; set; }
    }
}