using System;
using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}