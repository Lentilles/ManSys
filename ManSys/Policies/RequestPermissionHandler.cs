using ManSys.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ManSys.Policies
{
    public class RequestPermissionHandler : AuthorizationHandler<PermissionsRequirement>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RequestPermissionHandler(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionsRequirement requirement)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.Where(x=> x.Id == userId).FirstOrDefault();
            var roleNames = await _userManager.GetRolesAsync(user);

            foreach(var roleName in roleNames)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role.requestPermissions.HasFlag(requirement.requestPermissions))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    var authFilterContext = context.Resource as AuthorizationFilterContext;

                    if(authFilterContext != null)
                    {
                        authFilterContext.Result = new RedirectToActionResult("Index", "Home", null);
                        context.Succeed(requirement);
                    }
                    else
                    {
                        context.Fail();
                    }

                    //TODO: Add reason and view
                }
            }
        }
    }
}
