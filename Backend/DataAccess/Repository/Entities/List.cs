using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Entities;

[Table("List")]
public partial class List
{
    [Key]
    public int ListId { get; set; }

    [StringLength(10)]
    public string Name { get; set; } = null!;

    [ForeignKey("ListId")]
    [InverseProperty("Lists")]
    public virtual ICollection<MusicalElement> MusicalElements { get; set; } = new List<MusicalElement>();

    [ForeignKey("ListId")]
    [InverseProperty("Lists")]
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();

    [ForeignKey("ListId")]
    [InverseProperty("Lists")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
