﻿using System.Collections.Generic;
using ECommerceAPI.Endpoints.Order.RequestResponse;

namespace ECommerceAPI.Endpoints.Order
{
    public class OrderService
    {
        public OrderService() { }

        public IEnumerable<OrderResponse> GetAllOrders()
        {
            var orders = new List<OrderResponse>();
            return orders;
        }

        public OrderResponse GetOrder(int id)
        {
            var order = new OrderResponse();
            return order;
        }

        public Domain.Order AddOrder(OrderRequest order)
        {
            var newOrder = new Domain.Order();
            return newOrder;
        }
    }
}
