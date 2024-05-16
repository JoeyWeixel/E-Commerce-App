using ECommerceAPI.Domain;
using ECommerceAPI.Endpoints.Customer.RequestResponse.Customer;
using ECommerceAPI.Endpoints.Customer.RequestResponse.Order;
using ECommerceAPI.Endpoints.PaymentInfo.RequestResponse;

namespace ECommerceAPI.Endpoints.Customer
{
    public class CustomerService
    {

        ECommerceContext _db;
        public CustomerService(ECommerceContext db) { 
            _db = db;
        }

        public IEnumerable<CustomerResponse> GetAllCustomers()
        {
            //TODO: Reference database which is yet to be created
            var products = new List<CustomerResponse>();
            return products;
        }

        public CustomerResponse GetCustomer(int id)
        {
            //TODO query database
            return new CustomerResponse();
        }

        public void DeleteCustomer(int id)
        {
            //TODO
        }

        public CustomerResponse AddCustomer(CustomerRequest customerRequest)
        {


            return new CustomerResponse
            {
                Id = customerRequest.Id,
                ContactInfo = customerRequest.ContactInfo,

            };
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
            var orderResponse = new OrderResponse
            {
                Id = order.Id,
                Cart = order.Cart,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate,
            };
            return orderResponse;
        }

        public Domain.Order AddOrder(OrderRequest order)
        {
            var newOrder = new Domain.Order
            {
                Id = order.Id,
                Cart = order.Cart,
                OrderDate = order.OrderDate
            };
            return newOrder;
        }
        public PaymentInfoResponse GetPaymentInfo(int id)
        {
            //TODO query database
            return new PaymentInfoResponse();
        }
    }

}
