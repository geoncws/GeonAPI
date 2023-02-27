using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
    public class Multimedia : BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public string StorageType { get; set; } 
    }
}