using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Entities;

[Table("Language")]
public partial class Language
{
    [Key]
    public int LanguageId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [ForeignKey("LanguageId")]
    [InverseProperty("Languages")]
    public virtual ICollection<MusicalElement> MusicalElements { get; set; } = new List<MusicalElement>();
}
