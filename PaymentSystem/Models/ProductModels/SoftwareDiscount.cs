using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystem.Models.ProductModels;

public class SoftwareDiscount
{
    [Key]
    public int SoftwareDiscountId { get; set; }
    [MaxLength(50)]
    public string DiscountName { get; set; }
    public decimal DiscountRate { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }

    public int SoftwareId { get; set; }
    [ForeignKey(nameof(SoftwareId))]
    public Software Software { get; set; }
}