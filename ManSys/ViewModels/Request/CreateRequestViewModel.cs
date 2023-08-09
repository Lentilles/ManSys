using ManSys.Models;

namespace ManSys.ViewModels
{
    public class CreateRequestViewModel
    {
        public List<Item> Items { get; set; }
        public User Creator { get; set; }
    }
}
