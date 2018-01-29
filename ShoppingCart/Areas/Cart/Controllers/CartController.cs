using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ShoppingCart.Repositories;
using ShoppingCart.Controllers;

namespace ShoppingCart.Areas.Cart.Controllers
{
    [Authorize]
    public class CartController: BaseController
    {
        private static CartRepository _cartRepo = CartRepository.getCartRepository();
        [HttpGet]
        public UserCart Get ()
        {
            UserDetail userDetail = GetUserDetail();
            UserCart userCart = _cartRepo.GetCartByUserId(userDetail.UserId);
            if (userCart != null)
            {
                return userCart;
            }
            userCart = new UserCart() { UserId = userDetail.UserId };
            return userCart;
        }

        [HttpPost]
        [Route("AddProduct")]
        public UserCart AddProduct (int productId)
        {
            UserDetail userDetail = GetUserDetail();
            UserCart userCart = _cartRepo.GetCartByUserId(userDetail.UserId);
            Product product = ProductRepository.getProductRepository().GetProdutcById(productId);
            userCart.AddProduct(product);
            _cartRepo.UpdateCart(userCart);
            return userCart;
        }

        [HttpPost]
        [Route("IncreaseQuantity")]
        public UserCart IncreaseQuantity(int productId)
        {
            UserDetail userDetail = GetUserDetail();
            UserCart userCart = _cartRepo.GetCartByUserId(userDetail.UserId);
            userCart.IncreaseQuantity(productId);
            _cartRepo.UpdateCart(userCart);
            return userCart;
        }

        [HttpPost]
        [Route("DecreaseQuantity")]
        public UserCart DecreaseQuantity(int productId)
        {
            UserDetail userDetail = GetUserDetail();
            UserCart userCart = _cartRepo.GetCartByUserId(userDetail.UserId);
            userCart.DecreaseQuantity(productId);
            _cartRepo.UpdateCart(userCart);
            return userCart;
        }

        [HttpPost]
        [Route("EmptyCart")]
        public UserCart EmptyCart(int productId)
        {
            UserDetail userDetail = GetUserDetail();
            UserCart userCart = _cartRepo.GetCartByUserId(userDetail.UserId);
            userCart.EmptyCart();
            _cartRepo.UpdateCart(userCart);
            return userCart;
        }

    }
}