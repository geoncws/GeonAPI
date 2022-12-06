using System;
using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Stocks { get; set; }
        public bool Visible { get; set; }
        public bool Deleted { get; set; }
        public Category Category { get; set; }
    }
}