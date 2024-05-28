using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Sententia;

[Table("MusicalElementType")]
public partial class MusicalElementType
{
    [Key]
    public int MusicalElementTypeId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    public string Description { get; set; } = null!;

    [StringLength(50)]
    public string DetailTableName { get; set; } = null!;

    [InverseProperty("MusicalElementType")]
    public virtual ICollection<MusicalElement> MusicalElements { get; set; } = new List<MusicalElement>();
}
