namespace GeonAPI.Domain.Entities.Common
{
    public class Translate
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; }
        public Language Language { get; set; }

    }
}