using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManSys.Models
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public User() : base() 
        {

        }
    }
}