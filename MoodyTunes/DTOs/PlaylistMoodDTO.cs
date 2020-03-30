using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Models;

namespace MoodyTunes.DTOs
{
    public class PlaylistMoodDTO
    {
        public int playlistId { get; set; } 
        public int moodId { get; set; }
    }
}
