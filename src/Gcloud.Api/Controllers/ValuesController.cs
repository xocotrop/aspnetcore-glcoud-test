using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gcloud.Api.Business.Contracts;
using Gcloud.Api.Repository.Contract;
using Gcloud.Api.Repository.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gcloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public ValuesController(IUserBusiness repository)
        {
            _userBusiness = repository;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await _userBusiness.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _userBusiness.Get(id);
            if (user == null)
                return NotFound();

            return Ok(user);

        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            await _userBusiness.AddUser(user);
            return Created($"/api/values/{user.Id}", user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            var userDb = await _userBusiness.Get(id);
            if (userDb == null)
                return NotFound();
            userDb.Name = user.Name;
            userDb.Age = user.Age;
            await _userBusiness.Edit(userDb);

            return Accepted();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userDb = await _userBusiness.Get(id);
            if (userDb == null)
                return NotFound();

            await _userBusiness.Remove(userDb);

            return Ok();
        }
    }
}
