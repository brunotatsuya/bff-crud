using System.ComponentModel.DataAnnotations;

namespace BFF_CRUD.Models
{
    public class DynamicStatement
    {
        [Required]
        public string statement { get; set; }
        [Required]
        public string environment { get; set; }
        [Required]
        public string database { get; set; }
    }
}