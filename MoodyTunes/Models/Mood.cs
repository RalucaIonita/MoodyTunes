using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodyTunes.Models
{
    public class Mood
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<PlaylistMood> playlistMood { get; set; }
        public List<Mood> linkedMoods { get; set; }
    }
}
