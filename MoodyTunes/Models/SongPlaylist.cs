using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodyTunes.Models
{
    public class SongPlaylist
    {
        public int id { get; set; }
        public int playlistId { get; set; }
        public int songId { get; set; }

        public virtual Song song { get; set; }
        public virtual Playlist playlist { get; set; }
    }
}
