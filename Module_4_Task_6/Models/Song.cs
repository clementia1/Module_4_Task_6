using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_4_Task_6.Models
{
    public class Song
    {
        public string Title { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public string Genre { get; set; }
    }
}
