namespace wellbeing.Components.API.Content
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;


    public class Content
    {

        public int ContentId { get; set; }

        public string Link { get; set; }

        public string Title { get; set; }

        public string Img { get; set; }

        public int MetricId { get; set; }

        public int Relevance { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


        public static async Task<List<Content>> GetContent()
        {
            DataTable table  = await ContentDbContext.Current.GetContentForFeed();

            return Content.FromDataTable(table);
        }

        public static List<Content> FromDataTable(DataTable table)
        {
            List<Content> content = new List<Content>();

            foreach (DataRow row in table.Rows)
            {
                Content c = Content.FromDataRow(row);
                content.Add(c);
            }

            return content;
        }

        public static Content FromDataRow(DataRow row)
        {
            return new Content()
            {
                Title = Convert.ToString(row["Title"]),
                Img = Convert.ToString(row["Img"]),
                Link = Convert.ToString(row["Link"])
            };
        }
    }
}
