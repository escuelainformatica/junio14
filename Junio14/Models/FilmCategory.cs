using System;
using System.Collections.Generic;

#nullable disable

namespace Junio14.Models
{
    public partial class FilmCategory
    {
        public int FilmId { get; set; }
        public byte CategoryId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Category Category { get; set; }
        public virtual Film Film { get; set; }
    }
}
