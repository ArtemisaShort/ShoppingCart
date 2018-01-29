using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ShoppingCart.Repositories
{
    public class CartRepository
    {
        private static CartRepository _instance = new CartRepository();

        private List<UserCart> _CartList = new List<UserCart>(); //dummy for database

        private CartRepository()
        { }

        public static CartRepository getCartRepository()
        {
            return _instance;
        }


        public UserCart GetCartByUserId(int userId)
        {
            var userCart = _CartList.Find((cart => cart.UserId == userId));
            if (userCart == null)
            {
                userCart = new UserCart { UserId = userId };
            }

            var userOrders = OrderRepository.getOrderRepository().GetLast12Months(userId);
            double totalOrders = userOrders.Sum(order => order.Total);

            var discount = 0.0;
            double goldGoal = double.Parse(ConfigurationManager.AppSettings["GoldGoal"] ?? "1500");
            double silverGoal = double.Parse(ConfigurationManager.AppSettings["SilverGoal"] ?? "500");
            if (totalOrders >= goldGoal)
                discount = double.Parse(ConfigurationManager.AppSettings["GoldDiscount"] ?? "2");
            else if (totalOrders>= silverGoal)
                discount = double.Parse(ConfigurationManager.AppSettings["SilverDiscount"] ?? "2");

            userCart.UserDiscount = 1.0 - (discount/100.0);

            return userCart;
        }

        public UserCart UpdateCart (UserCart userCart)
        {
            UserCart updateCart =_CartList.Find(cart => cart.UserId == userCart.UserId);
            if (updateCart == null)
                return InsertCart(userCart);
             updateCart.Products = userCart.Products;
            return updateCart;
        }
        public UserCart InsertCart (UserCart userCart)
        {
            UserCart updateCart = _CartList.Find(cart => cart.UserId == userCart.UserId);
            if (updateCart != null)
                throw new ArgumentException("Duplicate Cart");
            _CartList.Add(userCart);
            return userCart;
        }
        public bool DeleteCart(int userId)
        {
             _CartList.RemoveAll(cart => cart.UserId == userId);
            return true;
        }
    }
}