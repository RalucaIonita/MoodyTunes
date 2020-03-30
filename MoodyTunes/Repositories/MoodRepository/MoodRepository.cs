using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Contexts;
using MoodyTunes.Models;

namespace MoodyTunes.Repositories.MoodRepository
{
    public class MoodRepository: IMoodRepository
    {
        public Context _context { get; set; }
        public MoodRepository(Context context)
        {
            _context = context;
        }
        public Mood Create(Mood mood)
        {
            var result = _context.Add<Mood>(mood);
            _context.SaveChanges();
            return result.Entity;
        }
        public Mood Get(int Id)
        {
            return _context.Moods.SingleOrDefault(x => x.id == Id);
        }
        public List<Mood> GetAll()
        {
            return _context.Moods.ToList();
        }
        public Mood Update(Mood mood)
        {
            _context.Entry(mood).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return mood;
        }
        public Mood Delete(Mood mood)
        {
            var result = _context.Remove(mood);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
