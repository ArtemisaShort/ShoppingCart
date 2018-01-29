using System;
using System.Collections.Generic;
using ShoppingCart.Models;

namespace ShoppingCart.Repositories
{
    public class ProductRepository
    {
        private static ProductRepository _instance = new ProductRepository();

        private List<Product> _productList = new List<Product>(); //dummy for database
        private ProductRepository()
        {
            //inicialize the product list with some dummy products
            _productList.Add(new Product()
            {
                Id = 1,
                Name = "T-Shirt",
                Price = 15.0,
                Description = "Dummy T-shirt Product"

            });

            _productList.Add(new Product()
            {
                Id = 2,
                Name = "Trousers",
                Price = 22.0,
                Description = "Dummy Trousers Product"

            });
            _productList.Add(new Product()
            {
                Id = 3,
                Name = "Cap",
                Price = 6.5,
                Description = "Dummy Cap Product"

            });
            _productList.Add(new Product()
            {
                Id = 4,
                Name = "Boots",
                Price = 27.95,
                Description = "Dummy Boots Product"

            });
        }

        public static ProductRepository getProductRepository()
        {
            return _instance;
        }

        public List<Product> GetProduts(){
            return _productList;
        }
        public Product GetProdutcById(int productId){
            return _productList.Find((prod => prod.Id == productId));
        }

        //TODO: insert/update/delete products
    }
}
