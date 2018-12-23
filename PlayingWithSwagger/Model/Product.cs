using System.ComponentModel.DataAnnotations;

namespace PlayingWithSwagger.Model
{
  public class Product
  {
    public int Id { get; set; }
    /// <summary>
    /// Name of the product.
    /// </summary>
    [Required]
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
  }
}
