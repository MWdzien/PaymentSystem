namespace PaymentSystem.DTOs.ContractDTOs;

public class AddContractDTO
{
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int? MaintenanceYears { get; set; }
    public int ClientId { get; set; }
    public int SoftwareId { get; set; }
}