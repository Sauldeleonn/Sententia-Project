using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Entities;

[Table("BandDetail")]
public partial class BandDetail
{
    [Key]
    public int MusicalElementId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AgroupationDate { get; set; }

    [Column("disolutionDate", TypeName = "datetime")]
    public DateTime? DisolutionDate { get; set; }

    [InverseProperty("MusicalElement2")]
    public virtual MusicalElement? MusicalElement { get; set; }
}
