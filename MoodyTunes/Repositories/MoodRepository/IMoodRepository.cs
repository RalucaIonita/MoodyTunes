using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Models;

namespace MoodyTunes.Repositories.MoodRepository
{
    public interface IMoodRepository
    {
        List<Mood> GetAll();
        Mood Get(int Id);
        Mood Create(Mood mood);
        Mood Update(Mood mood);
        Mood Delete(Mood mood);

    }
}
