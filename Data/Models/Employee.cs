using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EmployeeManagementSystem.Data.Models;

[Index("Department", Name = "IX_Employees_Department")]
[Index("EmployeeCode", Name = "UQ__Employee__1F64254821D77864", IsUnique = true)]
public partial class Employee
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [StringLength(20)]
    public string EmployeeCode { get; set; } = null!;

    [StringLength(100)]
    public string Department { get; set; } = null!;

    [StringLength(100)]
    public string Designation { get; set; } = null!;

    [StringLength(20)]
    public string? Phone { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Salary { get; set; }

    public DateOnly DateOfJoining { get; set; }

    public bool IsActive { get; set; } = true;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    [InverseProperty("Employee")]
    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

    [ForeignKey("UserId")]
    [InverseProperty("Employees")]
    [ValidateNever]
    public virtual User User { get; set; } = null!;
    
   
}
