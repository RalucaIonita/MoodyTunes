using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodyTunes.Models
{
    public class PlaylistMood
    {
        public int id { get; set; }
        public int playlistId { get; set; }
        public int moodId { get; set; }

        public virtual Playlist Playlist { get; set; }
        public virtual Mood Mood { get; set; }
    }
}
