﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiUsers.Data;
using WebApiUsers.Models;

namespace WebApiUsers.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController] 


    public class UsersController : ControllerBase
    {

        private readonly ApplicationDbContext _context;


        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersList()
        {
            return await _context.Users.ToListAsync();

        }

        // GET: api/roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserIndividual(int id)
        {
            var userIndividual = _context.Users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id == id);
                
            if (userIndividual == null)
            {
                return NotFound(); 
            }

            return await userIndividual;
        }


        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User userCreated)
        {
            _context.Users.Add(userCreated);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserIndividual), new { id = userCreated.Id }, userCreated);
        }


        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User userUpdated)
        {
            if(id != userUpdated.Id)
            {
                return BadRequest();
            }

            _context.Entry(userUpdated).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            Console.WriteLine(id);
            var userForDelete = await _context.Users.FindAsync(id);
            
            if(userForDelete == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userForDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
