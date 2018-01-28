using ShoppingCart.Models;
using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingCart.Areas.Produt.Controllers
{
    public class ProductController : ApiController
    {
        public ProductModels GetProduct(int productId)
        {
            ProductModels product = ProductRepository.getProductRepository().GetProdutcById(productId);

            return product;
        }
        public List<ProductModels> ListProducts()
        {
            var products= ProductRepository.getProductRepository().GetProduts();

            return products;
        }
    }
}
