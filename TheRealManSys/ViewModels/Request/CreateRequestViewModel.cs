using TheRealManSys.Models;

namespace TheRealManSys.ViewModels
{
    public class CreateRequestViewModel
    {
        public List<Item> Items { get; set; }
        public User Creator { get; set; }
    }
}
