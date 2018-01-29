using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class UserCart
    {
        public int UserId;
        public List<OrderProduct> Products { get; set; }
        public double UserDiscount { get; set; }
        public double Total
        {
            get
            {
                
                return Products.Sum(prod => (prod.Product.Price * prod.Quantity))*UserDiscount;
            }

        }

        public bool AddProduct(Product product) {
            OrderProduct productOrder = Products.Find(prod => prod.Product.Id == product.Id);
            if (productOrder!= null)
            {
                //product already exists, increase quantity
                productOrder.Quantity++;
            }
            else
            {
                productOrder = new OrderProduct
                {
                    Product = product,
                    Quantity = 1,
                };
                Products.Add(productOrder);
            }
            return true;
        }
        public bool RemoveProduct (int productId) {
            Products.RemoveAll(prod => prod.Product.Id == productId);
            return true;
        }
        public bool IncreaseQuantity(int productId) {
            OrderProduct productOrder = Products.Find(prod => prod.Product.Id == productId);
            if (productOrder== null)
            {
                throw new ArgumentException("Product does not exist");
            }
            productOrder.Quantity++;
            return true;
        }

        public bool DecreaseQuantity(int productId)
        {
            OrderProduct productOrder = Products.Find(prod => prod.Product.Id == productId);
            if (productOrder == null)
            {
                throw new ArgumentException("Product does not exist");
            }
            if (productOrder.Quantity <= 0)
                throw new ArgumentException("Quantity cannot be negative");
            productOrder.Quantity--;
            return true;
        }

        public bool EmptyCart ()
        {
            Products = new List<OrderProduct>();
            return true;
        }
    }
}