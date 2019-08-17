using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ECommerce.Data.Entities
{
    public class Colour
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}