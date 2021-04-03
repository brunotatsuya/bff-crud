using System.ComponentModel.DataAnnotations;

namespace BFF_CRUD.Models
{
    public class ClientCredentials
    {
        [Required]
        public string client_id { get; set; }
    }
}
