
using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Endpoints.Customer.RequestResponse.Customer;
using ECommerceAPI.Endpoints.Customer.RequestResponse.Order;


namespace ECommerceAPI.Endpoints.Customer
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

        [HttpGet("")]
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

        [HttpGet("/{id}")]
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

        [HttpPost("")]
        public IActionResult CreateCustomer(CustomerRequest customer)
        {

            try
            {
                _service.AddCustomer(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);


            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }



        [HttpDelete("/{id}")]
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

        [HttpGet("/{customerId}/orders/{orderId}/paymentinfo")]
        public IActionResult GetPaymentInfo(int customerId, int orderId)
        {
            try
            {
                var paymentinfo = _service.GetPaymentInfo(customerId, orderId);
                return Ok(paymentinfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/{id}/orders")]
        public IActionResult AddOrder(int id, OrderRequest order)
        {
            try
            {
                var newOrder = _service.AddOrder(order);
                return Created($"/customers/{id}/orders/{newOrder.Id}", newOrder);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/{customerId}/orders/{orderId}")]
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

        [HttpGet("/{id}/orders")]
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




        #region 
        [HttpGet("/customer{id}/contact-info")]
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

        [HttpGet("/customer{id}/contact-info")]
        public IActionResult GetCustomer(int id)
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

        [HttpPost("/customer{id}/contact-info")]
        public IActionResult CreateCustomer(CustomerRequest customer)
        {

            try
            {
                _service.AddCustomer(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);


            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }



        [HttpDelete("/customer{id}/contact-info")]
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

        #endregion

    }

}