using SimilarityToolkit.Evaluators.Generic;
using SimilarityToolkit.SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimilarityToolkit.SampleApi.Repository
{
    public static class ProductModelRepository
    {
        public static readonly List<ProductModel> Products = new List<ProductModel>
        {
            new ProductModel
            {
                Name = "Cerveja",
                Price = 12.60m,
                Specifications = new List<SpecificationModel>
                {
                    new SpecificationModel { Name = "Volume", Value = "350" }
                }
            },
            new ProductModel
            {
                Name = "Cerveja",
                Price = 8.00m,
                Specifications = new List<SpecificationModel>
                {
                    new SpecificationModel { Name = "Volume", Value = "350" }
                }
            },
            new ProductModel
            {
                Name = "Camisa",
                Price = 36.90m,
                Specifications = new List<SpecificationModel>
                {
                    new SpecificationModel { Name = "Cor", Value = "Azul" },
                    new SpecificationModel { Name = "Tamanho", Value = "M" }
                }
            },
            new ProductModel
            {
                Name = "Camisa",
                Price = 36.90m,
                Specifications = new List<SpecificationModel>
                {
                    new SpecificationModel { Name = "Cor", Value = "Vermelho" },
                    new SpecificationModel { Name = "Tamanho", Value = "G" }
                }
            }
        };

        public static IEnumerable<ProductModel> GetSimilarProducts(ProductModel product)
        {
            var evaluations = new List<Tuple<decimal, ProductModel>>();
            var evaluator = new SimilarityEvaluator<ProductModel>();

            foreach (var repositoryProduct in Products)
            {
                var distance = evaluator.EvaluateDistance(product, repositoryProduct);
                evaluations.Add(new Tuple<decimal, ProductModel>(distance, repositoryProduct));
            }

            return evaluations.OrderBy(e => e.Item1).Select(e => e.Item2).Take(2);
        }
    }
}