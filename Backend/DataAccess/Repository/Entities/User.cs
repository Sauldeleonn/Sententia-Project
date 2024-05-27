using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Entities;

[Table("User")]
public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime BirthDate { get; set; }

    [StringLength(50)]
    public string NickName { get; set; } = null!;

    [StringLength(500)]
    public string Bio { get; set; } = null!;

    public bool Banned { get; set; }

    public bool Active { get; set; }

    [StringLength(250)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    [InverseProperty("User")]
    public virtual ICollection<Review> ReviewsNavigation { get; set; } = new List<Review>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Users")]
    public virtual ICollection<List> Lists { get; set; } = new List<List>();

    [ForeignKey("UserIdLikeId")]
    [InverseProperty("UserIdLikes")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
