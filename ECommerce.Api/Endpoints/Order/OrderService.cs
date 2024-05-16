using System.Collections;
using System.Collections.Generic;

namespace ECommerce.Api.Endpoints.Order
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

        public Order AddOrder AddOrder(OrderRequest order)
        {
            var newOrder = new Order(order);
            return newOrder;
        }
    }
}
