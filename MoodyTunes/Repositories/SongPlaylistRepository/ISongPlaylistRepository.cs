using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Models;

namespace MoodyTunes.Repositories.SongPlaylistRepository
{
    public interface ISongPlaylistRepository
    {
        List<SongPlaylist> GetAll();
        SongPlaylist Get(int Id);
        SongPlaylist Create(SongPlaylist songPlaylist);
        SongPlaylist Update(SongPlaylist songPlaylist);
        SongPlaylist Delete(SongPlaylist songPlaylist);
    }
}
