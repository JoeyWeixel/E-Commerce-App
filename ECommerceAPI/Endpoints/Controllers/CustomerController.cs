//using Microsoft.AspNetCore.Mvc;
//using ECommerceAPI.Domain;



//[Route("api/[controller]")]
//[ApiController]
//public class CustomerController : ControllerBase
//{
//    private readonly CustomerService _service;

//    public CustomerController(CustomerService _service)
//    {
//        _service = _service;
//    }

//    [HttpGet("/customer")]
//    public IActionResult GetCustomers()
//    {

//        try
//        {
//            var customers = _service.Customers.ToList();
//            return Ok(customers);

//        }
//        catch (Exception ex)
//        {
//            return BadRequest(ex.Message);

//        }
    
//    }

//    [HttpGet("/customer/{id}")]
//    public IActionResult GetCustomer(int id)
//    {
//        try
//        {
//            var customer = _service.Customers.Find(id);

//            return Ok(customer);

//        }
//        catch (Exception ex) { 
//            return NotFound();

//        }
//    }

//    [HttpPost("/customer")]
//    public IActionResult CreateCustomer([FromBody] Customer customer)
//    {

//        try
//        {
//            _service.Customers.Add(customer);
//            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);


//        }
//        catch (Exception ex)
//        {
//            return BadRequest();
//        }

//    }



//    [HttpDelete("/customer/{id}")]
//    public IActionResult DeleteCustomer(int id)
//    {
//        try
//        {
//            _service.Customers.Remove(id);
//            return Ok();
//        }
//        catch (Exception ex)
//        {
//            return BadRequest();

//        }
//    }
//}
