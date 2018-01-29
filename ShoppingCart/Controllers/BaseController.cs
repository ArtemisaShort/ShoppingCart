using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ShoppingCart.Models;
using ShoppingCart.Repositories;

namespace ShoppingCart.Controllers
{
    public class BaseController : ApiController
    {
        protected UserDetail GetUserDetail()
        {
            string userName = User.Identity.GetUserName();
            return UserRepository.getUserRepository().GetUserDetail(userName);
        }
    }
}
