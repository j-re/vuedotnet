using System.Collections.Generic;
using vue.Features.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace vue.Features.Products
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Thumbnail { get; set; }
        public IEnumerable<string> Images { get; set; }
        public IEnumerable<string> Features { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public IEnumerable<SelectListItem> Colours { get; set; }
        public IEnumerable<SelectListItem> Storage { get; set; }
        public IEnumerable<ProductVariantViewModel> Variants { get; set; }
    }

    public class ProductVariantViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public int ColourId { get; set; }
        public string Colour { get; set; }
        public int StorageId { get; set; }
        public string Capacity { get; set; }
        public decimal Price { get; set; }
    }
}