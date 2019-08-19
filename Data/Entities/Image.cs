using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace vue.Data.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [Required]
        public string Url { get; set; }
        public Product Product { get; set; }
    }
}