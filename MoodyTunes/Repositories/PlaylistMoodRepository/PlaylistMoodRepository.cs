using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Contexts;
using MoodyTunes.Models;

namespace MoodyTunes.Repositories.PlaylistMoodRepository
{
    public class PlaylistMoodRepository: IPlaylistMoodRepository
    {
        public Context _context { get; set; }
        public PlaylistMoodRepository(Context context)
        {
            _context = context;
        }
        public PlaylistMood Create(PlaylistMood playlistMood)
        {
            var result = _context.Add<PlaylistMood>(playlistMood);
            _context.SaveChanges();
            return result.Entity;
        }
        public PlaylistMood Get(int Id)
        {
            return _context.PlaylistMoods.SingleOrDefault(x => x.id == Id);
        }
        public List<PlaylistMood> GetAll()
        {
            return _context.PlaylistMoods.ToList();
        }
        public PlaylistMood Update(PlaylistMood playlistMood)
        {
            _context.Entry(playlistMood).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return playlistMood;
        }
        public PlaylistMood Delete(PlaylistMood playlistMood)
        {
            var result = _context.Remove(playlistMood);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
