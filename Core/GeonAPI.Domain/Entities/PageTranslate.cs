using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public partial class PageTranslate : PageTranslateEntity
    {
        public virtual Page Page { get; set; }
    }
}