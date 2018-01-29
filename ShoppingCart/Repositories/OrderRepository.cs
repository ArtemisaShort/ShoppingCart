using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Repositories
{
    public class OrderRepository
    {
        private static OrderRepository _instance = new OrderRepository();

        private List<Order> _orderList = new List<Order>(); //dummy for database

        private OrderRepository()
        {

            var userProducts1 = new List<OrderProduct>();
            userProducts1.Add(new OrderProduct()
            {
                Product = ProductRepository.getProductRepository().GetProdutcById(2),
                Quantity = 23
            });
            DateTime orderDate1 = new DateTime(2018, 01, 20, 12, 23, 00);
            _orderList.Add(new Order()
            {
                OrderId = 1,
                Products = userProducts1.ToList(),
                UserId = 3,
                Total = userProducts1.Sum(item => item.Product.Price * item.Quantity),
                OrderDate = orderDate1,
                DispatchDate = orderDate1.AddDays(WorkDays3()),
                UserDiscount = 0,
                loyalty = LoyaltyLevel.Standart
            });

            var userProducts2 = new List<OrderProduct>();
            userProducts2.Add(new OrderProduct()
            {
                Product = ProductRepository.getProductRepository().GetProdutcById(1),
                Quantity = 100
            });
            DateTime orderDate2 = new DateTime(2018, 01, 23, 12, 23, 00);
            _orderList.Add(new Order()
            {
                OrderId = 2,
                Products = userProducts2.ToList(),
                UserId = 4,
                Total = userProducts2.Sum(item => item.Product.Price * item.Quantity),
                OrderDate = orderDate2,
                DispatchDate = orderDate2.AddDays(WorkDays3()),
                UserDiscount = 0,
                loyalty = LoyaltyLevel.Standart
            });
        }

        public static OrderRepository getOrderRepository()
        {
            return _instance;
        }


        public Order GetOrderById(int orderId, int userId)
        {
            var userOrder = _orderList.Find((order => order.OrderId == orderId && order.UserId == userId));   

            return userOrder;
        }

        public List<OrderShort> GetOrderByDates(int userId, DateTime beginDate, DateTime endate)
        {
            var userOrder = _orderList.Where((order => order.UserId == userId &&
            order.OrderDate >= beginDate && order.OrderDate <= endate));

            return userOrder.Select(order=>new OrderShort() {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                UserId = order.UserId,
                DispatchDate = order.DispatchDate,
                Total = order.Total,              
            }).ToList();
        }

        public List<OrderShort> GetLast12Months(int userId)
        {
            DateTime now = DateTime.Now;
            return GetOrderByDates(userId, now.AddMonths(-12), now);
        }

        public List<OrderShort> getUnDispatchedOrders(int userId)
        {
            var userOrder = _orderList.Where((order => order.UserId == userId && 
            order.DispatchDate >= DateTime.Now ));

            return userOrder.Select(order => new OrderShort()
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                UserId = order.UserId,
                DispatchDate = order.DispatchDate,
                Total = order.Total,
            }).ToList();

        }

        private int WorkDays3()
        {
            int[] days = { 4, 3, 3, 5, 5, 5, 5 };
            return days[(int)DateTime.Now.DayOfWeek];
        }
       
        public Order InsertOrder(UserCart newOrder)
        {

            Order userOrder = new Order()
            {
                //HACK
                OrderId = _orderList.Count()+1,
                UserId = newOrder.UserId,
                OrderDate = DateTime.Now,
                DispatchDate = DateTime.Now.AddDays(WorkDays3()),
                Products = newOrder.Products,
                Total = newOrder.Total,
                UserDiscount = newOrder.UserDiscount
            };
            _orderList.Add(userOrder);
            return userOrder;
        }
        

    }
}