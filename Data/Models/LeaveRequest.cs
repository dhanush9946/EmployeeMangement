using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data.Models;

[Index("Status", Name = "IX_LeaveRequests_Status")]
public partial class LeaveRequest
{
    [Key]
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly FromDate { get; set; }

    public DateOnly ToDate { get; set; }

    [StringLength(500)]
    public string? Reason { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime AppliedDate { get; set; }

    public int? ApprovedBy { get; set; }

    [ForeignKey("ApprovedBy")]
    [InverseProperty("LeaveRequests")]
    public virtual User? ApprovedByNavigation { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("LeaveRequests")]
    public virtual Employee Employee { get; set; } = null!;
}
