﻿using ECommerceAPI.Domain;
using ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceAPI.Endpoints.CustomerEndpoint
{
    public class CustomerService
    {
        private readonly ECommerceContext _db;

        public CustomerService(ECommerceContext db)
        {
            _db = db;
        }

        public IEnumerable<CustomerResponse> GetAllCustomers()
        {
            var customers = _db.Customer
                .Include(customer => customer.ContactInfo)
                .ToList();

            return customers.Select(customer => new CustomerResponse(customer)).ToList();
        }

        public CustomerResponse GetCustomer(int id)
        {
            var customer = _db.Customer
                .Include(customer => customer.ContactInfo)
                .SingleOrDefault(customer => customer.Id == id);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            return new CustomerResponse(customer);
        }

        public CustomerResponse DeleteCustomer(int id)
        {
            var customer = _db.Customer
                .Include(c => c.ContactInfo)
                .Include(c => c.Cart)
                .Include(c => c.Orders)
                .Include(c => c.PaymentInfos)
                .FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            _db.Customer.Remove(customer);
            _db.SaveChanges();
            return new CustomerResponse(customer);
        }

        public CustomerResponse AddCustomer(CustomerRequest customerRequest)
        {
            var newCustomer = new Customer
            {
                ContactInfo = new ContactInfo
                {
                    Name = customerRequest.ContactInfo.Name,
                    Email = customerRequest.ContactInfo.Email,
                    PhoneNumber = customerRequest.ContactInfo.PhoneNumber,
                    Address = customerRequest.ContactInfo.Address
                },
                Cart = new Cart(),
                Orders = new List<Order>(),
                PaymentInfos = new List<PaymentInfo>()
            };

            _db.Customer.Add(newCustomer);
            _db.SaveChanges();
            return new CustomerResponse(newCustomer);
        }

        public OrderResponse GetOrder(int customerId, int orderId)
        {
            var customer = _db.Customer
                .Include(c => c.Orders)
                .ThenInclude(o => o.Cart)
                .ThenInclude(cart => cart.Products)
                .ThenInclude(pp => pp.Product)
                .SingleOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {customerId} not found.");
            }

            var order = customer.Orders.SingleOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with ID {orderId} not found.");
            }

            return new OrderResponse(order);
        }

        public Order AddOrder(int customerId, OrderRequest orderRequest)
        {
            var customer = _db.Customer
                .Include(c => c.Orders)
                .Include(c => c.Cart)
                .ThenInclude(cart => cart.Products)
                .SingleOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {customerId} not found.");
            }

            var newOrder = new Order
            {
                Cart = customer.Cart,
                OrderDate = DateTime.Now
            };

            customer.Orders.Add(newOrder);
            customer.Cart = new Cart(); // Reset the cart
            _db.SaveChanges();

            return newOrder;
        }

        public PaymentInfoResponse GetPaymentInfo(int customerId, int paymentId)
        {
            var customer = _db.Customer
                .Include(c => c.PaymentInfos)
                .SingleOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {customerId} not found.");
            }

            var paymentInfo = customer.PaymentInfos.SingleOrDefault(p => p.Id == paymentId);
            if (paymentInfo == null)
            {
                throw new KeyNotFoundException($"PaymentInfo with ID {paymentId} not found.");
            }

            return new PaymentInfoResponse(paymentInfo);
        }

        public PaymentInfoResponse AddPaymentInfo(int customerId, PaymentInfoRequest request)
        {
            var customer = _db.Customer
                .Include(c => c.PaymentInfos)
                .Include(c => c.Cart)
                .Include(c => c.Orders)
                .Include(c => c.ContactInfo)
                .SingleOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {customerId} not found.");
            }

            var paymentInfo = new PaymentInfo
            {
                Name = request.Name,
                PaymentMethod = request.PaymentMethod,
                Email = request.Email,
                Address = request.Address
            };

            customer.PaymentInfos.Add(paymentInfo);
            _db.SaveChanges();

            return new PaymentInfoResponse(paymentInfo);
        }

        public PurchaseProductResponse AddPurchaseProduct(int customerId, PurchaseProductRequest request)
        {
            try
            {
                var customer = _db.Customer
                    .Include(c => c.Cart)
                    .ThenInclude(cart => cart.Products)
                    .ThenInclude(products => products.Product)
                    .FirstOrDefault(c => c.Id == customerId);

                if (customer == null)
                {
                    throw new KeyNotFoundException($"Customer with ID {customerId} not found.");
                }

                if (customer.Cart == null)
                {
                    throw new InvalidOperationException($"Cart for customer with ID {customerId} not found.");
                }

                var cart = customer.Cart;
                var existingProduct = cart.Products.FirstOrDefault(cp => cp.ProductId == request.ProductId);
                PurchaseProduct purchaseProduct;

                if (existingProduct != null)
                {
                    existingProduct.Quantity += request.Quantity;
                    purchaseProduct = existingProduct;
                }
                else
                {
                    // Verify the product exists
                    var product = _db.Product.FirstOrDefault(p => p.Id == request.ProductId);
                    if (product == null)
                    {
                        throw new KeyNotFoundException($"Product with ID {request.ProductId} not found.");
                    }

                    purchaseProduct = new PurchaseProduct
                    {
                        CartId = cart.Id,
                        ProductId = request.ProductId,
                        Quantity = request.Quantity
                    };

                    cart.Products.Add(purchaseProduct);
                }

                _db.SaveChanges();

                return new PurchaseProductResponse(purchaseProduct);
            }
            catch (DbUpdateException dbEx)
            {
                // Log the inner exception details for debugging
                Console.WriteLine($"DbUpdateException: {dbEx.InnerException?.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Log the error details for debugging
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }

        public CartResponse GetCart(int customerId)
        {
            var customer = _db.Customer
                .Include(c => c.Cart)
                .ThenInclude(cart => cart.Products)
                .ThenInclude(pp => pp.Product)
                .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                throw new ArgumentException($"Customer with Id {customerId} does not exist.");
            }
            var cart = customer.Cart;

            if (cart == null)
            {
                var emptyCartResponse = new CartResponse(customer.Id);
                emptyCartResponse.Products = new List<PurchaseProductResponse>();
                return emptyCartResponse;
            }

            var cartResponse = new CartResponse(customer.Id);
            cartResponse.Products = cart.Products.Select(product => new PurchaseProductResponse(product)).ToList();

            return cartResponse;
        }

        public List<OrderResponse> GetOrders(int customerId)
        {
            var customer = _db.Customer
                .Include(c => c.Orders)
                .ThenInclude(o => o.Cart)
                .ThenInclude(cart => cart.Products)
                .ThenInclude(pp => pp.Product)
                .SingleOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {customerId} not found.");
            }

            var orders = customer.Orders.Select(order => new OrderResponse(order)).ToList();

            return orders;
        }


        public PurchaseProductResponse DeletePurchaseProduct(int customerId, int productId)
        {
            var customer = _db.Customer
                .Include(c => c.Cart)
                .ThenInclude(cart => cart.Products)
                .ThenInclude(product => product.Product)
                .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                throw new ArgumentException($"Customer with Id {customerId} does not exist.");
            }

            var cart = customer.Cart;

            if (cart == null)
            {
                throw new ArgumentException($"Cart for customer with Id {customerId} does not exist.");
            }

            var purchaseProduct = cart.Products.FirstOrDefault(p => p.ProductId == productId);

            if (purchaseProduct == null)
            {
                throw new ArgumentException($"Product with Id {productId} is not in the cart.");
            }

            cart.Products.Remove(purchaseProduct);

            _db.PurchaseProduct.Remove(purchaseProduct);

            _db.SaveChanges();

            return new PurchaseProductResponse(purchaseProduct);
        }
    }
}
