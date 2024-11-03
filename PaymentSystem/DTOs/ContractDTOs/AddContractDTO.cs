using System.ComponentModel.DataAnnotations;

namespace PaymentSystem.DTOs.ContractDTOs;

public class AddContractDTO
{
    [Required]
    public DateTime DateFrom { get; set; }
    [Required]
    public DateTime DateTo { get; set; }
    
    public int? MaintenanceYears { get; set; }
    [Required]
    public int ClientId { get; set; }
    [Required]
    public int SoftwareId { get; set; }
}