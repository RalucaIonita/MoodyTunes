using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Models;

namespace MoodyTunes.Repositories.SongRepository
{
    public interface ISongRepository
    {
        List<Song> GetAll();
        Song Get(int Id);
        Song Create(Song song);
        Song Update(Song song);
        Song Delete(Song song);
    }
}
