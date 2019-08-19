using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vue.Data.Entities
{
    public class ProductVariant
    {
        public int ProductId { get; set; }
        public int ColourId { get; set; }
        public int StorageId { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public Colour Colour { get; set; }
        public Storage Storage { get; set; }

        public int StockLevel { get; set; } = 0;
    }

    public class ProductFeature
    {
        public int ProductId { get; set; }
        public int FeatureId { get; set; }
        public Product Product { get; set; }
        public Feature Feature { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Thumbnail { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal ScreenSize { get; set; }
        [Required]
        public decimal TalkTime { get; set; }
        [Required]
        public decimal StandbyTime { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int OSId { get; set; }
        public List<Image> Images { get; set; }
        public Brand Brand { get; set; }
        public OS OS { get; set; }

        public List<ProductFeature> ProductFeatures { get; set; } = new List<ProductFeature>();
        public List<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}