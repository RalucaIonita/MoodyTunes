using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MoodyTunes.DTOs;
using MoodyTunes.Models;
using MoodyTunes.Repositories.MoodLinkRepository;


namespace MoodyTunes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoodLinkController : ControllerBase
    {
        public IMoodLinkRepository iMoodLinkRepository { get; set; }
        public MoodLinkController(IMoodLinkRepository repository)
        {
            iMoodLinkRepository = repository;
        }
        // GET: api/MoodLink
        [HttpGet]
        public ActionResult<IEnumerable<MoodLink>> Get()
        {
            return iMoodLinkRepository.GetAll();
        }

        // GET: api/MoodLink/5
        [HttpGet("{id}")]
        public MoodLink Get(int id)
        {
            return iMoodLinkRepository.Get(id);
        }

        // POST: api/MoodLink
        [HttpPost]
        public void Post(MoodLinkDTO value) //THIS SHIT NEEDS TO BE MODIFIED
        {
            MoodLink model = new MoodLink()
            {
                moodId = value.moodId,
                linkedMoodId = value.linkedMoodId,
                
            };
            iMoodLinkRepository.Create(model);

            MoodLink reversedModel = new MoodLink()
            {
                moodId = value.linkedMoodId,
                linkedMoodId = value.moodId,

            };
            iMoodLinkRepository.Create(reversedModel);

        }

        // PUT: api/MoodLink/5
        [HttpPut("{id}")]
        public void Put(int id, MoodLinkDTO value) //modify
        {
            MoodLink model = iMoodLinkRepository.Get(id);
            //stuff?
            iMoodLinkRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public MoodLink Delete(int id)
        {
            MoodLink model = iMoodLinkRepository.Get(id);
            return iMoodLinkRepository.Delete(model);
        }
    }
}
 