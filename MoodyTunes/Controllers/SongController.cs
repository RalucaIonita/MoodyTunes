using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MoodyTunes.DTOs;
using MoodyTunes.Models;
using MoodyTunes.Repositories.SongRepository;


namespace MoodyTunes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase //GOOD
    {
        public ISongRepository iSongRepository { get; set; }
        public SongController(ISongRepository repository)
        {
            iSongRepository = repository;
        }
        // GET: api/Song
        [HttpGet]
        public ActionResult<IEnumerable<Song>> Get()
        {
            return iSongRepository.GetAll();
        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public Song Get(int id)
        {
            return iSongRepository.Get(id);
        }

        // POST: api/Song
        [HttpPost]
        public Song Post(SongDTO value)
        {
            Song model = new Song()
            {
                title = value.title,
                artist = value.artist,
                link = value.link
            };
            return iSongRepository.Create(model);

        }

        // PUT: api/Song/5
        [HttpPut("{id}")]
        public Song Put(int id, SongDTO value)
        {
            Song model = iSongRepository.Get(id);
            if (value.title != null)
            {
                model.title = value.title;
            }
            if (value.artist != null)
            {
                model.artist = value.artist;
            }
            if (value.link != null)
            {
                model.link = value.link;
            }

            return iSongRepository.Update(model);


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Song Delete(int id)
        {
            Song model = iSongRepository.Get(id);
            return iSongRepository.Delete(model);

        }
    }
}
