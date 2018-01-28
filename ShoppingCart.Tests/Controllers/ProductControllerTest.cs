using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart;
using ShoppingCart.Areas.Produt.Controllers;
using ShoppingCart.Controllers;
using ShoppingCart.Models;

namespace ShoppingCart.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
            List<ProductModels> result = controller.ListProducts();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
            Assert.AreEqual("T-Shirt", result.ElementAt(0).Name);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
            ProductModels result = controller.GetProduct(2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Trousers", result.Name);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
