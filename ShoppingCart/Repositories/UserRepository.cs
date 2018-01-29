using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Repositories
{
    public class UserRepository
    {
        private static UserRepository _instance = new UserRepository();

        private List<UserDetail> _UserList = new List<UserDetail>(); //dummy for database

        private UserRepository()
        {
            //inicialize the user list with some dummy users
            _UserList.Add(new UserDetail()
            {
                UserId = 1,
                UserName = "StandartClient1",
                AccountBalance = 12.0,
                Loyalty = LoyaltyLevel.Standart

            });

            _UserList.Add(new UserDetail()
            {
                UserId = 2,
                UserName = "StandartClient2",
                AccountBalance = 12.0,
                Loyalty = LoyaltyLevel.Standart

            });

            _UserList.Add(new UserDetail()
            {
                UserId = 3,
                UserName = "SilverClient",
                AccountBalance = 12.0,
                Loyalty = LoyaltyLevel.Standart

            });

            _UserList.Add(new UserDetail()
            {
                UserId = 4,
                UserName = "GoldClient",
                AccountBalance = 12.0,
                Loyalty = LoyaltyLevel.Standart

            });

            
        }

        public static UserRepository getUserRepository()
        {
            return _instance;
        }


        public UserDetail GetUserDetail(string userName)
        {
            var userDetail = _UserList.Find((user => user.UserName == userName));

            //HACK: always gets an user
            if (userName.StartsWith("gold",StringComparison.CurrentCultureIgnoreCase))
            {
                userDetail = _UserList.ElementAt(3);
            }
            else if (userName.StartsWith("silver", StringComparison.CurrentCultureIgnoreCase))
            {
                userDetail = _UserList.ElementAt(2);
            }
            else
            {
                userDetail = _UserList.ElementAt(userName.Length % 2);
            }

            if (userDetail == null)
            {
                throw new ArgumentException("invalide UserName");
            }

            //OrderRepository.Get

            return userDetail;
        }
    }
}