namespace Post___App.Models
{
    public interface IDateTimeProvider
    {
        DateTime GetDateTime();
    }

    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}