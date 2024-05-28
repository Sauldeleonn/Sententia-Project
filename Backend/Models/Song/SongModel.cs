using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Song
{
    public class SongModel
    {
        [Key]
        [Required]
        public int MusicalElementId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(500)]
        public string Bio { get; set; } = null!;
        [Required]
        public int MusicalElementTypeId { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
    }

    #region post
    public class SongPost_Request
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(500)]
        public string Bio { get; set; } = null!;
        [Required]
        public int MusicalElementTypeId { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? ReleaseDate { get; set; }
    }

    public class SongPost_Response
    {
        public int MusicalElementId { get; set; }
    }
    #endregion

    #region get all

    public class SongGetAll_Response
    {
        List<SongModel> Songs { get; set; }
    }

    #endregion

    #region get by id
    public class SongGetById_Response
    {
        [Key]
        [Required]
        public int MusicalElementId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(500)]
        public string Bio { get; set; } = null!;
        [Required]
        public int MusicalElementTypeId { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
    }

    #endregion

    #region get by quantity
    public class SongGetByQuantity_Request
    {
        [Required]
        public int Quantity { get; set; }
    }

    public class SongGetByQuantity_Response
    {
        List<SongModel> Songs { get; set; }
    }
    #endregion

    #region put

    public class SongPut_Request
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(500)]
        public string Bio { get; set; } = null!;
        [Required]
        public int MusicalElementTypeId { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? ReleaseDate { get; set; }
    }

    public class SongPut_Response
    {
        public int MusicalElementId { get; set; }
    }

    #endregion

    #region get all
    public class SongDelete_Response
    {
        public int MusicalElementId { get; set; }
    }
    #endregion
}
