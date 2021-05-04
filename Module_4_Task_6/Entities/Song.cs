using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_4_Task_6.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DurationSeconds { get; set; }
        public DateTime ReleasedDate { get; set; }

        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public virtual ICollection<SongArtist> Artists { get; set; } = new List<SongArtist>();
    }
}
