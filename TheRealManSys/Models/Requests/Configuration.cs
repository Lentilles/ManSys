using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRealManSys.Models.Requests
{
    public class Configuration
    {
        [Key]
        public string key { get; set; }
        public string value { get; set; }
    }
}
