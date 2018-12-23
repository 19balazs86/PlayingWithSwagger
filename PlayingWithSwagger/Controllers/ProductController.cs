using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlayingWithSwagger.Model;

namespace PlayingWithSwagger.Controllers
{
  /// <summary>
  /// This controller is responsible for manage the product object.
  /// </summary>
  [Produces("application/json")]
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    /// <summary>
    /// Get all products.
    /// </summary>
    [HttpGet]
    public IEnumerable<Product> Get()
    {
      return Enumerable.Range(1, 5).Select(x
           => new Product { Name = $"Product-{x}", Price = x * 10, Description = $"P{x}-Description" });
    }

    /// <summary>
    /// Get a product with a specific id.
    /// </summary>
    /// <param name="id">Id of the product.</param>
    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
      if (id == 5)
        return NotFound();

      return new Product { Name = $"Product-{id}", Price = id * 10, Description = $"P{id}-Description" };
    }

    /// <summary>
    /// Create a new product.
    /// </summary>
    /// <response code="201">Returns the newly created item.</response>
    /// <response code="400">If the validation is failed.</response>
    /// <param name="product">Product details.</param>
    [HttpPost]
    public ActionResult<Product> Post([FromBody] Product product)
    {
      return CreatedAtAction(nameof(Get), new { product.Id }, product);
    }

    /// <summary>
    /// Modify an existing product.
    /// </summary>
    /// <param name="id">Id of the product.</param>
    /// <param name="product">Product details.</param>
    [HttpPut("{id}")]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesDefaultResponseType]
    public IActionResult Put(int id, [FromBody] Product product)
    {
      if (id == 5)
        return NotFound();

      return NoContent();
    }

    /// <summary>
    /// Delete a specific product.
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      if (id == 5)
        return NotFound();

      return Ok();
    }
  }
}
