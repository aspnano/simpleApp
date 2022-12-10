using simpleApp.Models.Abstract;
using simpleApp.Models.Contracts;

namespace simpleApp.Models
{
    // sample business entity
    public class Product : BaseEntity, IAuditableEntity, ISoftDelete
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
