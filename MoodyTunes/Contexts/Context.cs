using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodyTunes.Models;
using Microsoft.EntityFrameworkCore;

namespace MoodyTunes.Contexts
{
    public class Context: DbContext
    {
        public DbSet<Mood> Moods { get; set; }
        public DbSet<MoodLink> MoodLinks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistMood> PlaylistMoods { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongPlaylist> SongPlaylists { get; set; }
        public DbSet<User> Users { get; set; }

        public static bool isMigration = true;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(isMigration)
            {
                optionsBuilder.UseSqlServer(@"Server=.\;Database=DBMoodyTunes;Trusted_Connection=True;");
            }
        }

        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) :base(options)
        {

        }
    }
}
