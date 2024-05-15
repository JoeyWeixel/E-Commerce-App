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
        var customers = _service.Customers.ToList();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomer(int id)
    {
        var customer = _service.Customers.Find(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult CreateCustomer([FromBody] Customer customer)
    {
        if (customer == null)
        {
            return BadRequest();
        }

        _service.Customers.Add(customer);
        _service.SaveChanges();
        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
    }


    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, [FromBody] Customer customer)
    {
        if (customer == null || customer.Id != id)
        {
            return BadRequest();
        }

        var customerToUpdate = _service.Customers.Find(id);
        if (customerToUpdate == null)
        {
            return NotFound();
        }

        customerToUpdate.Cart = customer.Cart;
        customerToUpdate.ContactInfo = customer.ContactInfo;
        customerToUpdate.PaymentInfo = customer.PaymentInfo;
        customerToUpdate.History = customer.History;

        _service.Customers.Update(customerToUpdate);
        _service.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var customer = _service.Customers.Find(id);
        if (customer == null)
        {
            return NotFound();
        }

        _service.Customers.Remove(customer);
        _service.SaveChanges();
        return NoContent();
    }
}
