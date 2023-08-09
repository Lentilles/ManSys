using Microsoft.AspNetCore.Identity;
using ManSys.Models;

namespace ManSys.ViewModels
{
    public class RolesViewModel
    {
        public List<Role> Roles { get; set; }

        public InputRole input { get; set; }

        public class InputRole
        {
            public Role Role { get; set; }

        }
    }
}
