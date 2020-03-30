using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MoodyTunes.DTOs;
using MoodyTunes.Models;
using MoodyTunes.Repositories.PlaylistRepository;
using MoodyTunes.Repositories.MoodRepository;
using MoodyTunes.Repositories.PlaylistMoodRepository;
using MoodyTunes.Repositories.SongPlaylistRepository;
using MoodyTunes.Repositories.SongRepository;


namespace MoodyTunes.Controllers //NEEDS TO BE RETHOUGHT
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistDetailsController : ControllerBase
    {
        public IPlaylistRepository iPlaylistRepository { get; set; }
        public ISongPlaylistRepository iSongPlaylistRepository { get; set; }
        public ISongRepository iSongRepository { get; set; }
        public IMoodRepository iMoodRepository { get; set; }
        public IPlaylistMoodRepository iPlaylistMoodRepository { get; set; }

        public PlaylistDetailsController(ISongPlaylistRepository songPlaylistRepository, ISongRepository songRepository, IPlaylistRepository playlistRepository, IMoodRepository moodRepository, IPlaylistMoodRepository playlistMoodRepository)
        {
            iSongPlaylistRepository = songPlaylistRepository;
            iSongRepository = songRepository;
            iPlaylistMoodRepository = playlistMoodRepository;
            iPlaylistRepository = playlistRepository;
            iMoodRepository = moodRepository;
        }
        // GET: api/PlaylistMood
        [HttpGet]
        public ActionResult<IEnumerable<Playlist>> Get()
        {
            return iPlaylistRepository.GetAll();
        }

        // GET: api/SongPlaylist/5
        [HttpGet("{id}")]
        public Playlist Get(int id)
        {
            return iPlaylistRepository.Get(id);
        }

        // POST: api/SongPlaylist
        [HttpPost]
        public Playlist Post(PlaylistDetailsDTO value)
        {
            Playlist model = new Playlist()
            {
                name = value.name,

                //stuff needs to be added
            };
            return iPlaylistRepository.Create(model);
        }

        // PUT: api/SongPlaylist/5
        [HttpPut("{id}")]
        public SongPlaylist Put(int id, SongPlaylistDTO value)
        {
            SongPlaylist model = iSongPlaylistRepository.Get(id);

            //stuff needs to be added
            
            return iSongPlaylistRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Playlist Delete(int id)
        {
            Playlist model = iPlaylistRepository.Get(id);
            return iPlaylistRepository.Delete(model);
        }
    }
}
