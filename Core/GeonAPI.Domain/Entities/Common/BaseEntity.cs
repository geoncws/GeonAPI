namespace GeonAPI.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        virtual public DateTime UpdatedDate { get; set; }

        public bool Deleted { get; set; }

        public bool Visible { get; set; }
    }
}