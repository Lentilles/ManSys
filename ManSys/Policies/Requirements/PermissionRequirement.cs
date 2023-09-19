using ManSys.Models;
using Microsoft.AspNetCore.Authorization;

namespace ManSys
{
    public class PermissionsRequirement : IAuthorizationRequirement
    {
        public PermissionsRequirement(RequestPermissions requestPermissions)
        {
            this.requestPermissions = requestPermissions;
        }

        protected internal RequestPermissions requestPermissions { get;set;}

        
    }
}