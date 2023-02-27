using System.ComponentModel.DataAnnotations;

namespace GeonAPI.Domain.Entities.Common
{
    public class PageTranslateEntity : Translate
    {
        [MaxLength(150)]
        public string? Name { get; set; }
        public int Hit { get; set; }
        [MaxLength(170)]
        public string? Slug { get; set; }
        [MaxLength(60)]
        public string? MetaTitle { get; set; }
        [MaxLength(155)]
        public string? MetaDescription { get; set; }
        [MaxLength(250)]
        public string? MetaKeywords { get; set; }
    }
}