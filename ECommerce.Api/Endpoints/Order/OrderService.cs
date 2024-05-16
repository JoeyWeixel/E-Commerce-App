using ECommerceAPI.Domain;
using ECommerceAPI.Endpoints.Order.RequestResponse;

namespace ECommerceAPI.Endpoints.Order
{
    public class OrderService
    {

        private readonly ECommerceContext _db;
        public OrderService(ECommerceContext db) {
            _db = db;
        }

        public IEnumerable<OrderResponse> GetAllOrders()
        {

            var orders = new List<OrderResponse>();
            foreach (Domain.Order order in _db.Orders)
            {
                orders.Add(new OrderResponse
                {
                    Id = order.Id,
                    Cart = order.Cart,
                    DeliveryDate = order.DeliveryDate,
                    OrderDate = order.OrderDate,
                });
            }
            return orders;
        }

        public OrderResponse GetOrder(int id)
        {
            var order = _db.Orders.FirstOrDefault(o => o.Id == id);
            var orderResponse = new OrderResponse {
                Id = order.Id,
                Cart = order.Cart,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate,
            };
            return orderResponse;
        }

        public Domain.Order AddOrder(OrderRequest order)
        {
            var newOrder = new Domain.Order { 
                Id = order.Id,
                Cart = order.Cart,
                OrderDate = order.OrderDate
                };
            return newOrder;
        }
    }
}
