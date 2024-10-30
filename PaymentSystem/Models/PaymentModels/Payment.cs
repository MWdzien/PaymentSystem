using System.ComponentModel.DataAnnotations.Schema;
using PaymentSystem.Enums;
using PaymentSystem.Models.ContractModels;

namespace PaymentSystem.Models;

public class Payment
{
    public int PaymentId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public PaymentType PaymentType { get; set; }
    
    
    public int ContractId { get; set; }
    [ForeignKey(nameof(ContractId))]
    public Contract Contract { get; set; }
}