using System.Collections.Generic;

namespace SimilarityToolkit.SampleApi.Models
{
    public class ProductModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<SpecificationModel> Specifications { get; set; }
    }
}