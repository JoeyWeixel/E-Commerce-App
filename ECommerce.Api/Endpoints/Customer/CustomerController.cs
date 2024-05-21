using ECommerceAPI.Endpoints.CustomerEndpoint;
using ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceAPI.Endpoints.ProductEndpoint
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
                _service.DeleteCustomer(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();

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
            try { 
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

        [HttpGet("{id}/orders")]
        public IActionResult GetAllOrders(int id)
        {
            try
            {
                var orders = _service.GetAllOrders(id);
                return Ok(orders);
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

        [HttpPost("{customerId}/cart/{cartId}/products/{productId}")]
        public IActionResult AddPurchaseProduct(int customerId, int cartId, PurchaseProductRequest request)
        {
            try
            {
                var pProduct = _service.AddPurchaseProduct(customerId, cartId, request);

                return Ok(pProduct);
            }
            catch
            {
                return StatusCode(500);

            }
        }

        [HttpPatch("{customerId}/cart/{cartId}/products/{productId}")]
        public IActionResult EditPurchaseProduct(int customerId, int cartId, int productId, int newQuantity)
        {
            try
            {
                var pProduct = _service.EditPurchaseProduct(customerId, cartId, productId, newQuantity);

                return Ok(pProduct);

            }
            catch
            {
                return StatusCode(500);

            }
        }

        [HttpGet("{customerId}/cart/{cartId}/products/{productId}")]
        public IActionResult DeletePurchaseProduct(int customerId, int cartId, int productId)
        {
            try
            {
                var pProduct = _service.DeletePurchaseProduct(customerId, cartId, productId);

                return Ok(pProduct);
            }
            catch
            {
                return StatusCode(500);

            }
        }
    }
}