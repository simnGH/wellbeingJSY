using System;
using System.Data;
using System.Collections.Generic;

namespace wellbeing.content
{
    public class ContentModel
    {
        public int ContentId { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Img { get; set; }
    }
}