using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Contexts;
using MoodyTunes.Models;

namespace MoodyTunes.Repositories.SongRepository
{
    public class SongRepository: ISongRepository
    {
        public Context _context { get; set; }
        public SongRepository(Context context)
        {
            _context = context;
        }
        public Song Create(Song song)
        {
            var result = _context.Add<Song>(song);
            _context.SaveChanges();
            return result.Entity;
        }
        public Song Get(int Id)
        {
            return _context.Songs.SingleOrDefault(x => x.id == Id);
        }
        public List<Song> GetAll()
        {
            return _context.Songs.ToList();
        }
        public Song Update(Song song)
        {
            _context.Entry(song).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return song;
        }
        public Song Delete(Song song)
        {
            var result = _context.Remove(song);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
