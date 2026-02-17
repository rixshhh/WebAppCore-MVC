using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Data;

public sealed class Courses
{
    [Key] public int CourseID { get; set; }

    [StringLength(100)] public required string CourseName { get; set; }

    [StringLength(20)] public required string CourseCode { get; set; }

    [Range(1, int.MaxValue)] public required int DurationMonths { get; set; }


    [Column(TypeName = "decimal(10,2)")]
    [Range(0, double.MaxValue)]
    public required decimal TotalFees { get; set; }

    [DataType(DataType.Date)] public required DateTime CreatedAt { get; set; }

    public List<string> Subjects { get; set; } = new();


}