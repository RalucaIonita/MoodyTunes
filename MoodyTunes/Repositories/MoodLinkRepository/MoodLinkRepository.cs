using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Contexts;
using MoodyTunes.Models;

namespace MoodyTunes.Repositories.MoodLinkRepository
{
    public class MoodLinkRepository: IMoodLinkRepository
    {
        public Context _context { get; set; }
        public MoodLinkRepository(Context context)
        {
            _context = context;
        }
        public MoodLink Create(MoodLink moodLink)
        {
            var result = _context.Add<MoodLink>(moodLink);
            _context.SaveChanges();
            return result.Entity;
        }
        public MoodLink Get(int Id)
        {
            return _context.MoodLinks.SingleOrDefault(x => x.id == Id);
        }
        public List<MoodLink> GetAll()
        {
            return _context.MoodLinks.ToList();
        }
        public MoodLink Update(MoodLink moodLink)
        {
            _context.Entry(moodLink).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return moodLink;
        }
        public MoodLink Delete(MoodLink moodLink)
        {
            var result = _context.Remove(moodLink);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
