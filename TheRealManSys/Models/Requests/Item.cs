using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRealManSys.Models
{
    [Table("RequestItems")]
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public uint Count { get; set; }
        [ForeignKey(nameof(StatusId))]
        public Status? Status { get; set; }
        public int? StatusId { get; set; }
        public string? Store { get; set; }
        [ForeignKey(nameof(VendorId))]
        public Contact? VendorContacts { get; set; }
        public int? VendorId { get; set; }
        [ForeignKey(nameof(RequestId))]
        public Request Request { get; set; }
        public int RequestId { get; set; }
        [NotMapped]
        public string StatusName { get { return Status.Name; } set { StatusName = value; } }



    }
}