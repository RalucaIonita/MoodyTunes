using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MoodyTunes.DTOs;
using MoodyTunes.Models;
using MoodyTunes.Repositories.MoodRepository;


namespace MoodyTunes.Controllers //THIS IS GOOD
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoodController : ControllerBase
    {
        public IMoodRepository iMoodRepository { get; set; }
        public MoodController(IMoodRepository repository)
        {
            iMoodRepository = repository;
        }
        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<Mood>> Get()
        {
            return iMoodRepository.GetAll();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public Mood Get(int id)
        {
            return iMoodRepository.Get(id);
        }

        // POST: api/Mood
        [HttpPost]
        public Mood Post(MoodDTO value)
        {
            Mood model = new Mood()
            {
                name = value.name,
            };
            return iMoodRepository.Create(model);

        }

        // PUT: api/Mood/5
        [HttpPut("{id}")]
        public Mood Put(int id, MoodDTO value)
        {
            Mood model = iMoodRepository.Get(id);
            if (value.name != null)
            {
                model.name = value.name;
            }
            return iMoodRepository.Update(model);


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Mood Delete(int id)
        {
            Mood model = iMoodRepository.Get(id);
            return iMoodRepository.Delete(model);
        }
    }
}
