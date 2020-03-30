using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Models;
using MoodyTunes.DTOs;

namespace MoodyTunes.DTOs
{
    public class MoodLinkDTO
    {
        public int moodId { get; set; }
        public int linkedMoodId { get; set; }
    }
}
