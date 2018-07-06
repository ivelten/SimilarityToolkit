using SimilarityToolkit.SampleApi.Models;
using SimilarityToolkit.SampleApi.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace SimilarityToolkit.SampleApi.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        public IEnumerable<ProductModel> All()
        {
            return ProductModelRepository.Products;
        }

        [HttpPost]
        public IEnumerable<ProductModel> Similar([FromBody] ProductModel product)
        {
            return ProductModelRepository.GetSimilarProducts(product);
        }
    }
}
