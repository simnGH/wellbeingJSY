namespace wellbeing.Components.API.Content
{
    using System;
    using System.Data;
    using System.Threading.Tasks;

    public interface IContentDbContext
    {
         Task<DataTable> GetContentForFeed();
    }
}