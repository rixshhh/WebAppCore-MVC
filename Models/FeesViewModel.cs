using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class FeesViewModel
{
    [Key] public int FeeID { get; set; }

    public int StudentID { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal PaidAmount { get; set; }

    public decimal DueAmount { get; set; } // Computed in DB

    public DateOnly? LastPaymentDate { get; set; }

    public string? Status { get; set; } // Computed i

    public string StudentName { get; set; } = string.Empty;
    public List<string> Students { get; set; } = new();
}