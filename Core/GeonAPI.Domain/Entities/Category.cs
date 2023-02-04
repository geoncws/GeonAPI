using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            this.CategoryTranslates = new HashSet<CategoryTranslate>();
            this.SubCategories = new HashSet<Category>();
        }
        public Nullable<Guid> CategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<CategoryTranslate> CategoryTranslates { get; set; }
        public ICollection<Category> SubCategories { get; set; }
    }
}