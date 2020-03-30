using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Models;

namespace MoodyTunes.DTOs
{
    public class PlaylistDetailsDTO
    {
        public string name { get; set; }
        public List<Song> songs { get; set; }
        public List<Mood> moods { get; set; }
    }
}
