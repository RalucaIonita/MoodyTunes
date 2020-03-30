using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MoodyTunes.DTOs;
using MoodyTunes.Models;
using MoodyTunes.Repositories.PlaylistRepository;


namespace MoodyTunes.Controllers //WORK
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        public IPlaylistRepository iPlaylistRepository { get; set; }
        public PlaylistController(IPlaylistRepository repository)
        {
            iPlaylistRepository = repository;
        }
        // GET: api/Playlist
        [HttpGet]
        public ActionResult<IEnumerable<Playlist>> Get()
        {
            return iPlaylistRepository.GetAll();
        }

        // GET: api/Playlist/5
        [HttpGet("{id}")]
        public Playlist Get(int id)
        {
            return iPlaylistRepository.Get(id);
        }

        // POST: api/Playlist
        [HttpPost]
        public Playlist Post(PlaylistDTO value) //needs to be modified!!!!!!!!
        {
            Playlist model = new Playlist()
            {
                name = value.name,

            };
            return iPlaylistRepository.Create(model);

        }

        // PUT: api/Playlist/5
        [HttpPut("{id}")]
        public Playlist Put(int id, PlaylistDTO value) //needs to be modified
        {
            Playlist model = iPlaylistRepository.Get(id);
            if (value.name != null)
            {
                model.name = value.name;
            }

            return iPlaylistRepository.Update(model);
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
