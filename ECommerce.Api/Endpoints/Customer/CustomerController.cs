
using Microsoft.AspNetCore.Mvc;
using ECommerce.Api.Endpoints.Customer.RequestResponse;


namespace ECommerceAPI.Endpoints.Customer
{
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet("/customer")]
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

        [HttpGet("/customer/{id}")]
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

        [HttpPost("/customer")]
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



        [HttpDelete("/customer/{id}")]
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

    }

}