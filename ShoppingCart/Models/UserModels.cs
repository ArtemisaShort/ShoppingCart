using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public enum LoyaltyLevel
    {
        Standart,
        Silver,
        Gold
    }
    public class UserDetail
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public double AccountBalance { get; set; }
        public LoyaltyLevel Loyalty { get; set; }
    }
}