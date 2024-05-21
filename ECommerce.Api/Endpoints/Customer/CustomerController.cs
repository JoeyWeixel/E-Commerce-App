using ECommerceAPI.Endpoints.CustomerEndpoint;
using ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse;
using ECommerceAPI.Endpoints.ProductEndpoint;
using ECommerceAPI.Endpoints.ProductEndpoint.RequestResponse;


using Microsoft.AspNetCore.Mvc;


namespace ECommerceAPI.Endpoints.Product
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

        [HttpGet("/customer{id}/contact-info")]
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
        [HttpGet("{customerId}/cart")]
        public ActionResult<CartResponse> GetCart(int customerId)
        {
            try
            {
                var cart = _service.GetCustomerCart(customerId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return NotFound();

            }

        }

        [HttpPost("{customerId}/cart/add")]
        public IActionResult AddProductToCart(int customerId, [FromBody] ProductRequest request)
        {
            try
            {
                var product = new ProductResponse
                {
                    Id = request.Id,
                    Name = request.Name,
                    Price = request.Price
                };
                _service.AddProductToCart(customerId, product, request.numInStock);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpDelete("{customerId}/cart/remove")]
        public IActionResult RemoveProductFromCart(int customerId, [FromBody] ProductRequest request)
        {
            try
            {
                var product = new ProductResponse
                {
                    Id = request.Id,
                    Name = request.Name,
                    Price = request.Price
                };
                _service.RemoveProductFromCart(customerId, product, request.numInStock);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound();

            }
        }
    }
}