using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Entities;

[Table("ReportReason")]
public partial class ReportReason
{
    [Key]
    [Column("ReportReason")]
    public int ReportReason1 { get; set; }

    [StringLength(300)]
    public string Description { get; set; } = null!;

    public short Level { get; set; }

    [InverseProperty("ReportReason")]
    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
