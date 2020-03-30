using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Contexts;
using MoodyTunes.Models;

namespace MoodyTunes.Repositories.PlaylistRepository
{
    public class PlaylistRepository: IPlaylistRepository
    {
        public Context _context { get; set; }
        public PlaylistRepository(Context context)
        {
            _context = context;
        }
        public Playlist Create(Playlist playlist)
        {
            var result = _context.Add<Playlist>(playlist);
            _context.SaveChanges();
            return result.Entity;
        }
        public Playlist Get(int Id)
        {
            return _context.Playlists.SingleOrDefault(x => x.id == Id);
        }
        public List<Playlist> GetAll()
        {
            return _context.Playlists.ToList();
        }
        public Playlist Update(Playlist playlist)
        {
            _context.Entry(playlist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return playlist;
        }
        public Playlist Delete(Playlist playlist)
        {
            var result = _context.Remove(playlist);
            _context.SaveChanges();
            return result.Entity;
        }

    }
}
