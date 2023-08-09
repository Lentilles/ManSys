using System.ComponentModel.DataAnnotations.Schema;

namespace ManSys.Models
{
    [Table("RequestComments")]
    public class Comment
    {
        public int Id { get; set; }
        [ForeignKey(nameof(CreatorId))]
        public User Creator { get; set; }
        public string CreatorId { get; set; }
        [ForeignKey(nameof(ReplyId))]
        public User Reply { get; set; }
        public string ReplyId { get; set; }
        public string Text { get; set; }
        [ForeignKey(nameof(RequestId))] 
        public Request Request { get; set; }
        public int RequestId { get; set; }
    }
}