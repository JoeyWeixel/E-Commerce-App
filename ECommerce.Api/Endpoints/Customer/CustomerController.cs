using ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Endpoints.CustomerEndpoint
{

    [ApiController]
    [Route("/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            try
            {
                var customers = _service.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            try
            {
                var customer = _service.GetCustomer(id);

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerRequest customer)
        {
            try
            {
                var newCustomer = _service.AddCustomer(customer);
                return Created($"Customers/{newCustomer.Id}", newCustomer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var customer = _service.DeleteCustomer(id);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{customerId}/payment-info/{paymentId}")]
        public IActionResult GetPaymentInfo(int customerId, int paymentId)
        {
            try
            {
                var paymentinfo = _service.GetPaymentInfo(customerId, paymentId);
                return Ok(paymentinfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{customerId}/payment-info")]
        public IActionResult AddPaymentInfo(int customerId, PaymentInfoRequest paymentInfo)
        {

            try
            {
                var response = _service.AddPaymentInfo(customerId, paymentInfo);
                return Ok(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("{customerId}/orders")]
        public IActionResult AddOrder(int customerId, OrderRequest order)
        {
            try
            {
                var newOrder = _service.AddOrder(customerId, order);
                return Created($"/customers/{customerId}/orders/{newOrder.Id}", newOrder);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{customerId}/orders")]
        public IActionResult GetOrders(int customerId)
        {
            try
            {
                var orders = _service.GetOrders(customerId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{customerId}/orders/{orderId}")]
        public IActionResult GetOrder(int customerId, int orderId)
        {
            try
            {
                var order = _service.GetOrder(customerId, orderId);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/contact-info")]
        public IActionResult GetContactInfo(int id)
        {
            try
            {
                var customer = _service.GetCustomer(id);

                return Ok(customer);

            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost("{customerId}/cart/products")]
        public IActionResult AddPurchaseProduct(int customerId, PurchaseProductRequest request)
        {
            try
            {
                var pProduct = _service.AddPurchaseProduct(customerId, request);

                return Ok(pProduct);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{customerId}/cart")]
        public IActionResult GetCart(int customerId)
        {
            try
            {
                var pProduct = _service.GetCart(customerId);

                return Ok(pProduct);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{customerId}/cart/products/{productId}")]
        public IActionResult DeleePurchaseProduct(int customerId, int productId)
        {
            try
            {
                var pProduct = _service.DeletePurchaseProduct(customerId, productId);

                return Ok(pProduct);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}