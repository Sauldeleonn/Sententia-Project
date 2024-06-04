using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MusicalElement
{
    public class MusicalElementModel
    {
        public int MusicalElementId { get; set; }
        public string Name { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public int MusicalElementTypeId { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
