using System.ComponentModel.DataAnnotations;
using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public partial class Language
    {
        public Language()
        {
            this.Translates = new HashSet<Translate>();
        }
        [Key]
        [MaxLength(5)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public bool Visible { get; set; }
        public virtual ICollection<Translate> Translates { get; set; }
    }
}