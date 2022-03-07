namespace wellbeing.Components.API.Content
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Codentia.Common.Data;

    public class ContentDbContext : DatabaseContext, IContentDbContext
    {
        private const string COLS_CONTENT = "c.ContentId, c.Link, c.Title, c.Img, c.MetricId, c.Relevance, c.CreatedAt, c.UpdatedAt";

        //--- SQL QUERIES ---//

        private static readonly string GetContentQuery = $"SELECT {COLS_CONTENT} FROM content";
        private static readonly string GetContentByRelevanceScoreQuery = $"SELECT {COLS_CONTENT} FROM content s WHERE c.ContentId = @ContentId;";


        //--- SQL QUERIES END ---//


        public static IContentDbContext Current { get; set; }

        public async Task<DataTable> GetContentForFeed()
        {
            DataTable content = await this.Execute<DataTable>(GetContentQuery, null);
            return content;
        }

        public async Task<DataTable> GetContentByRelevance(int score)
        {
            DataTable questions = await this.Execute<DataTable>(GetContentByRelevanceScoreQuery, null);
            return questions;
        }
    }
}