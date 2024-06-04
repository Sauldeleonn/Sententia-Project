using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.MusicalElement;
using Models.MusicalElementType;

namespace Models.List
{
    public class ListModel
    {
        [Required]
        public int ListId { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; } = null!;
        List<MusicalElementModel> MusicalElements { get; set; } = new List<MusicalElementModel>();
    }

    #region Post

    public class ListPost_Request 
    {
        [Required]
        [StringLength(10)]
        public string Name { get; set; } = null!;
    }

    public class ListPost_Response
    {
        public int ListId { get; set; }
    }

    #endregion

    #region Get all

    public class ListGetAll_Response
    {
        public List<ListModel> Lists { get; set; }
    }

    #endregion

    #region Get by id

    public class ListGetById_Response
    {
        [Required]
        public int ListId { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; } = null!;
        public List<MusicalElementModel> MusicalElements { get; set; } = new List<MusicalElementModel>();
    }

    #endregion

    #region Put

    public class ListPut_Request
    {
        [Required]
        public int ListId { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; } = null!;
    }

    #endregion

    #region Delete

    public class ListDelete_Request
    {
        [Required]
        public int ListId { get; set; }
    }

    public class ListDelete_Response
    {
        public int ListId { get; set; }
    }

    #endregion

    #region Add Musical Element

    public class ListAddMusicalElement_Request
    {
        [Required]
        public int ListId { get; set; }
        [Required]
        public int MusicalElementId { get; set; }
    }

    public class ListAddMusicalElement_Response
    {
        public int ListId { get; set; }
        public int MusicalElementId { get; set; }
    }

    #endregion

    #region Remove Musical Element

    public class ListRemoveMusicalElement_Request
    {
        [Required]
        public int ListId { get; set; }
        [Required]
        public int MusicalElementId { get; set; }
    }

    public class ListRemoveMusicalElement_Response
    {
        public int ListId { get; set; }
        public int MusicalElementId { get; set; }
    }

    #endregion
}
