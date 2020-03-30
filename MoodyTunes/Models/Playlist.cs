using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodyTunes.Models
{
    public class Playlist
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<PlaylistMood> playlistMoods { get; set; }
        public List<SongPlaylist> songPlaylists { get; set; }
    }
}
