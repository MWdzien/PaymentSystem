namespace PaymentSystem.DTOs;

public class PaymentDTO
{
    public decimal Amount { get; set; }
    public int ClientId { get; set; }
    public int ContractId { get; set; }
}