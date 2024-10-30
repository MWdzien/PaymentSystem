using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PaymentSystem.Models.ProductModels;

namespace PaymentSystem.Models.ContractModels;

public class Contract
{
    [Key] 
    public int ContractId { get; set; }

    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal Price { get; set; }
    [Range(1, 4)]
    public int MaintenanceYears { get; set; } = 1;

    public bool IsSigned { get; set; } = false;
    public bool IsExpired { get; set; } = true;

    public int ClientId { get; set; }
    [ForeignKey(nameof(ClientId))]
    public Client Client { get; set; }

    public int SoftwareId { get; set; }
    [ForeignKey(nameof(SoftwareId))]
    public Software Software { get; set; }
}