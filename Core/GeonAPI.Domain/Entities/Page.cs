using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public class Page : BaseEntity
    {
        public Page()
        {
            this.PageTranslates = new HashSet<PageTranslate>();
        }
        public ICollection<PageTranslate> PageTranslates { get; set; }
    }
}