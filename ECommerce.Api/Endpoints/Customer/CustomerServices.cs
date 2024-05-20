﻿using ECommerceAPI.Domain;
using ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse;
using ECommerceAPI.Endpoints.ProductEndpoint.RequestResponse;


namespace ECommerceAPI.Endpoints.CustomerEndpoint
{
    public class CustomerService
    {

        ECommerceContext _db;
        private static int _nextCustomerId = 1;

        private readonly Dictionary<int, CartResponse> _customerCarts = new Dictionary<int, CartResponse>();

        public CustomerService(ECommerceContext db)
        {
            _db = db;
        }

        public IEnumerable<CustomerResponse> GetAllCustomers()
        {
            var customers = new List<CustomerResponse>();
            foreach (Customer customer in _db.Customers)
            {
                customers.Add(new CustomerResponse
                {
                    Id = customer.Id,
                    ContactInfo = new ContactInfoResponse
                    {
                        Name = customer.ContactInfo.Name,
                        Email = customer.ContactInfo.Email,
                        PhoneNumber = customer.ContactInfo.PhoneNumber,
                        Address = customer.ContactInfo.Address
                    }
                });
            }
            return customers;
        }

        public CustomerResponse GetCustomer(int id)
        {
            Customer customer = _db.Customers.Find((Customer c) => c.Id == id);
            return (new CustomerResponse
            {
                Id = customer.Id,
                ContactInfo = new ContactInfoResponse
                {
                    Name = customer.ContactInfo.Name,
                    Email = customer.ContactInfo.Email,
                    PhoneNumber = customer.ContactInfo.PhoneNumber,
                    Address = customer.ContactInfo.Address
                }
            });
        }

        public void DeleteCustomer(int id)
        {
            var customer = _db.Customers.First(c => c.Id == id);
            _db.Customers.Remove(customer);
        }

        public Customer AddCustomer(CustomerRequest customerRequest)
        {
            var newCustomer = new Customer
            {
                Id = _nextCustomerId++,
                ContactInfo = new ContactInfo
                {
                    Name = customerRequest.ContactInfo.Name,
                    Email = customerRequest.ContactInfo.Email,
                    PhoneNumber = customerRequest.ContactInfo.PhoneNumber,
                    Address = customerRequest.ContactInfo.Address
                },
                Cart = new Cart(),
                Orders = []

            };
            _db.Customers.Add(newCustomer);
            return newCustomer;
        }

        public IEnumerable<OrderResponse> GetAllOrders(int customerId)
        {
            Domain.Customer customer = _db.Customers.Find((Domain.Customer c) => c.Id == customerId);

            var orders = new List<OrderResponse>();
            foreach (Domain.Order order in customer.Orders)
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

        public OrderResponse GetOrder(int customerId, int orderId)
        {
            Domain.Customer customer = _db.Customers.Find((Customer c) => c.Id == customerId);

            var order = customer.Orders.Find(o => o.Id == orderId);
            var orderResponse = new OrderResponse
            {
                Id = order.Id,
                Cart = order.Cart,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate,
            };
            return orderResponse;
        }

        public Domain.Order AddOrder(int customerId, OrderRequest order)
        {
            var customer = _db.Customers.Find((Customer c) => c.Id == customerId);

            var newOrder = new Order
            {
                Id = new int(),
                Cart = customer.Cart,
                OrderDate = DateTime.Now
            };
            return newOrder;
        }
        public PaymentInfoResponse GetPaymentInfo(int customerId, int paymentId)
        {
            return new PaymentInfoResponse();
        }

        public CartResponse GetCart(int customerId)
        {
            if (!_customerCarts.ContainsKey(customerId))
            {
                _customerCarts[customerId] = new CartResponse { Id = customerId };
            }
            return _customerCarts[customerId];
        }

        public void AddProductToCart(int customerId, ProductResponse product, int quantity)
        {
            var cart = GetCart(customerId);
            if (cart.Products.ContainsKey(product))
            {
                cart.Products[product] += quantity;
            }
            else
            {
                cart.Products[product] = quantity;
            }
            UpdateTotalPrice(cart);
        }

        public void RemoveProductFromCart(int customerId, ProductResponse product, int quantity)
        {
            var cart = GetCart(customerId);
            if (cart.Products.ContainsKey(product))
            {
                cart.Products[product] -= quantity;
                if (cart.Products[product] <= 0)
                {
                    cart.Products.Remove(product);
                }
                UpdateTotalPrice(cart);
            }
        }

        public CartResponse GetCustomerCart(int customerId)
        {
            return GetCart(customerId);
        }

        private void UpdateTotalPrice(CartResponse cart)
        {
            cart.TotalPrice = cart.Products.Sum(p => p.Key.Price * p.Value);
        }
    }
}
