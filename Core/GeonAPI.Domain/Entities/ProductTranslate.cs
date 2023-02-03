using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public partial class ProductTranslate : PageTranslateEntity
    {
        public virtual Product Product { get; set; }
    }
}