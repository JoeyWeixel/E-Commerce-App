﻿using ECommerceAPI.Domain;
using ECommerceAPI.Endpoints.Customer.RequestResponse;
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
                    ContactInfo = new ContactInfoResponse {
                        Name = customer.ContactInfo.Name,
                        Email = customer.ContactInfo.Email,
                        PhoneNumber = customer.ContactInfo.PhoneNumber,
                        Address = customer.ContactInfo.Address
                    }
                });
            }
            return customers;
        }

        public CustomerResponse GetCustomer(Guid id)
        {
            Domain.Customer customer = _db.Customers.Find((Domain.Customer c) => c.Id == id);
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

        public void DeleteCustomer(Guid id)
        {
            var customer = _db.Customers.First(c => c.Id == id);
            _db.Customers.Remove(customer);
        }

        public CustomerResponse AddCustomer(CustomerRequest customerRequest)
        {
            var newCustomer = new Domain.Customer
            {
                Id = new Guid(),
                ContactInfo = new ContactInfo
                {
                    Name = customerRequest.ContactInfo.Name,
                    Email = customerRequest.ContactInfo.Email,
                    PhoneNumber = customerRequest.ContactInfo.PhoneNumber,
                    Address = customerRequest.ContactInfo.Address
                },
                Cart = new Cart(),
                Orders = new List<Order>()

            };
            _db.Customers.Add(newCustomer);
            return new CustomerResponse
            {
                Id = newCustomer.Id,
                ContactInfo = new ContactInfoResponse
                {
                    Name = newCustomer.ContactInfo.Name,
                    Email = newCustomer.ContactInfo.Email,
                    PhoneNumber = newCustomer.ContactInfo.PhoneNumber,
                    Address = newCustomer.ContactInfo.Address
                }

            };
        }

        public IEnumerable<OrderResponse> GetAllOrdersForCustomer(Guid customerId)
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

        public OrderResponse GetOrderForCustomer(Guid customerId, Guid orderId)
        {
            Domain.Customer customer = _db.Customers.Find((Domain.Customer c) => c.Id == customerId);

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

        public Domain.Order AddOrder(Guid customerId, OrderRequest order)
        {
           var customer = _db.Customers.Find((Domain.Customer c) => c.Id == customerId);

            var newOrder = new Domain.Order
            {
                Id = new Guid(),
                Cart = customer.Cart,
                OrderDate = DateTime.Now
            };
            return newOrder;
        }
        public PaymentInfoResponse GetPaymentInfo(int id)
        {
            return new PaymentInfoResponse();
        }
    }

}
