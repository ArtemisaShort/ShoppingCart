using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderProduct> Products { get; set; }
        public int UserId { get; set; }
        public double Total { get; set; }
        public DateTime DispatchDate { get; set; }
        public DateTime OrderDate { get; set; }
        public double UserDiscount { get; set; }
        public LoyaltyLevel loyalty { get; set; }
    }

    public class OrderShort
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public double Total { get; set; }
        public DateTime DispatchDate { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class OrderProduct
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}