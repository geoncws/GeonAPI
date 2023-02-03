using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public partial class Category : BaseEntity
    {
        public Category()
        {
            this.CategoryTranslates = new HashSet<CategoryTranslate>();
            this.SubCategories = new HashSet<Category>();
        } 
        public Nullable<Guid> CategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<CategoryTranslate> CategoryTranslates { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
    }
}