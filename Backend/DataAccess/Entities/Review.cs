using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Sententia;

[PrimaryKey("UserId", "MusicalElementId")]
[Table("Review")]
public partial class Review
{
    [Key]
    public int UserId { get; set; }

    [Key]
    public int MusicalElementId { get; set; }

    [StringLength(50)]
    public string? Title { get; set; }

    [StringLength(250)]
    public string? Text { get; set; }

    public bool? Like { get; set; }

    public short Stars { get; set; }

    public bool Active { get; set; }

    [ForeignKey("MusicalElementId")]
    [InverseProperty("Reviews")]
    public virtual MusicalElement MusicalElement { get; set; } = null!;

    [InverseProperty("Review")]
    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    [ForeignKey("UserId")]
    [InverseProperty("ReviewsNavigation")]
    public virtual User User { get; set; } = null!;

    [ForeignKey("UserReviewId, MusicalElementId")]
    [InverseProperty("Reviews")]
    public virtual ICollection<User> UserIdLikes { get; set; } = new List<User>();
}
