using Microsoft.AspNetCore.Identity;

namespace ManSys.Models
{
    public class Role : IdentityRole
    {
        public AdminPermissions adminPermissions { get; set; }
        public RequestPermissions requestPermissions { get; set; }
    }

    [Flags]
    public enum AdminPermissions
    {
        None = 0,
        ManageRoles = 1,
        ManageUsers = 2,
        EmailSettings = 4,
        SiteSettings = 8,
    }

    [Flags]
    public enum RequestPermissions
    {
        None = 0,
        CreateRequest = 1,
        UpdateRequest = 2,
        DeleteRequest = 4,
        ChangeStatus = 8,
        WriteComment = 16,
        AssignManager = 32,
        AssignDelivery = 64,
    }
}