using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/inventory")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _service;

    public InventoryController(IInventoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Product> GetAll()
    {
        return _service.GetAll();
    }

    [HttpPost]
    public Product Add([FromBody] Product product)
    {
        return _service.Add(product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Product product)
    {
        var result = _service.Update(id, product);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        if (!result) return NotFound();
        return Ok();
    }

    [HttpGet("above-price/{price}")]
    public IEnumerable<Product> GetByPrice(decimal price)
    {
        return _service.GetByPrice(price);
    }

    // დამატებითი endpoint 1
    [HttpGet("by-supplier/{supplierId}")]
    public IEnumerable<Product> GetBySupplier(int supplierId)
    {
        return _service.GetBySupplier(supplierId);
    }

    // დამატებითი endpoint 2
    [HttpGet("search")]
    public IEnumerable<Product> Search([FromQuery] string name)
    {
        return _service.SearchByName(name);
    }
}