using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data;

public class Fees
{
    [Key] public required int FeeID { get; set; }

    public required int StudentID { get; set; }

    public required decimal TotalAmount { get; set; }

    public decimal PaidAmount { get; set; }

    public decimal DueAmount { get; set; } // Computed in DB

    public DateOnly? LastPaymentDate { get; set; }

    public string? Status { get; set; } // Computed i
}