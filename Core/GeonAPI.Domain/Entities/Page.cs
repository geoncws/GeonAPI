using System;
using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public class Page : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Visible { get; set; }
    }
}