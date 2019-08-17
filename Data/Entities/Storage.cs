using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ECommerce.Data.Entities
{
    public class Storage
    {
        public int Id { get; set; }
        [Required]
        public int Capacity { get; set; }
        public List<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}