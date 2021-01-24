using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BFF_CRUD.Models
{
    public class ClientCredentials
    {
        [Required]
        public string client_id { get; set; }
    }
}
