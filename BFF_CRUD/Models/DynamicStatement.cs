using System.ComponentModel.DataAnnotations;

namespace BFF_CRUD.Models
{
    public class DynamicStatement
    {
        [Required]
        public string statement { get; set; }
    }
}