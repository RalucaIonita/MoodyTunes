using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Models;

namespace MoodyTunes.DTOs
{
    public class SongPlaylistDTO
    {
        public int playlistId { get; set; }
        public int songId { get; set; }
    }
}
