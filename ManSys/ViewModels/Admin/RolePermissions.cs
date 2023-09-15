using ManSys.Models;

namespace ManSys.ViewModels.Admin
{
    public class RolePermissions
    {
        public Role role { get; set; }
        public List<int> permissions { get; set; }
        
    }
}
