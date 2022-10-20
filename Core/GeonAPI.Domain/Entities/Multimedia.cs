using System;
using System.ComponentModel.DataAnnotations.Schema;
using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public class Multimedia: BaseEntity
    { 
        public string? FileName { get; set; }
        public string? Path { get; set; }
        public string? ContentType { get; set; }
        public string? StorageType { get; set; }
        public bool Visible { get; set; }
        public bool Deleted { get; set; }
        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}