using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.Models.ProductModels;

public class Software
{
    [Key]
    public int SoftwareId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string Description { get; set; }
    [MaxLength(10)]
    public string CurrentVersion { get; set; }
    [MaxLength(20)]
    public string Category { get; set; }
    public decimal Price { get; set; }

    public ICollection<SoftwareDiscount> SoftwareDiscounts { get; set; } = new List<SoftwareDiscount>();
}