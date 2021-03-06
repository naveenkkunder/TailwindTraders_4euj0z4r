﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using TailwindTraders.Mobile.Features.Common;

namespace TailwindTraders.Mobile.Features.Product
{
    public class FakeProductsAPI : IProductsAPI
    {
        public async Task<ProductDTO> GetDetailAsync([Header("Authorization")] string authorizationHeader, string id) =>
            await FakeNetwork.ReturnAsync(FakeProducts.Fakes.FirstOrDefault(product => product.Id.ToString() == id));

        public async Task<ProductsPerTypeDTO> GetProductsAsync(
            [Header("Authorization")] string authorizationHeader, 
            string type) =>
            await FakeNetwork.ReturnAsync(new ProductsPerTypeDTO { Products = FakeProducts.Fakes, });

        public Task<IEnumerable<ProductDTO>> GetSimilarProductsAsync(
            [Header("Authorization")] string authorizationHeader, 
            [AliasAs("file")] StreamPart stream) => Task.FromResult(FakeProducts.Fakes);
    }
}
