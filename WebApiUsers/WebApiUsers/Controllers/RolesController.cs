using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiUsers.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiUsers.Controllers
{
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;


        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/users
        [HttpGet]
        [Route("api/Users/{UserId}/Roles")]
        public async Task<ActionResult<IEnumerable<Role>>> GetRolesForUser(int userId)
        {
            return await _context.Roles.ToListAsync();


        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRolesList()
        {
            return await _context.Roles.ToListAsync();

        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return await role;
        }


        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult<Role>> PostUser(Role roleCreated)
        {
            _context.Roles.Add(roleCreated);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRole), new { id = roleCreated.Id }, roleCreated);
        }


        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role roleUpdated)
        {
            if (id != roleUpdated.Id)
            {
                return BadRequest();
            }

            _context.Entry(roleUpdated).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var roleForDelete = await _context.Roles.FindAsync(id);

            if (roleForDelete == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(roleForDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
