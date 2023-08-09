using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManSys.Models
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
        public Status? Status { get; set; }
        public int? StatusId { get; set; }
        public string? Store { get; set; }
        public Contact? VendorContacts { get; set; }
        public int? VendorId { get; set; }
        public Request Request { get; set; }
        public int RequestId { get; set; }
       // [NotMapped]
        //public string? StatusName { get { return Status.Name; } set { StatusName = value; } }



    }
}