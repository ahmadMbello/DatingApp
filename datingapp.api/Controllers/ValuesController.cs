﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp.api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace datingApp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
    
            


        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
var values = await _context.Values.ToListAsync();
return Ok(values);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task< IActionResult> GetValues(int id)
        {
            var values=await _context.Values.FirstOrDefaultAsync(x=> x.id == id);
            return Ok(values);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}