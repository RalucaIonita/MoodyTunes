using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Models;

namespace MoodyTunes.Repositories.PlaylistMoodRepository
{
    public interface IPlaylistMoodRepository
    {
        List<PlaylistMood> GetAll();
        PlaylistMood Get(int Id);
        PlaylistMood Create(PlaylistMood playlistMood);
        PlaylistMood Update(PlaylistMood playlistMood);
        PlaylistMood Delete(PlaylistMood playlistMood);
    }
}
