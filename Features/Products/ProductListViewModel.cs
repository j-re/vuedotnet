using System.Collections.Generic;

namespace vue.Features.Products
{
    public class ProductListViewModel
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public string Thumbnail { get; set; }
    }

    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal TalkTime { get; set; }
        public decimal StandbyTime { get; set; }
        public decimal ScreenSize { get; set; }
        public string Brand { get; set; }
        public string OS { get; set; }
        public List<string> Features { get; set; }
        public List<CreateProductVariantViewModel> Variants { get; set; }
    }

    public class CreateProductVariantViewModel
    {
        public string Colour { get; set; }
        public string Storage { get; set; }
        public decimal Price { get; set; }
    }
    public class ValidateProductViewModel
    {
        public string Name { get; set; }
    }
}