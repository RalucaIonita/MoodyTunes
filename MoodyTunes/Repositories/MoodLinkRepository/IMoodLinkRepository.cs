using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Models;

namespace MoodyTunes.Repositories.MoodLinkRepository
{
    public interface IMoodLinkRepository
    {
        List<MoodLink> GetAll();
        MoodLink Get(int Id);
        MoodLink Create(MoodLink moodLink);
        MoodLink Update(MoodLink moodLink);
        MoodLink Delete(MoodLink moodLink);
    }
}
