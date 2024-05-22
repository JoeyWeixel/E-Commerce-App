using ECommerceAPI.Domain;
using ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse;
using ECommerceAPI.Endpoints.ProductEndpoint.RequestResponse;

using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Endpoints.CustomerEndpoint
{
    public class CustomerService
    {
        ECommerceContext _db;
        private static int _nextCustomerId = 1;

        public CustomerService(ECommerceContext db)
        {
            _db = db;
        }

        public IEnumerable<CustomerResponse> GetAllCustomers()
        {
            var customers = new List<CustomerResponse>();
            foreach (Customer customer in _db.Customers.Include(customer => customer.ContactInfo))
            {
                customers.Add(new CustomerResponse(customer));
            }
            return customers;
        }

        public CustomerResponse GetCustomer(int id)
        {
            Customer customer = _db.Customers
                .Include(customer => customer.ContactInfo)
                .SingleOrDefault(customer => customer.Id == id);
            return (new CustomerResponse(customer));
        }

        public CustomerResponse DeleteCustomer(int id)
        {
            var customer = _db.Customers.First(c => c.Id == id);
            _db.Customers.Remove(customer);
            _db.SaveChanges();
            return new CustomerResponse(customer);
        }

        public CustomerResponse AddCustomer(CustomerRequest customerRequest)
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
                Orders = [],
                PaymentInfos = []
            };
            _db.Customers.Add(newCustomer);
            _db.SaveChanges();
            return new CustomerResponse(newCustomer);
        }

        public IEnumerable<OrderResponse> GetAllOrders(int customerId)
        {
            Customer customer = _db.Customers
                .Include(customer => customer.Orders)
                .ThenInclude(order => order.DeliveryDate)
                .Include(customer => customer.Orders)
                .ThenInclude(order => order.OrderDate)
                .SingleOrDefault(customer => customer.Id == customerId);

            var orders = new List<OrderResponse>();
            foreach (Order order in customer.Orders)
            {
                orders.Add(new OrderResponse
                {
                    Id = order.Id,
                    DeliveryDate = order.DeliveryDate,
                    OrderDate = order.OrderDate,
                });
            }
            return orders;
        }

        public OrderResponse GetOrder(int customerId, int orderId)
        {
            Customer customer = _db.Customers.Include(customer => customer.Orders).SingleOrDefault((Customer c) => c.Id == customerId);

            var order = customer.Orders.Find(o => o.Id == orderId);
            var orderResponse = new OrderResponse
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate,
            };
            return orderResponse;
        }

        public Order AddOrder(int customerId, OrderRequest order)
        {
            Customer customer = _db.Customers
                .Include(customer => customer.Orders)
                .SingleOrDefault((Customer c) => c.Id == customerId);

            var newOrder = new Order
            {
                Id = customer.Orders.Max(o => o.Id) + 1,
                Cart = customer.Cart,
                OrderDate = DateTime.Now
            };
            customer.Cart = new Cart();
            _db.SaveChanges();
            return newOrder;
        }

        public PaymentInfoResponse GetPaymentInfo(int customerId, int paymentId)
        {
            List<PaymentInfo> paymentInfos = _db.Customers
                .Include(customer => customer.PaymentInfos)
                .SingleOrDefault((Customer c) => c.Id == customerId)
                .PaymentInfos;

            PaymentInfo paymentInfo = paymentInfos
                .SingleOrDefault(paymentInfo => paymentInfo.Id == paymentId);

            return new PaymentInfoResponse(paymentInfo);
        }

        public PaymentInfoResponse AddPaymentInfo(int customerId, PaymentInfoRequest request)
        {
            List<PaymentInfo> paymentInfos = _db.Customers
                .Include(customer => customer.PaymentInfos)
                .SingleOrDefault((Customer c) => c.Id == customerId)
                .PaymentInfos;

            PaymentInfo paymentInfo = new PaymentInfo
            {
                Name = request.Name,
                PaymentMethod = request.PaymentMethod,
                Email = request.Email,
                Address = request.Address
            };

            paymentInfos.Add(paymentInfo);
            _db.SaveChanges();

            return new PaymentInfoResponse(paymentInfo);
        }

        public PurchaseProductResponse AddPurchaseProduct(int customerId, PurchaseProductRequest request)
        {
            var customer = _db.Customers
                .Include(customer => customer.Cart)
                .ThenInclude(cart => cart.Products)
                .Where(customer => customer.Id == customerId).ToList().First();
            var cartProducts = customer.Cart.Products;

            var newPurchaseProduct = new PurchaseProduct
            {
                CartId = customerId,
                ProductId = request.ProductId,
                Quantity = 1
            };

            _db.SaveChanges();

            return new PurchaseProductResponse(newPurchaseProduct);
        }

        public PurchaseProductResponse EditPurchaseProduct(int customerId, int productId, int newQuantity)
        {
            var purchaseProduct = from c in _db.Customers
                                  where c.Id == customerId
                                  select (
                                      from p in c.Cart.Products
                                      where p.ProductId == productId && p.CartId == customerId
                                      select p
                                      );


            foreach (PurchaseProduct product in purchaseProduct)
            {
                product.Quantity = newQuantity;
            }

            _db.SaveChanges();
            return new PurchaseProductResponse
            {
                CartId = customerId,
                ProductId = productId,
                Quantity = newQuantity
            };

        }

        public PurchaseProductResponse DeletePurchaseProduct(int customerId, int productId)
        {
            var purchaseProduct = from c in _db.Customers
                                  where c.Id == customerId
                                  select (
                                      from p in c.Cart.Products
                                      where p.ProductId == productId && p.CartId == customerId
                                      select p
                                      );
            _db.Remove(purchaseProduct);
            _db.SaveChanges();

            return new PurchaseProductResponse
            {
                CartId = customerId,
                ProductId = productId,
                Quantity = 0
            };
        }
    }
}