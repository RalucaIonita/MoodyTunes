using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodyTunes.Models
{
    public class Song
    { 
        public int id { get; set; }
        public string title { get; set; }
        public string artist { get; set; }
        public string link { get; set; }

        public List<SongPlaylist> songPlaylist { get; set; }
    }
}
