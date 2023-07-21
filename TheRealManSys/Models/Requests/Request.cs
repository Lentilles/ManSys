using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRealManSys.Models
{
    [Table("Requests")]
    public class Request
    {
        #region system data
        
        public int Id { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        [ForeignKey(nameof(CreatorId))]
        public User Creator { get; set; }
        public string CreatorId { get; set; }

        #endregion
        
        public string? CodeName { get; set; }
        [ForeignKey(nameof(ManagerId))]
        public User? Manager { get; set; }
        public string? ManagerId { get; set; }
        [ForeignKey(nameof(DeliveryId))]
        public User? Delivery { get; set; }
        public string? DeliveryId { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime? DeliveryDateStart { get; set; }
        public DateTime? DeliveryDateEnd { get; set; } // DeliveryDate = From; DeliveryDate + DeliveryTime = To;
        [Required]
        [InverseProperty(nameof(Item.Request))]
        public List<Item> Items { get; set; }
        public List<Comment> Comments { get; set; }
        [ForeignKey(nameof(StatusId))]
        public Status? GeneralStatus { get; set; }
        public int? StatusId { get; set; }
        [NotMapped]
        public string StatusName { get { return GeneralStatus.Name; } set { StatusName = value; } }
        public Request(string creatorId)
        {
            Created = DateTime.UtcNow;
            LastModified = DateTime.UtcNow;
            CreatorId = creatorId;
        }

        public Request(){}
    }
}