using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MusicalElementType
{
    public partial class MusicalElementTypeModel
    {
        [Key]
        public int MusicalElementTypeId { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = null!;

        [StringLength(200)]
        public string Description { get; set; } = null!;

        [StringLength(50)]
        public string DetailTableName { get; set; } = null!;
    }

    //get
    public class MusicalElementTypeGetAll_Response
    {
        public List<MusicalElementTypeModel> MusicalElementTypes { get; set; }
    }
}
