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
            var customers = new List<CustomerResponse>();
            foreach (Domain.Customer customer in _db.Customers)
            {
                customers.Add(new CustomerResponse
                {
                    Id = customer.Id,
                    ContactInfo = customer.ContactInfo,
                    Cart = customer.Cart
                });
            }
            return customers;
        }

        public CustomerResponse GetCustomer(int id)
        {
            Domain.Customer customer = _db.Customers.Find((Domain.Customer c) => c.Id == id);
            return (new CustomerResponse
                {
                    Id = customer.Id,
                    ContactInfo = customer.ContactInfo,
                    Cart = customer.Cart
                });
        }

        public void DeleteCustomer(int id)
        {
            
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
