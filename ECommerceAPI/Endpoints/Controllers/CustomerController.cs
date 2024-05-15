using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Domain



[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ECommerceService _service;

    public CustomerController(ECommerceService _service)
    {
        _service = _service;
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {

        try
        {
            var customers = _service.Customers.ToList();
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
            var customer = _service.Customers.Find(id);

            return Ok(customer);

        }
        catch (Exception ex) { 
            return NotFound();
        
        }
    }

    [HttpPost]
    public IActionResult CreateCustomer([FromBody] Customer customer)
    {
               
        try
        {
            _service.Customers.Add(customer);
            _service.SaveChanges();
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);


        }
        catch (Exception ex)
        {
            return BadRequest();
        }
        
    }
}
