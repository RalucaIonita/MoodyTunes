using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MoodyTunes.DTOs;
using MoodyTunes.Models;
using MoodyTunes.Repositories.SongPlaylistRepository;


namespace MoodyTunes.Controllers //THIS
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongPlaylistController : ControllerBase
    {
        public ISongPlaylistRepository iSongPlaylistRepository { get; set; }
        public SongPlaylistController(ISongPlaylistRepository repository)
        {
            iSongPlaylistRepository = repository;
        }
        // GET: api/PlaylistMood
        [HttpGet]
        public ActionResult<IEnumerable<SongPlaylist>> Get()
        {
            return iSongPlaylistRepository.GetAll();
        }

        // GET: api/SongPlaylist/5
        [HttpGet("{id}")]
        public SongPlaylist Get(int id)
        {
            return iSongPlaylistRepository.Get(id);
        }

        // POST: api/SongPlaylist
        [HttpPost]
        public SongPlaylist Post(SongPlaylistDTO value)
        {
            SongPlaylist model = new SongPlaylist()
            {
                songId = value.songId,
                playlistId = value.playlistId

            };
            return iSongPlaylistRepository.Create(model);

        }

        // PUT: api/SongPlaylist/5
        [HttpPut("{id}")]
        public SongPlaylist Put(int id, SongPlaylistDTO value)
        {
            SongPlaylist model = iSongPlaylistRepository.Get(id);
            if (value.songId != null)
            {
                model.songId = value.songId;
            }
            if(value.playlistId != null)
            {
                model.playlistId = value.playlistId;
            }
            return iSongPlaylistRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public SongPlaylist Delete(int id)
        {
            SongPlaylist model = iSongPlaylistRepository.Get(id);
            return iSongPlaylistRepository.Delete(model);
        }
    }
}
