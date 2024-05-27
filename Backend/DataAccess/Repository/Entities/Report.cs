using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Entities;

[PrimaryKey("UserId", "UserReportId", "MusicalElementId")]
[Table("Report")]
public partial class Report
{
    [Key]
    public int UserId { get; set; }

    [StringLength(50)]
    public string Reason { get; set; } = null!;

    public int ReportReasonId { get; set; }

    [Key]
    public int UserReportId { get; set; }

    [Key]
    public int MusicalElementId { get; set; }

    [ForeignKey("ReportReasonId")]
    [InverseProperty("Reports")]
    public virtual ReportReason ReportReason { get; set; } = null!;

    [ForeignKey("UserReportId, MusicalElementId")]
    [InverseProperty("Reports")]
    public virtual Review Review { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Reports")]
    public virtual User User { get; set; } = null!;
}
