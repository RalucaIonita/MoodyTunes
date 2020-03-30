using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Models;

namespace MoodyTunes.Repositories.PlaylistRepository
{
    public interface IPlaylistRepository
    {
        List<Playlist> GetAll();
        Playlist Get(int playlistId);
        Playlist Create(Playlist playlist);
        Playlist Update(Playlist playlist);
        Playlist Delete(Playlist playlist);
    }
}
