using System.ComponentModel.DataAnnotations.Schema;

namespace TheRealManSys.Models.Requests
{
    public class DraftItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public uint Count { get; set; }
        public string CountType { get; set; }
        [ForeignKey(nameof(draftId))]
        public Draft draft { get; set; }
        public string draftId { get; set; }
    }
}
