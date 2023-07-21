using Microsoft.AspNetCore.Identity;
using TheRealManSys.Models;

namespace TheRealManSys.ViewModels
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
