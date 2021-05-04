using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_4_Task_6.Entities
{
    public class SongArtist
    {
        public virtual Song Song { get; set; }
        public int SongId { get; set; }

        public virtual Artist Artist { get; set; }
        public int ArtistId { get; set; }
    }
}
