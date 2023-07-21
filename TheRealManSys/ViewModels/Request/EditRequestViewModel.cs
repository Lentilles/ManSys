using TheRealManSys.Models;

namespace TheRealManSys.ViewModels.Request
{
    public class EditRequestViewModel
    {
        public TheRealManSys.Models.Request request { get; set; }
        public List<Status> statuses { get; set; }
        public Comment comment { get; set; }
        public List<User> users { get; set; }
    }
}
