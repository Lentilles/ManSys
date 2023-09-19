using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Нет прав для работы с заявками")]
        None = 0,
        [Display(Name = "Создавать запросы")]
        CreateRequest = 1,
        [Display(Name = "Обновлять запросы")]
        UpdateRequest = 2,
        [Display(Name = "Удалять запросы")]
        DeleteRequest = 4,
        [Display(Name = "Изменять статус")]
        ChangeStatus = 8,
        [Display(Name = "Писать комментарии")]
        WriteComment = 16,
        [Display(Name = "Назначать ответственного")]
        AssignManager = 32,
        [Display(Name = "Назначать доставку")]
        AssignDelivery = 64,
    }
}