using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodyTunes.Models
{
    public class MoodLink
    {
        public int id { get; set; }
        public int moodId { get; set; }
        public int linkedMoodId { get; set; }

        public virtual Mood linkedMood { get; set; }
    }
}
