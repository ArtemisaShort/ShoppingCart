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
        [HttpGet]
        public Product GetProduct(int productId)
        {
            Product product = ProductRepository.getProductRepository().GetProdutcById(productId);

            return product;
        }

        [HttpGet]
        public List<Product> ListProducts()
        {
            var products= ProductRepository.getProductRepository().GetProduts();

            return products;
        }
    }
}
