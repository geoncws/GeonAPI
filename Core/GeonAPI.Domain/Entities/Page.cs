using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public partial class Page : BaseEntity
    {
        public Page()
        {
            this.PageTranslates = new HashSet<PageTranslate>();
        }
        public virtual ICollection<PageTranslate> PageTranslates { get; set; }
    }
}