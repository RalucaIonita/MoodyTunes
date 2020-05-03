using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MoodyTunes.DTOs;
using MoodyTunes.Models;
using MoodyTunes.Repositories.UserRepository;


namespace MoodyTunes.Controllers //GOOD
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserRepository iUserRepository { get; set; }
        public UserController(IUserRepository repository)
        {
            iUserRepository = repository;
        }
        // GET: api/Provider
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return iUserRepository.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return iUserRepository.Get(id);
        }

        // POST: api/User
        [HttpPost]
        public void Post(UserDTO value)
        {
            User model = new User()
            {
                firstName = value.firstName,
                lastName = value.lastName,
                username = value.username,
                password = value.password,
            };
            iUserRepository.Create(model);

        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, UserDTO value)
        {
            User model = iUserRepository.Get(id);
            if (value.firstName != null)
            {
                model.firstName = value.firstName;
            }
            if (value.lastName != null)
            {
                model.lastName = value.lastName;
            }
            if (value.username != null)
            {
                model.username = value.username;
            }
            if (value.password != null)
            {
                model.password = value.password;
            }

            iUserRepository.Update(model);


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public User Delete(int id)
        {
            User model = iUserRepository.Get(id);
            return iUserRepository.Delete(model);
        }
    }
}
