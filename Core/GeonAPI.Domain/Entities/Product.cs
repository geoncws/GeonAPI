using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            this.ProductTranslates = new HashSet<ProductTranslate>();
        }
        public ICollection<ProductTranslate> ProductTranslates { get; set; }
    }
}