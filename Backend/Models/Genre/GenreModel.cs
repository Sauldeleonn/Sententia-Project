using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Genre
{
    public class GenreModel
    {
        public int GenreId { get; set; }

        [StringLength(50)]
        //value cannot be null
        [Required]
        public string Description { get; set; } = null!;

        [StringLength(50)]
        //value cannot be null
        [Required]
        public string Name { get; set; } = null!;
    }
    #region Post

    public class GenrePost_Request
    {
        [StringLength(50)]
        //value cannot be null
        [Required]
        public string Description { get; set; } = null!;

        [StringLength(50)]
        //value cannot be null
        [Required]
        public string Name { get; set; } = null!;
    }
    public class GenrePost_Response
    {
        //the post id
        public int GenreId { get; set; }
    }
    #endregion

    #region get by id

    public class GenreGet_Request
    {
        //the id of the genre
        [Required]
        public int GenreId { get; set; }
    }

    public class GenreGet_Response
    {
        public int GenreId { get; set; }
        public string Description { get; set; } = null!;
        public string Name { get; set; } = null!;
    }

    #endregion

    #region get all

    public class GenreGetAll_Response
    {
        public int GenreId { get; set; }
        public string Description { get; set; } = null!;
        public string Name { get; set; } = null!;
    }

    #endregion

    #region put pending
    //pending
    #endregion

    #region delete

    public class GenreDelete_Request
    {
        //the id of the genre
        [Required]
        public int GenreId { get; set; }
    }

    public class GenreDelete_Response
    {
        //the id of the genre
        public int GenreId { get; set; }
    }

    #endregion
}
