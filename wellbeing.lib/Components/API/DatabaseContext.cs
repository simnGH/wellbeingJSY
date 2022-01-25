namespace wellbeing.Components
{
    public abstract class DatabaseContext : Codentia.Common.Data.DbContext<AppSettings>
    {
        protected DatabaseContext()
            : base("wellbeing")
        {
        }
    }
}
