using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Contexts;
using MoodyTunes.Models;

namespace MoodyTunes.Repositories.SongPlaylistRepository
{
    public class SongPlaylistRepository: ISongPlaylistRepository
    {
        public Context _context { get; set; }
        public SongPlaylistRepository(Context context)
        {
            _context = context;
        }
        public SongPlaylist Create(SongPlaylist songPlaylist)
        {
            var result = _context.Add<SongPlaylist>(songPlaylist);
            _context.SaveChanges();
            return result.Entity;
        }
        public SongPlaylist Get(int Id)
        {
            return _context.SongPlaylists.SingleOrDefault(x => x.id == Id);
        }
        public List<SongPlaylist> GetAll()
        {
            return _context.SongPlaylists.ToList();
        }
        public SongPlaylist Update(SongPlaylist songPlaylist)
        {
            _context.Entry(songPlaylist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return songPlaylist;
        }
        public SongPlaylist Delete(SongPlaylist songPlaylist)
        {
            var result = _context.Remove(songPlaylist);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
