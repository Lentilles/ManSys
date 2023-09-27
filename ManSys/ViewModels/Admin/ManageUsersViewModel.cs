using ManSys.Models;

namespace ManSys.ViewModels.Admin{

    public class ManageUsersViewModel{
        public List<User> Users {get; set;}
        public List<string> IdsForChange { get; set;}
    }
}