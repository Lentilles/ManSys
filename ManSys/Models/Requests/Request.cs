using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManSys.Models
{
    [Table("Requests")]
    public class Request
    {
        #region system data
        
        public int Id { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public User Creator { get; set; }
        [Required]
        public string CreatorId { get; set; }

        #endregion
        
        public string? CodeName { get; set; }
        public User? Manager { get; set; }
        public string? ManagerId { get; set; }
        public User? Delivery { get; set; }
        public string? DeliveryId { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime? DeliveryDateStart { get; set; }
        public DateTime? DeliveryDateEnd { get; set; } // DeliveryDate = From; DeliveryDate + DeliveryTime = To;
        [Required]
        public List<Item> Items { get; set; }
        public List<Comment> Comments { get; set; }
        public Status? GeneralStatus { get; set; }
        public int? GeneralStatusId { get; set; }
        [NotMapped]
        public string StatusName { get { 
                if(GeneralStatus != null)
                    return GeneralStatus.Name;
                else
                {
                    return "";
                }
            
            } set { StatusName = value; } }
        public Request(string creatorId)
        {
            Created = DateTime.UtcNow;
            LastModified = DateTime.UtcNow;
            CreatorId = creatorId;
        }

        public Request(){}
    }
}