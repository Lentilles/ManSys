using ManSys.Models;

namespace ManSys.ViewModels.Request
{
    public class EditRequestViewModel
    {
        public Models.Request request { get; set; }
        public List<Status> statuses { get; set; }
        public Comment comment { get; set; }
        public List<User> users { get; set; }
        public string DeliveryDateRange { get; set; }
    }
}
