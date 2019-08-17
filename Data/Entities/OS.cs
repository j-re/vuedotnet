using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ECommerce.Data.Entities
{
    public class OS
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Product> Products = new List<Product>();
    }
}