using System.Threading.Tasks;
using datingapp.api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using datingapp.api.Dtos;
using System.Collections.Generic;

namespace datingapp.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController: ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _automap;

        public UsersController(IDatingRepository repo,IMapper automap )
        {
            _repo = repo;
            _automap = automap;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
         { 
             var users = await _repo.GetUsers();
             var ReturnUser= _automap.Map<IEnumerable< UserForListDto>> (users);
             return Ok(ReturnUser);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var users = await _repo.GetUser(id);
            var userToReturn = _automap.Map<userForDetailsDto>(users);
            return Ok(userToReturn);
        }

      
    }
}