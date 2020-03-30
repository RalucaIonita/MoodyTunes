using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MoodyTunes.DTOs;
using MoodyTunes.Models;
using MoodyTunes.Repositories.PlaylistMoodRepository;


namespace MoodyTunes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistMoodController : ControllerBase
    {
        public IPlaylistMoodRepository iPlaylistMoodRepository { get; set; }
        public PlaylistMoodController(IPlaylistMoodRepository repository)
        {
            iPlaylistMoodRepository = repository;
        }
        // GET: api/PlaylistMood
        [HttpGet]
        public ActionResult<IEnumerable<PlaylistMood>> Get()
        {
            return iPlaylistMoodRepository.GetAll();
        }

        // GET: api/PlaylistMood/5
        [HttpGet("{id}")]
        public PlaylistMood Get(int id)
        {
            return iPlaylistMoodRepository.Get(id);
        }

        // POST: api/PlaylistMood
        [HttpPost]
        public PlaylistMood Post(PlaylistMoodDTO value)
        {
            PlaylistMood model = new PlaylistMood()
            {
                playlistId = value.playlistId,
                moodId = value.moodId
            };
            return iPlaylistMoodRepository.Create(model);

        }

        // PUT: api/PlaylistMood/5
        [HttpPut("{id}")]
        public PlaylistMood Put(int id, PlaylistMoodDTO value)
        {
            PlaylistMood model = iPlaylistMoodRepository.Get(id);
            if (value.playlistId != null)
            {
                model.playlistId = value.playlistId;
            }
            if(value.moodId != null)
            {
                model.moodId = value.moodId;
            }
            //stuff?
            return iPlaylistMoodRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public PlaylistMood Delete(int id)
        {
            PlaylistMood model = iPlaylistMoodRepository.Get(id);
            return iPlaylistMoodRepository.Delete(model);
        }
    }
}
