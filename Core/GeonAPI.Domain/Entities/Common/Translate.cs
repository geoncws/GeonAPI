namespace GeonAPI.Domain.Entities.Common
{
    public partial class Translate
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; }
        public virtual Language Language { get; set; }
      
    }
}