using System.ComponentModel.DataAnnotations;

namespace BFF_CRUD.Models
{
    public class Credentials
    {
        [Required]
        public string user { get; set; }
        [Required]
        public string password { get; set; }
    }
}
