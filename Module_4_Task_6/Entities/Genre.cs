using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_4_Task_6.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
