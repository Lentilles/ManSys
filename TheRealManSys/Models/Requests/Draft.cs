using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRealManSys.Models.Requests
{
    public class Draft
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public Draft()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}