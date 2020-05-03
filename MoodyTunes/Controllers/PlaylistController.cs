using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MoodyTunes.DTOs;
using MoodyTunes.Models;
using MoodyTunes.Repositories.PlaylistRepository;
using MoodyTunes.Repositories.SongPlaylistRepository;
using MoodyTunes.Repositories.SongRepository;
using MoodyTunes.Repositories.MoodLinkRepository;
using MoodyTunes.Repositories.MoodRepository;
using MoodyTunes.Repositories.PlaylistMoodRepository;



namespace MoodyTunes.Controllers //WORK
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        public IPlaylistRepository iPlaylistRepository { get; set; }
        public ISongPlaylistRepository iSongPlaylistRepository { get; set; }
        public ISongRepository iSongRepository { get; set; }
        public IMoodLinkRepository iMoodLinkRepository { get; set; }
        public IMoodRepository iMoodRepository { get; set; }
        public IPlaylistMoodRepository iPlaylistMoodRepository { get; set; }
        public PlaylistController(IPlaylistRepository playlistRepository, ISongRepository songRepository, ISongPlaylistRepository songPlaylistRepository, IMoodLinkRepository moodLinkRepository, IMoodRepository moodRepository, IPlaylistMoodRepository playlistMoodRepository)
        {
            iPlaylistRepository = playlistRepository;
            iSongPlaylistRepository = songPlaylistRepository;
            iSongRepository = songRepository;
            iMoodLinkRepository = moodLinkRepository;
            iMoodRepository = moodRepository;
            iPlaylistMoodRepository = playlistMoodRepository;
        }
        // GET: api/Playlist
        [HttpGet]
        public ActionResult<IEnumerable<Playlist>> Get()
        {
            return iPlaylistRepository.GetAll();
        }

        // GET: api/Playlist/5
        [HttpGet("{id}")]
        public PlaylistDetailsDTO Get(int id)
        {
            Playlist playlist = iPlaylistRepository.Get(id);
            PlaylistDetailsDTO myPlaylist = new PlaylistDetailsDTO()
            {
                name = playlist.name,
            };

            IEnumerable<SongPlaylist> mySongsPlaylist = iSongPlaylistRepository.GetAll().Where(x => x.playlistId == playlist.id);
            IEnumerable<PlaylistMood> myPlaylistMoods = iPlaylistMoodRepository.GetAll().Where(x => x.playlistId == playlist.id);

            //moods
            if(myPlaylistMoods != null)
            {
                List<Mood> moodsList = new List<Mood>();
                foreach (PlaylistMood playlistMood in myPlaylistMoods)
                {
                    Mood mood = iMoodRepository.GetAll().SingleOrDefault(x => x.id == playlistMood.moodId);
                    moodsList.Add(mood);
                }
                myPlaylist.moods = moodsList;
            }
            

            if (mySongsPlaylist != null)
            {
                List<Song> songsList = new List<Song>();
                foreach (SongPlaylist songPlaylist in mySongsPlaylist)
                {
                    Song song = iSongRepository.GetAll().SingleOrDefault(x => x.id == songPlaylist.songId);
                    songsList.Add(song);
                }
                myPlaylist.songs = songsList;

            }

            return myPlaylist;
        }

        // POST: api/Playlist
        [HttpPost]
        public void Post(PlaylistDetailsDTO value) //needs to be modified!!!!!!!!
        {
            Playlist model = new Playlist()
            {
                name = value.name,

            };

            iPlaylistRepository.Create(model);
            for(int i = 0; i < value.moods.Count; i++)
            {
                PlaylistMood playlistMood = new PlaylistMood()
                {
                    playlistId = model.id,
                    moodId = value.moods[i].id
                };
                iPlaylistMoodRepository.Create(playlistMood);
            }

            for (int i = 0; i < value.songs.Count; i++)
            {
                SongPlaylist songPlaylist = new SongPlaylist()
                {
                    playlistId = model.id,
                    songId = value.songs[i].id
                };
                iSongPlaylistRepository.Create(songPlaylist);
            }


            iPlaylistRepository.Create(model);

        }

        // PUT: api/Playlist/5
        [HttpPut("{id}")]
        public void Put(int id, PlaylistDetailsDTO value) //needs to be modified
        {
            Playlist model = iPlaylistRepository.Get(id);

            if (value.name != null)
            {
                model.name = value.name;
            }

            if (value.moods != null)
            {
                foreach (Mood mood in value.moods)
                {
                    if (iMoodRepository.Get(mood.id) == null)
                        iMoodRepository.Update(mood);
                    PlaylistMood newPlaylistMood = new PlaylistMood()
                    {
                        moodId = mood.id,
                    };
                    iPlaylistMoodRepository.Update(newPlaylistMood);
                }

            }

            if(value.songs != null)
            {
                foreach (Song song in value.songs)
                {
                    if (iSongRepository.Get(song.id) == null)
                        iSongRepository.Update(song);
                    SongPlaylist newSongPlaylist = new SongPlaylist()
                    {
                        songId = song.id
                    };
                    iSongPlaylistRepository.Update(newSongPlaylist);
                }
            }

            iPlaylistRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Playlist Delete(int id) //on delete cascade
        {
            Playlist model = iPlaylistRepository.Get(id);
            return iPlaylistRepository.Delete(model);
        }
    }
}
