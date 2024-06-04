using ECommerceAPI.Domain;
using ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse;

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
            var customers = _db.Customer
                .Include(customer => customer.ContactInfo)
                .ToList();

            return customers.Select(customer => new CustomerResponse(customer)).ToList();
        }

        public CustomerResponse GetCustomer(int id)
        {
            Customer customer = _db.Customer
                .Include(customer => customer.ContactInfo)
                .SingleOrDefault(customer => customer.Id == id);
            return (new CustomerResponse(customer));
        }

        public CustomerResponse DeleteCustomer(int id)
        {
            var customer = _db.Customer.Include(c => c.ContactInfo).FirstOrDefault(c => c.Id == id);
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
                Orders = [],
                PaymentInfos = []
            };
            _db.Customer.Add(newCustomer);
            _db.SaveChanges();
            return new CustomerResponse(newCustomer);
        }
        public OrderResponse GetOrder(int customerId, int orderId)
        {
            Customer customer = _db.Customer
                .Include(c => c.Orders)
                .SingleOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {customerId} not found.");
            }

            var order = customer.Orders.Find(o => o.Id == orderId);
            var orderResponse = new OrderResponse
            {
                Id = order.Id,
                Cart = customer.Cart,
            };
            return orderResponse;
        }

        public Order AddOrder(int customerId, OrderRequest orderRequest)
        {
            var customer = _db.Customer
                .Include(c => c.Orders)
                .Include(c => c.Cart)
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
            customer.Cart = new Cart();
            _db.SaveChanges();

            return newOrder;
        }

        public PaymentInfoResponse GetPaymentInfo(int customerId, int paymentId)
        {
            List<PaymentInfo> paymentInfos = _db.Customer
                .Include(customer => customer.PaymentInfos)
                .SingleOrDefault((Customer c) => c.Id == customerId)
                .PaymentInfos;

            PaymentInfo paymentInfo = paymentInfos
                .SingleOrDefault(paymentInfo => paymentInfo.Id == paymentId);

            return new PaymentInfoResponse(paymentInfo);
        }

        public PaymentInfoResponse AddPaymentInfo(int customerId, PaymentInfoRequest request)
        {
            List<PaymentInfo> paymentInfos = _db.Customer
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
            var customer = _db.Customer
                .Include(c => c.Cart)
                .ThenInclude(cart => cart.Products)
                .FirstOrDefault(c => c.Id == customerId);

            var cart = customer.Cart;

            var existingProduct = cart.Products.FirstOrDefault(cp => cp.Product.Id == request.ProductId);
            var newPurchaseProduct = new PurchaseProduct();

            if (existingProduct != null)
            {
                existingProduct.Quantity += request.Quantity;
            }
            else
            {
                newPurchaseProduct = new PurchaseProduct
                {
                    Cart = customer.Cart,
                    Product = _db.Product.FirstOrDefault(p => p.Id == request.ProductId),
                    Quantity = request.Quantity
                };

                cart.Products.Add(newPurchaseProduct);
            }

            _db.SaveChanges();

            return new PurchaseProductResponse(existingProduct ?? newPurchaseProduct);
        }

        public CartResponse GetCart(int customerId)
        {
            var customer = _db.Customer
                .Include(c => c.Cart)
                .ThenInclude(cart => cart.Products)
                .FirstOrDefault(c => c.Id == customerId);

            var cart = customer.Cart;

            var cartResponse = new CartResponse(customer.Id);

            foreach (var product in cart.Products)
            {
                cartResponse.AddProduct(product);
            }

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
            var purchaseProduct = from c in _db.Customer
                                  where c.Id == customerId
                                  select (
                                      from p in c.Cart.Products
                                      where p.Product.Id == productId && p.Cart.Id == c.Cart.Id
                                      select p
                                      );
            _db.Remove(purchaseProduct);
            _db.SaveChanges();

            return new PurchaseProductResponse();
        }
    }
}