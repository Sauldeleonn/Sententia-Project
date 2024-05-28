using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class UserModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(50)]
        public string NickName { get; set; } = null!;
        [Required]
        [StringLength(500)]
        public string Bio { get; set; } = null!;
        [Required]
        public bool Banned { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        [StringLength(250)]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Password { get; set; } = null!;
        [Required]
        public int RoleId { get; set; }
    }

    #region Post

    public class UserPostRequest
    {
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must contain only letters")]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must contain only letters")]
        public string LastName { get; set; } = null!;
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(50)]
        public string NickName { get; set; } = null!;
        [Required]
        [StringLength(500)]
        public string Bio { get; set; } = null!;
        [Required]
        public bool Banned { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        [StringLength(250)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Password { get; set; } = null!;
        [Required]
        public int RoleId { get; set; }
    }


    #endregion
}
