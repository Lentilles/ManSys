using ManSys.Models;

namespace ManSys.ViewModels
{
    public class RequestViewModel
    {
        public List<Models.Request>? requestsForView { get; set; }

        public Input input { get; set; }

        public class Input
        {
            public int id { get; set; }
        }
    }
}
