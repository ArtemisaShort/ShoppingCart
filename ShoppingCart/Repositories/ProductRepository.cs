using System;
using System.Collections.Generic;
using ShoppingCart.Models;

namespace ShoppingCart.Repositories
{
    public class ProductRepository
    {
        private static ProductRepository _instance = new ProductRepository();

        private List<ProductModels> _productList = new List<ProductModels>(); //dummy for database
        private ProductRepository()
        {
            //inicialize the product list with some dummy products
            _productList.Add(new ProductModels()
            {
                Id = 1,
                Name = "T-Shirt",
                Price = 12.0,
                Description = "Dummy T-shirt Product"

            });

            _productList.Add(new ProductModels()
            {
                Id = 2,
                Name = "Trousers",
                Price = 22.0,
                Description = "Dummy Trousers Product"

            });
            _productList.Add(new ProductModels()
            {
                Id = 3,
                Name = "Cap",
                Price = 6.5,
                Description = "Dummy Cap Product"

            });
            _productList.Add(new ProductModels()
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

        public List<ProductModels> GetProduts(){
            return _productList;
        }
        public ProductModels GetProdutcById(int productId){
            return _productList.Find((prod => prod.Id == productId));
        }

        //TODO: insert/update/delete products
    }
}
