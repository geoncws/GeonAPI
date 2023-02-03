using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public partial class Product : BaseEntity
    {
        public Product()
        {
            this.ProductTranslates = new HashSet<ProductTranslate>();
        }
        public virtual ICollection<ProductTranslate> ProductTranslates { get; set; }
    }
}